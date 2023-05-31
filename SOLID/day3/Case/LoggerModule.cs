using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case
{
    public class FileLogger : ILogger
    {
        public void LogMessage(string aStackTrace)
        {
            //code to log stack trace into a file.  
            Console.WriteLine("writing in a file");
        }
    }
    public class DBLogger : ILogger
    {
        public void LogMessage(string aStackTrace)
        {
            //code to log stack trace into DB.  
            Console.WriteLine("writing in DB");
        }
    }

    public interface ILogger
    {
        void LogMessage(string aStackTrace);
    }

    public class ExceptionLogger
    {
        public void LogEx(Exception aException, ILogger logger)
        {
            logger.LogMessage(GetUserReadableMessage(aException));
        }

        private string GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user readable format.  
            //........
            return strMessage;
        }
    }

    // class to export data from many files to a database.
    public class DataExporter
    {
        private readonly ILogger logger;
        private readonly ExceptionLogger exceptionLogger;

        public DataExporter(ILogger logger, ExceptionLogger exceptionLogger)
        {
            this.logger = logger;
            this.exceptionLogger = exceptionLogger;
        }

        public void ExportDataFromFile()
        {
            try
            {
                //code to export data from files to database.
                throw new Exception();
            }
            catch (Exception ex)
            {
                exceptionLogger.LogEx(ex, logger);
            }
        }
    }

    // DataExporter factory to create instance of DataExporter
    public class DataExporterFactory
    {
        private readonly Container container;

        public DataExporterFactory()
        {
            // Container Creation
            container = new Container(builder =>
            {
                // Registration
                builder.For<ExceptionLogger>().Use<ExceptionLogger>();
                builder.For<DataExporter>().Use<DataExporter>();
                builder.For<ILogger>().Use<FileLogger>().Named("file");
                builder.For<ILogger>().Use<DBLogger>().Named("db");
            });
        }

        public DataExporter GetFileDataExporter()
        {
            var fileLogger = container.GetInstance<ILogger>("file");
            var exLogger = container.GetInstance<ExceptionLogger>();

            var exporter = container
                .With(fileLogger)
                .With(exLogger)
                .GetInstance<DataExporter>();

            return exporter;
        }

        public DataExporter GetDBDataExporter()
        {
            var dbLogger = container.GetInstance<ILogger>("db");
            var exLogger = container.GetInstance<ExceptionLogger>();

            var exporter = container
                .With(dbLogger)
                .With(exLogger)
                .GetInstance<DataExporter>();

            return exporter;
        }
    }
}
