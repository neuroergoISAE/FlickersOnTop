from PyQt5.QtWidgets import QVBoxLayout, QLabel, QLineEdit, QComboBox, QHBoxLayout, QFrame, QPushButton
from PyQt5.QtGui import QKeySequence
from Flicker import SeqType, SeqCondition, SequenceBlock


class SequenceBuilder(QFrame):
    def __init__(self, flicker):
        super().__init__()
        self.Flicker = flicker
        self.MainLayout = QVBoxLayout()
        self.setLayout(self.MainLayout)
        self.InitSeq(self.MainLayout, flicker.sequence)

        BottomLayout = QHBoxLayout()
        closeButton = QPushButton("Close")
        HelpButton = QPushButton("Help")
        closeButton.clicked.connect(self.hide)
        HelpButton.clicked.connect(self.help)
        BottomLayout.addWidget(HelpButton)
        BottomLayout.addStretch(0)
        BottomLayout.addWidget(closeButton)
        self.MainLayout.addLayout(BottomLayout)

    def InitSeq(self, parent, seq: SequenceBlock, rootSeq=None):
        seqWidget = QFrame()
        seqWidget.setFrameStyle(QFrame.StyledPanel)
        seqLayout = QVBoxLayout()
        argsLayout = QHBoxLayout()
        # for subseq
        frame = QFrame()

        # type
        ly1 = QHBoxLayout()
        l1 = QLabel("Type")
        l1.setMinimumWidth(55)
        typebox = QComboBox()
        typebox.setMinimumWidth(65)
        for types in (SeqType):
            typebox.addItem(str(types.name))

        def assigntype(seq, text, frame):
            seq.seqType = SeqType[text]
            if text == "Block" or text == "Loop":
                frame.show()
                container_value.hide()
            else:
                frame.hide()
                if seq.Condition == SeqCondition.KeyPress or seq.Condition == SeqCondition.Time:
                    container_value.show()

        typebox.setCurrentText(seq.seqType.name)
        typebox.currentTextChanged.connect(lambda text, seq=seq, f=frame: assigntype(seq, text, frame))

        ly1.addWidget(l1)
        ly1.addWidget(typebox)
        ly1.addStretch(0)
        argsLayout.addLayout(ly1)

        # Condition
        ly2 = QHBoxLayout()
        l2 = QLabel("Condition")
        l2.setMinimumWidth(55)
        conditionBox = QComboBox()
        conditionBox.setMinimumWidth(65)
        for cond in (SeqCondition):
            conditionBox.addItem(str(cond.name))

        def assigncond(seq, text):
            seq.Condition = SeqCondition[text]
            if SeqCondition[text] == SeqCondition.KeyPress:
                l3.setText("Key to proceed")
                container_value.show()
                keyButton.show()
                valueEdit.hide()
            if seq.Condition == SeqCondition.Time:
                l3.setText("Time in seconds")
                container_value.show()
                keyButton.hide()
                valueEdit.show()
            if seq.Condition == SeqCondition.Never or seq.Condition == SeqCondition.Always:
                container_value.hide()

        conditionBox.setCurrentText(seq.Condition.name)
        conditionBox.currentTextChanged.connect(lambda text, seq=seq: assigncond(seq, text))
        ly2.addWidget(l2)
        ly2.addWidget(conditionBox)
        ly2.addStretch(0)
        argsLayout.addLayout(ly2)

        # Value
        ly3 = QHBoxLayout()
        l3 = QLabel("Value")
        valueEdit = QLineEdit(str(seq.value))
        keyButton = QPushButton()

        def keyget(e, widget: QPushButton, seq):
            widget.releaseKeyboard()
            widget.setText("Key: " + QKeySequence(int(e.key())).toString())
            seq.value = float(e.key())
            widget.keyPressEvent = lambda e: QPushButton.keyPressEvent(widget, e)

        def assignValue(text, seq, widget: QPushButton = None):
            try:
                if seq.Condition == SeqCondition.KeyPress:
                    widget.setText("Press a key...")
                    widget.grabKeyboard()
                    widget.keyPressEvent = lambda e, widget=widget, seq=seq: keyget(e, widget, seq)
                else:
                    seq.value = float(text)
            except:
                valueEdit.setText(str(seq.value))

        valueEdit.textChanged.connect(lambda text, seq=seq: assignValue(text, seq))
        keyButton.clicked.connect(lambda b, seq=seq, w=keyButton: assignValue(b, seq, keyButton))
        keyButton.setText("Key: " + QKeySequence(int(seq.value)).toString())
        ly3.addWidget(l3)
        ly3.addWidget(valueEdit)
        ly3.addWidget(keyButton)
        ly3.addStretch(0)
        container_value = QFrame()
        container_value.setFrameStyle(QFrame.StyledPanel)
        container_value.setLayout(ly3)
        argsLayout.addWidget(container_value)

        seqLayout.addLayout(argsLayout)
        if seq.Condition == SeqCondition.KeyPress:
            l3.setText("Key to proceed")
            valueEdit.hide()
        else:
            l3.setText("Time in seconds")
            keyButton.hide()
        if seq.Condition == SeqCondition.Never or seq.Condition == SeqCondition.Always:
            container_value.hide()

        # subsequence
        subseqLayout = QVBoxLayout()
        frame.setLayout(subseqLayout)
        frame.setLineWidth(5)
        # frame.setFrameStyle(QFrame.StyledPanel)

        l4 = QLabel("Subsequences:")
        addButton = QPushButton("+")
        separation_line = QFrame()
        separation_line.setFrameStyle(QFrame.HLine)

        ly4 = QHBoxLayout()
        ly4.addWidget(l4)
        ly4.addWidget(addButton)
        ly4.addStretch(0)
        subseqLayout.addLayout(ly4)

        # subseqLayout.addWidget(separation_line)

        def addNew(p, s, root):
            seq.AddSeq(s)
            self.InitSeq(p, s, root)

        addButton.clicked.connect(lambda b, p=subseqLayout, s=SequenceBlock(), root=seq: addNew(p, s, root))
        seqLayout.addWidget(frame)
        if seq.seqType == SeqType.Active or seq.seqType == SeqType.Inactive:
            frame.hide()

        for subseq in seq.contained_sequence:
            self.InitSeq(subseqLayout, subseq, seq)

        # Final thing
        finalLayout = QHBoxLayout()
        finalLayout.addLayout(seqLayout)
        ly5 = QVBoxLayout()
        removeButton = QPushButton("-")
        removeButton.setMaximumWidth(30)

        def remove(p: SequenceBlock, s: SequenceBlock):
            p.removeSeq(s)
            seqWidget.hide()
            self.adjustSize()

        if rootSeq:
            removeButton.clicked.connect(lambda b, s=seq, p=rootSeq: remove(p, s))

        ly5.addWidget(removeButton)
        ly5.addStretch(0)
        finalLayout.addLayout(ly5)
        seqWidget.setLayout(finalLayout)
        parent.addWidget(seqWidget)

    def help(self):
        self.helpLabel = QLabel("Sequences are a way to control your flickers with time or your keyboard\n\n" +
                                " Sequences can have 4 types:\n" +
                                "   - Block   : Sequence that contains other sequence, used to gather sequence together\n" +
                                "   - Loop    : Same as a Block but it will loop until its condition as been verified\n" +
                                "   - Active  : Flicker will be shown\n" +
                                "   - Inactive: Flicker will be hidden\n\n" +
                                " For a sequence to leave the sequence and go to the next, they must verify a conditions\n" +
                                " There are 4 type of condition currently:\n" +
                                "   - Never   : will never leave the current sequence\n" +
                                "   - Always  : condition is always verified, this sequence will be jumped over\n" +
                                "   - Time    : coupled with a value in seconds, the sequence will last X seconds\n" +
                                "   - KeyPress: coupled with a key, the sequence will last until that key is pressed\n\n" +
                                " It must be observed that a LSL marker will be sent everytime a flicker reach a Active\n" +
                                " or Inactive sequence\n\n" +
                                " You can change in setting whether all Flickers use the same sequences or if they all have individual one\n")
        self.helpLabel.show()
