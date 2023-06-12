namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {

            if (b > 100)
                return 12;

            return checked(a + b);
        }
    }
}