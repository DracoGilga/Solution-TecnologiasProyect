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
        public async void GuardarProblematica(Problematica problematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool problematicaService = await conexionServicios.GuardarProblematicaAsync(problematica);
            }
        }
        public ProblematicaAcademivaViewModel(Problematica problematica)
        {
            problematicaBD = new ObservableCollection<Problematica>();
            ModificarProblematica(problematica);
        }
        public async void ModificarProblematica(Problematica problematica)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                bool problematicaService = await conexionServicios.ModificarProblematicaAsync(problematica);
            }
        }
    }
}
