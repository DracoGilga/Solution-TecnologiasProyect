using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class SolucionDAO
    {
        public static List<Solucion> ObtenerSolucion(int IdProblematica)
        {
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            List<Solucion> solucion = new List<Solucion>();
            IQueryable<Solucion> soluciones = from sol in conexionBD.Solucion
                                              where sol.IdProblematica == IdProblematica
                                              select sol;
            foreach (Solucion solu in soluciones)
            {
                solucion.Add(new Solucion
                {
                    IdSolucion = solu.IdSolucion,
                    descripcion = solu.descripcion,
                    IdProblematica = solu.IdProblematica
                });
            }
            return solucion;
        }
        public static Boolean GuardarSolucion(Solucion solucion)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var solu = new Solucion()
                {
                    titulo = solucion.titulo,
                    descripcion = solucion.descripcion,
                    IdProblematica = solucion.IdProblematica,
                    IdProgramaEducativo = solucion.IdProgramaEducativo
                };
                conexionBD.Solucion.InsertOnSubmit(solu);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public static Boolean ModificarSolucion(Solucion solucion)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                Solucion solu = conexionBD.Solucion.FirstOrDefault(s => s.IdSolucion == solucion.IdSolucion);
                solu.titulo = solucion.titulo;
                solu.descripcion = solucion.descripcion;
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception)
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