using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class MateriaViewModel
    {
        ObservableCollection<Materia> materiasBD { get; set; }

        public MateriaViewModel()
        {

        }
        public async Task<Materia> CargarMateriaId(int IdMateria)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Materia materia = await conexionServicios.ObtenerMateriaFiltradaAsync(IdMateria);
                return materia;
            }
            return null;
        }
    }
}
