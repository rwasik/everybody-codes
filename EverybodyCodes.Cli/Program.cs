// See https://aka.ms/new-console-template for more information
using Autofac;
using EverybodyCodes.Cli.Services;
using EverybodyCodes.Cli.Utils;
using EverybodyCodes.DataAccess.DataContext;
using EverybodyCodes.DataAccess.Repositories;

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterType<CSVContext>();
containerBuilder.RegisterType<CameraRepository>().As<ICameraRepository>();
containerBuilder.RegisterType<SearchService>().As<ISearchService>();

var container = containerBuilder.Build();

try
{
    var argsDto = ArgsParser.Parse(args);

    var searchService = container.Resolve<ISearchService>();
    var cameras = searchService.FindByName(argsDto.Name);

    foreach (var c in cameras)
    {
        Console.WriteLine($"{c.Id} | {c.Name} | {c.Latitude} | {c.Longitude}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}