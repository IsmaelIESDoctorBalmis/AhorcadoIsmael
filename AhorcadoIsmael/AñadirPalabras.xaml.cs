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

namespace AhorcadoIsmael
{
    /// <summary>
    /// Lógica de interacción para AñadirPalabras.xaml
    /// </summary>
    public partial class AñadirPalabras : Window
    {
        public AñadirPalabras()
        {
            InitializeComponent();
        }

        private void volverJuegoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void palabraAñadirButton_Click(object sender, RoutedEventArgs e)
        {

            if (!palabraAñadirTextBox.Text.Equals(""))
            {
                Palabras.palabrasUsuario.Add(palabraAñadirTextBox.Text);
            }


        }
    }
}
