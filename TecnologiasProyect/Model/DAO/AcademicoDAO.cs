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
                    password = academicoNuevo.password
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
        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}