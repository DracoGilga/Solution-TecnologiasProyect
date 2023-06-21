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
    /// Lógica de interacción para LlenarReporteTA.xaml
    /// </summary>
    public partial class LlenarReporteTA : Window
    {
        Academico academicoLlave;
        Tutoria tutoriaLlave;
        int tipoAcademicoLlave;
        private LlenarReporteTAViewModel llenarReporteTAViewModel;

        public LlenarReporteTA(Academico traspasoAcademicoc, int tipoAcademico)
        {
            InitializeComponent();
            academicoLlave = traspasoAcademicoc;
            tipoAcademicoLlave = tipoAcademico;
            llenarReporteTAViewModel = new LlenarReporteTAViewModel();
            FormatoTabla(traspasoAcademicoc);
            
        }

        private void Btn_registrarProblematica(object sender, RoutedEventArgs e)
        {
            RegistrarProblematicaA registrarProblematicaA = new RegistrarProblematicaA(tutoriaLlave,academicoLlave);
            registrarProblematicaA.ShowDialog();
        }

        private void Btn_comentariosGenerales(object sender, RoutedEventArgs e)
        {
            RegistrarComentariosG registrarComentariosG = new RegistrarComentariosG(tutoriaLlave,academicoLlave);
            registrarComentariosG.ShowDialog();
        }

        private void Btn_modificarProblematica(object sender, RoutedEventArgs e)
        {
            ModificarProblematicaA  modificarProblematicaA = new ModificarProblematicaA(tutoriaLlave, academicoLlave);
            modificarProblematicaA.ShowDialog();
        }

        private async void Btn_guardar(object sender, RoutedEventArgs e)
        {
            if (tablaAlumno.Items.Count > 0)
            {
                int registrados = 0;
                int noRegistrados = 0;
                foreach (Estudiante estudiante in tablaAlumno.Items)
                {
                    ReporteTutoria reporte = new ReporteTutoria();

                    reporte.IdTutor = academicoLlave.IdAcademico;
                    reporte.Academico = new Academico()
                    {
                        IdAcademico = academicoLlave.IdAcademico
                    };
                    reporte.IdEstudiante = estudiante.IdEstudiante;
                    reporte.Estudiante = new Estudiante()
                    {
                        IdEstudiante = estudiante.IdEstudiante
                    };
                    reporte.IdProgramaEducativo = estudiante.IdProgramaEducativo;
                    reporte.ProgramaEducativo = new ProgramaEducativo()
                    {
                        IdProgramaEducativo = estudiante.IdProgramaEducativo
                    };    
                    reporte.IdTutoria = tutoriaLlave.IdTutoria;
                    reporte.Tutoria = new Tutoria()
                    {
                        IdTutoria = tutoriaLlave.IdTutoria
                    };
                    reporte.IdProgramaEducativo = estudiante.IdProgramaEducativo;

                    DataGridRow row = (DataGridRow)tablaAlumno.ItemContainerGenerator.ContainerFromItem(estudiante);
                    CheckBox cbx_Asistencia = FindChild<CheckBox>(row, "cbx_Asistencia");
                    if (cbx_Asistencia != null)
                    {
                        reporte.asistencia = cbx_Asistencia.IsChecked ?? false;
                    }
                    CheckBox cbx_Riesgo = FindChild<CheckBox>(row, "cbx_Riesgo");
                    if (cbx_Riesgo != null)
                    {
                        reporte.riesgo = cbx_Riesgo.IsChecked ?? false;
                    }

                    bool resultado = await llenarReporteTAViewModel.GuardarLlenarReporteTA(reporte);
                    if (resultado)
                    {
                        registrados++;
                    }
                    else
                    {
                        noRegistrados++;
                    }
                }
                MessageBox.Show($"Se registro {registrados} reportes de tutoria. No se pudieron modificar {noRegistrados} reportes de tutoria.");
                GuardarRepoteTA.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Este tutor no tiene estudiantes, faavor de contactar con Cordinacion de tutoria");
            }
        }

        private async void FormatoTabla(Academico traspasoAcademicoc)
        {
            DateTime hoy = DateTime.Now;
            tutoriaLlave = await llenarReporteTAViewModel.FechaTutoria(hoy);
            EstudianteViewModel modelo = new EstudianteViewModel(traspasoAcademicoc.IdAcademico);
            tablaAlumno.ItemsSource = modelo.estudiantesBD;

            if(tutoriaLlave == null)
            {
                RegistrarproblematicaA.IsEnabled = false;
                ModificarProblematicaA.IsEnabled = false;
                RegistrarComentariosGenerales.IsEnabled = false;
                GuardarRepoteTA.IsEnabled = false;
                
            }
        }    
        
        
        //selecciona el checkbox dentro de la tabla para poderla utilizar
        private T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T && child.GetValue(NameProperty).ToString() == childName)
                    return (T)child;

                T childItem = FindChild<T>(child, childName);
                if (childItem != null)
                    return childItem;
            }
            return null;
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            if(tipoAcademicoLlave == 3)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
            }
            this.Close();
        }


    }
}