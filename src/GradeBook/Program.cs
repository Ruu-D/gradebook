using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book =  new Book("Daan Grade Book");
            book.GradeAdded += OnGradeAdded; // += combine operation
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded; // -= subtraction operation
            book.GradeAdded += OnGradeAdded;

            var done = false;  // Finish the looping when 'done' = True
            while (!done)  //! = not true operator = opposite of the above line
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done=true;
                    continue;
                    // break;   // Then we don't need the 'var done'.
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);    // If this catches the exception, the software would not crash and continue on working to 'AddGrades'.
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally    // A piece of code that must be executed, but also when something adds an exception, it will process the following code.
                // Can be usefull when you MUST close a file or network socket or ...
                {
                    Console.WriteLine("**This is the 'finally' text**");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);  //'Book' is the class name here!
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added in the book");
        }

    }
}
