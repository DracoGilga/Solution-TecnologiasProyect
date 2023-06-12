using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TecnologiasProyect.Model;

namespace TecnologiasProyect
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Mensaje IniciarSesion(string numPersonal, string password);

        //Insertaciones
        [OperationContract]
        Boolean GuardarAlumno(Estudiante estudiante);

        [OperationContract]
        Boolean GuardarReporteTutoria(ReporteTutoria reporteTutoria);

        [OperationContract]
        Boolean GuardarProblematica(Problematica problematica);

        [OperationContract]
        Boolean GuardarComentarioGeneral(ComentarioGeneral comentarioGeneral);

        [OperationContract]
        Boolean RegistrarAcademico(Academico academico);

        //Modificaciones
        [OperationContract]
        Boolean ModificarProblematica(Problematica problematica);

        //consultas
        [OperationContract]
        List<Problematica> ObtenerProblematicas();

        [OperationContract]
        List<Estudiante> ObtenerEstudiantes(int programaEducativo);

        [OperationContract]
        //List<Academico> ObtenerAcademicos(int programaEducativo);
        List<Materia> ObtenerMateria();
        [OperationContract]
        List<Estudiante> ObtenerEstudiantesTutor(int idTutor);
        [OperationContract]
        List<ProgramaEducativo> ObtenerProgramas();
        [OperationContract]
        List<TipoProblematica> ObtenerTipoProblematicas();
        [OperationContract]
        List<ExperienciaEducativa> ObtenerExperienciasEducativas();
        [OperationContract]
        List<Problematica> ObtenerProblemticasId(int idProblematica);
        
    }
}
