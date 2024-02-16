using Microsoft.Extensions.Configuration;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.IO;

namespace Phoneshop.Business
{
    public class FileLogger : ILogger
    {
        private readonly StreamWriter streamWriter;

        public FileLogger(IConfiguration configuration)
        {
            var filePath = configuration.GetValue<string>("ConnectionString:filepath");
            this.streamWriter = new StreamWriter(filePath);
        }

        public FileLogger(StreamWriter streamWriter)
        {
            this.streamWriter = streamWriter;
        }

        public void Error(string message)
        {
            this.AddLog(message, LogType.Error);
        }

        public void Information(string message)
        {
            this.AddLog(message, LogType.Information);
        }

        public void Warning(string message)
        {
            this.AddLog(message, LogType.Warning);
        }

        public void AddLog(string message, LogType logType)
        {
            this.streamWriter.WriteLine($"{logType}: {message} - ({DateTime.Now})");
            this.streamWriter.Flush();
        }
    }
}