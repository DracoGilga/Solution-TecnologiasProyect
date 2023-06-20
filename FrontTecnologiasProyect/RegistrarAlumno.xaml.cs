﻿using FrontTecnologiasProyect.Modelo;
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
    /// Lógica de interacción para RegistrarAlumno.xaml
    /// </summary>
    public partial class RegistrarAlumno : Window
    {
        public RegistrarAlumno()
        {
            InitializeComponent();
            ProgramaEducativoViewModel programaEducativoViewModel = new ProgramaEducativoViewModel();
            Cb_programaEducativo.DisplayMemberPath = "nombre";
            Cb_programaEducativo.ItemsSource = programaEducativoViewModel.programasEducativosBD;
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel(true);
            Estudiante estudiante = new Estudiante();
            estudiante.matricula = tb_maticula.Text;
            estudiante.nombre = tb_nombre.Text;
            estudiante.apellidoPaterno = tb_apellidoP.Text;
            estudiante.apellidoMaterno = tb_apellidoM.Text;
            estudiante.correoPersonal = tb_correoP.Text;
            estudiante.correoInstitucional = tb_maticula.Text + "@estudiantes.uv.mx";
            estudiante.IdProgramaEducativo = 3;
            estudiante.ProgramaEducativo = new ProgramaEducativo()
            {
                IdProgramaEducativo = estudiante.IdProgramaEducativo
            };

            bool resultado = await estudianteViewModel.GuardarEstudiante(estudiante);
            if (resultado)
            {
                MessageBox.Show("Se guardo correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se guardo correctamente");
            }

        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
