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
    /// Lógica de interacción para RegistrarComentariosG.xaml
    /// </summary>
    public partial class RegistrarComentariosG : Window
    {
        public RegistrarComentariosG()
        {
            InitializeComponent();
        }
        private void Btn_guardar(object sender, RoutedEventArgs e)
        {
            ComentarioGeneral comentarioGeneral = new ComentarioGeneral();
            comentarioGeneral.descripcion = cb_comentarioG.Text;
            comentarioGeneral.IdReporte = 0;
            comentarioGeneral.ReporteTutoria = new ReporteTutoria()
            {
                IdReporte = comentarioGeneral.IdReporte
            };
            ComentarioGeneralViewModel comentarioGeneralViewModel = new ComentarioGeneralViewModel(comentarioGeneral);
        }
    }
}
