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

            if (!DatosInvalidos())
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
        }

        private Boolean DatosInvalidos()
        {
            Boolean campoInvalido = false;
            if (ExistenCamposVacios() || ExistenCamposInvalidos() || ExisteExcesoLongitud())
            {
                campoInvalido = true;
            }
            return campoInvalido;
        }

        private Boolean ExistenCamposVacios()
        {
            Boolean campoVacio = false;
            if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(apellidoPaterno) || String.IsNullOrWhiteSpace(apellidoMaterno)
               || String.IsNullOrWhiteSpace(correoElectronico) || String.IsNullOrWhiteSpace(correoInstitucional) || String.IsNullOrWhiteSpace(password)
               || String.IsNullOrWhiteSpace(noPersonal))
            {
                campoVacio = true;
                MessageBox.Show("Existen campos vacíos, favor de verificar", "Campos vacíos", MessageBoxButton.OK);
            }
            return campoVacio;
        }

        private Boolean ExisteExcesoLongitud()
        {
            Boolean campoExcedido = false;
            if (nombre.Length > 25)
            {
                campoExcedido = true;
                MessageBox.Show("El campo de 'Nombre' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            if (apellidoPaterno.Length > 30)
            {
                campoExcedido = true;
                MessageBox.Show("El campo de 'Apellido Paterno' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            if (apellidoMaterno.Length > 30)
            {
                campoExcedido = true;
                MessageBox.Show("El campo de 'Apellido Materno' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            if (correoElectronico.Length > 70)
            {
                campoExcedido = true;
                MessageBox.Show("El campo de 'Correo Electronico' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            if (correoInstitucional.Length > 70)
            {
                campoExcedido = true;
                MessageBox.Show("El campo de 'Correo Institucional' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            if (password.Length > 64)
            {
                campoExcedido = true;
                MessageBox.Show($"El campo de 'Contraseña' excede la longitud permitida, favor de ingresarlo de nuevo", "Exceso de longitud", MessageBoxButton.OK);
            }

            return campoExcedido;
        }

        private Boolean ExistenCamposInvalidos()
        {
            Boolean campoInvalido = false;
            if (ExistenCaracteresInvalidos(tbx_Nombre.Text))
            {
                MessageBox.Show("El campo de 'Nombre' contiene carácteres inválidos, favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            if (ExistenCaracteresInvalidos(tbx_ApellidoPaterno.Text))
            {
                MessageBox.Show("El campo de 'Apellido Paterno' contiene carácteres inválidos,favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            if (ExistenCaracteresInvalidos(tbx_ApellidoMaterno.Text))
            {
                MessageBox.Show("El campo de 'Apellido Materno' contiene carácteres inválidos, favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            if (ExistenCaracteresInvalidosNumero(tbx_NumeroPersonal.Text))
            {
                MessageBox.Show("El campo de 'No. de Personal' contiene carácteres inválidos, favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            if (ExistenCaracteresInvalidosCorreo(tbx_CorreoElectronico.Text))
            {
                MessageBox.Show("El campo de 'Correo Electrónico' contiene carácteres inválidos, favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            if (ExistenCaracteresInvalidosCorreo(tbx_CorreoInstitucional.Text))
            {
                MessageBox.Show("El campo de 'Correo Institucional' contiene carácteres inválidos, favor de volver a ingresarlo", "Carácteres inválidos", MessageBoxButton.OK);
                campoInvalido = true;
            }

            return campoInvalido;
        }

        private Boolean ExistenCaracteresInvalidosCorreo(String texto)
        {
            Boolean caracterInvalido = false;
            if (Regex.IsMatch(texto, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") == false)
            {
                caracterInvalido = true;
            }
            return caracterInvalido;
        }

        private Boolean ExistenCaracteresInvalidos(String texto)
        {
            Boolean caracterInvalido = false;
            if (Regex.IsMatch(texto, "^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$") == false)
            {
                caracterInvalido = true;
            }
            return caracterInvalido;
        }

        private Boolean ExistenCaracteresInvalidosNumero(String texto)
        {
            Boolean caracterInvalido = false;
            if (Regex.IsMatch(texto, @"^\d+$") == false)
            {
                caracterInvalido = true;
            }
            return caracterInvalido;
        }


        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
