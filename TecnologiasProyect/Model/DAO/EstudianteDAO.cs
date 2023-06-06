using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class EstudianteDAO
    {
        public static Boolean GuardarEstudiante(Estudiante estudianteNuevo)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var estudiante = new Estudiante()
                {
                    matricula = estudianteNuevo.matricula,
                    nombre = estudianteNuevo.nombre,
                    apellidoPaterno = estudianteNuevo.apellidoPaterno,
                    apellidoMaterno = estudianteNuevo.apellidoMaterno,
                    correoPersonal = estudianteNuevo.correoPersonal,
                    correoInstitucional = estudianteNuevo.correoInstitucional,
                    IdProgramaEducativo = estudianteNuevo.IdProgramaEducativo
                };
                conexionBD.Estudiante.InsertOnSubmit(estudiante);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Estudiante> ObtenerEstudiantes(int programaEducativo)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();

            IQueryable<Estudiante> estudiantesBD = from estudianteQuery in conexionBD.Estudiante
                                                   join programaEducativoQuery in conexionBD.ProgramaEducativo
                                                   on estudianteQuery.IdProgramaEducativo equals programaEducativoQuery.IdProgramaEducativo
                                                   where programaEducativoQuery.IdProgramaEducativo == programaEducativo
                                                   select estudianteQuery;
            return estudiantesBD.ToList();
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}