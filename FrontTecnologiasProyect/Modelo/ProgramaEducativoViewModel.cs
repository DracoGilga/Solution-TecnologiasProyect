using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    class ProgramaEducativoViewModel
    {
        public ObservableCollection<ProgramaEducativo> programasEducativosBD { get; set; }
        public ProgramaEducativoViewModel()
        {
            programasEducativosBD = new ObservableCollection<ProgramaEducativo>();
            CargarProgramasEducativos();
        }
        public async void CargarProgramasEducativos()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                ProgramaEducativo[] programasEducativosService = await conexionServicios.ObtenerProgramasAsync();
                foreach (ProgramaEducativo item in programasEducativosService)
                {
                    programasEducativosBD.Add(item);
                }
            }
        }
        public async Task<int> TipoAcademico(int IdPersonal)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                int tipoAcademico = await conexionServicios.TipoAcademicoAsync(IdPersonal);
                return tipoAcademico;
            }
            return 0;
        }

    }
}
