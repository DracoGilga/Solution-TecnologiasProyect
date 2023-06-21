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
    /// Lógica de interacción para ModificarProblematicaA.xaml
    /// </summary>
    public partial class ModificarProblematicaA : Window
    {
        Tutoria tutoriaLlave;
        Academico academicoLlave;
        ProblematicaAcademivaViewModel problematicaAcademivaViewModel;
        public ModificarProblematicaA(Tutoria tutoria,Academico academico)
        {
            InitializeComponent();
            tutoriaLlave = tutoria;
            academicoLlave = academico;
            ConfigurarComboBox();
            problematicaAcademivaViewModel = new ProblematicaAcademivaViewModel();
        }
        private async void Btn_Guardar(object sender, RoutedEventArgs e)
        {
            try
            {
                var problematicaLlave = (Problematica)cb_Problematica.SelectedItem;
                Problematica problematica = new Problematica();
                problematica.noIncidencias = Convert.ToInt32(Tb_incidencias.Text);
                problematica.descripcion = Tb_descripcion.Text;
                problematica.IdProblematica = problematicaLlave.IdProblematica;

                if (!string.IsNullOrWhiteSpace(Tb_incidencias.Text) && !string.IsNullOrWhiteSpace(Tb_descripcion.Text))
                {
                    bool respuesta = await problematicaAcademivaViewModel.ModificarProblematica(problematica);
                    if (respuesta)
                    {
                        MessageBox.Show("Se modifico correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se modifico correctamente");
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Seleccione una problematica");
                return;
            }
        }

        private void ConfigurarComboBox()
        {
            Problematica problematica = new Problematica();
            problematica.IdTutoria = tutoriaLlave.IdTutoria;
            problematica.Tutoria = new Tutoria()
            {
                IdTutoria = tutoriaLlave.IdTutoria
            };
            problematica.IdTutor = academicoLlave.IdAcademico;
            problematica.Academico = new Academico()
            {
                IdAcademico = academicoLlave.IdAcademico
            };
            ProblematicaAcademivaViewModel problematicaAcademivaViewModel = new ProblematicaAcademivaViewModel(problematica);
            cb_Problematica.DisplayMemberPath = "titulo";
            cb_Problematica.ItemsSource = problematicaAcademivaViewModel.problematicaBD;
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Problematica)cb_Problematica.SelectedItem;
            if (selectedItem != null)
            {
                Tb_incidencias.Text = selectedItem.noIncidencias.ToString();
                Tb_descripcion.Text = selectedItem.descripcion;
            }
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
