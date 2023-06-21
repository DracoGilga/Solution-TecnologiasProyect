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
    /// Lógica de interacción para RegistrarProblematicaA.xaml
    /// </summary>
    public partial class RegistrarProblematicaA : Window
    {
        Tutoria tutoriaLlave;
        Academico academicoLlave;
        private ProblematicaAcademivaViewModel problematicaAcademivaViewModel;
        public RegistrarProblematicaA(Tutoria tutoria, Academico academico)
        {
            InitializeComponent();
            tutoriaLlave = tutoria;
            academicoLlave = academico;
            problematicaAcademivaViewModel = new ProblematicaAcademivaViewModel();
            EditarCombox();
        }        

        private async void Btn_guardar(object sender, RoutedEventArgs e)
        {
            Problematica problematica = new Problematica();
            problematica.titulo = Tb_titulo.Text;
            problematica.noIncidencias = Convert.ToInt32(Tb_incidencias.Text);
            problematica.descripcion = Tb_descripcion.Text;
            problematica.IdTutoria = tutoriaLlave.IdTutoria;
            problematica.Tutoria = new Tutoria()
            {
                IdTutoria = problematica.IdTutoria
            };
            problematica.IdTutor = academicoLlave.IdAcademico;
            problematica.Academico = new Academico()
            {
                IdAcademico = problematica.IdTutor
            };
            try
            {
                var problematicaLlaveTipo = (TipoProblematica)Cb_tipoProblematica.SelectedItem;
                problematica.IdTipo = problematicaLlaveTipo.IdTipo;
                problematica.TipoProblematica = new TipoProblematica()
                {
                    IdTipo = problematica.IdTipo
                };
            }
            catch(Exception)
            {
                MessageBox.Show("Seleccione un tipo de problematica");
                return;
            }
            try
            {
                var problematicaLlaveExperiencia = (ExperienciaEducativa)cb_Nrc.SelectedItem;
                problematica.IdExperienciaEducativa = problematicaLlaveExperiencia.IdExperienciaEducativa;
                problematica.ExperienciaEducativa = new ExperienciaEducativa()
                {
                    IdExperienciaEducativa = problematica.IdExperienciaEducativa
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una experiencia educativa");
                return;
            }


            bool problematicaRespuesta = await problematicaAcademivaViewModel.GuardarProblematica(problematica);
            if (problematicaRespuesta)
            {
                MessageBox.Show("Se guardo correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se guardo correctamente");
            }
        }
        

        
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var character in e.Text)
            {
                if (!char.IsDigit(character))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
        private void EditarCombox()
        {
            //tipo de problematica
            TipoProblematicaViewModel tipoProblematicaViewModel = new TipoProblematicaViewModel();
            Cb_tipoProblematica.DisplayMemberPath = "tipo";
            Cb_tipoProblematica.ItemsSource = tipoProblematicaViewModel.tipoProblematicaBD;

            //experiencia educativa
            ExperienciaEducativaViewModel experienciaEducativaViewModel = new ExperienciaEducativaViewModel();
            cb_Nrc.DisplayMemberPath = "nrc";
            cb_Nrc.ItemsSource = experienciaEducativaViewModel.experienciaEducativaBD;
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


    }
}
