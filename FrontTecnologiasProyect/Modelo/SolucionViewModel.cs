using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class SolucionViewModel
    {
        public ObservableCollection<Solucion> solucionBD { get; set; }
        public SolucionViewModel()
        {
            
        }
        public async Task<Solucion> ConsultarSolucion(int IdProblematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Solucion solucionService = await conexionServicios.ObtenerSolucionAsync(IdProblematica);
                return solucionService;
            }
            return null;
        }
        public async Task<bool> GuardarSolucion(Solucion solucion)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool solucionService = await conexionServicios.GuardarSolucionAsync(solucion);
                return solucionService;
            }
            return false;
        }
        public SolucionViewModel(int idSolucion, Solucion solucion)
        {
            solucionBD = new ObservableCollection<Solucion>();
            ModificarSolucion(solucion);
        }
        public async Task<bool> ModificarSolucion(Solucion solucion)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool solucionService = await conexionServicios.ModificarSolucionAsync(solucion);
                return solucionService;
            }
            return false;
        }
    }
}
