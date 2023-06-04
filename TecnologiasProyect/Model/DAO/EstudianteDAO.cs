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
                DataClassTutoriaDataContext conexionBD = GetConexion();
                var estudiante = new Estudiante()
                {
                    matricula = estudianteNuevo.matricula,
                    nombre = estudianteNuevo.nombre,
                    apellidoPaterno = estudianteNuevo.apellidoPaterno,
                    apellidoMaterno = estudianteNuevo.apellidoMaterno,
                    correoPersonal = estudianteNuevo.correoPersonal,
                    correoInstitucional = estudianteNuevo.correoInstitucional,
                    IdTutor = estudianteNuevo.IdTutor,
                    IdProgramaEducativo = estudianteNuevo.IdProgramaEducativo
                };
                conexionBD.Estudiante.InsertOnSubmit(estudiante);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataClassTutoriaDataContext GetConexion()
        {
            return new DataClassTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}