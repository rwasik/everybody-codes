using EverybodyCodes.Cli.Dtos;

namespace EverybodyCodes.Cli.Utils;

public static class ArgsParser
{
    private static readonly IDictionary<string, Action<string, ArgsDto>> _argsStrategy;

    static ArgsParser()
    {
        _argsStrategy = new Dictionary<string, Action<string, ArgsDto>>
        {
            { "--name", (arg, dto) => dto.Name = arg },
            { "-n", (arg, dto) => dto.Name = arg }
        };
    }

    public static ArgsDto Parse(string[] args)
    {
        if (args.Length == 0)
            throw new Exception("Please specify '[-n]--name' argument");

        var dto = new ArgsDto();

        for (var i = 0; i < args.Length; i += 2)
        {
            var argument = args[i];

            if (!_argsStrategy.ContainsKey(argument))
                throw new NotImplementedException($"Not supported argument '{argument}'");

            if (args.Length <= i + 1)
                throw new IndexOutOfRangeException($"Please specify argument value after '{argument}'");

            _argsStrategy[argument].Invoke(args[i + 1], dto);
        }

        return dto;
    }
}