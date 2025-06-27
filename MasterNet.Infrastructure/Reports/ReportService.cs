using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;

namespace MasterNet.Infrastructure.Reports;

public class ReportService<T> : IReportService<T> where T : BaseEntity
{
    public Task<MemoryStream> GetCsvReport(List<T> records)
    {
        using var memoryStream = new MemoryStream();
        using var textWriter = new StreamWriter(memoryStream);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        using var csvWriter = new CsvWriter(textWriter, config);

        csvWriter.WriteRecords(records);
        textWriter.Flush();
        memoryStream.Seek(0, SeekOrigin.Begin);

        return Task.FromResult(memoryStream);
    }
}