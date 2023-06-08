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
    /// Lógica de interacción para LlenarReporteTA.xaml
    /// </summary>
    public partial class LlenarReporteTA : Window
    {
        public LlenarReporteTA()
        {
            InitializeComponent();
            EstudianteViewModel modelo = new EstudianteViewModel(4);
            tablaAlumno.ItemsSource = modelo.estudiantesBD;
        }

        private void Btn_registrarProblematica(object sender, RoutedEventArgs e)
        {
            RegistrarProblematicaA registrarProblematicaA = new RegistrarProblematicaA();
            registrarProblematicaA.Show();
        }

        private void Btn_comentariosGenerales(object sender, RoutedEventArgs e)
        {
            RegistrarComentariosG registrarComentariosG = new RegistrarComentariosG();
            registrarComentariosG.Show();
        }

        private void Btn_modificarProblematica(object sender, RoutedEventArgs e)
        {
            ModificarProblematicaA  modificarProblematicaA = new ModificarProblematicaA();
            modificarProblematicaA.Show();
        }

        private void Btn_guardar(object sender, RoutedEventArgs e)
        {

        }
    }
}