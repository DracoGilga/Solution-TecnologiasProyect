using FrontTecnologiasProyect.Modelo;
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
using System.Windows.Shapes;

namespace FrontTecnologiasProyect
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            EstudianteViewModel modelo = new EstudianteViewModel(4);
            tablaAlumno.ItemsSource = modelo.estudiantesBD;
        }

        private void Btn_problematicaA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_comentariosG_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}