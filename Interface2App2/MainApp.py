from PyQt5.QtWidgets import QMainWindow, QApplication, QWidget, QHBoxLayout, QVBoxLayout, QPushButton, QFileDialog, \
    QLabel, QShortcut, QFrame, QCheckBox
from PyQt5.QtGui import QColor, QKeySequence, QCursor, QScreen
from PyQt5.QtCore import QTimer, Qt, pyqtSlot
from sys import exit, argv
from FlickerTable import FlickerTable, Flicker, FreqType, SequenceBlock
from Flicker import SeqType, SeqCondition
from ScreenViewer import ScreenViewer
from SequenceBuilder import SequenceBuilder
from os import system, path
from Settings import Settings
import xml.etree.cElementTree as ET
import psutil
from xml.dom import minidom
from multiprocessing import Process
import platform

Standard_Save_File = "Flickers.xml"


class MainApp(QMainWindow):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Flickers On Top")
        # self.setGeometry(100, 100, 500, 500)

        # create main widget
        central_widget = QWidget(self)
        # central_widget.setStyleSheet("border: 1px solid black")
        self.setCentralWidget(central_widget)

        # Main Data
        self.Flickers = []
        self.backgroundFlicker = None

        #self.Load()
        self.MainLayout = QVBoxLayout()
        self.process = None


        # graphical init
        self.InitFlickerTable()
        self.InitLowerPart()
        self.MainLayout.addStretch(0)

    def InitFlickerTable(self):

        ButtonLayout = QHBoxLayout()

        # Flicker table containing all flicker
        self.Table = FlickerTable(self.Flickers)
        QShortcut(QKeySequence("Ctrl+C"), self, self.Table._copy)
        QShortcut(QKeySequence("Ctrl+V"), self, self.Table._paste)

        self.MainLayout.addWidget(self.Table)

        buttonAdd = QPushButton("Add")

        def add():
            f = Flicker()
            self.Flickers.append(f)
            self.Table.AddNewFlicker(f)

        buttonAdd.clicked.connect(lambda: add())
        buttonAdd.setShortcut("Ctrl+N")
        buttonRemove = QPushButton("Remove")

        def remove():
            if len(self.Flickers) > 0:
                if self.Table.selected:
                    self.Table.RemoveRow(*self.Table.selected)
                else:
                    self.Table.RemoveRow(self.Table.Rows[list(self.Table.Rows.keys())[-1]])

        buttonRemove.clicked.connect(lambda: remove())
        buttonRemove.setShortcut(Qt.Key_Delete)

        # Black Screen checkbox
        self.checkboxblack = QCheckBox(
            "Add a Black Screen background? (WARNING: flickers are click-through even with a background)")

        ButtonLayout.addWidget(buttonAdd)
        ButtonLayout.addWidget(buttonRemove)
        ButtonLayout.addWidget(self.checkboxblack)
        ButtonLayout.addStretch(0)

        self.MainLayout.addLayout(ButtonLayout)

        self.centralWidget().setLayout(self.MainLayout)


        # create setting window
        self.buttonSequence=QPushButton()
        self.setting = Settings()
        self.setting.updateSettingSignal.connect(self._apply_setting)
        self._apply_setting()

    def InitLowerPart(self):
        lowerContainer = QFrame()
        lowerLayout = QHBoxLayout()

        lowerContainer.setFrameStyle(QFrame.Panel | QFrame.Sunken)
        # button on the left
        buttonContainer = QFrame()
        # buttonContainer.setFrameStyle(QFrame.StyledPanel)

        buttonLayout = QVBoxLayout()
        actionLayout = QHBoxLayout()
        buttonTest = QPushButton("Test")
        buttonRun = QPushButton("Run")
        buttonStop = QPushButton("Stop")
        buttonTest.clicked.connect(lambda b: self.testVisual())
        buttonRun.clicked.connect(lambda b: self.LaunchVisualStimuli())
        buttonStop.clicked.connect(lambda b: self.stopVisual())
        actionLayout.addWidget(buttonTest)
        actionLayout.addWidget(buttonRun)
        actionLayout.addWidget(buttonStop)
        buttonLayout.addLayout(actionLayout)
        buttonSave = QPushButton("Save")
        buttonSave.clicked.connect(lambda a: self.Save())
        buttonSave.setShortcut("Ctrl+S")
        buttonSaveAs = QPushButton("Save As...")
        buttonSaveAs.clicked.connect(lambda b: self.SaveAs())
        buttonSaveAs.setShortcut("Ctrl+Shift+S")
        buttonImport = QPushButton("Import")
        buttonImport.clicked.connect(lambda b: self.Import())
        buttonHelp = QPushButton("Help")
        buttonHelp.clicked.connect(lambda b: self.help())
        buttonSettings = QPushButton("Settings")
        buttonSettings.clicked.connect(self.settings)
        self.buttonSequence=QPushButton("Sequence")
        def seqbuildopen():
            if len(self.Flickers)>0:
                self.build=SequenceBuilder(self.Flickers[0])
                self.build.show()
        self.buttonSequence.clicked.connect(lambda b:seqbuildopen())

        if self.setting.seqlinkCheckBox.checkState():
            for row in self.Table.Rows.values():
                row.attrDict["sequence"].hide()
        else:
            self.buttonSequence.hide()
        buttonLayout.addWidget(self.buttonSequence)
        buttonLayout.addWidget(buttonSave)
        buttonLayout.addWidget(buttonSaveAs)
        buttonLayout.addWidget(buttonImport)
        buttonLayout.addWidget(buttonHelp)
        buttonLayout.addWidget(buttonSettings)
        buttonLayout.addStretch(0)
        buttonContainer.setLayout(buttonLayout)
        lowerLayout.addWidget(buttonContainer)

        # Screen Viewer
        self.screenviewer = ScreenViewer(self.Flickers)
        self.screenviewer.changeSignal.connect(self.Table.updateFlicker)
        self.screenviewer.removeSignal.connect(self.Table.removeFlicker)
        self.screenviewer.addSignal.connect(self.Table.updateFlicker)
        self.screenviewer.addSignal.connect(lambda f: self.Flickers.append(f))
        self.Table.tableUpdateSignal.connect(lambda flicker: self.screenviewer.updateFlickers(flicker))
        self.Table.tableRemoveSignal.connect(self.screenviewer.removeFlicker)
        self.Table.tableAddSignal.connect(lambda flicker: self.screenviewer.setupFlickers(flicker))
        lowerLayout.addWidget(self.screenviewer.view)

        # mousePosition
        mousePosLayout = QVBoxLayout()
        titleLabel = QLabel("Mouse Position")
        xlabel = QLabel()
        ylabel = QLabel()
        mousePosLayout.addWidget(titleLabel)
        mousePosLayout.addWidget(xlabel)
        mousePosLayout.addWidget(ylabel)
        mousePosLayout.addStretch(0)
        lowerLayout.addLayout(mousePosLayout)

        def get_mouse_pos():
            pos = QCursor.pos()
            xlabel.setText("X: " + str(pos.x()))
            ylabel.setText("Y: " + str(pos.y()))

        mouseTimer = QTimer(self)
        mouseTimer.timeout.connect(get_mouse_pos)
        mouseTimer.start(20)

        lowerContainer.setLayout(lowerLayout)
        self.MainLayout.addWidget(lowerContainer)

    def Load(self, file=Standard_Save_File):
        def loadseq(attribute):
            value = SequenceBlock(SeqType[attribute[0].text], SeqCondition[attribute[2].text], float(attribute[3].text))
            for subseq in attribute[1]:
                value.AddSeq(loadseq(subseq))
            return value

        if path.exists(file):
            Tree = ET.parse(file)
            root = Tree.getroot()
            for f in root:
                try:
                    temp = Flicker()
                    for attribute in f:

                        # Basic Attribute
                        if (attribute.tag in temp.__dict__.keys()):
                            value = None
                            if attribute.text != None and len(
                                    attribute) == 0 and attribute.text != "false" and attribute.text != "true":
                                value = attribute.text
                                if "." in value:
                                    try:
                                        value = float(value)
                                    except:
                                        pass
                                else:
                                    try:
                                        value = int(value)
                                    except:
                                        pass
                                if attribute.tag == "Type":
                                    value = FreqType[value]
                            if attribute.tag == "Color":
                                value = QColor(int(attribute[1].text), int(attribute[2].text), int(attribute[3].text))
                            if attribute.tag == "sequence":
                                value = loadseq(attribute)
                            if attribute.text == "false":
                                value = False
                            if attribute.text == "true":
                                value = True

                            temp.__setattr__(attribute.tag, value)
                        # Special attribute
                        if attribute.tag == "Code":
                            temp.Code = attribute.text
                    self.Flickers.append(temp)
                except:
                    print("Couldn't load flicker")

    def Save(self, file=Standard_Save_File):
        def saveSeq(root, seq: SequenceBlock):
            t = ET.SubElement(root, "Type")
            t.text = seq.seqType.name
            subseq = ET.SubElement(root, "contained_sequence")
            c = ET.SubElement(root, "cond")
            c.text = seq.Condition.name
            v = ET.SubElement(root, "value")
            v.text = str(seq.value)
            for s in seq.contained_sequence:
                saveSeq(ET.SubElement(subseq, "SequenceValue"), s)

        root = ET.Element("ArrayOfFlicker")
        for f in self.Flickers:
            fEle = ET.SubElement(root, "Flicker")
            for attr in f.__dict__:
                value = f.__dict__[attr]

                ele = ET.SubElement(fEle, attr)
                if value == None or isinstance(value, SequenceBuilder):
                    continue
                if isinstance(value, FreqType):
                    value = value.name
                if isinstance(value, QColor):
                    A = ET.SubElement(ele, "A")
                    A.text = str(value.alpha())
                    R = ET.SubElement(ele, "R")
                    R.text = str(value.red())
                    G = ET.SubElement(ele, "G")
                    G.text = str(value.green())
                    B = ET.SubElement(ele, "B")
                    B.text = str(value.blue())
                    continue
                if isinstance(value, SequenceBlock):
                    saveSeq(ele, value)
                    continue
                if isinstance(value, bool):
                    value = str(value).lower()
                ele.text = str(value)
        tree = ET.ElementTree(root)
        xmlstr = minidom.parseString(ET.tostring(root)).toprettyxml(indent="  ")
        with open(file, "w") as f:
            f.write(xmlstr)

    def SaveAs(self):
        file = QFileDialog.getSaveFileName(filter="*.xml")[0]
        if path.exists(file): self.Save(file)

    def Import(self):
        file = QFileDialog.getOpenFileName(filter="*.xml")[0]
        if path.exists(file):
            self.Table.RemoveRow(*list(self.Table.Rows.values()))

            def loadseq(attribute):
                value = SequenceBlock(SeqType[attribute[0].text], SeqCondition[attribute[2].text],
                                      float(attribute[3].text))
                for subseq in attribute[1]:
                    value.AddSeq(loadseq(subseq))
                return value

            if path.exists(file):
                Tree = ET.parse(file)
                root = Tree.getroot()
                for f in root:
                    try:
                        temp = Flicker()
                        for attribute in f:
                            # Basic Attribute
                            if (attribute.tag in temp.__dict__.keys()):
                                value = None
                                if attribute.text != None and len(
                                        attribute) == 0 and attribute.text != "false" and attribute.text != "true":
                                    value = attribute.text
                                    if "." in value:
                                        try:
                                            value = float(value)
                                        except:
                                            pass
                                    else:
                                        try:
                                            value = int(value)
                                        except:
                                            pass
                                    if attribute.tag == "Type":
                                        value = FreqType[value]
                                if attribute.tag == "Color":
                                    value = QColor(int(attribute[1].text), int(attribute[2].text),
                                                   int(attribute[3].text))
                                if attribute.tag == "sequence":
                                    value = loadseq(attribute)
                                if attribute.text == "false":
                                    value = False
                                if attribute.text == "true":
                                    value = True

                                temp.__setattr__(attribute.tag, value)
                            # Special attribute
                            if attribute.tag == "Code":
                                temp.Code = attribute.text
                        self.Flickers.append(temp)
                    except:
                        print("Couldn't load flicker")
            self.Table.InitRows()

    def LaunchVisualStimuli(self):
        # Launch the main code
        if len(self.Flickers) > 0:
            if self.checkboxblack.checkState() and not self.backgroundFlicker in self.Flickers:
                screen = app.primaryScreen()
                size = screen.size()
                self.backgroundFlicker = Flicker(width=size.width(), height=size.height(), frequency=1, opacity_min=100,
                                                 color=QColor(0, 0, 0))
                self.Flickers.insert(0, self.backgroundFlicker)
            self.Save()
            if "Windows" in platform.system():
                func_arg = ("VisualStimuli.exe",)
            else:
                func_arg = ("./VisualStimuli.exe",)
            self.process = Process(target=system, args=func_arg)
            self.process.start()

    def testVisual(self):
        t = QTimer(self)
        t.setInterval(10000)
        t.setSingleShot(True)
        t.timeout.connect(self.stopVisual)
        t.start()
        self.LaunchVisualStimuli()

    def stopVisual(self):
        if self.process:
            if self.process.is_alive():
                for proc in psutil.process_iter():
                    # check whether the process name matches
                    if proc.name() == "VisualStimuli.exe":
                        proc.kill()
                self.process.kill()
                if self.backgroundFlicker in self.Flickers:
                    self.Flickers.remove(self.backgroundFlicker)

    def help(self):
        self.helpLabel = QLabel("I.\n"
                                + "  X (Horizontal), Y (Vertical) correspond to the position of top-left point of a Flicker (in pixel).\n"
                                + "II.\n"
                                + " Width, Height is the size of a Flicker (in pixel).\n"
                                + "III.\n"
                                + " Frequency in Hz and Phase in degrees.\n"
                                + "IV.\n"
                                + " You can choose in Type\n"
                                + " Random \n"
                                + " Sinous \n"
                                + " Square \n"
                                + " Root Square\n"
                                + " Maximum lenght sequence\n"
                                + "V.\n"
                                + " You can click on Add to create a new Flicker \n"
                                + "VI.\n"
                                + " Finally, click on RUN to run the Flicker program or TEST for a 10 seconds test.\n"
                                + " press 'Echap' to close all flickers. Or alternatively, click on 'Stop'\n"
                                + "Note: Please be sure that your screen can support the frequency you want for your flickers\n"
                                + " as a reminder the screen frequency must always be at least 2 times higher than the flicker's frequency\n"
                                + "THANK FOR READING !!!")
        self.helpLabel.show()

    def closeEvent(self, a0) -> None:
        if self.process:
            if self.process.is_alive():
                self.process.kill()
        if self.backgroundFlicker in self.Flickers:
            self.Flickers.remove(self.backgroundFlicker)
            self.Save()
        QApplication.quit()
        return super().closeEvent(a0)

    def settings(self):
        self.setting.show()

    @pyqtSlot()
    def _apply_setting(self):
        if self.setting:
            if self.setting.seqlinkCheckBox.checkState():
                if len(self.Flickers) > 0:
                    for f in self.Flickers[1:]:
                        f.sequence = self.Flickers[0].sequence
                    for row in self.Table.Rows.values():
                        row.attrDict["sequence"].hide()
                    self.buttonSequence.show()
            else:
                self.buttonSequence.hide()
                for row in self.Table.Rows.values():
                    row.attrDict["sequence"].show()
                for f in self.Flickers[1:]:
                    if f.sequence == self.Flickers[0].sequence:
                        f.sequence = SequenceBlock(SequenceBlock(seq_type=SeqType.Active))
        self.setting.save()


if __name__ == "__main__":
    app = QApplication(argv)
    window = MainApp()
    window.show()
    exit(app.exec_())
