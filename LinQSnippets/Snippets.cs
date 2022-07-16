using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQSnippets
{

    public class Snippets
    {
       static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // SELECT * CARS
            var carList = from car in cars select car;

            foreach( var car in carList)
            {
                Console.WriteLine(car);
	        }

            // SELECT WHERE
            var audiList = from car in cars
                           where car.Contains("Audi")
                           select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        static public void LinqNumbers()
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiply by 3 takes all but 9 order ascending
            var cubic = numbers.Select(num => num * 3)
                               .Where(num => num != 9)
                               .OrderBy(num => num);
            foreach(int number in cubic)
            {
                Console.WriteLine(number);
	        }
	    }

        static public void SearchEmples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "f",
                "cj",
                "c"
            };

            var first = textList.First();

            // first element that is c
            var cText = textList.First(text => text.Equals("c"));

            // First elemant thath contains c
            var jText = textList.First(text => text.Contains("j"));

            // First element that contains Z or default
            var firstODefault = textList.FirstOrDefault(text => text.Contains("z"));

            // Last or default
            var lastoODefault = textList.LastOrDefault(text => text.Contains("z"));

            // SIngle values
            var unique = textList.Single();
            var uniqueDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumers = { 0, 2, 6 };

            // Obtain {4, 8}
            var even = evenNumbers.Except(otherNumers);
        }

        static public void MutipleSelect()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinion = myOpinions.SelectMany(opinion => opinion.Split(","));

            var entrepises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Entrepise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Alex",
                            Email="alex@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id=2,
                            Name="Pepe",
                            Email="pepe@gmail.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id=3,
                            Name="Martin",
                            Email="martin@gmail.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Entrepise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id=4,
                            Name="Ana",
                            Email="ana@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id=5,
                            Name="Maria",
                            Email="maria@gmail.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id=6,
                            Name="Marta",
                            Email="marta@gmail.com",
                            Salary = 4000
                        }
                    }
                }
            };

            // Todos empleados of all entrepises
            var employeeList = entrepises.SelectMany(entrepise => entrepise.Employees);

            // Know if listy is empty
            bool hasEnterpises = entrepises.Any();

            // tiene empleados
            bool hasEmployees = entrepises.Any(entrepise => entrepise.Employees.Any());

            // Alle entrepises at leaast has an employee with at least 1000€ salary
            bool employewithSalaryMoreThan1000 =
                entrepises.Any(
                    entrepises => entrepises.Employees.Any(employee => employee.Salary >= 1000)
                   );
            
	    }

        static public void LinqCollections()
        {

            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
		        secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new {element, secondElement}
		
		    );

            // Outer JOIN - LEFT

            var leftJoin = from element in firstList
                           join secondElement in secondList
                           on element equals secondElement
                           into temporalList
                           from temporalElement in temporalList.DefaultIfEmpty()
                           where element != temporalElement
                           select new { Element = element };

            var leftOuterJoin = from element in firstList
                                from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                select new { Element = element, SecondElement = secondElement };

            var rightJoin = from secondElement in secondList
                           join element in firstList
                           on secondElement equals element
                           into temporalList
                           from temporalElement in temporalList.DefaultIfEmpty()
                           where secondElement != temporalElement
                           select new { Element = secondElement };


            // Union 
            var unionList = leftJoin.Union(rightJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var SkipTwoFirstValues = myList.Skip(2); // From 3 to ...

            var skipLastTwoValuse = myList.SkipLast(2); // {1...8}

            var skipWhile = myList.SkipWhile(num => num <= 4); // {5, 6, 7, 8, 9, 10}

            // TAKE

            var takeFirstTwoValues = myList.Take(2); // Get number skipped
            var takeLastTwoValues = myList.TakeLast(2);
            var takeWhileSmaller = myList.TakeWhile(num => num < 4);
	    }
    }
}

