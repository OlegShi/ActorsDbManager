using System.Net;

namespace ActorsManagerService.Handlers
{
    public interface IErrorHandler
    {
        HttpStatusCode GetHttpStatusCode(Exception ex);       
    }
}
