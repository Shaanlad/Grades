using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            // SpeechSynthesizer synth = new SpeechSynthesizer();
            // synth.Speak("Hey..what's up!");

            GradeBook book = new GradeBook();
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            book.NameChanged += OnNameChanged2;
            book.NameChanged -= OnNameChanged2;

            book.AddGrade(91);
            book.AddGrade(85.5f);
            book.AddGrade(75);

            book.Name = "Lad's Grade Book";
            book.Name = "Lad's Book";

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            WriteResult("Average",stats.AverageGrade);
            WriteResult("Highest",stats.HighestGrade);
            WriteResult("Lowest",stats.LowestGrade);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Name changing from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("* * *");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + " : " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }   
    }
}
