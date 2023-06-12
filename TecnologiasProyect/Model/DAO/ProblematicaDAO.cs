using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class ProblematicaDAO
    {
        public static Boolean GuardarProblematica(Problematica problematicaNuevo)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var problematica = new Problematica()
                {
                    titulo = problematicaNuevo.titulo,
                    descripcion = problematicaNuevo.descripcion,
                    noIncidencias = problematicaNuevo.noIncidencias,
                    IdReporte = problematicaNuevo.IdReporte,
                    IdTipo = problematicaNuevo.IdTipo,
                    IdExperienciaEducativa = problematicaNuevo.IdTipo
                };
                conexionBD.Problematica.InsertOnSubmit(problematica);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<Problematica> ObtenerProblematicas()
        {
            List<Problematica> listas = new List<Problematica>();
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            IQueryable<Problematica> problematicas = from problematica in conexionBD.Problematica
                                                     select problematica;
            foreach (var prob in problematicas)
            {
                listas.Add(new Problematica
                {
                    IdProblematica = prob.IdProblematica,
                    titulo = prob.titulo,
                    descripcion = prob.descripcion,
                    noIncidencias = prob.noIncidencias,
                    IdReporte = prob.IdReporte,
                    IdTipo = prob.IdTipo,
                    IdExperienciaEducativa = prob.IdExperienciaEducativa
                });
            }
            return listas;
        }
        public static List<Problematica> ObtenerPRoblematicasId(int idReporte)
        {
            List<Problematica> listas = new List<Problematica>();
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            IQueryable<Problematica> problematicas = from problematica in conexionBD.Problematica
                                                     where problematica.IdReporte == idReporte
                                                     select problematica;
            foreach (var prob in problematicas)
            {
                listas.Add(new Problematica
                {
                    IdProblematica = prob.IdProblematica,
                    titulo = prob.titulo,
                    descripcion = prob.descripcion,
                    noIncidencias = prob.noIncidencias,
                    IdReporte = prob.IdReporte,
                    IdTipo = prob.IdTipo,
                    IdExperienciaEducativa = prob.IdExperienciaEducativa
                });
            }
            return listas;
        }
        public static Boolean ModificarProblematica(Problematica problematicaM)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var problematicaTemp = conexionBD.Problematica.FirstOrDefault(p => p.IdProblematica == problematicaM.IdProblematica);
                if (problematicaTemp != null)
                {
                    problematicaTemp.descripcion = problematicaM.descripcion;
                    problematicaTemp.noIncidencias = problematicaM.noIncidencias;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                    return false;
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