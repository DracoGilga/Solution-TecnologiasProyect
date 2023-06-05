using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TecnologiasProyect.Model;
using TecnologiasProyect.Model.DAO;

namespace TecnologiasProyect
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Boolean GuardarAlumno(Estudiante estudiante)
        {
            Boolean guardarEstudiante = EstudianteDAO.GuardarEstudiante(estudiante);
            return guardarEstudiante;
        }
        public Boolean GuardarProblematica(Problematica problematica)
        {
            Boolean guardarProblematica = ProblematicaDAO.GuardarProblematica(problematica);
            return guardarProblematica;
        }
        public Boolean GuardarReporteTutoria(ReporteTutoria reporteTutoria)
        {
            Boolean guardarReporteTutoria = ReporteTutoriaDAO.GuardarReporteTuroria(reporteTutoria);
            return guardarReporteTutoria;
        }
    }
}
