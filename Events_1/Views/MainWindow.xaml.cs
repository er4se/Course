using Events_1.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Events_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()                                         //Инициализация компонентов и экземпляра Presenter
        {                                                           //Склеивание Presenter и MainWindow
            InitializeComponent();
            new TimerPresenter(this);
        }
                                                                    //Создание событий для каждой из кнопок
        public event EventHandler StartButton_Clicked = null;       //Start
        public event EventHandler StopButton_Clicked = null;        //Stop
        public event EventHandler ResetButton_Clicked = null;       //Reset

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton_Clicked.Invoke(sender, e);                  //Обработка нажатия кнопки Start
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopButton_Clicked.Invoke(sender, e);                   //Обработка нажатия кнопки Stop
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButton_Clicked.Invoke(sender, e);                  ////Обработка нажатия кнопки Reset
        }
    }
}
