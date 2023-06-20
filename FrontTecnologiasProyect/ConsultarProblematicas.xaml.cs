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
        SolucionViewModel solucionViewModel = new SolucionViewModel();
        public ConsultarProblematicas()
        {
            InitializeComponent();
            ProblematicaAcademivaViewModel modelo = new ProblematicaAcademivaViewModel(1);
            
            dg_Problematicas.ItemsSource = modelo.problematicaBD;
        }

        private async void Dc_Solucion(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Problematica dato = (Problematica)dg_Problematicas.SelectedItem;
                if (dato != null)
                {
                    Solucion resultado = await solucionViewModel.ConsultarSolucion(dato.IdProblematica);
                    if (resultado != null)
                    {
                        EditarSolucion editarSolucion = new EditarSolucion(dato, resultado);
                        editarSolucion.Show();
                        
                    }
                    else
                    {
                        RegistrarSolucionProblematica solucion = new RegistrarSolucionProblematica(dato);
                        solucion.Show();
                        
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