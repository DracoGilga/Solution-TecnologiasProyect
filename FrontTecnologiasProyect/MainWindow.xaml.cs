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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontTecnologiasProyect
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_InicioSesion(object sender, RoutedEventArgs e)
        {
            string numPersonal = tbNumPersonal.Text;
            string password = pbPassword.Password;
            if (numPersonal.Length > 0 && password.Length > 0)
            {
                verificarInicioSesion(numPersonal, password);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña requeridos para iniciar sesión", "Campos vacíos");
            }
        }

        private async void verificarInicioSesion(string numPersonal, string password)
        {
            var conexionServicios = new Service1Client();

            if (conexionServicios != null)
            {
                Mensaje resultado = await conexionServicios.IniciarSesionAsync(numPersonal, password);
                if (resultado.error == true)
                {
                    MessageBox.Show(resultado.mensaje, "Credenciales incorrectas");
                }
                else
                {
                    MessageBox.Show("Bienvenido(a) " + resultado.usuarioAutenticado.nombre + " al sistema.", "Usuario verificado");

                    MenuPrincipal ventanaMenu = new MenuPrincipal();
                    ventanaMenu.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sin servicio disponible...", "Error");
            }
        }

    }
}
