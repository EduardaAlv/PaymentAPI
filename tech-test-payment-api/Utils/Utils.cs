using PaymentAPI.Enumeradores;

namespace PaymentAPI.Utils;

public static class Utils
{
    public static string ObterStringConexao()
    {
        var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
        IConfiguration _configuration = builder.Build();
        string conexaoPadrao = _configuration.GetConnectionString("ConexaoPadrao");

        return conexaoPadrao;
    }

    public static EnumStatusVenda ToEnum<TEnum>(int value)
    {
        if (typeof(EnumStatusVenda).IsEnumDefined(value))
            return (EnumStatusVenda)(object)value;

        return default;
    }
}

