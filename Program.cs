using System.Text.RegularExpressions;

namespace ConsoleAppAlgorithmsExamples
{
    internal partial class Program
    {
        //Our regex: "^\d{4}-\d{2}-\d{2}$"
        [GeneratedRegex(@"^\d{4}-\d{2}-\d{2}$")]
        private static partial Regex DateRegex();
        static void Main(string[] args)
        {
            var testValue1 = "2025-10-03"; //true
            var testValue2 = "03/10/2025"; //false


            Console.WriteLine(DateRegex().IsMatch("2025-10-03")); // true
            Console.WriteLine(DateRegex().IsMatch("03/10/2025")); // false
        }
    }
}
