namespace Utility
{
    public static class ParserUtility
    {
        public static int ParseInt(this string input)
        {
            return int.TryParse(input, out var result) ? result : 0;
        }
    }
}