using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontTecnologiasProyect.Modelo
{
    internal class LlenarReporteTAViewModel
    {
        public ObservableCollection<LlenarReporteTA> llenarReporteTABD { get; set; }
        public ObservableCollection<ReporteTutoria> llenarReporteTABD2 { get; set; }
        public LlenarReporteTAViewModel()
        {
            
        }
        public LlenarReporteTAViewModel(ReporteTutoria reporteTutoria)
        {
            llenarReporteTABD2 = new ObservableCollection<ReporteTutoria>();
            ObtenerReporteTutoria(reporteTutoria);
        }
        public async Task<bool> GuardarLlenarReporteTA(ReporteTutoria reporteTutoria)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Boolean resultado = await conexionServicios.GuardarReporteTutoriaAsync(reporteTutoria);
                return resultado;
            }
            return false;
        }
        public async void ObtenerReporteTutoria(ReporteTutoria reporteTutoria)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                ReporteTutoria[] resultadoService = await conexionServicios.ObtenerReporteTutoriaAsync(reporteTutoria);
                if(resultadoService != null)
                {
                    foreach(ReporteTutoria ite in resultadoService)
                        llenarReporteTABD2.Add(ite);
                }
            }
        }
        public async Task<Tutoria> FechaTutoria(DateTime fechatutoria)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Tutoria resultado = await conexionServicios.ObtenerTutoriaAsync(fechatutoria);
                return resultado;
            }
            return null;
        }
    }
}
