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
        public Boolean ModificarEstudiante(int idEstudiante, int idTutor)
        {
            Boolean modificarEstudiante = EstudianteDAO.ModificarEstudiante(idEstudiante, idTutor);
            return modificarEstudiante;
        }

        //obtener
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
        public List<TipoProblematica> ObtenerTipoProblematicas()
        {
            List<TipoProblematica> listaTipoProblematicas = TipoProblematicaDAO.ObtenerTipoProblematicas();
            return listaTipoProblematicas;
        }
        public List<Problematica> ObtenerProblematicas(Problematica problematica)
        {
            List<Problematica> listaProblematicas = ProblematicaDAO.ObtenerProblematicas(problematica);
            return listaProblematicas;
        }
        public List<Problematica> MostrarProblematicas()
        {
            List<Problematica> listaProblematicas = ProblematicaDAO.MostrarProblematica();
            return listaProblematicas;
        }
        public Boolean RegistrarAcademico(Academico academico)
        {
            Boolean guardarTutor = AcademicoDAO.RegistrarTutorAcademico(academico);
            return guardarTutor;
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
        public List<ExperienciaEducativa> ObtenerExperienciasEducativas()
        {
            List<ExperienciaEducativa> listaExperienciasEducativas = ExperienciaEducativaDAO.ObtenerExperienciasEducativas();
            return listaExperienciasEducativas;
        }
        public List<Estudiante> ObtenerEstudianteSinTutor()
        {
            List<Estudiante> listaEstudiantes = EstudianteDAO.ObtenerEstudiantesSinTutor();
            return listaEstudiantes;
        }
        public List<Academico> ObtenerAcademico()
        {
            List<Academico> listaAcademico = AcademicoDAO.ObtenerAcademico();
            return listaAcademico;
        }
        public Tutoria ObtenerTutoria(DateTime fecha)
        {
            List<Tutoria> listaTutoria = TutoriaDAO.ObtenerFechaTutoria();
            if(listaTutoria != null)
            {
                foreach(Tutoria tutoria in listaTutoria)
                {
                    if (fecha >= tutoria.fechaSesion && fecha <= tutoria.fechaEntrega)
                    {
                        return tutoria;
                    }
                }
            }
            return null;
            
        }
        public List<ReporteTutoria> ObtenerReporteTutoria(ReporteTutoria reporteTutoria)
        {
            List<ReporteTutoria> reporte = ReporteTutoriaDAO.ObtenerReporteTutoria(reporteTutoria);
            return reporte;
        }


        //login
        public Academico Login(string noPersonal, string contrasena)
        {
            Academico academico = AcademicoDAO.Login(noPersonal, contrasena);
            return academico;
        }
        public int TipoAcademico(int IdPersonal) {             
            int tipoAcademico = ProgramaEducativoDAO.TipoAcademico(IdPersonal);
            return tipoAcademico;
        }
    }
}
