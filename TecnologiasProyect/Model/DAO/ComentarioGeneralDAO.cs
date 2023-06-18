using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class ComentarioGeneralDAO
    {
        public static Boolean GuardarComentarioGeneral(ComentarioGeneral comentarioGeneralNuevo)
        {
            try
            {
                DataClassesTutoriaDataContext conexionBD = GetConexion();
                var comentarioGeneral = new ComentarioGeneral()
                {
                    IdTutoria= comentarioGeneralNuevo.IdTutoria,
                    IdTutor = comentarioGeneralNuevo.IdTutor,
                    descripcion = comentarioGeneralNuevo.descripcion
                };
                conexionBD.ComentarioGeneral.InsertOnSubmit(comentarioGeneral);
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