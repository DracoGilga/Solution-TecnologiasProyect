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
        [OperationContract]
        Boolean ModificarEstudiante(int idEstudiante, int idTutor);

        //consultas
        [OperationContract]
        List<Problematica> ObtenerProblematicas(Problematica problematica);

        [OperationContract]
        List<Estudiante> ObtenerEstudiantes(int programaEducativo);

        [OperationContract]
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
        List<Estudiante> ObtenerEstudianteSinTutor();
        [OperationContract]
        List<Academico> ObtenerAcademico();
        [OperationContract]
        Tutoria ObtenerTutoria(DateTime fecha);
        [OperationContract]
        List<ReporteTutoria> ObtenerReporteTutoria(ReporteTutoria reporteTutoria);


        //login
        [OperationContract]
        Academico Login(string noPersonal, string contrasena);
        [OperationContract]
        int TipoAcademico(int IdPersonal);
    }
}
