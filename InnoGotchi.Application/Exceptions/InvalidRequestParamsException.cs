namespace InnoGotchi.Application.Exceptions
{
    public class InvalidRequestParamsException : ApplicationException
    {
        internal InvalidRequestParamsException(string businessMessage) 
            : base(businessMessage)
        {
        }

        internal InvalidRequestParamsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
