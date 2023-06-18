using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class TutoriaDAO
    {
        public static List<Tutoria> ObtenerFechaTutoria()
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                IQueryable<Tutoria> tutoriasBD = from tutoriaQuery in conexionBD.Tutoria
                                                 select tutoriaQuery;
                List<Tutoria> tutorias = new List<Tutoria>();
                foreach(Tutoria tutoria in tutoriasBD)
                {
                    tutorias.Add(new Tutoria
                    {
                        IdTutoria = tutoria.IdTutoria,
                        fechaSesion = tutoria.fechaSesion,
                        fechaEntrega = tutoria.fechaEntrega
                    });
                }
                return tutorias;
            }
            catch (Exception)
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