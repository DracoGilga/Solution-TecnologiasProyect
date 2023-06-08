using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrontTecnologiasProyect.Modelo
{
    class EstudianteViewModel
    {
        public ObservableCollection<Estudiante> estudiantesBD { get; set; }
        public EstudianteViewModel(int idTutor)
        {
            estudiantesBD = new ObservableCollection<Estudiante>();
            
            cargarEstudiantes(idTutor);
        }

        private async void cargarEstudiantes(int IdTutor)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Estudiante[] estudinteService = await conexionServicios.ObtenerEstudiantesTutorAsync(IdTutor);
                foreach(Estudiante item in estudinteService)
                {
                    estudiantesBD.Add(item);
                }
            }

        }
        public EstudianteViewModel(Estudiante estudiante)
        {
            estudiantesBD = new ObservableCollection<Estudiante>();
            Console.WriteLine("EntryWrittenEventArgs en EstudianteViewModel");
            GuardarEstudiante(estudiante);
        }
        private async void GuardarEstudiante(Estudiante estudiante)
        {
            var conexionServicios = new Service1Client();
            Console.WriteLine("EntryWrittenEventArgs en guardarEstudiante");
            if (conexionServicios != null)
            {
                bool estudianteService = await conexionServicios.GuardarAlumnoAsync(estudiante);
                Console.WriteLine(estudianteService);
            }
        }
    }
}
