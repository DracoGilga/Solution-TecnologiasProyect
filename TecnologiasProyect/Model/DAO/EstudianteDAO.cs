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

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}