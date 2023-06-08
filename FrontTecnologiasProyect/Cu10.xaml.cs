using FrontTecnologiasProyect.Modelo;
using ServiceReference1;
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
    /// Lógica de interacción para Cu10.xaml
    /// </summary>
    public partial class Cu10 : Window
    {
        public Cu10()
        {
            InitializeComponent();
            ProgramaEducativoViewModel programaEducativoViewModel = new ProgramaEducativoViewModel();
            Cb_programaEducativo.DisplayMemberPath = "nombre";
            Cb_programaEducativo.ItemsSource = programaEducativoViewModel.programasEducativosBD;
            Console.WriteLine("boton inicio");

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("boton inicio");
            Estudiante estudiante = new Estudiante();
            estudiante.matricula = tb_maticula.Text;
            estudiante.nombre = tb_nombre.Text;
            estudiante.apellidoPaterno = tb_apellidoP.Text;
            estudiante.apellidoMaterno = tb_apellidoM.Text;
            estudiante.correoPersonal = tb_correoP.Text;
            estudiante.correoInstitucional = tb_maticula.Text + "@estudiantes.uv.mx";
            Console.WriteLine("boton");
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel(estudiante);
            Console.WriteLine("boton2");
        }
    }
}
