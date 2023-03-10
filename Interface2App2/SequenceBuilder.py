from PyQt5.QtWidgets import QWidget, QVBoxLayout, QLabel, QLineEdit, QComboBox, QHBoxLayout, QFrame,QPushButton
from Flicker import SeqType, SeqCondition, SequenceBlock


class SequenceBuilder(QWidget):
    def __init__(self, flicker):
        super().__init__()
        self.Flicker = flicker
        self.MainLayout = QVBoxLayout()
        self.setLayout(self.MainLayout)
        self.InitSeq(self.MainLayout, flicker.sequence)

    def InitSeq(self, parent, seq: SequenceBlock,rootSeq=None):
        seqWidget = QWidget()
        seqLayout = QVBoxLayout()
        #for subseq
        frame = QFrame()


        # type
        ly1 = QHBoxLayout()
        l1 = QLabel("Type")
        typebox = QComboBox()
        for type in (SeqType):
            typebox.addItem(str(type.name))

        def assigntype(seq, text,frame):
            seq.Type = SeqType[text]
            if text=="Block" or text=="Loop":
                frame.show()
            else:
                frame.hide()

        typebox.setCurrentText(seq.seqType.name)
        typebox.currentTextChanged.connect(lambda text, seq=seq,f=frame: assigntype(seq, text,frame))

        ly1.addWidget(l1)
        ly1.addWidget(typebox)
        seqLayout.addLayout(ly1)

        # Condition
        ly2 = QHBoxLayout()
        l2 = QLabel("Condition")
        conditionBox = QComboBox()
        for cond in (SeqCondition):
            conditionBox.addItem(str(cond.name))

        def assigncond(seq, text):
            seq.Condition = SeqCondition[text]


        conditionBox.setCurrentText(seq.Condition.name)
        conditionBox.currentTextChanged.connect(lambda text, seq=seq: assigncond(seq, text))
        ly2.addWidget(l2)
        ly2.addWidget(conditionBox)
        seqLayout.addLayout(ly2)

        # Value
        ly3 = QHBoxLayout()
        l3 = QLabel("Value to check")
        valueEdit = QLineEdit(str(seq.value))

        def assignValue(text, seq):
            seq.value = text

        valueEdit.textChanged.connect(lambda text, seq=seq: assignValue(text, seq))
        ly3.addWidget(l3)
        ly3.addWidget(valueEdit)
        seqLayout.addLayout(ly3)




        subseqLayout = QVBoxLayout()
        frame.setLayout(subseqLayout)
        frame.setLineWidth(5)
        frame.setFrameStyle(QFrame.Panel | QFrame.Raised)

        l4 = QLabel("Subsequences:")
        addButton = QPushButton("+")

        ly4 = QHBoxLayout()
        ly4.addWidget(l4)
        subseqLayout.addLayout(ly4)

        ly4.addWidget(addButton)
        def addNew(p,s,root):
            seq.AddSeq(s)
            self.InitSeq(p, s,root)
        addButton.clicked.connect(lambda b,p=subseqLayout,s=SequenceBlock(),root=seq:addNew(p,s,root))
        seqLayout.addWidget(frame)
        if seq.seqType == SeqType.Active or seq.seqType == SeqType.Inactive:
            frame.hide()

        for subseq in seq.contained_sequence:
            self.InitSeq(subseqLayout, subseq,seq)

        #Final thing
        finalLayout=QHBoxLayout()
        finalLayout.addLayout(seqLayout)
        ly5=QVBoxLayout()
        removeButton=QPushButton("-")
        def remove(p,s):
            p.RemoveSeq(s)
        if rootSeq:
            removeButton.clicked.connect(lambda b,s=seq,p=rootSeq:remove(p,s))

        ly5.addWidget(removeButton)
        ly5.addStretch(0)
        seqWidget.setLayout(finalLayout)
        parent.addWidget(seqWidget)
