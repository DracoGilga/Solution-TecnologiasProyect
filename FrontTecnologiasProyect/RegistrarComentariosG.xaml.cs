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
        Tutoria tutoriaLlave;
        Academico academicoLlave;
        ComentarioGeneralViewModel comentarioGeneralViewModel;
        public RegistrarComentariosG(Tutoria tutoria, Academico academico)
        {
            InitializeComponent();
            tutoriaLlave = tutoria;
            academicoLlave = academico;
            comentarioGeneralViewModel = new ComentarioGeneralViewModel();
        }
        private async void Btn_guardar(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_comentarioG.Text))
            {
                MessageBox.Show("Debe ingresar un comentario general");
                return;
            }
            ComentarioGeneral comentarioGeneral = new ComentarioGeneral();
            comentarioGeneral.descripcion = cb_comentarioG.Text;
            comentarioGeneral.IdTutoria = tutoriaLlave.IdTutoria;
            comentarioGeneral.Tutoria = new Tutoria()
            {
                IdTutoria = tutoriaLlave.IdTutoria
            };
            comentarioGeneral.IdTutor = academicoLlave.IdAcademico;
            comentarioGeneral.Academico = new Academico()
            {
                IdAcademico = academicoLlave.IdAcademico
            };
            
            bool respuesta = await comentarioGeneralViewModel.GuardarComentarioGeneral(comentarioGeneral);
            if (respuesta)
            {
                MessageBox.Show("Comentario general guardado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el comentario general");
            }
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}
