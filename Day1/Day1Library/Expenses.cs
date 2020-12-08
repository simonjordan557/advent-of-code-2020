using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day1Library
{
    public class Expenses
    {
        public List<int> _expensesList;
        private List<int> _complementsSet;
        private List<int> _secondComplementsSet;

        public Expenses()
        {
            // Populate the expenses list into memory   
            _expensesList = new List<int>();
            _complementsSet = new List<int>();
            FileStream fs = File.Open("expenses.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                _expensesList.Add(int.Parse(sr.ReadLine()));
            }
            sr.Close();
        }

        public int FindProductWhere2NumbersSum2020()
        {
            // for each expenses item, check if its complement has previously appeared in the list
            foreach (int expense in _expensesList)
            {
                _complementsSet.Add(expense);
                if (_complementsSet.Contains(2020 - expense))
                {
                    Console.WriteLine($"{expense} multiplied by {2020 - expense} equals {expense * (2020 - expense)}.");
                    return expense * (2020 - expense);
                }
            }
            return -1;
        }

        public int FindProductWhere3NumbersSum2020()
        {
            _complementsSet = new List<int>();
            _secondComplementsSet = new List<int>();

            foreach (int expense in _expensesList)
            {
                for (int i = 0; i < _complementsSet.Count; i++)
                {
                    for (int j = 0; j < _complementsSet.Count; j++)
                    {
                        if (i == j) continue;
                        if (_complementsSet[i] + _secondComplementsSet[j] + expense == 2020)
                        {
                            Console.WriteLine($"{expense} multiplied by {_complementsSet[i]} and {_secondComplementsSet[j]} equals {expense * _complementsSet[i] * _complementsSet[j]}.");
                            return _complementsSet[i] * _secondComplementsSet[j] * expense;
                        }
                    }
                }
                _complementsSet.Add(expense);
                _secondComplementsSet.Add(expense);
            }
            return -1;
        }
    }
}
