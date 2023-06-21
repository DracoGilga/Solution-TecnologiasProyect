using FrontTecnologiasProyect.Modelo;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para RegistrarAlumno.xaml
    /// </summary>
    public partial class RegistrarAlumno : Window
    {
        public RegistrarAlumno()
        {
            InitializeComponent();
            ProgramaEducativoViewModel programaEducativoViewModel = new ProgramaEducativoViewModel();
            Cb_programaEducativo.DisplayMemberPath = "nombre";
            Cb_programaEducativo.ItemsSource = programaEducativoViewModel.programasEducativosBD;
        }
        private async void Btn_Registrar(object sender, RoutedEventArgs e)
        {
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel(true);
            Estudiante estudiante = new Estudiante();
            estudiante.matricula = tb_maticula.Text;
            estudiante.nombre = tb_nombre.Text;
            estudiante.apellidoPaterno = tb_apellidoP.Text;
            estudiante.apellidoMaterno = tb_apellidoM.Text;
            estudiante.correoPersonal = tb_correoP.Text;
            estudiante.correoInstitucional = tb_maticula.Text + "@estudiantes.uv.mx";
            try
            {
                var programaEducativo = (ProgramaEducativo)Cb_programaEducativo.SelectedItem;
                estudiante.IdProgramaEducativo = programaEducativo.IdProgramaEducativo;
                estudiante.ProgramaEducativo = new ProgramaEducativo()
                {
                    IdProgramaEducativo = estudiante.IdProgramaEducativo
                };
            }
            catch(Exception)
            {
                MessageBox.Show("No se selecciono un programa educativo");
                return;
            }
            
            if (!String.IsNullOrWhiteSpace(estudiante.matricula) && !String.IsNullOrWhiteSpace(estudiante.nombre) 
                && !String.IsNullOrWhiteSpace(estudiante.apellidoPaterno) && !string.IsNullOrWhiteSpace(estudiante.apellidoPaterno) 
                && !String.IsNullOrWhiteSpace(estudiante.correoPersonal) && estudiante.IdProgramaEducativo >= 0)
            {
                if (ValidarCorreo(estudiante.correoPersonal))
                {
                    bool resultado = await estudianteViewModel.GuardarEstudiante(estudiante);
                    if (resultado)
                    {
                        MessageBox.Show("Se guardo correctamente");
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se guardo correctamente");
                }
                else
                    MessageBox.Show("Correo no valido, favor de ingresar un correo valido");       
            }
            else
                MessageBox.Show("Una o mas celdas vacias, favor de llenar todas");
        }

        public static bool ValidarCorreo(string correo)
        {
            string patron = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,})+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(correo);
        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
