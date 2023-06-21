using FrontTecnologiasProyect.Modelo;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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
    /// Lógica de interacción para EditarSolucion.xaml
    /// </summary>
    public partial class EditarSolucion : Window
    {
        Problematica problematicaLlave;
        Academico academicoLlave;
        ExperienciaEducativa experienciaEducativaLlave;
        Materia materiaLlave;
        Solucion solucionLlave;
        public EditarSolucion(Problematica dato, Solucion solucion)
        {
            InitializeComponent();
            problematicaLlave = dato;
            solucionLlave = solucion;
            ConfigurarFormulario(problematicaLlave);
        }
        private async void Btn_GuardarSolucion(object sender, RoutedEventArgs e)
        {
            SolucionViewModel solucionViewModel = new SolucionViewModel();
            Solucion solucion = new Solucion();
            solucion.IdSolucion = solucionLlave.IdSolucion;
            solucion.titulo = tb_TituloSolucion.Text;
            solucion.descripcion = tb_DescripcionSolucion.Text;
            if (!string.IsNullOrWhiteSpace(tb_TituloSolucion.Text) 
                && !string.IsNullOrWhiteSpace(tb_DescripcionSolucion.Text))
            {
                bool resultado = await solucionViewModel.ModificarSolucion(solucion);
                if (resultado)
                    MessageBox.Show("Solucion Editada Correctamente");
                else
                    MessageBox.Show("Error al editar solucion");
            }
            else
                MessageBox.Show("No se puede guardar una solución vacía");
        }
        private async void ConfigurarFormulario(Problematica dato)
        {
            ExperienciaEducativaViewModel experienciaEducativaViewModel = new ExperienciaEducativaViewModel(1);
            AcademicoViewModel academicoViewModel = new AcademicoViewModel(1);
            MateriaViewModel materiaViewModel = new MateriaViewModel();
            ExperienciaEducativa experienciaEducativa = await experienciaEducativaViewModel.CargarExperienciaEducativaId(problematicaLlave.IdExperienciaEducativa);
            Materia materia = await materiaViewModel.CargarMateriaId(experienciaEducativa.IdMateria);
            Academico academico = await academicoViewModel.ObtenerAcademicoId(experienciaEducativa.IdAcademico);
            experienciaEducativaLlave = experienciaEducativa;
            materiaLlave = materia;
            academicoLlave = academico;
            tb_NoIncidencias.Text = dato.noIncidencias.ToString();
            tb_Titulo.Text = dato.titulo;
            tb_DescripcionProblematica.Text = dato.descripcion;
            tb_ExperienciaEducativa.Text = experienciaEducativa.nrc + " - " + materia.nombre;
            tb_Academico.Text = academico.nombre + " " + academico.apellidoPaterno + " " + academico.apellidoMaterno;
            tb_TituloSolucion.Text = solucionLlave.titulo;
            tb_DescripcionSolucion.Text = solucionLlave.descripcion;
        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
