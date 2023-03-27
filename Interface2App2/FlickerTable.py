from PyQt5.QtWidgets import QWidget, QHBoxLayout, QLineEdit, QVBoxLayout, QComboBox, QLabel, QPushButton, QColorDialog, \
    QFileDialog, QFrame, QScrollArea, QMenu, QAction, QApplication
from PyQt5.QtGui import QColor, QImage, QBrush, QMouseEvent,QPalette
from PyQt5.QtCore import Qt, pyqtSlot, pyqtSignal, QPoint, QTimer
from Flicker import Flicker, FreqType, SequenceBlock
from SequenceBuilder import SequenceBuilder
from collections import OrderedDict
from os import path

Selection_Color = QColor(0, 120, 215, 100)

# size must be int for compatibility purpose
size = 70


def open_color_chooser(text, widget, row, f):
    # choose a color
    widget=row.colorButton
    if text=="Color":
        color = QColorDialog.getColor()
        f.IsImageFlicker=False
        if color.isValid():
            f.Color = color
            print(widget)
            row.rowUpdateSignal.emit(f)
            p = widget.palette()
            p.setColor(QPalette.Button, color)
            widget.setAutoFillBackground(True)
            widget.setPalette(p)
    # choose an image file MUST BE .bmp due to SDL limitation
    else:
        image = QFileDialog.getOpenFileName(filter="*.bmp")
        f.IsImageFlicker = True
        f.image = image[0]
        row.rowUpdateSignal.emit(f)
        p = widget.palette()
        p.setColor(widget.backgroundRole(), QColor(0, 0, 0, 0))

        image = QImage(f.image)
        image = image.scaled(int(widget.rect().width()), int(widget.rect().height()))
        p.setBrush(QPalette.Button, (QBrush(image)))
        widget.setPalette(p)
        widget.setStyleSheet("background-image: url(" + f.image + ")")



def _decode_file(file):
    with open(file) as f:
        test = f.readlines()
        if len(test) > 1:
            raise Exception
        text = test[0].split(";")
        if len(text) > 1:
            for i in text: float(i)
            return test[0]
        raise Exception


timer_choose_file = QTimer()


def _set_file_name_button(widget, f: Flicker, file):
    if "Code" in f.__dict__:
        widget.setText(file.split("/")[-1])
    else:
        widget.setText("Choose Custom...")


def open_code_chooser(widget, row, f):
    file = QFileDialog.getOpenFileName()[0]
    timer_choose_file.timeout.connect(lambda f=f, file=file: _set_file_name_button(widget, f, file))
    timer_choose_file.setSingleShot(True)
    if path.exists(file):
        setattr(f, "custom", file)
        try:
            text = _decode_file(file)
            setattr(f, "Code", text)
            widget.setText("Set")
        except:
            print("Incorrect File Format:\n"
                  "\tfile must be in the following format exemple:'0.5;1;0;0.6'\n"
                  "\ta single line list of float between 0 and 1 using ';' as a delimiter")
            widget.setText("Incorrect file")
        timer_choose_file.start(1000)


def open_sequence_builder(f):
    f.seqbuild = SequenceBuilder(f)
    f.seqbuild.show()


class FlickerTableRow(QFrame):
    rowUpdateSignal = pyqtSignal(Flicker)
    removeSignal = pyqtSignal(Flicker)

    def __init__(self, flicker: Flicker):
        super().__init__()
        self.Flicker = flicker
        self.attrDict = {}
        self.labelDict = {}
        self.editDict={}
        self.rowInit()
        self.setContentsMargins(2, 2, 2, 2)
        self.setFrameStyle(QFrame.StyledPanel | QFrame.Sunken)
        self.setMinimumHeight(100)
        self.setMaximumHeight(100)
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor(220, 220, 220, 100))
        self.setPalette(p)
        self.defaultPalette = p
        self.setContextMenuPolicy(Qt.CustomContextMenu)
        self.customContextMenuRequested.connect(self.customMenu)
        self.selected = False

    def customMenu(self, point: QPoint):
        Menu = QMenu("FlickerMenu", self)
        a1 = QAction("Remove this Flicker")
        a1.triggered.connect(lambda: self.removeSignal.emit(self.Flicker))
        Menu.addAction(a1)
        Menu.exec(self.mapToGlobal(point))

    def rowInit(self):
        self.Layout = QHBoxLayout(self)

        # Loop on the Flickers Attribute to create each row cell
        for attribute in self.Flicker.__dict__:
            temp = False
            attr = self.Flicker.__dict__[attribute]
            label = QLabel(attribute)
            container = QWidget()
            vlayout = QVBoxLayout()
            container.setLayout(vlayout)
            if attribute == "image" or attribute == "Code" or attribute == "IsImageFlicker": continue

            def change(new_Value, attribute):
                self.Flicker.__setattr__(attribute, new_Value)
                # cap for opacity
                if "Opacity" in attribute:
                    if new_Value > 100:
                        self.Flicker.__setattr__(attribute, 100)
                    if new_Value < 0:
                        self.Flicker.__setattr__(attribute, 0)
                    self.updateData()
                if attribute == "Type":
                    if new_Value == FreqType.Custom:
                        self.attrDict["Frequency"].hide()
                        self.attrDict["Code"].show()
                        self.Flicker.Code = ""
                    else:
                        self.attrDict["Frequency"].show()
                        self.attrDict["Code"].hide()
                if attribute == "IsImageFlicker":
                    if new_Value:
                        self.labelDict["Color"].setText("Image")
                    else:
                        self.labelDict["Color"].setText("Color")

                self.rowUpdateSignal.emit(self.Flicker)

            def formatdata(type, v, a, w):
                try:
                    return type(v)
                except:
                    w.setText(str(self.Flicker.__dict__[a]))
                    return self.Flicker.__dict__[a]

            # differenciate attribute type (will be more efficient if lots of same type attribute)
            if isinstance(attr, bool):
                temp = QComboBox()
                temp.addItem("False")
                temp.addItem("True")
                temp.setCurrentText(str(attr))
                temp.currentTextChanged.connect(lambda text, a=attribute: change(False if text == "False" else True, a))
            if isinstance(attr, str) and not temp:
                temp = QLineEdit(attr)
                temp.textChanged.connect(lambda text, a=attribute: change(text, a))
            if (isinstance(attr, float)) and not temp:
                temp = QLineEdit(str(attr))
                temp.textChanged.connect(lambda text, a=attribute, w=temp: change(formatdata(float, text, a, w), a))
            if (isinstance(attr, int)) and not temp:
                temp = QLineEdit(str(attr))
                temp.textChanged.connect(lambda text, a=attribute, w=temp: change(formatdata(int, text, a, w), a))
            if isinstance(attr, QColor):
                hlayout=QHBoxLayout()
                temp = QComboBox()
                temp.addItem("Image")
                temp.addItem("Color")
                label.setText("Texture")
                temp.setCurrentText("Image" if self.Flicker.IsImageFlicker else "Color")
                # temp.mousePressEvent = lambda event, widget=temp, row=self, f=self.Flicker: open_color_chooser(widget,
                #                                                                                               row, f)
                temp.currentTextChanged.connect(
                    lambda text, widget=temp, row=self, f=self.Flicker: open_color_chooser(text, widget,
                                                                                        row, f))

                temp.setAutoFillBackground(True)
                temp.setFixedSize(int(size//1.5), int(size * (9 / 16)))
                p = temp.palette()
                if self.Flicker.IsImageFlicker:
                    image = QImage(self.Flicker.image)
                    image = image.scaled(int(temp.rect().width()), int(temp.rect().height()))
                    p.setBrush(temp.backgroundRole(), (QBrush(image)))
                else:
                    p.setColor(temp.backgroundRole(), self.Flicker.Color)
                temp.setPalette(p)
                chooser=QPushButton("Change")
                chooser.setFixedSize(int(size//1.5), int(size * (9 / 16)))
                chooser.clicked.connect(lambda b,f=self.Flicker,widget=chooser,row=self:open_color_chooser(self.editDict["Color"].currentText(),widget,row,f))

                hlayout.addWidget(temp)
                hlayout.addWidget(chooser)
                self.attrDict[attribute] = container
                self.labelDict[attribute] = label
                self.editDict[attribute] = temp
                self.colorButton=chooser
                vlayout.addWidget(label)
                vlayout.addLayout(hlayout)
                self.Layout.addWidget(container)
                continue
            if isinstance(attr, FreqType):
                temp = QComboBox()
                for type in (FreqType):
                    temp.addItem(str(type.name))
                temp.setCurrentText(self.Flicker.Type.name)
                temp.currentTextChanged.connect(lambda text, a=attribute: change(FreqType[text], a))
            if isinstance(attr, SequenceBlock):
                temp = QPushButton("Sequence")
                temp.clicked.connect(lambda b, f=self.Flicker: open_sequence_builder(f))
            if temp:
                temp.setFixedSize(size, int(size * (9 / 16)))
                # self.attrDict[attribute] = temp
                self.attrDict[attribute] = container
                self.labelDict[attribute] = label
                self.editDict[attribute] = temp
                vlayout.addWidget(label)
                vlayout.addWidget(temp)
                self.Layout.addWidget(container)
                # add a special widget for custom type
                if attribute == "Type":
                    t = QPushButton("Choose custom...")
                    if "Code" in self.Flicker.__dict__:
                        t.setText("Code Set")
                    tlabel = QLabel("Code")
                    tvlayout = QVBoxLayout()
                    tcontainer = QWidget()
                    tcontainer.setLayout(tvlayout)
                    t.setFixedSize(size, int(size * (9 / 16)))
                    font = t.font()
                    font.setPointSize(6)
                    t.setFont(font)
                    self.attrDict["Code"] = tcontainer
                    self.labelDict["Code"] = tlabel
                    self.editDict["Code"] = t
                    t.clicked.connect(lambda b, f=self.Flicker, row=self, widget=t: open_code_chooser(widget, row, f))
                    tvlayout.addWidget(tlabel)
                    tvlayout.addWidget(t)
                    self.Layout.addWidget(tcontainer)
                    if self.Flicker.Type != FreqType.Custom:
                        tcontainer.hide()
                    else:
                        self.attrDict["Frequency"].hide()

        self.setLayout(self.Layout)

    # select a row for deleting and copying purpose
    def select(self, event: QMouseEvent, l, Rows):
        if event.button() == Qt.LeftButton and QApplication.keyboardModifiers() != Qt.ShiftModifier:
            if self in l:
                l.remove(self)
                self.setPalette(self.defaultPalette)
            else:
                l.insert(0, self)
                p = self.palette()
                p.setColor(self.backgroundRole(), Selection_Color)
                self.setPalette(p)
        # if we use shift, gather other rows inbetween
        else:
            if event.button() == Qt.LeftButton and l != []:
                previous = l[0]
                for row in l:
                    l.remove(row)
                    row.setPalette(row.defaultPalette)
                previous_index = list(Rows.values()).index(previous)
                currentIndex = list(Rows.values()).index(self)
                toAdd = list(Rows.values())[min(previous_index, currentIndex):max(previous_index + 1, currentIndex + 1)]
                for f in toAdd:
                    if not f in l:
                        l.append(f)
                        p = f.palette()
                        p.setColor(f.backgroundRole(), Selection_Color)
                        f.setPalette(p)

    # in instance of an updated data
    def updateData(self):
        for attr in self.attrDict:
            if attr == "Code": continue
            value = self.Flicker.__dict__[attr]
            if (isinstance(value, float) or isinstance(value, int)) and not isinstance(value, bool):
                self.editDict[attr].setText(str(int(value)))
                continue
            if isinstance(value, str):
                self.editDict[attr].setText(value)
                continue
            if isinstance(value, QColor):
                temp = self.attrDict[attr]
                p = temp.palette()
                if self.Flicker.IsImageFlicker:
                    image = QImage(self.Flicker.image)
                    image = image.scaled(int(temp.rect().width()), int(temp.rect().height()))
                    p.setBrush(temp.backgroundRole(), (QBrush(image)))
                else:
                    p.setColor(temp.backgroundRole(), self.Flicker.Color)
                temp.setPalette(p)
                continue


class FlickerTable(QFrame):
    tableUpdateSignal = pyqtSignal(Flicker)
    tableRemoveSignal = pyqtSignal(Flicker)
    tableAddSignal = pyqtSignal(Flicker)

    def __init__(self, flickerlist):
        super().__init__()
        self.Flickers = flickerlist
        self.VLayout = QVBoxLayout()
        self.setLayout(self.VLayout)
        self.Rows = OrderedDict()
        self.selected = []

        # graphic property
        self.setMaximumHeight(400)
        self.setMinimumHeight(400)
        # modify style
        self.setFrameStyle(QFrame.StyledPanel | QFrame.Sunken)
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor(150, 150, 150))
        self.setPalette(p)
        """
        # first row with column name
        labelWidget = QWidget()
        labelLayout = QHBoxLayout()
        testFlicker = Flicker()
        for i in testFlicker.__dict__:
            if testFlicker.__dict__[i] != None:
                t = QLabel(i)
                if i == "Color":
                    t.setText("Texture")
                t.setAlignment(Qt.AlignCenter)
                t.setFixedSize(int(size), int(size * (9 / 16)))
                labelLayout.addWidget(t)
        labelWidget.setLayout(labelLayout)
        self.VLayout.addWidget(labelWidget)"""

        # Row Area
        self.RowArea = QScrollArea()
        self.RowArea.setWidgetResizable(True)
        self.RowArea.setHorizontalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        RowContainer = QWidget(self.RowArea)
        self.RowLayout = QVBoxLayout(RowContainer)
        self.RowLayout.addStretch(0)
        self.InitRows()
        self.setMinimumWidth(1100)
        self.RowArea.setWidget(RowContainer)
        self.VLayout.addWidget(self.RowArea)

        # shortcut definition
        self.toCopy = []

        # custom menu
        self.setContextMenuPolicy(Qt.CustomContextMenu)
        self.customContextMenuRequested.connect(self.customMenu)

    def customMenu(self, point: QPoint):
        Menu = QMenu("Flicker Table Menu", self)
        a1 = QAction("Add a Flicker", self)
        a1.triggered.connect(lambda: self.AddNewFlicker(Flicker()))
        Menu.addAction(a1)
        Menu.exec(self.mapToGlobal(point))

    def InitRows(self):
        for f in self.Flickers:
            self.AddNewFlicker(f)

    def AddNewFlicker(self, flicker):
        row = FlickerTableRow(flicker)
        row.removeSignal.connect(self.removeFlicker)
        self.RowLayout.insertWidget(self.RowLayout.count() - 1, row)
        self.Rows[flicker] = row
        row.mousePressEvent = lambda event: row.select(event, self.selected, self.Rows)
        row.rowUpdateSignal.connect(lambda flicker: self.tableUpdateSignal.emit(flicker))
        self.tableAddSignal.emit(flicker)

    def RemoveRow(self, *args):
        for row in args:
            self.Flickers.remove(row.Flicker)
            del self.Rows[row.Flicker]
            self.RowLayout.removeWidget(row)
            self.tableRemoveSignal.emit(row.Flicker)
            try:
                self.selected.remove(row)
            except:
                pass
            row.setParent(None)

    @pyqtSlot(Flicker)
    def updateFlicker(self, f):
        if f in self.Rows.keys():
            self.Rows[f].updateData()
        else:
            self.AddNewFlicker(f)

    @pyqtSlot(Flicker)
    def removeFlicker(self, f):
        if f in self.Rows.keys():
            self.RemoveRow(self.Rows[f])

    @pyqtSlot()
    def _copy(self):
        self.toCopy = []
        for f in self.Flickers:
            if self.Rows[f] in self.selected:
                self.toCopy.append(f)

    @pyqtSlot()
    def _paste(self):
        for f in self.toCopy:
            newf = f.__copy__()
            self.Flickers.append(newf)
            self.AddNewFlicker(newf)
