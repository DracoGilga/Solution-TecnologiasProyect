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
    /// Lógica de interacción para ModificarAlumno.xaml
    /// </summary>
    public partial class ModificarAlumno : Window
    {
        public ModificarAlumno()
        {
            InitializeComponent();
            CargarCombobox();
        }

        private void btn_AgregarTabla(object sender, RoutedEventArgs e)
        {
            // Obtener el estudiante seleccionado en el ComboBox cb_Alumno
            Estudiante estudianteSeleccionado = cb_Alumno.SelectedItem as Estudiante;

            // Obtener el académico seleccionado en el ComboBox cb_Tutor
            Academico academicoSeleccionado = cb_Tutor.SelectedItem as Academico;

            if (estudianteSeleccionado != null && academicoSeleccionado != null)
            {
                bool estudianteExistente = tablaAlumno.Items.Cast<dynamic>()
                                    .Any(item => item.Matricula == estudianteSeleccionado.matricula);
                if (!estudianteExistente)
                {

                    var newRow = new
                    {
                        IdEstudiante = estudianteSeleccionado.IdEstudiante,
                        Matricula = estudianteSeleccionado.matricula,
                        Nombre = estudianteSeleccionado.nombre,
                        ApellidoPaterno = estudianteSeleccionado.apellidoPaterno,
                        ApellidoMaterno = estudianteSeleccionado.apellidoMaterno,
                        IdAcademico = academicoSeleccionado.IdAcademico,
                        NoTutor = academicoSeleccionado.noPersonal
                    };
                    tablaAlumno.Items.Add(newRow);
                }
                else
                {
                    MessageBox.Show("El estudiante ya existe en la tabla");
                } 
            }
            else
            {
                MessageBox.Show("Seleccione un estudiante y/o un académico");
            }
        }

        private void btn_ModificarEstudiante(object sender, RoutedEventArgs e)
        {
            foreach(dynamic fila in tablaAlumno.Items)
            {
                EstudianteViewModel estudianteViewModel = new EstudianteViewModel(fila.IdEstudiante, fila.IdAcademico);
            }
            CargarCombobox();
        }

        public void CargarCombobox()
        {
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel();
            cb_Alumno.DisplayMemberPath = "matricula";
            cb_Alumno.ItemsSource = estudianteViewModel.estudiantesBD;

            AcademicoViewModel academicoViewModel = new AcademicoViewModel();
            cb_Tutor.DisplayMemberPath = "noPersonal";
            cb_Tutor.ItemsSource = academicoViewModel.academicoBD;
        }
    }
}
