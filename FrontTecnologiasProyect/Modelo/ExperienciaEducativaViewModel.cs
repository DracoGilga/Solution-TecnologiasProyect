using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class ExperienciaEducativaViewModel
    {
        public ObservableCollection<ExperienciaEducativa> experienciaEducativaBD { get; set; }  
        public ExperienciaEducativaViewModel()
        {
            experienciaEducativaBD = new ObservableCollection<ExperienciaEducativa>();
            CargarExperienciaEducativa();
        }
        public async void CargarExperienciaEducativa()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                ExperienciaEducativa[] experienciaEducativaService = await conexionServicios.ObtenerExperienciasEducativasAsync();
                if (experienciaEducativaService != null)
                {
                    foreach (ExperienciaEducativa item in experienciaEducativaService)
                    {
                        experienciaEducativaBD.Add(item);
                    }
                }
            }
        }
    }
}
