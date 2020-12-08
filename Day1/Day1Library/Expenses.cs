using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day1Library
{
    public class Expenses
    {
        private List<int> _expensesList;
        private HashSet<int> _complementsSet;

        public Expenses()
        {
            _expensesList = new List<int>();
            _complementsSet = new HashSet<int>();
            FileStream fs = File.Open("expenses.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                _expensesList.Add(int.Parse(sr.ReadLine()));
            }
            sr.Close();
        }

        public void FindProductWhereNumbersSum2020()
        {
            foreach (int expense in _expensesList)
            {
                _complementsSet.Add(expense);
                if (_complementsSet.Contains(2020 - expense))
                {
                    Console.WriteLine($"{expense} multiplied by {2020 - expense} equals {expense * (2020 - expense)}.");
                }
            }
        }

    }
}
