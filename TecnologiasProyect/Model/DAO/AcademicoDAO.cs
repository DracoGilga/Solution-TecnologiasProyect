using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class AcademicoDAO
    {
        public static Boolean RegistrarTutorAcademico(Academico academicoNuevo)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var tutor = new Academico()
                {
                    noPersonal = academicoNuevo.noPersonal,
                    nombre = academicoNuevo.nombre,
                    apellidoPaterno = academicoNuevo.apellidoPaterno,
                    apellidoMaterno = academicoNuevo.apellidoMaterno,
                    correoPersonal = academicoNuevo.correoPersonal,
                    correoInstitucional = academicoNuevo.correoInstitucional,
                    password = academicoNuevo.password,
                    rol = academicoNuevo.rol
                };
                conexionBD.Academico.InsertOnSubmit(tutor);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Academico> ObtenerAcademicos(int programaEducativo)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();

            IQueryable<Academico> academicosBD = from academicoQuery in conexionBD.Academico
                                                 join programaQuery in conexionBD.ProgramaEducativoTutor on
                                                 academicoQuery.IdAcademico equals programaQuery.IdAcademico
                                                 join programaEducativoQuery in conexionBD.ProgramaEducativo on
                                                 programaQuery.IdProgramaEducativo equals programaEducativoQuery.IdProgramaEducativo
                                                 where programaEducativoQuery.IdProgramaEducativo == programaEducativo
                                                 select academicoQuery;
            return academicosBD.ToList();
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}