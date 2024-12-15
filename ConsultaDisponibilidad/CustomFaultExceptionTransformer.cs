using System.Xml;

namespace ConsultaDisponibilidad;
using SoapCore.Extensibility;
using System.ServiceModel.Channels;

public class CustomFaultExceptionTransformer : IFaultExceptionTransformer
{
    public Message ProvideFault(Exception exception, MessageVersion messageVersion)
    {
        // Implement your custom fault transformation logic here
        return Message.CreateMessage(messageVersion, "", exception.Message);
    }

    public Message ProvideFault(Exception exception, MessageVersion messageVersion, Message requestMessage, XmlNamespaceManager xmlNamespaceManager)
    {
        // Implement your custom fault transformation logic here
        return Message.CreateMessage(messageVersion, "", exception.Message);
    }
}