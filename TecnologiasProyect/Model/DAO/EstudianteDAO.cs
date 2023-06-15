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
                    IdProgramaEducativo = estudianteNuevo.IdProgramaEducativo,
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
        public static List<Estudiante> ObtenerEstudiantesTutor(int idTutor)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            IQueryable<Estudiante> estudiantesBD = from estudianteQuery in conexionBD.Estudiante
                                                   join tutorQuery in conexionBD.Academico
                                                   on estudianteQuery.IdTutor equals tutorQuery.IdAcademico
                                                   where tutorQuery.IdAcademico == idTutor
                                                   select estudianteQuery;
            foreach (Estudiante estudiante in estudiantesBD)
            {
                estudiantes.Add(new Estudiante
                {
                    IdEstudiante = estudiante.IdEstudiante,
                    matricula = estudiante.matricula,
                    nombre = estudiante.nombre,
                    apellidoPaterno = estudiante.apellidoPaterno,
                    apellidoMaterno = estudiante.apellidoMaterno,
                    correoPersonal = estudiante.correoPersonal,
                    correoInstitucional = estudiante.correoInstitucional,
                    IdProgramaEducativo = estudiante.IdProgramaEducativo,
                    IdTutor = estudiante.IdTutor
                });
            }
            return estudiantes;
        }
        public static List<Estudiante> ObtenerEstudiantesSinTutor()
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            IQueryable<Estudiante> estudiantesBD = from estudianteQuery in conexionBD.Estudiante
                                                   where estudianteQuery.IdTutor == null
                                                   select estudianteQuery;
            foreach (Estudiante estudiante in estudiantesBD)
            {
                estudiantes.Add(new Estudiante
                {
                    IdEstudiante = estudiante.IdEstudiante,
                    matricula = estudiante.matricula,
                    nombre = estudiante.nombre,
                    apellidoPaterno = estudiante.apellidoPaterno,
                    apellidoMaterno = estudiante.apellidoMaterno,
                    correoPersonal = estudiante.correoPersonal,
                    correoInstitucional = estudiante.correoInstitucional,
                    IdProgramaEducativo = estudiante.IdProgramaEducativo,
                    IdTutor = estudiante.IdTutor
                });
            }
            return estudiantes;
        }

        public Boolean ModificarEstudiante(int idEstudiante, int idTutor)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                Estudiante estudiante = conexionBD.Estudiante.FirstOrDefault(estudianteQuery => estudianteQuery.IdEstudiante == idEstudiante);
                estudiante.IdTutor = idTutor;
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}