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
        public RegistrarProblematicaA()
        {
            InitializeComponent();
        }        

        private void Btn_guarfar(object sender, RoutedEventArgs e)
        {
            Problematica problematica = new Problematica();
            problematica.titulo = Tb_titulo.Text;
            problematica.noIncidencias = Convert.ToInt32(Tb_incidencias.Text);
            problematica.descripcion = Tb_descripcion.Text;

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
    }
}
