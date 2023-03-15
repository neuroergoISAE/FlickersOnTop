from PyQt5.QtWidgets import QWidget, QHBoxLayout, QLineEdit, QVBoxLayout, QComboBox, QLabel, QPushButton, QColorDialog, \
    QFileDialog, QFrame, QScrollArea
from PyQt5.QtGui import QColor, QImage, QBrush
from PyQt5.QtCore import Qt, pyqtSlot, pyqtSignal
from Flicker import Flicker, FreqType, SequenceBlock
from SequenceBuilder import SequenceBuilder

Selection_Color = QColor(0, 120, 215, 100)
size = 70


def open_color_chooser(widget, row, f):
    if not f.IsImageFlicker:
        color = QColorDialog.getColor()

        if color.isValid():
            f.Color = color
            row.rowUpdateSignal.emit(f)
            p = widget.palette()
            p.setColor(widget.backgroundRole(), color)
            widget.setPalette(p)
    else:
        image = QFileDialog.getOpenFileName(filter="*.bmp")
        f.image = image[0]
        row.rowUpdateSignal.emit(f)
        p = widget.palette()
        p.setColor(widget.backgroundRole(), QColor(0, 0, 0, 0))

        image = QImage(f.image)
        image = image.scaled(int(widget.rect().width()), int(widget.rect().height()))
        p.setBrush(widget.backgroundRole(), (QBrush(image)))
        widget.setPalette(p)
        widget.setStyleSheet("background-image: url(" + f.image + ")")


def open_sequence_builder(f):
    f.seqbuild = SequenceBuilder(f)
    f.seqbuild.show()


class FlickerTableRow(QFrame):
    rowUpdateSignal = pyqtSignal(Flicker)

    def __init__(self, flicker: Flicker):
        super().__init__()
        self.Flicker = flicker
        self.attrDict = {}
        self.rowInit()
        self.setContentsMargins(2, 2, 2, 2)
        self.setFrameStyle(QFrame.StyledPanel | QFrame.Sunken)
        self.setMinimumHeight(70)
        self.setMaximumHeight(70)
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor(220, 220, 220, 100))
        self.setPalette(p)
        self.defaultPalette = p

    def rowInit(self):
        Layout = QHBoxLayout(self)

        for attribute in self.Flicker.__dict__:
            temp = False
            attr = self.Flicker.__dict__[attribute]
            if attribute == "image": continue

            def change(new_Value, attribute):
                self.Flicker.__dict__[attribute] = new_Value
                self.rowUpdateSignal.emit(self.Flicker)

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
                temp.textChanged.connect(lambda text, a=attribute: change(float(text if text != "" else 0), a))
            if (isinstance(attr, int)) and not temp:
                temp = QLineEdit(str(attr))
                temp.textChanged.connect(lambda text, a=attribute: change(int(text if text != "" else 0), a))
            if isinstance(attr, QColor):
                temp = QWidget()
                temp.mousePressEvent = lambda event, widget=temp, row=self, f=self.Flicker: open_color_chooser(widget,
                                                                                                               row, f)
                temp.setAutoFillBackground(True)
                temp.setFixedSize(size, size * (9 / 16))
                p = temp.palette()
                if self.Flicker.IsImageFlicker:
                    image = QImage(self.Flicker.image)
                    image = image.scaled(int(temp.rect().width()), int(temp.rect().height()))
                    p.setBrush(temp.backgroundRole(), (QBrush(image)))
                else:
                    p.setColor(temp.backgroundRole(), self.Flicker.Color)
                temp.setPalette(p)
            if isinstance(attr, FreqType):
                temp = QComboBox()
                for type in (FreqType):
                    temp.addItem(str(type.name))
                temp.currentTextChanged.connect(lambda text, a=attribute: change(FreqType[text], a))
            if isinstance(attr, SequenceBlock):
                temp = QPushButton("Sequence")
                temp.clicked.connect(lambda b, f=self.Flicker: open_sequence_builder(f))
            if temp:
                temp.setFixedSize(size, size * (9 / 16))
                self.attrDict[attribute] = temp
                Layout.addWidget(temp)

        self.setLayout(Layout)

    def select(self, l):
        if self in l:
            l.remove(self)
            self.setPalette(self.defaultPalette)
        else:
            l.append(self)
            p = self.palette()
            p.setColor(self.backgroundRole(), Selection_Color)
            self.setPalette(p)

    def updateData(self):
        for attr in self.attrDict:
            value = self.Flicker.__dict__[attr]
            if (isinstance(value, float) or isinstance(value, int)) and not isinstance(value, bool):
                self.attrDict[attr].setText(str(int(value)))
                continue
            if isinstance(value, str):
                self.attrDict[attr].setText(value)
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
        self.Rows = {}
        self.selected = []
        self.setMaximumHeight(400)
        self.setMinimumHeight(400)
        # modify style
        self.setFrameStyle(QFrame.StyledPanel | QFrame.Sunken)
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor(100, 100, 100))
        self.setPalette(p)
        labelWidget = QWidget()
        labelLayout = QHBoxLayout()
        testFlicker = Flicker()
        for i in testFlicker.__dict__:
            if testFlicker.__dict__[i] != None:
                t = QLabel(i)
                t.setAlignment(Qt.AlignCenter)
                t.setFixedSize(size, size * (9 / 16))
                labelLayout.addWidget(t)
        labelWidget.setLayout(labelLayout)
        self.VLayout.addWidget(labelWidget)
        self.RowArea = QScrollArea()
        self.RowArea.setWidgetResizable(True)
        self.RowArea.setHorizontalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        RowContainer = QWidget(self.RowArea)
        self.RowLayout = QVBoxLayout(RowContainer)
        self.RowLayout.addStretch(0)
        self.InitRows()
        self.RowArea.setWidget(RowContainer)
        self.VLayout.addWidget(self.RowArea)
        # self.VLayout.addStretch(0)

    def InitRows(self):
        for f in self.Flickers:
            self.AddNewFlicker(f)

    def AddNewFlicker(self, flicker):
        row = FlickerTableRow(flicker)
        self.RowLayout.insertWidget(self.RowLayout.count()-1,row)
        #self.RowLayout.addWidget(row)
        self.Rows[flicker] = row
        row.mousePressEvent = lambda event: row.select(self.selected)
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
