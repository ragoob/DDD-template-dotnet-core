namespace On.Core
{
    public interface ILoggingService
    {
        void LogInformation(string message,params object[] parameters);
      
    }
}
