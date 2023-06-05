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

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}