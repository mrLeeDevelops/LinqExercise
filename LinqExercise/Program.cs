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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE--Print the Sum and Average of numbers
            int sum = numbers.Sum();
            double avg = numbers.Average();
            Console.WriteLine($"The SUM is: {sum}. The AVERAGE is {avg}.");
            Console.WriteLine("");
            //DONE--Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(num => num).ToArray();
            var descending = numbers.OrderByDescending(num => num).ToArray();
            Console.WriteLine("ASCENDING ORDER");
            Console.WriteLine("-------------------");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{ascending[i]} ");
            }
            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("DESCENDING ORDER");
            Console.WriteLine("-------------------");
            for (int x = 0; x < numbers.Length; x++)
            {
                Console.Write($"{descending[x]} ");

            }
            Console.WriteLine("");
            Console.WriteLine("");
            //DONE--Print to the console only the numbers greater than 6
            var few = numbers.Where(num => num > 6).ToArray();
            Console.WriteLine("NUMBERS > 6");
            Console.WriteLine("-----------");
            for (int y = 0; y < few.Length; y++)
            {
              Console.Write($"{few[y]} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //DONE--Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var asc = numbers.OrderBy(num => num).ToArray();
            var four = asc.Where(num => num < asc.Length - 6).ToArray();
            Console.WriteLine("FOUR NUMBERS");
            Console.WriteLine("------------");
            foreach (int one in four)
            {
                Console.Write($"{one}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //DONE--Change the value at index 4 to your age, then print the numbers in decsending order
            //The steps are:
            //1) Print unaltered array.
            Console.WriteLine("UNALTERED ARRAY");
            Console.WriteLine("-------------------");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //2) change array to list.
            var numbers2 = numbers.ToList();
            //3) select element at index 4 and save its value to a variable.
            var index4 = numbers2.ElementAt(4);
            numbers2.RemoveAt(4);
            //4) Change the value of index4 variable.
            index4 = 43;
            //5) Add index 4 to the end of list.
            numbers2.Add(index4);
            //6) order list in descending order and change list to array.
            var orderList = numbers2.OrderByDescending(num => num).ToArray();
            //7) Print array.
            Console.WriteLine("ALTERED ARRAY");
            Console.WriteLine("--------------------");
            for (int i = 0; i < orderList.Length; i++)
            {
                Console.Write($"{orderList[i]} ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //DONE--Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            Console.WriteLine("CERTAIN EMPLOYEES");
            Console.WriteLine("-----------------");
            var selectEmployees = new List<Employee>();
            /*foreach (var employee in employees)
            {
                if (employee.FirstName.ElementAt(0) == 'C')
                {
                    selectEmployees.Add(employee);
                    Console.WriteLine(employee.FullName);
                }
                else if (employee.FirstName.ElementAt(0) == 'S')
                {
                    selectEmployees.Add(employee);
                    Console.WriteLine(employee.FullName);
                }
            }*/

            foreach (var employee in employees)
            {
                if (employee.FirstName.ElementAt(0).ToString().IndexOf('C') != -1 || employee.FirstName.ElementAt(0).ToString().IndexOf('S') != -1)
                {
                    selectEmployees.Add(employee);
                    Console.WriteLine(employee.FullName);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //DONE--Order this in acesnding order by FirstName.
            selectEmployees = selectEmployees.OrderBy(x => x.FirstName).ToList();
            Console.WriteLine("ASCENDING ORDER");
            Console.WriteLine("-----------------");
            foreach (Employee emp in selectEmployees)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //DONE--Print all the employees' FullName and Age who are over the age 26 to the console.
            Console.WriteLine("EMPLOYEES OVER 26");
            Console.WriteLine("---------------------");
            var twentySix = employees.Where(x => x.Age > 26);
            foreach (var one in twentySix)
            {
                Console.WriteLine($"{one.FullName}, {one.Age}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //DONE--Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("ORDERED LIST");
            Console.WriteLine("----------------------");
            var employeeList = twentySix.OrderBy(x => x.Age).ThenBy(x => x.FirstName); 
            foreach (var list in employeeList)
            {
                Console.WriteLine($"{list.FullName}, {list.Age}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //DONE--Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("YEARS OF EXOERIENCE");
            Console.WriteLine("--------------------"); 
            var experience = employees.Where(x => x.Age > 35).Where(y => y.YearsOfExperience <= 10);
            int yearsSum = 0;
            int yearsAvg = 0;
            foreach (var item in experience)
            {
                Console.WriteLine($"{item.FullName}, {item.YearsOfExperience}");
                yearsSum += item.YearsOfExperience;
            }
            Console.WriteLine("--------------------");
            yearsAvg = yearsSum / (experience.Count());
            Console.WriteLine($"SUM : {yearsSum}  AVERAGE: {yearsAvg}");
            Console.WriteLine("");
            Console.WriteLine("");
            //DONE--Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("OLD EMPLOYEES");
            Console.WriteLine("-------------");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FullName}, {emp.Age}, {emp.YearsOfExperience}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            var newHire = new Employee() {FirstName = "D'Mario", LastName = "Jones", Age = 29 , YearsOfExperience = 10 };
            employees.Insert(10 , newHire);
            Console.WriteLine("NEW EMPLOYEES");
            Console.WriteLine("-------------"); 
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FullName}, {emp.Age}, {emp.YearsOfExperience}");
            }

            Console.WriteLine("");
            Console.WriteLine(""); 
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
