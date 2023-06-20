using FrontTecnologiasProyect.Controladores;
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
    /// Lógica de interacción para RegistrarSolucionProblematica.xaml
    /// </summary>
    public partial class RegistrarSolucionProblematica : Window
    {
        Problematica problematicaLlave;
        Academico academicoLlave;
        ExperienciaEducativa experienciaEducativaLlave;
        Materia materiaLlave;
        public RegistrarSolucionProblematica(Problematica dato)
        {
            InitializeComponent();
            problematicaLlave = dato;
            ConfigurarFormulario(problematicaLlave);
        }

        private void Btn_CancelarSolucion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_GuardarSolucion(object sender, RoutedEventArgs e)
        {
            SolucionViewModel solucionViewModel = new SolucionViewModel();
            Solucion solucion = new Solucion();
            solucion.titulo = tb_TituloSolucion.Text;
            solucion.descripcion = tb_DescripcionSolucion.Text;
            solucion.IdProblematica = problematicaLlave.IdProblematica;
            solucion.Problematica = new Problematica()
            {
                IdProblematica = solucion.IdProblematica
            };
            solucion.IdProgramaEducativo = experienciaEducativaLlave.IdProgramaEducativo;
            solucion.ProgramaEducativo = new ProgramaEducativo()
            {
                IdProgramaEducativo = solucion.IdProgramaEducativo
            };
            bool resultdo = await solucionViewModel.GuardarSolucion(solucion);

        }
        private async void ConfigurarFormulario(Problematica dato)
        {
            ExperienciaEducativaViewModel experienciaEducativaViewModel = new ExperienciaEducativaViewModel(1);
            AcademicoViewModel academicoViewModel = new AcademicoViewModel(1);
            MateriaViewModel materiaViewModel = new MateriaViewModel();
            ExperienciaEducativa experienciaEducativa =await experienciaEducativaViewModel.CargarExperienciaEducativaId(problematicaLlave.IdExperienciaEducativa);
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
        }
    }
}
