using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Events_1.Models
{
    class TimerModel
    {
        public DateTime DataTimer = new DateTime(0, 0);             //DataTimer для обработки события Tick  
        private DispatcherTimer timer = null;                       //Для таймера используем DispatcherTimer

        public event EventHandler TimeChanged = null;               //Event для обработки Tick в Presenter

        public TimerModel()                                         //Конструктор, устанавливает настройки для DispatcherTimer
        {                                                           //Интервал - 1 секунда
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)         //Обработка Tick'ов таймера
        {                                                           //Добавляет по секунде в DataTimer
            DataTimer = DataTimer.AddSeconds(1);                    //Вызывает событие TimeChanged
            TimeChanged.Invoke(sender, e);
        }

        public void TimerStart()                                    //Публичный метод запуска таймера
        {
            timer.Start();
        }

        public void TimerStop()                                     //Публичный метод остановки таймера
        {
            timer.Stop();
        }

        public void TimerReset()                                    //Публичный метод сброса таймера
        {                                                           //И вызов события TimeChanged для сброса показателей
            timer.Stop();
            DataTimer = DateTime.MinValue;
            TimeChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
