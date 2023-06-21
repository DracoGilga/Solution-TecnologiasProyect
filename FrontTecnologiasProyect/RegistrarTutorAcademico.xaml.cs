using FrontTecnologiasProyect.Modelo;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FrontTecnologiasProyect
{
    /// <summary>
    /// Lógica de interacción para RegistrarTutorAcademico.xaml
    /// </summary>
    public partial class RegistrarTutorAcademico : Window
    {
        string nombre = "";
        string noPersonal = "";
        string apellidoPaterno = "";
        string apellidoMaterno = "";
        string correoElectronico = "";
        string correoInstitucional = "";
        string password = "";

        public RegistrarTutorAcademico()
        {
            InitializeComponent();
        }
        private async void Btn_Guardar(object sender, RoutedEventArgs e)
        {
            nombre = "NP" + tbx_Nombre.Text;
            apellidoPaterno = tbx_ApellidoPaterno.Text;
            apellidoMaterno = tbx_ApellidoMaterno.Text;
            noPersonal = tbx_NumeroPersonal.Text;
            correoElectronico = tbx_CorreoElectronico.Text;
            correoInstitucional = tbx_CorreoInstitucional.Text;
            password = pb_Password.Password;

            if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellidoPaterno) 
                && !String.IsNullOrWhiteSpace(apellidoMaterno) && !String.IsNullOrWhiteSpace(noPersonal) 
                && !String.IsNullOrWhiteSpace(correoElectronico) && !String.IsNullOrWhiteSpace(correoInstitucional) 
                && !String.IsNullOrEmpty(password))
            {
                if (ValidarCorreo(correoElectronico))
                {
                    if (ValidarCorreo(correoInstitucional))
                    {
                        Academico academico = new Academico()
                        {
                            nombre = nombre,
                            apellidoPaterno = apellidoPaterno,
                            apellidoMaterno = apellidoMaterno,
                            noPersonal = noPersonal,
                            correoPersonal = correoElectronico,
                            correoInstitucional = correoInstitucional,
                            password = password
                        };

                        AcademicoViewModel academicoViewModel = new AcademicoViewModel(1);
                        bool resultado = await academicoViewModel.GuardarTutorAcademico(academico);
                        if (resultado)
                        {
                            MessageBox.Show("El Tutor Académico ha sido guardado", "Confirmación de guardado", MessageBoxButton.OK);
                            this.Close();
                        }
                        else
                            MessageBox.Show("El Tutor Académico no ha sido guardado", "Error de guardado", MessageBoxButton.OK);
                    }
                    else
                        MessageBox.Show("Correo Electronico institucional invalido");
                }
                else
                    MessageBox.Show("Correo Electronico personal invalido");
            }
            else
                MessageBox.Show("Falta llenar 1 o mas campos, favor de llenarlos");
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public static bool ValidarCorreo(string correo)
        {
            string patron = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,})+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(correo);
        }
    }
}
