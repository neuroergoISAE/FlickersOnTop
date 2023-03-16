from PyQt5.QtWidgets import QWidget, QGraphicsRectItem, QGraphicsScene, QGraphicsView, QApplication, \
    QGraphicsPixmapItem, \
    QGraphicsItem, QGraphicsSceneMouseEvent, QGraphicsObject,QGraphicsTextItem,QMenu,QAction
from PyQt5.QtGui import QColor, QPainter, QBrush, QResizeEvent, QPen,QImage,QTransform,QMatrix2x2
from PyQt5.QtCore import Qt, pyqtSignal, QRectF,pyqtSlot,QPoint
from Flicker import Flicker
import typing


class FlickerRect(QGraphicsObject):
    def __init__(self):
        super().__init__()
        self.rect = QGraphicsRectItem()
        self.resizeRect = QGraphicsRectItem(0, 0, 7, 7)
        p = QPen(QColor(10, 10, 10))
        p.setWidth(2)
        self.resizeRect.setPen(p)
        self.resizeRect.setBrush(QColor(240, 240, 240))
        self.resizeRect.setFlags(QGraphicsItem.ItemIsMovable)
        self.nameTag=QGraphicsTextItem(self)
        self.rect.setParentItem(self)
        self.resizeRect.setParentItem(self)

    def boundingRect(self) -> QRectF:
        return self.rect.boundingRect()

    def paint(self, painter: QPainter, option: 'QStyleOptionGraphicsItem',
              widget: typing.Optional[QWidget] = ...) -> None:
        pass


class viewer(QGraphicsView):
    def __init__(self, parent):
        super().__init__(parent)
        self.parent = parent
        self.screen = QApplication.primaryScreen()
        self.screensize = self.screen.size()
        self.ratio_X = self.size().width() / self.screensize.width()
        self.ratio_Y = self.size().height() / self.screensize.height()


    def resizeEvent(self, event: QResizeEvent) -> None:
        super().resizeEvent(event)
        self.ratio_X = self.size().width() / self.screensize.width()
        self.ratio_Y = self.size().height() / self.screensize.height()
        self.parent._set_image()
        self.parent.updateFlickers(*self.parent.Flickers)




class ScreenViewer(QGraphicsScene):
    changeSignal = pyqtSignal(Flicker)
    removeSignal=pyqtSignal(Flicker)
    addSignal=pyqtSignal(Flicker)

    def __init__(self, flickers, parent=None):
        super().__init__(parent)
        self.Flickers = flickers
        self.graphDict = {}
        self.screen = QApplication.primaryScreen()

        self.view = viewer(self)
        self.view.setRenderHint(QPainter.Antialiasing)
        self.view.setViewportUpdateMode(QGraphicsView.BoundingRectViewportUpdate)
        self.view.setBackgroundBrush(QBrush(Qt.transparent))
        self.view.setMinimumSize(200, 200)
        self.view.setHorizontalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        self.view.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        self.view.mouseDoubleClickEvent=lambda event:self._set_blank()

        # setup context menu
        self.view.setContextMenuPolicy(Qt.CustomContextMenu)
        self.view.customContextMenuRequested.connect(self._customMenu)


        self.background = None
        self._set_image()

        # self.ratio_X=self.view.size().width()/size.width()
        # self.ratio_Y=self.view.size().height()/size.height()
        self.setupFlickers(*flickers)



    @pyqtSlot(QPoint)
    def _customMenu(self,point:QPoint):
        menu = QMenu("Context Menu", self.view)
        flickerUnder=self.itemAt(point,QTransform())
        if isinstance(flickerUnder,QGraphicsRectItem):
            a2=QAction("Remove this Flicker",self.view)
            a2.triggered.connect(lambda :self.removeSignal.emit(*[k for k, v in self.graphDict.items() if v == flickerUnder.parentItem()]))
            menu.addAction(a2)

        a1=QAction("Add a new Flicker",self.view)
        a1.triggered.connect(lambda :self.addSignal.emit(Flicker(x=int(point.x()/self.view.ratio_X),y=int(point.y()/self.view.ratio_Y))))
        menu.addAction(a1)

        menu.exec(self.view.mapToGlobal(point))

    def _set_image(self):
        screenshot = self.screen.grabWindow(0, 0, 0, self.screen.size().width(), self.screen.size().height())
        screenshot = screenshot.scaled(self.view.rect().width(), self.view.rect().height())
        if self.background != None:
            self.removeItem(self.background)
        self.background = QGraphicsPixmapItem(screenshot)
        self.background.setZValue(0)
        exactRect = self.background.sceneBoundingRect();
        self.view.setSceneRect(exactRect);
        self.addItem(self.background)
    def _set_blank(self):
        if self.background != None:
            self.removeItem(self.background)

    def setupFlickers(self, *flickers):
        def mouseReleaseEvent(item, event: QGraphicsSceneMouseEvent, fli) -> None:
            fli.X = int(item.pos().x() / self.view.ratio_X)
            fli.Y = int(item.pos().y() / self.view.ratio_Y)

            self.changeSignal.emit(fli)
            return FlickerRect.mouseReleaseEvent(item, event)

        def mouseReleaseEvent2(item, event: QGraphicsSceneMouseEvent, fli) -> None:
            if item.resizeRect.pos().x() < 0:
                item.resizeRect.setX(10)
            if item.resizeRect.pos().y() < 0:
                item.resizeRect.setY(10)
            item.rect.setRect(0, 0, item.resizeRect.pos().x(), item.resizeRect.pos().y())
            fli.Width, fli.Height = int(item.rect.rect().width() / self.view.ratio_X), int(item.rect.rect().height() / self.view.ratio_Y)
            self.changeSignal.emit(fli)
            return FlickerRect.mouseReleaseEvent(item, event)

        for f in flickers:
            self.graphDict[f] = FlickerRect()
            self.graphDict[f].nameTag.setPlainText(f.Name)
            self.graphDict[f].setZValue(1)
            self.graphDict[f].setFlags(QGraphicsItem.ItemIsMovable)
            self.graphDict[f].mouseReleaseEvent = lambda event, fli=f, item=self.graphDict[f]: mouseReleaseEvent(item,
                                                                                                                 event,
                                                                                                                 fli)
            self.graphDict[f].resizeRect.mouseReleaseEvent = lambda event, fli=f,item=self.graphDict[f]: mouseReleaseEvent2(item,
                                                                                                               event,
                                                                                                               fli)

            self.addItem(self.graphDict[f])
            self.graphDict[f].installSceneEventFilter(self.graphDict[f].resizeRect)
            self.updateFlickers(f)

    def updateFlickers(self, *flickers):
        for f in flickers:
            try:
                group = self.graphDict[f]
                group.setPos(self.view.ratio_X * float(f.X), self.view.ratio_Y * float(f.Y))
                group.rect.setRect(0, 0, self.view.ratio_X * float(f.Width), self.view.ratio_Y * float(f.Height))
                group.resizeRect.setPos(group.rect.rect().width(), group.rect.rect().height())
                if f.IsImageFlicker:
                    image=QImage(f.image)
                    image=image.scaled(int(group.rect.rect().width()),int(group.rect.rect().height()))
                    b=QBrush(image)
                else:
                    b=QBrush(QColor(255, 255, 255, 50))
                p = QPen(f.Color)
                p.setWidth(3)
                group.rect.setPen(p)
                group.rect.setBrush(b)
                group.nameTag.setPlainText(f.Name)
            except Exception as e:
                print(e)
    @pyqtSlot(Flicker)
    def removeFlicker(self,Flicker):
        self.removeItem(self.graphDict[Flicker])

