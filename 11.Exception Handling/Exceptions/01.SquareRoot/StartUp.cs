namespace _01.SquareRoot
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string exceptionMessage = string.Empty;
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    exceptionMessage = "Invalid number";
                    Console.WriteLine(exceptionMessage);
                }
                else
                {
                    var squareNumber = Math.Sqrt(number);
                    Console.WriteLine($"{squareNumber:F2}");
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(exceptionMessage);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
