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

        public static List<ReporteTutoria> ObtenerReporteTutoriaPorTutor(int idTutor)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();

            IQueryable<ReporteTutoria> reportesBD = from reportesQuery in conexionBD.ReporteTutoria
                                                    join tutorQuery in conexionBD.Academico
                                                    on reportesQuery.IdTutor equals tutorQuery.IdAcademico
                                                    where reportesQuery.IdTutor == idTutor
                                                    select reportesQuery;

            return reportesBD.ToList();
        }

        public static List<ReporteTutoria> ObtenerConcentradoAsistencias(int idPeriodoEscolar)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();

            IQueryable<ReporteTutoria> asistenciasBD = from asistenciasQuery in conexionBD.ReporteTutoria
                                                    join tutoriaQuery in conexionBD.Tutoria
                                                    on asistenciasQuery.IdTutoria equals tutoriaQuery.IdTutoria
                                                    join periodoQuery in conexionBD.PeriodoEscolar
                                                    on tutoriaQuery.IdPeriodoEscolar equals periodoQuery.IdPeriodoEscolar
                                                    where tutoriaQuery.IdPeriodoEscolar == idPeriodoEscolar
                                                    select asistenciasQuery;

            return asistenciasBD.ToList();
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}