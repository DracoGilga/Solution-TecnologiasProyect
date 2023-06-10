using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class TipoProblematicaViewModel
    {
        public ObservableCollection<TipoProblematica> tipoProblematicaBD { get; set; }
        public TipoProblematicaViewModel()
        {
            tipoProblematicaBD = new ObservableCollection<TipoProblematica>();
            CargarTipoProblematica();
        }
        public async void CargarTipoProblematica()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                TipoProblematica[] tipoProblematicaService = await conexionServicios.ObtenerTipoProblematicasAsync();
                if (tipoProblematicaService != null)
                {
                    foreach (TipoProblematica item in tipoProblematicaService)
                    {
                        tipoProblematicaBD.Add(item);
                    }
                }
            }
        }
    }
}
