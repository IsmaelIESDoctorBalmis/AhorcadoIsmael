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
using System.Windows.Threading;

namespace AhorcadoIsmael
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double contador = 180;
        DispatcherTimer timer = new DispatcherTimer();



        public MainWindow()
        {
            InitializeComponent();


            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += timer_Tick;




        }

        void Contador()
        {
            // contador = TimeSpan.FromSeconds(contador).TotalSeconds;

            botonMenu.IsEnabled = false;

            timer.Start();

        }

        


        void timer_Tick(object sender, EventArgs e)
        {


            contador = TimeSpan.FromSeconds(contador).TotalSeconds;
            if (contador != 0)
            {
                contador = contador - 1;

                countDownTextBlock.Text = TimeSpan.FromSeconds(contador).ToString(@"mm\:ss");
            }
            else
            {
                timer.Stop();
                botonMenu.IsEnabled = true;
            }


        }

        private void facilMenuClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Has seleccionado la dificultad FACIL");

            contador = 300;

            Contador();
        }

        private void medioMenuClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Has seleccionado la dificultad MEDIA");

            contador = 180;

            Contador();
        }

        private void dificilMenuClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Has seleccionado la dificultad DIFICIL");

            contador = 60;

            Contador();
        }







    }


}
