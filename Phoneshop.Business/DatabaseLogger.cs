using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business
{
    public class DatabaseLogger : ILogger
    {
        private readonly DataContext dataContext;

        public DatabaseLogger(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Error(string message)
        {
            this.dataContext.Set<DataLog>().Add(new DataLog(message, LogType.Error.ToString()));
            this.dataContext.SaveChanges();
        }

        public void Information(string message)
        {
            this.dataContext.Set<DataLog>().Add(new DataLog(message, LogType.Information.ToString()));
            this.dataContext.SaveChanges();
        }

        public void Warning(string message)
        {
            this.dataContext.Set<DataLog>().Add(new DataLog(message, LogType.Warning.ToString()));
            this.dataContext.SaveChanges();
        }
    }
}