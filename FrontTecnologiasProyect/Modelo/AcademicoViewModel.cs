using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    class AcademicoViewModel
    {
        public ObservableCollection<Academico> academicoBD { get; set; }

        public AcademicoViewModel(int i)
        {
            
        }
        public async Task<Boolean> GuardarTutorAcademico(Academico academico)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Boolean resultado = await conexionServicios.RegistrarAcademicoAsync(academico);
                return resultado;
            }
            else
                return false;
        }

        public AcademicoViewModel()
        {
            academicoBD = new ObservableCollection<Academico>();
            ObtenerAcademico();
        }
        public async void ObtenerAcademico()
        {
            var conexionServicios = new Service1Client();
            if(conexionServicios != null)
            {
                Academico[] academicoService = await conexionServicios.ObtenerAcademicoAsync();
                if(academicoService != null)
                {
                    foreach(Academico item in academicoService)
                    {
                        academicoBD.Add(item);
                    }
                }
            }
        }
        public async Task<Academico> Login (string noPersonal, string contraseña)
        {
            var conexionServicios = new Service1Client();
            if(conexionServicios != null)
            {
                Academico academico = await conexionServicios.LoginAsync(noPersonal, contraseña);
                if(academico != null)
                {
                    academicoBD.Add(academico);
                    return academico;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
