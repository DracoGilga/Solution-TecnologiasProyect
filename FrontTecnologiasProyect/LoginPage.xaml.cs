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
    /// Lógica de interacción para LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private AcademicoViewModel academicoViewModel;
        private ProgramaEducativoViewModel programaEducativoViewModel;
        public LoginPage()
        {
            InitializeComponent();
            academicoViewModel = new AcademicoViewModel();
            programaEducativoViewModel = new ProgramaEducativoViewModel();
        }
        private async void btn_Iniciar(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_NoPersonal.Text) || string.IsNullOrWhiteSpace(tb_Password.Text))
            {
                MessageBox.Show("Ingrese el usuario y/o contraseña");
                return;
            }
            Academico resultadoAcademico = await academicoViewModel.Login(tb_NoPersonal.Text, tb_Password.Text);
            if (resultadoAcademico != null)
            {
                MessageBox.Show("Bienvenido " + resultadoAcademico.nombre);
                int tipoAcademico = await programaEducativoViewModel.TipoAcademico(resultadoAcademico.IdAcademico);
                switch (tipoAcademico)
                {
                      case 1:
                        MainJefeCarrera menuAdministrador = new MainJefeCarrera();
                        menuAdministrador.Show();
                        this.Close();
                        break;
                    case 2:
                        MainCordinadorTutoria menuTutor = new MainCordinadorTutoria();
                        menuTutor.Show();
                        this.Close();
                        break;
                    case 3:
                        MainAcademico menuAcademico = new MainAcademico();
                        menuAcademico.Show();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("No se encontro el tipo de academico");
                        break;
                }
            }   
            else
                MessageBox.Show("usuario o contraseña incorrecto");
        }
    }
}
