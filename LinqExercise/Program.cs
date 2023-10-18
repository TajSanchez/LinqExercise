using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers 
             Console.WriteLine($" Sum: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($" Average: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Numbers Ascending");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Numbers Descending");
            numbers.OrderByDescending( x => x ).ToList().ForEach(x => Console.WriteLine(x));
          

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers Greater Than 6");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));


            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Take 4:");
            var orderedNums = numbers.OrderBy(x => x);
            foreach(var number in orderedNums.Take(4))
            {
                Console.WriteLine(number);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Adding age DESC:");
            numbers[4] = 31;
            var numbersDesc = numbers.OrderByDescending(x => x);
            foreach(var number in numbersDesc) 
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();


            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine(" Employees S and C:");

            var filteredEmployees = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith ('S')).OrderBy(p => p.FirstName);
            foreach(var person in filteredEmployees)
            {
                Console.WriteLine(person.FirstName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees Over 26");
            var employeesOver26 = employees.Where(person => person.Age > 26).OrderBy(p => p.Age).ThenBy(p => p.FirstName);
            foreach (var person in employeesOver26)
            {
                Console.WriteLine($"{person.FullName}, {person.Age}");
            }


            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Special");
            var specialFilteredEmployees = employees.Where(p => p.YearsOfExperience <= 10 && p.Age > 35);

            Console.WriteLine($"Total YOE: {specialFilteredEmployees.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average YOE: {specialFilteredEmployees.Average(x => x.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Taj", "Roller", 31, 1)).ToList();

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
