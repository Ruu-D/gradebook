using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
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

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                // if (grade >= 0)
                // Nesting of an 'if' statement in another 'if' statement.
                // Only if the first 'if' statement is not combined with '&&'.
                // {
                grades.Add(grade);
                // }
            }
            else
            {
                // Console.WriteLine("Invalid value");
                throw new ArgumentException($"Invalid {nameof(grade)+ " entered dude..."}");
            }
            

        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

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
                        // (initialization ; condition for code below ; operation to perform after each loop)
                        {
                            result.Low = Math.Min(grades[index], result.Low);
                            result.High = Math.Max(grades[index], result.High);
                            result.Average += grades[index];
                        }
                        result.Average /= grades.Count;

            switch(result.Average)
                // This switch statement does 'pattern matching' which allows for type matches / comparisons.
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

                        return result;

            #endregion

/*
            #region JUMPING WITH BREAK AND CONTINUE
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
                    // continue; //When value '42.1' is detected, continue the loop.

                    //////// Method 3
                    // goto to done;  // No one really uses this principle these days...
                }
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            return result;
            #endregion
*/

        }

        private List<double> grades;
        public string Name;
    }
}