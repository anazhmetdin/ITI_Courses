using StructureMap;

namespace Case
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new DataExporterFactory();

            var exporter1 = factory.GetDBDataExporter();
            var exporter2 = factory.GetFileDataExporter();

            exporter1.ExportDataFromFile();
            exporter2.ExportDataFromFile();
        }
    }
}