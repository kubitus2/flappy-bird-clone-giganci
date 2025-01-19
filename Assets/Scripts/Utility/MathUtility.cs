namespace Utility
{
    public static class MathUtility
    {
        public static bool CheckDivisibility(this int number, int divider)
        {
            return number % divider == 0;
        }
    }
}