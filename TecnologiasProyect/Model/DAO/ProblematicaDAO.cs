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
                    descripcion = problematicaNuevo.titulo,
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
                }
                               );
            }
            return listas;
        }
        public static Boolean ModificarProblematica(Problematica problematica)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var problematicaTemp = (from prob in conexionBD.Problematica
                                        where prob.IdProblematica == problematica.IdProblematica
                                        select prob).Single();
                problematicaTemp.titulo = problematica.titulo;
                problematicaTemp.descripcion = problematica.descripcion;
                problematicaTemp.noIncidencias = problematica.noIncidencias;
                problematicaTemp.IdReporte = problematica.IdReporte;
                problematicaTemp.IdTipo = problematica.IdTipo;
                problematicaTemp.IdExperienciaEducativa = problematica.IdExperienciaEducativa;
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