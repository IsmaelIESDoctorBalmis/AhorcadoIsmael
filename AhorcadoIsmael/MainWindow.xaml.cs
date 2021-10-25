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
        string teclaPulsada;

        TextBlock palabra = new TextBlock();
        ScrollViewer scroll = new ScrollViewer();

        bool partidaEmpezada = false;
        char[] arr;
        char[] arr2;

        StringBuilder sb = new StringBuilder();



        public MainWindow()
        {
            InitializeComponent();


            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += timer_Tick;

            List<char> Teclado = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToList<Char>();
            Teclado.Insert(14, 'Ñ');

            foreach (var letra in Teclado)
            {
                Button letras = new Button();
                letras.Tag = letra;
                TextBlock texto = new TextBlock();
                texto.Text = letra.ToString();
                Viewbox box = new Viewbox();
                box.Child = texto;
                letras.Content = box;
                contenedorTeclado.Children.Add(letras);
                letras.Click += Button_Click;

            }


            



        }




        void Contador()
        {


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

           

            partida();

            contador = 60;

            Contador();
        }

        public void partida()
        {

            if (partidaEmpezada == false)
            {

                int numeroRan = numeroRandom();

                numeroRan = numeroRan - 1;

                String pAdivina = Palabras.palabrasDificiles[numeroRan];
                int longitudCadena = pAdivina.Length;
                pAdivina = pAdivina.ToUpper();
                arr = pAdivina.ToCharArray(0, longitudCadena);

               
                scroll.Content = palabra;
                scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                //Para los scrollview debemos poner los
                PalabraWrapPanel.Children.Add(scroll);

                for (int i = 0; i < arr.Length; i++)
                {

                    palabra.Text = sb.Append("_").ToString();


                    palabra.FontSize = 40;



                }



                arr2 = palabra.Text.ToCharArray(0, palabra.Text.Length);

                

                partidaEmpezada = true;
            }
            

           
            
        }

        public void comprobar()
        {
            char tecla = Char.Parse(teclaPulsada);
            for (int i = 0; i < arr.Length; i++)
            {

                //MessageBox.Show(arr[i].ToString() + " " + tecla.ToString());


                if (arr[i].ToString() == tecla.ToString())
                {
                   // MessageBox.Show("Se ha encontrado igualdad");
                    
                    

                    arr2[i] = tecla;

                }

               
               

            }
            string regenerarPalabra = "";
            sb.Clear();
            for (int j = 0; j < arr2.Length; j++)
            {

                regenerarPalabra = sb.Append(arr2[j]).ToString();
                

            }

            palabra.Text = regenerarPalabra;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button boton = (Button)sender;
            boton.IsEnabled = false;
            teclaPulsada = boton.Tag.ToString();
            comprobar();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                foreach (Button b in contenedorTeclado.Children)
                {
                    if (b.Tag.ToString() == e.Key.ToString())
                    {
                        b.IsEnabled = false;
                        teclaPulsada = b.Tag.ToString();
                        comprobar();
                    }
                }
            }
            
        }

        private void desarrolladorMenuClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Has seleccionado la dificultad DESARROLLADOR");

            contador = 15;

            Contador();
        }

        private void usuarioMenuClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Has seleccionado el modo usuario");

            insertarPalabrasUsuario();

        }

        private void insertarPalabrasUsuario()
        {


            AñadirPalabras frm = new AñadirPalabras();

            frm.Show();

        }


        private void insertarCodigoClick(object sender, RoutedEventArgs e)
        {

            if (campoCodigoTextBox.Text == "javi tu siempre molas")
            {
                MessageBox.Show("Has activado el modo desarrollador");

                campoCodigoTextBox.Text = "";

                codigosGrid.Visibility = Visibility.Hidden;

                menuDesarrolladorMenu.Visibility = Visibility.Visible;
                menuUsuarioMenu.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Este código no existe");
                campoCodigoTextBox.Text = "";
                codigosGrid.Visibility = Visibility.Hidden;
            }





        }


        private void codigoClick(object sender, RoutedEventArgs e)
        {


            codigosGrid.Visibility = Visibility.Visible;


        }

        private void rendirseButton_Click(object sender, RoutedEventArgs e)
        {

            timer.Stop();
            botonMenu.IsEnabled = true;

            countDownTextBlock.Text = "";

        }

        public int numeroRandom()
        {
            int numero = 0;

            numero = new Random().Next(1, 4);



            return numero;
        }

        


    }
}
