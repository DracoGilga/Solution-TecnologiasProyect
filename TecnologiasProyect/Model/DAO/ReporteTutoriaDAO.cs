using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class ReporteTutoriaDAO
    {
        public static Boolean GuardarReporteTuroria(ReporteTutoria reporteTutoriaNuevo)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var reporteTutoria = new ReporteTutoria()
                {
                    descripcion = reporteTutoriaNuevo.descripcion,
                    IdProgramaEducativo = reporteTutoriaNuevo.IdProgramaEducativo,
                    IdTutoria = reporteTutoriaNuevo.IdTutoria,
                    IdTutor = reporteTutoriaNuevo.IdTutor,
                    IdEstudiante = reporteTutoriaNuevo.IdEstudiante,
                    asistencia = reporteTutoriaNuevo.asistencia
                };
                conexionBD.ReporteTutoria.InsertOnSubmit(reporteTutoria);
                conexionBD.SubmitChanges();
                return true;
            }
            catch(Exception)
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