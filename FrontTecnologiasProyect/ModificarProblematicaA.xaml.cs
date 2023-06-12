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
        public ModificarProblematicaA()
        {
            InitializeComponent();
            ProblematicaAcademivaViewModel problematicaAcademivaViewModel = new ProblematicaAcademivaViewModel(0);
            cb_Problematica.DisplayMemberPath = "titulo";
            cb_Problematica.ItemsSource = problematicaAcademivaViewModel.problematicaBD;
        }
        private void Btn_Guardar(object sender, RoutedEventArgs e)
        {
            var problematicaLlave= (Problematica)cb_Problematica.SelectedItem;
            Problematica problematica = new Problematica();
            problematica.noIncidencias = Convert.ToInt32(Tb_incidencias.Text);
            problematica.descripcion = Tb_descripcion.Text;
            problematica.IdProblematica = problematicaLlave.IdProblematica;
            ProblematicaAcademivaViewModel problematicaAcademivaViewModel = new ProblematicaAcademivaViewModel(problematica);
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

    }
}
