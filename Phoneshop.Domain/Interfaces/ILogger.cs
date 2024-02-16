namespace Phoneshop.Domain.Interfaces
{
    public interface ILogger
    {
        void Information(string message);
        void Error(string message);
        void Warning(string message);
    }
}