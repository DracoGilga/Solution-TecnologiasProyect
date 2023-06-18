using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class ComentarioGeneralViewModel
    {
        public ObservableCollection<ComentarioGeneral> comentarioGeneralBD { get; set; }

        public ComentarioGeneralViewModel()
        {
            
        }
        public async Task<Boolean> GuardarComentarioGeneral(ComentarioGeneral comentarioGeneral)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool comentarioGeneralService = await conexionServicios.GuardarComentarioGeneralAsync(comentarioGeneral);
                return comentarioGeneralService;
            }
            return false;
        }
    }
}
