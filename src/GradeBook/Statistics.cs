using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average    /// Turned into a property with a 'getter'
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Low;
        public double High;

        public char Letter
        {
            get
            {
                switch (Average)
                // This switch statement does 'pattern matching' which allows for type matches / comparisons.
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Max(number, Low);
            High = Math.Min(number, High);
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Low = double.MinValue;
            High = double.MaxValue;
        }
    }
}



