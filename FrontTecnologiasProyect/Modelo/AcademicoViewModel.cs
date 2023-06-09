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

        public AcademicoViewModel(Academico academico)
        {
            academicoBD = new ObservableCollection<Academico>();
            GuardarTutorAcademico(academico);
        }
        public async void GuardarTutorAcademico(Academico academico)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Boolean resultado = await conexionServicios.RegistrarAcademicoAsync(academico);
            }
        }
    }
}
