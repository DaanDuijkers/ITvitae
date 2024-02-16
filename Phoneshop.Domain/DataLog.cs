using System;
using System.Diagnostics.CodeAnalysis;

namespace Phoneshop.Domain
{
    [ExcludeFromCodeCoverage]
    public class DataLog
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public DataLog() { }

        public DataLog(string message, string logType)
        {
            this.Type = logType;
            this.Message = message;
            this.Date = DateTime.Now;
        }
    }
}