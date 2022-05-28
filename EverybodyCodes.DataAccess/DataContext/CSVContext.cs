using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using EverybodyCodes.DataAccess.Entities;

namespace EverybodyCodes.DataAccess.DataContext;

public class CSVContext
{
    private IEnumerable<Camera>? _cameras;

    public IEnumerable<Camera> Cameras => _cameras ?? (_cameras = Load());

    private IEnumerable<Camera> Load()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "data/cameras-defb.csv");

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            MissingFieldFound = null,
            Delimiter = ";"
        };

        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, config))
        {
            var records = new List<Camera>();
            var recordId = 0;

            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = new Camera
                {
                    Id = ++recordId,
                    Name = csv.GetField("Camera"),
                    Latitude = csv.GetField<double>("Latitude"),
                    Longitude = csv.GetField<double>("Longitude")
                };
                records.Add(record);
            }

            return records;
        }
    }
}

