using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class ExperienciaEducativaDAO
    {
        public static List<ExperienciaEducativa> ObtenerExperienciasEducativas()
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<ExperienciaEducativa> experienciasEducativas = new List<ExperienciaEducativa>();
            IQueryable<ExperienciaEducativa> experienciasEducativasBD = from experienciaEducativaQuery in conexionBD.ExperienciaEducativa
                                                                        select experienciaEducativaQuery;
            foreach (ExperienciaEducativa experienciaEducativa in experienciasEducativasBD)
            {
                experienciasEducativas.Add(new ExperienciaEducativa
                {
                    IdExperienciaEducativa = experienciaEducativa.IdExperienciaEducativa,
                    nrc = experienciaEducativa.nrc,
                    bloque = experienciaEducativa.bloque,
                    IdPeriodoEscolar = experienciaEducativa.IdPeriodoEscolar,
                    IdMateria = experienciaEducativa.IdMateria,
                    IdProgramaEducativo = experienciaEducativa.IdProgramaEducativo,
                    IdAcademico = experienciaEducativa.IdAcademico
                });
            }
            return experienciasEducativas;
        }


        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}