from PyQt5.QtWidgets import QVBoxLayout, QLabel, QLineEdit, QComboBox, QHBoxLayout, QFrame, QPushButton, QCheckBox
from PyQt5.QtGui import QKeySequence
from PyQt5.QtCore import pyqtSignal
from Flicker import SeqType, SeqCondition, SequenceBlock
import os

setting_file = "setting"


class Settings(QFrame):
    updateSettingSignal = pyqtSignal()

    def __init__(self):
        super().__init__()
        self.MainLayout = QVBoxLayout()
        self.setLayout(self.MainLayout)
        self.setWindowTitle("Settings")

        exitLayout = QHBoxLayout()
        exitbutton = QPushButton("Exit")
        exitbutton.clicked.connect(self.hide)
        exitLayout.addStretch(0)
        line = QFrame()
        line.setFrameStyle(QFrame.HLine)
        exitLayout.addWidget(line)
        exitLayout.addWidget(exitbutton)

        setLayout = QVBoxLayout()
        self.seqlinkCheckBox = QCheckBox("Use the same sequence for all Flicker. WARNING: you will lose your current sequence")
        self.seqlinkCheckBox.clicked.connect(lambda b: self.updateSettingSignal.emit())
        setLayout.addWidget(self.seqlinkCheckBox)

        self.MainLayout.addLayout(setLayout)
        self.MainLayout.addStretch(0)
        self.MainLayout.addLayout(exitLayout)
        self.load()

    def save(self):
        with open(setting_file, 'w+') as f:
            for a in self.__dict__:
                if isinstance(self.__dict__[a], QCheckBox):
                    f.write(a + ":" + str(getattr(self, a).checkState()))

    def load(self):
        if not os.path.exists(setting_file):
            self.save()
        with open(setting_file,'r+') as f:
            for line in f.readlines():
                a, v = line.split(":")
                if a in self.__dict__:
                    if isinstance(self.__dict__[a], QCheckBox):
                        self.__getattribute__(a).setCheckState(int(v))