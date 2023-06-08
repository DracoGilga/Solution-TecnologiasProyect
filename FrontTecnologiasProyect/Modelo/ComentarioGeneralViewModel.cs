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

        public ComentarioGeneralViewModel(ComentarioGeneral comentarioGeneral)
        {
            comentarioGeneralBD = new ObservableCollection<ComentarioGeneral>();
            GuardarComentarioGeneral(comentarioGeneral);
        }
        public async void GuardarComentarioGeneral(ComentarioGeneral comentarioGeneral)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool comentarioGeneralService = await conexionServicios.GuardarComentarioGeneralAsync(comentarioGeneral);
            }
        }
    }
}
