using System.Text;

public class NumberToWordConverter
{
    private static string zero = "zero";
    private static string[] units = { "", " jeden ", " dwa ", " trzy ",
        " cztery ", " pięć ", " sześć ", " siedem ", " osiem ", " dziewięć " };
    private static string[] tens = { "", " dziesięć ", " dwadzieścia ",
        " trzydzieści ", " czterdzieści ", " pięćdziesiąt ",
        " sześćdziesiąt ", " siedemdziesiąt ", " osiemdziesiąt ",
        " dziewięćdziesiąt "};
    private static string[] teens = { "dziesięć", " jedenaście ", " dwanaście ",
        " trzynaście ", " czternaście ", " piętnaście ", " szesnaście ",
        " siedemnaście ", " osiemnaście ", " dziewiętnaście "};
    private static string[] hundreds = { "", " sto ", " dwieście ", " trzysta ",
        " czterysta ", " pięćset ", " sześćset ",
        " siedemset ", " osiemset ", " dziewięćset " };
    private static string[,] orders = {{" tysiąc ", " tysiące ", " tysięcy "},
                            {" milion ", " miliony ", " milionów "},
                            {" miliard ", " miliardy ", " miliardów "}};

    private static Dictionary<string, string[]> Currencies = new Dictionary<string, string[]>() {
        //Formy podawane według wzorca: jeden-dwa-pięć, np.
        //(jeden) złoty, (dwa) złote, (pięć) złotych
        { "PLN", new string[]{ "złoty", "złote", "złotych" } },
        { "RUB", new string[]{ "rubel", "ruble", "rubli" } },
        { "USD", new string[]{ "dolar", "dolary", "dolarów" } }
    };

    public static string NumberToWords(int number)
    {
        return NumberToWordsBase(number).Replace("  ", " ").Trim();
    }

    public static string CurrencyToWords(int number, string currencyCode)
    {
        var key = Currencies[currencyCode];
        return key[GetCurrencyFormIndex(number)];
    }

    private static string NumberToWordsBase(int value)
    {
        StringBuilder sb = new StringBuilder();
        //0-999
        if (value == 0)
            return zero;
        int unitsDigit = value % 10;
        int tensDigits = value % 100;
        int hundredsDigit = (value % 1000) / 100;
        if (tensDigits > 10 && tensDigits < 20)
            sb.Insert(0, teens[unitsDigit]);
        else
        {
            sb.Insert(0, units[unitsDigit]);
            sb.Insert(0, tens[tensDigits / 10]);
        }
        sb.Insert(0, hundreds[hundredsDigit]);

        //Pozostałe rzędy wielkości
        value = value / 1000;
        int order = 0;
        while (value > 0)
        {
            unitsDigit = value % 10;
            tensDigits = value % 100;
            hundredsDigit = (value % 1000) / 100;
            bool orderExists = value % 1000 != 0;
            if ((value % 1000) / 10 == 0)
            {
                //nie ma dziesiątek i setek
                if (unitsDigit == 1)
                    sb.Insert(0, orders[order, 0]);
                else if (unitsDigit >= 2 && unitsDigit <= 4)
                    sb.Insert(0, orders[order, 1]);
                else if (orderExists)
                    sb.Insert(0, orders[order, 2]);
                if (unitsDigit > 1)
                    sb.Insert(0, units[unitsDigit]);
            }
            else
            {
                if (tensDigits >= 10 && tensDigits < 20)
                {
                    sb.Insert(0, orders[order, 2]);
                    sb.Insert(0, teens[tensDigits % 10]);
                }
                else
                {
                    if (unitsDigit >= 2 && unitsDigit <= 4)
                        sb.Insert(0, orders[order, 1]);
                    else if (orderExists)
                        sb.Insert(0, orders[order, 2]);
                    sb.Insert(0, units[unitsDigit]);
                    sb.Insert(0, tens[tensDigits / 10]);
                }
                sb.Insert(0, hundreds[hundredsDigit]);
            }
            order++;
            value = value / 1000;
        }
        return sb.ToString();
    }

    private static int GetCurrencyFormIndex(int number)
    {
        if (number == 1)
            return 0;

        int tensDigits = number % 100;
        if (tensDigits >= 10 && tensDigits < 20)
            return 2;

        int unitsDigit = number % 10;
        if (unitsDigit >= 2 && unitsDigit <= 4)
            return 1;

        return 2;
    }

    public static string AmountInWords(decimal amount, string currencyCode)
    {
        int wholePart = (int)amount;
        int decimalPart = (int)(amount * 100) % 100;
        return string.Format("{0} {1}, {2} {3}",
            NumberToWords(wholePart),
            CurrencyToWords(wholePart, currencyCode),
            NumberToWords(decimalPart),
            CurrencyToWords(decimalPart, currencyCode));
    }
}