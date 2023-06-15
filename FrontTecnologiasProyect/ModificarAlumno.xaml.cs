﻿using FrontTecnologiasProyect.Modelo;
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
    /// Lógica de interacción para ModificarAlumno.xaml
    /// </summary>
    public partial class ModificarAlumno : Window
    {
        public ModificarAlumno()
        {
            InitializeComponent();
            CargarCombobox();
        }

        private void btn_AgregarTabla(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ModificarEstudiante(object sender, RoutedEventArgs e)
        {

        }

        public void CargarCombobox()
        {
            EstudianteViewModel estudianteViewModel = new EstudianteViewModel();
            cb_Alumno.DisplayMemberPath = "matricula";
            cb_Alumno.ItemsSource = estudianteViewModel.estudiantesBD;

            AcademicoViewModel academicoViewModel = new AcademicoViewModel();
            cb_Tutor.DisplayMemberPath = "noPersonal";
            cb_Tutor.ItemsSource = academicoViewModel.academicoBD;
        }
    }
}