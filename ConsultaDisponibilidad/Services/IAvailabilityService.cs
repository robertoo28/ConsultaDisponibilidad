namespace ConsultaDisponibilidad.Services;
using System.ServiceModel;
using System.Xml.Linq;

[ServiceContract]
public interface IAvailabilityService
{
    [OperationContract]
    XElement GetAvailability(DateTime startDate, DateTime endDate, string roomType);
    
    [OperationContract]
    XElement CheckAvailability(DateTime startDate, DateTime endDate, string roomType); // Add this line
}
