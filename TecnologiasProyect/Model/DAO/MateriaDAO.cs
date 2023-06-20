using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnologiasProyect.Model.DAO
{
    public class MateriaDAO
    {
        public static List<Materia> ObtenerMaterias()
        {
            List<Materia> listas = new List<Materia>();
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            IQueryable<Materia> materias = from materia in conexionBD.Materia
                                           select materia;
            foreach (var mat in materias)
            {
                listas.Add(new Materia
                { 
                    IdMateria = mat.IdMateria, 
                    nombre = mat.nombre, 
                    creditos = mat.creditos 
                });
            }
            return listas;
        }
        public static List<Materia> ObtenerMateriaFiltrada(int idMateria)
        {
            List<Materia> listas = new List<Materia>();
            DataClassesTutoriaDataContext conexionBD = GetConexion();
            IQueryable<Materia> materias = from materia in conexionBD.Materia
                                           where materia.IdMateria == idMateria
                                           select materia;
            foreach (var mat in materias)
            {
                listas.Add(new Materia
                { 
                    IdMateria = mat.IdMateria, 
                    nombre = mat.nombre,    
                    creditos = mat.creditos 
                });
            }
            return listas;
        }

        public static DataClassesTutoriaDataContext GetConexion()
        {
            return new DataClassesTutoriaDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TecnologiasConnectionString"].ConnectionString);
        }
    }
}