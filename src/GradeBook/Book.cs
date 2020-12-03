using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject  //Inheritance c# constructor
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
}

    public interface IBook     // 'IBook' with letter 'i' because it's an inferface, this is just a convention.
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }



    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }



    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using var writer = File.AppendText($"{Name}.txt");
            {
                writer.WriteLine(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }  // at this line, with the 'using' statement, the compiler will 'Dispose or Close' the file auotmatically.
                
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using var reader = File.OpenText($"{Name}.txt");
            {
                var line = reader.ReadLine();
                while (line!=null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }


    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        //public string AddGrade(char letter, int x)
        //{
        //    return "This is just to show that the 'AddGrade' name can exist multiple times, BUT with additional parameters!";
        //}



        /*
        public void AddGrade(char letter)
        {
            ////////// Most basic form of the 'switch' statement.
            // Could also be done with nested 'if' + 'else if' statements.
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }
        */

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                // Console.WriteLine("Invalid value");
                throw new ArgumentException($"Invalid {nameof(grade)+ " entered dude..."}");
            }
        }

        public override event GradeAddedDelegate GradeAdded; //Gives some additional restrictions to the 'GradeAdded' delegate

        public override Statistics GetStatistics()
        {
            var result = new Statistics();


#region LOOPING STATEMENTS
            /*
                        //////////////////////////////////
                        // Looping statement possibility 1
                        //////////////////////////////////
                        // Clearest form of looping, when this method can be used.
                        foreach (var grade in grades)
                        {
                            result.Low = Math.Min(grade, result.Low);
                            result.High = Math.Max(grade, result.High);
                            result.Average += grade;
                        }
                        result.Average /= grades.Count;

                        return result;

                        //////////////////////////////////
                        // Looping statement possibility 2
                        //////////////////////////////////
                        // Becomes an issue when the list of 'grades' is empty.
                        var index = 0;
                        do
                        {
                            result.Low = Math.Min(grades[index], result.Low);
                            result.High = Math.Max(grades[index], result.High);
                            result.Average += grades[index];
                                // The 3 lines above are !at least once executed with the 'do while method'.
                            index += 1;   // add '1' to the index
                        } while (index < grades.Count);   // Only when reaching this line, the looping happens.
                        result.Average /= grades.Count;

                        return result;

                        //////////////////////////////////
                        // Looping statement possibility 3
                        //////////////////////////////////
                        // This method won't execute the code below when the 'while' condition is not true.
                        // It's a improvement over the methode '2' above.
                        var index = 0;
                        while(index < grades.Count)
                        {
                            result.Low = Math.Min(grades[index], result.Low);
                            result.High = Math.Max(grades[index], result.High);
                            result.Average += grades[index];
                            index += 1; 
                        };
                        result.Average /= grades.Count;

                        return result;
            */

            //////////////////////////////////
            // Looping statement possibility 4
            //////////////////////////////////
            for (var index =0; index < grades.Count; index +=1)
                        {
                result.Add(grades[index]);
                        }

                        return result;

            #endregion

#region JUMPING WITH BREAK AND CONTINUE
/*

            // JUMPING WITH BREAK AND CONTINUE
            //////////////////////////////////
            // Jumping over lines of code
            //////////////////////////////////
            for (var index = 0; index < grades.Count; index += 1)
            {
                if(grades[index] == 42.1)
                {
                    //////// Method 1
                    break;  // Ability to break out of the loop and skip the 3 lines of code below. Jump to line "result.Average /= grades.Count;"

                    //////// Method 2
                    continue; //When value '42.1' is detected, continue the loop.

                    //////// Method 3
                    goto to done;  // No one really uses this principle these days...
                }
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            return result;
            #endregion
*/
#endregion

        }

        private List<double> grades;

        //////////////////////////////////
        ////// Long hand syntax for defining a property :
        ////public string Name
        ////{
        ////    get
        ////    {
        ////        return name;    // Code being executed when someone wants to READ the Name property.
        ////    }
        ////    set
        ////    {
        ////        if (!String.IsNullOrEmpty(value))  // Perform a check if value is empty. ! means that 'if it's NOT' empty, set the field Name as the incoming input value.
        ////        {
        ////            name = value;
        ////        }
        ////        else
        ////        {
        ////            Console.WriteLine($"The input you gave me is empty bro");
        ////        }
        ////    }
        ////}

        ////private string name;  // = backing field that sits behind the property.




        ////////////////////////////////
        //// short way for defining a property :
        //public string Name
        //{
        //    get;
        //    set;  // makes sure that once a 'Name' is given to the book, it can no longer be changed afterwards.
        //}

        // readonly string category = "Science";
        public const string CATEGORY = "Science";  // Normally written uppercase to annotate that its a 'const' = constant value
    }
}