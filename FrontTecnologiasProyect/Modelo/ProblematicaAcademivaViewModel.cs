using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class ProblematicaAcademivaViewModel
    {
        public ObservableCollection<Problematica> problematicaBD { get; set; }
        public ProblematicaAcademivaViewModel(int idReporte,Problematica problematica)
        {
            problematicaBD = new ObservableCollection<Problematica>();
            GuardarProblematica(problematica);
        }
        public async Task<bool> GuardarProblematica(Problematica problematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool problematicaService = await conexionServicios.GuardarProblematicaAsync(problematica);
                return problematicaService;
            }
            return false;
        }

        public ProblematicaAcademivaViewModel(Problematica problematica)
        {
            problematicaBD = new ObservableCollection<Problematica>();
            ConsultarProblematicas(problematica);
        }
        public async void ConsultarProblematicas(Problematica problematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Problematica[] problematicaService = await conexionServicios.ObtenerProblematicasAsync(problematica);
                if (problematicaService != null)
                {
                    foreach (Problematica item in problematicaService)
                    {
                        problematicaBD.Add(item);
                    }
                }
            }
        }
        public ProblematicaAcademivaViewModel()
        {
            
        }
        public async Task<bool> ModificarProblematica(Problematica problematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool problematicaService = await conexionServicios.ModificarProblematicaAsync(problematica);
                return problematicaService;
            }
            return false;
        }
    }
}
