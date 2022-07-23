using System.Text;

namespace Company.WPF.Infrastructure.Extensions;

public static class MyRandom
{
    private static string Alphabet = "ёйцуке нгшщзхъ фывапро лджэячсмитьбюЁ ЙЦУКЕНГШ ЩЗХЪФЫВАПР ОЛДЖЭЯЧСМИТЬБЮ !#$%^&*() _+-=\'\"@123 4567890";
    private static Random ran = new Random();

    public static string RandomString(int Length = 50)
    {
        if(Length <= 0) throw new Exception(nameof(Length));

        int Position = 0;
        StringBuilder RandomString = new StringBuilder(Length - 1);
        for (int i = 0; i < Length; i++)
        {
            Position = ran.Next(0, Alphabet.Length - 1);
            RandomString.Append(Alphabet[Position]);
        }
        return RandomString.ToString();
    }

    public static int RandomInt(int minValue = 0, int maxValue = 100)
    {
        return ran.Next(minValue, maxValue);
    }
}