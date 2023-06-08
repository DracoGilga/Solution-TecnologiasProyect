using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class TipoProblematicaDAO
    {
        public static List<TipoProblematica> ObtenerTipoProblematicas()
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<TipoProblematica> tipoProblematicas = new List<TipoProblematica>();
            IQueryable<TipoProblematica> tipoProblematicasBD = from tipoProblematicaQuery in conexionBD.TipoProblematica
                                                                select tipoProblematicaQuery;
            foreach (TipoProblematica tipoProblematica in tipoProblematicasBD)
            {
                tipoProblematicas.Add(new TipoProblematica
                {
                    IdTipo = tipoProblematica.IdTipo,
                    tipo = tipoProblematica.tipo
                });
            }
            return tipoProblematicas;
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}