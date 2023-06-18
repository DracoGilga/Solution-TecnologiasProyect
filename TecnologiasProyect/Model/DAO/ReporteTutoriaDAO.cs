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
                    IdProgramaEducativo = reporteTutoriaNuevo.IdProgramaEducativo,
                    IdTutoria = reporteTutoriaNuevo.IdTutoria,
                    IdTutor = reporteTutoriaNuevo.IdTutor,
                    IdEstudiante = reporteTutoriaNuevo.IdEstudiante,
                    asistencia = reporteTutoriaNuevo.asistencia,
                    riesgo = reporteTutoriaNuevo.riesgo
                };
                conexionBD.ReporteTutoria.InsertOnSubmit(reporteTutoria);
                conexionBD.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public static List<ReporteTutoria> ObtenerReporteTutoria(ReporteTutoria reporteTutoria)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                List<ReporteTutoria> reporteTutoriaLista = new List<ReporteTutoria>();
                IQueryable<ReporteTutoria> reporteTutoriaBD = from reporteTutoriaQuery in conexionBD.ReporteTutoria
                                                              where reporteTutoriaQuery.IdTutoria == reporteTutoria.IdTutoria
                                                              && reporteTutoriaQuery.IdTutor == reporteTutoria.IdTutor
                                                              select reporteTutoriaQuery;
                if(reporteTutoriaBD != null)
                {
                    foreach (ReporteTutoria reporteTutoriaQuery in reporteTutoriaBD)
                    {
                        reporteTutoriaLista.Add(new ReporteTutoria
                        {
                            IdReporte = reporteTutoriaQuery.IdReporte,
                            IdProgramaEducativo = reporteTutoriaQuery.IdProgramaEducativo,
                            IdTutoria = reporteTutoriaQuery.IdTutoria,
                            IdTutor = reporteTutoriaQuery.IdTutor,
                            IdEstudiante = reporteTutoriaQuery.IdEstudiante,
                            asistencia = reporteTutoriaQuery.asistencia,
                            riesgo = reporteTutoriaQuery.riesgo
                        });
                    }
                    return reporteTutoriaLista;
                }
                else
                {
                    return null;
                }    
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}