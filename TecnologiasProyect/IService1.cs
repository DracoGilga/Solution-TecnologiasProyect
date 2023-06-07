using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TecnologiasProyect.Model;

namespace TecnologiasProyect
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        //Insertaciones
        [OperationContract]
        Boolean GuardarAlumno(Estudiante estudiante);
        [OperationContract]
        Boolean GuardarReporteTutoria(ReporteTutoria reporteTutoria);
        [OperationContract]
        Boolean GuardarProblematica(Problematica problematica);
        [OperationContract]
        Boolean GuardarComentarioGeneral(ComentarioGeneral comentarioGeneral);
  
    }
}
