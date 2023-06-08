using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
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
        //guardar
        public Boolean GuardarAlumno(Estudiante estudiante)
        {
            Boolean guardarEstudiante = EstudianteDAO.GuardarEstudiante(estudiante);
            return guardarEstudiante;
        }
        public Boolean GuardarComentarioGeneral(ComentarioGeneral comentarioGeneral)
        {
            Boolean guardarComentarioGeneral = ComentarioGeneralDAO.GuardarComentarioGeneral(comentarioGeneral);
            return guardarComentarioGeneral;
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

        //modificar
        public Boolean ModificarProblematica(Problematica problematica)
        {
            Boolean modificarProblematica = ProblematicaDAO.ModificarProblematica(problematica);
            return modificarProblematica;
        }

        //obtener
        //public List<Academico> ObtenerAcademicos(int programaEducativo)
        //{
           // List<Academico> listaAcademicos = AcademicoDAO.ObtenerAcademicos(programaEducativo);
            //return listaAcademicos;
        //}
        public List<Materia> ObtenerMateria()
        {
            List<Materia> listaMaterias = MateriaDAO.ObtenerMaterias();
            
            return listaMaterias;
        }

        public List<Estudiante> ObtenerEstudiantes(int programaEducativo)
        {
            List<Estudiante> listaEstudiantes = EstudianteDAO.ObtenerEstudiantes(programaEducativo);
            return listaEstudiantes;
        }

        public List<Problematica> ObtenerProblematicas()
        {
            List<Problematica> listaProblematicas = ProblematicaDAO.ObtenerProblematicas();
            return listaProblematicas;
        }

        public Boolean registrarAcademico(Academico academico)
        {
            throw new NotImplementedException();
        }
        public List<Estudiante> ObtenerEstudiantesTutor(int idTutor)
        {
            List<Estudiante> listaEstudiantes = EstudianteDAO.ObtenerEstudiantesTutor(idTutor);
            return listaEstudiantes;
        }

        public List<ProgramaEducativo> ObtenerProgramas()
        {
            List<ProgramaEducativo> listaProgramas = ProgramaEducativoDAO.ObtenerProgramasEducativos();
            return listaProgramas;
        }

        public Mensaje IniciarSesison(string numPersonal, string password)
        {
            return AcademicoDAO.iniciarSesion(numPersonal, password);
        }
    }
}
