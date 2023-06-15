using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class ProgramaEducativoDAO
    {
        public static List<ProgramaEducativo> ObtenerProgramasEducativos()
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<ProgramaEducativo> programasEducativos = new List<ProgramaEducativo>();
            IQueryable<ProgramaEducativo> programasEducativosBD = from programaEducativoQuery in conexionBD.ProgramaEducativo
                                                                   select programaEducativoQuery;
            foreach (ProgramaEducativo programaEducativo in programasEducativosBD)
            {
                programasEducativos.Add(new ProgramaEducativo
                {
                    IdProgramaEducativo = programaEducativo.IdProgramaEducativo,
                    nombre = programaEducativo.nombre,
                    IdCoordinador = programaEducativo.IdCoordinador,
                    IdAcademicoJefe= programaEducativo.IdAcademicoJefe
                });
            }
            return programasEducativos;
        }

        public static int TipoAcademico(int IdPersonal) { 
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            IQueryable<ProgramaEducativo> ProgramaEducativoBD = from academicoQuery in conexionBD.ProgramaEducativo
                                                where academicoQuery.IdAcademicoJefe == IdPersonal
                                                select academicoQuery;
            if (ProgramaEducativoBD.Count() > 0)
                return 1;
            else
            {
                IQueryable<ProgramaEducativo> ProgramaEducativoBD2 = from academicoQuery in conexionBD.ProgramaEducativo
                                                             where academicoQuery.IdCoordinador == IdPersonal
                                                             select academicoQuery;
                if (ProgramaEducativoBD2.Count() > 0)
                    return 2;
                else
                    return 3;
            }
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}