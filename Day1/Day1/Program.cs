using System;
using Day1Library;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Expenses expenses = new Expenses();
            int productofTwo = expenses.FindProductWhere2NumbersSum2020();
            int productOfThree = expenses.FindProductWhere3NumbersSum2020();
            Console.WriteLine($"\nDay 1, Challenge 1 solution: {productofTwo}.\nDay 1, Challenge 2 solution: {productOfThree}.");
        }
    }
}
