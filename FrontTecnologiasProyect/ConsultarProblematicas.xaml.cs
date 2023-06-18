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
    /// Lógica de interacción para ConsultarProblematicas.xaml
    /// </summary>
    public partial class ConsultarProblematicas : Window
    {
        private Problematica problematica;
        public ConsultarProblematicas()
        {
            InitializeComponent();
            ProblematicaAcademivaViewModel modelo = new ProblematicaAcademivaViewModel(1);
            dg_Problematicas.ItemsSource = modelo.problematicaBD;
        }

        private void Dc_Solucion(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Problematica dato = (Problematica)dg_Problematicas.SelectedItem;
                if (dato != null)
                {
                    ProblematicaAcademivaViewModel model = new ProblematicaAcademivaViewModel(dato.IdProblematica);
                    if (model.Equals(true))
                    {
                        EditarSolucion editarSolucion = new EditarSolucion(dato);
                        editarSolucion.Show();
                        this.Close();
                    }
                    else
                    {
                        RegistrarSolucionProblematica solucion = new RegistrarSolucionProblematica(dato);
                        solucion.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar", "Error al cargar", MessageBoxButton.OK);
            }
        }

        private void Btn_Cerrar(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}