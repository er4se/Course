using Events_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Events_1.Presenters
{
    class TimerPresenter
    {
        TimerModel timerModel = null;                               //Пустые экземпляры классов
        MainWindow mainWindow = null;                               //TimerModel и MainWindow

        public TimerPresenter(MainWindow mainWindow)                //Конструктор Presenter для склеивания с MainWindow
        {                                                           //Инициализирует таймер, а также добавляет обработку событий
            this.mainWindow = mainWindow;                           //И передает результаты в MainWindow

            this.timerModel = new TimerModel();
            this.timerModel.TimeChanged += new EventHandler(Timer_Tick);

            this.mainWindow.StartButton_Clicked += new EventHandler(mainWindow_ButtonStart);
            this.mainWindow.StopButton_Clicked += new EventHandler(mainWindow_ButtonStop);
            this.mainWindow.ResetButton_Clicked += new EventHandler(mainWindow_ButtonReset);
        }

        void Timer_Tick(object sender, EventArgs e)                 //Обработка Tick'ов таймера и обновление результата MainWindow
        {
            mainWindow.TimerBox.Content = timerModel.DataTimer.ToString("mm:ss");
        }

        void mainWindow_ButtonStart(object sender, EventArgs e)     //Обработка кнопки Start, которая инициализирует работу метода TimerStart
        {
            timerModel.TimerStart();
        }

        void mainWindow_ButtonStop(object sender, EventArgs e)      //Обработка кнопки Stop, которая инициализирует работу метода TimerStop
        {
            timerModel.TimerStop();
        }

        void mainWindow_ButtonReset(object sender, EventArgs e)     //Обработка кнопки Reset, которая инициализирует работу метода TimerReset
        {
            timerModel.TimerReset();
        }
    }
}
