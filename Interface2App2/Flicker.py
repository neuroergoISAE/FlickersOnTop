from enum import Enum
from PyQt5.QtGui import QColor


class FreqType(Enum):
    Sine = 1
    Root_Square = 3
    Square = 2
    Maximum_Length_Sequence = 4
    Random = 0
    Custom = 5


class SeqType(Enum):
    Block = 1
    Loop = 2
    Active = 3
    Inactive = 4


class SeqCondition(Enum):
    Never = 0
    Always = 1
    KeyPress = 2
    Time = 3


class SequenceBlock:
    def __init__(self, seq_type=SeqType.Block, cond_type=SeqCondition.Never, value=0.0,*args):
        self.seqType = seq_type
        self.Condition = cond_type
        self.value = value
        if len(args)>0:
            self.contained_sequence = args
        else:
            self.contained_sequence=[]

    def AddSeq(self, seq, index=None):
        if index==None:
            index= len(self.contained_sequence)
        self.contained_sequence.insert(index, seq)
        return self

    def removeSeq(self, seq):
        self.contained_sequence.remove(seq)

    def removeSeqByIndex(self, index):
        self.contained_sequence.pop(index)

    def __len__(self):
        return len(self.contained_sequence)

    def __repr__(self):
        return "Type: " + self.seqType.name + " Condition: " + self.Condition.name + str(self.contained_sequence) + "\n"


class Flicker:
    def __init__(self, name="Flicker", x=0, y=0, width=100, height=100, frequency=1.0, phase=0.0, type_freq=FreqType.Sine,
                 opacity_min=0, opacity_max=100, color=QColor(255, 255, 255), sequence=(SequenceBlock().AddSeq(SequenceBlock(SeqType.Active,SeqCondition.Never))), image=None,
                 IsImageFlicker=False):
        self.Name = name
        self.X = int(x)
        self.Y = int(y)
        self.Width = width
        self.Height = height
        self.Frequency = frequency
        self.Phase = phase
        self.Type = type_freq
        self.Opacity_Min = opacity_min
        self.Opacity_Max = opacity_max
        self.Color = color

        self.sequence = sequence
        self.image = image
        self.IsImageFlicker = IsImageFlicker

    def __repr__(self):
        return "Flicker X:" + str(self.X) + " Y:" + str(self.Y) + " Width" + str(self.Width) + " Height" + str(
            self.Height) + " Type:" + self.Type.name
    def __copy__(self):
        f=Flicker()
        for key in self.__dict__:
            f.__setattr__(key,self.__dict__[key])
        return f
