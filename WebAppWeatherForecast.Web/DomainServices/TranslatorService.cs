using WebAppWeatherForecast.Web.DomainServices.Base;

namespace WebAppWeatherForecast.Web.DomainServices;

public class TranslatorService: ITranslatorService
{
    public string ToSimplePolish(string entryString)
    {
        var result = Normalize(entryString.Replace(" ", ""));
        return result;
    }

    //source: https://stackoverflow.com/questions/3560871/removing-diacritics-in-polish
    private static Dictionary<string, string> NormalizeTable()
    {
        return new Dictionary<string, string>()
        {
            {"ą", "a"},
            {"ć", "c"},
            {"ę", "e"},
            {"ł", "l"},
            {"ń", "n"},
            {"ó", "o"},
            {"ś", "s"},
            {"ź", "z"},
            {"ż", "z"},
        };
    }

    public static string Normalize(string original)
    {
        if (original == null) return null;
        var lower = original.ToLower();
        var dictionary = NormalizeTable();
        foreach (var (key, value) in dictionary)
        {
            lower = lower.Replace(key, value);
        }
        return lower;
    }
}