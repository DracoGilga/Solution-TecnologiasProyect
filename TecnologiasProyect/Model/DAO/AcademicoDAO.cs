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
        public static List<Academico> ObtenerAcademico()
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<Academico> academicos = new List<Academico>();
            IQueryable<Academico> academicoBD = from academicoQuery in conexionBD.Academico
                                                select academicoQuery;
            foreach (Academico academico in academicoBD)
            {
                academicos.Add(new Academico
                {
                    IdAcademico = academico.IdAcademico,
                    noPersonal = academico.noPersonal,
                    nombre = academico.nombre,
                    apellidoPaterno = academico.apellidoPaterno,
                    apellidoMaterno = academico.apellidoMaterno,
                    correoPersonal = academico.correoPersonal,
                    correoInstitucional = academico.correoInstitucional,
                    password = academico.password
                });
            }
            return academicos;
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}