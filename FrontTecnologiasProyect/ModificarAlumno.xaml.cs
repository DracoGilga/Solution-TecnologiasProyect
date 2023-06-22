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
        private EstudianteViewModel estudianteViewModelGuardar;
        public ModificarAlumno()
        {
            InitializeComponent();
            estudianteViewModelGuardar = new EstudianteViewModel();
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

        private async void btn_ModificarEstudiante(object sender, RoutedEventArgs e)
        {
            if (tablaAlumno.Items.Count > 0)
            {
                int contadorAgregados = 0;
                int contadorNoAgregados = 0;

                foreach (dynamic fila in tablaAlumno.Items)
                {
                    bool resultado =await estudianteViewModelGuardar.ModificarAlumno(fila.IdEstudiante, fila.IdAcademico);
                    if (resultado)
                    {
                        contadorAgregados++;
                    }
                    else
                    {
                        contadorNoAgregados++;
                    }
                }

                MessageBox.Show($"Se modificaron {contadorAgregados} estudiantes correctamente. No se pudieron modificar {contadorNoAgregados} estudiantes.");
                tablaAlumno.Items.Clear();
                CargarCombobox();
            }
            else
            {
                MessageBox.Show("No hay filas para modificar.");
            }
        }



        public void CargarCombobox()
        {
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel();
            cb_Alumno.DisplayMemberPath = "matricula";
            cb_Alumno.ItemsSource = estudianteViewModel.estudiantesBD;

            AcademicoViewModel academicoViewModel = new AcademicoViewModel();
            cb_Tutor.ItemTemplate = (DataTemplate)Resources["TutorItemTemplate"];
            cb_Tutor.ItemsSource = academicoViewModel.academicoBD;
        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
