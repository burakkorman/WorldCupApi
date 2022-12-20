namespace WorldCupApi.Data.Errors;

public class WorldCupException : Exception
{
    private string ErrorMessage { get; }
    
    public WorldCupException(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}