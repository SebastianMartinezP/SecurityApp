namespace Business.Util
{
    public static class ValidationHandler
    {
        public static bool ValidateEmail(string email)
        {
            bool correctLength = email.Length > 5;
            bool containsAt = email.Contains('@');
            bool containsDot = email.Contains('.');
            return correctLength && containsAt && containsDot;
        }

        public static bool ValidateRut(string rut)
        {
            bool correctLength = rut.Length == 9 || rut.Length == 10; //"XX.XXX.XXX-X"
            //bool containsDot = rut.Contains('.');
            bool containsDash = rut.Contains('-');
            return correctLength && containsDash;
        }

        public static bool ValidateString(string? value)
        {
            bool notNull = value != null;
            bool correctLength = value?.Length != 0;
            return notNull && correctLength;
        }
    }
}
