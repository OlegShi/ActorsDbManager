using System.Net;

namespace ActorsManagerService.Handlers
{
    public class ErrorHandler : IErrorHandler
    {

        public HttpStatusCode GetHttpStatusCode(Exception ex)
        {
            return ex switch
            {
                ArgumentNullException _ => HttpStatusCode.BadRequest,
                ArgumentException _ => HttpStatusCode.NotFound,
                InvalidOperationException _ => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError,
            };
        }

    }
}
