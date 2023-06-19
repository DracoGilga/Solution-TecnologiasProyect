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
        public SolucionViewModel(Solucion solucion)
        {
            solucionBD = new ObservableCollection<Solucion>();
            GuardarSolucion(solucion);
        }
        public async void GuardarSolucion(Solucion solucion)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                ;
            }
        }
        public SolucionViewModel(int idSolucion, Solucion solucion)
        {
            solucionBD = new ObservableCollection<Solucion>();
            ModificarSolucion(solucion);
        }
        public async void ModificarSolucion(Solucion solucion)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                
            }
        }
    }
}
