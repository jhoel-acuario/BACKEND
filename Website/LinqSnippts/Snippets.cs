using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace LinqSnippts
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VMW",
                "TOYOTA",
                "NISSAN",
                "FORD",
                "VOLQUETE",
                "KIA",
                "AUDI A5",
                "AUDI A45"
            };
            var carList = from car in cars select car;
            foreach ( var car in carList )
            {
                Console.WriteLine(car);
            }
            //Buscar en  la lista la palabra que contenga AUDI y luego iterar
            var audiList = from car in cars where car.Contains("AUDI") select car;
            foreach( var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }
        static public void LinqNumber()
        {
            List<int> numbers = new List<int> { 1,65,4,56,8,2,5,64,654,654,6 ,9};
            var numList = numbers
                                .Select(num => num*3) //Multiplica x3 a todos
                                .Where(num=>num != 9) // Obvia el numero 9
                                .OrderBy(num=>num); //Ordena

        }
        static public void SearchEmples()
        {
            List<string> employees = new List<string>
            {
                "uno",
                "dos",
                "tres",
                "cuantro",
                "cinco",
                "seis",
                "siete",
                "uno",
                "uno cinco"
            };
            var firt = employees.First();
            var repetidos = employees.First(text => text.Equals("uno"));
            var repetidosContent = employees.First(text => text.Contains("uno"));

            int[] eventNumber = { 4, 5, 5, 4, 68, 2, 76, 4 };
            int[] eventNumberOthers = { 0, 44, 6, 1, 68, 2, 76, 4 };
            //Compara y muestra los datos que no serepiten
            var result = eventNumber.Except(eventNumberOthers);
        }
        static public void SelectOptions()
        {
            string[] opinions =
            {
                "opinion 1, valor1",
                "opinion 2, valor2",
                "opinion 3, valor3",
                "opinion 4, valor4",
            };
            var selectOpionion = opinions.SelectMany(o => o.Split(","));
            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 01",
                    Employees= new []
                    {
                       new Employee
                       {
                           Id=1,
                           Name="jhoel",
                           Email = "jhoel@gmail.com",
                           Salary = 1200
                       },
                        new Employee
                       {
                           Id=1,
                           Name="Juan",
                           Email = "juan@gmail.com",
                           Salary = 1400
                       },
                         new Employee
                       {
                           Id=1,
                           Name="Pepe",
                           Email = "pepe@gmail.com",
                           Salary = 1000
                       }

                    }

                },
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 02",
                    Employees= new []
                    {
                       new Employee
                       {
                           Id=1,
                           Name="Agustin",
                           Email = "jhoel@gmail.com",
                           Salary = 1200
                       },
                        new Employee
                       {
                           Id=1,
                           Name="marilu",
                           Email = "juan@gmail.com",
                           Salary = 1400
                       },
                         new Employee
                       {
                           Id=1,
                           Name="felipe",
                           Email = "pepe@gmail.com",
                           Salary = 1000
                       }

                    }

                },
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 03",
                    Employees= new []
                    {
                       new Employee
                       {
                           Id=1,
                           Name="rosa",
                           Email = "jhoel@gmail.com",
                           Salary = 1200
                       },
                        new Employee
                       {
                           Id=1,
                           Name="flor",
                           Email = "juan@gmail.com",
                           Salary = 1400
                       },
                         new Employee
                       {
                           Id=1,
                           Name="Pepe",
                           Email = "pepe@gmail.com",
                           Salary = 1000
                       }

                    }

                },
                new Enterprise()
                {
                    Id=1,
                    Name="Enterprise 04",
                    Employees= new []
                    {
                       new Employee
                       {
                           Id=1,
                           Name="mary",
                           Email = "jhoel@gmail.com",
                           Salary = 1200
                       },
                        new Employee
                       {
                           Id=1,
                           Name="Juan",
                           Email = "juan@gmail.com",
                           Salary = 1400
                       },
                         new Employee
                       {
                           Id=1,
                           Name="jose",
                           Email = "pepe@gmail.com",
                           Salary = 1000
                       }

                    }

                }
            };
            var lista = enterprises.SelectMany(enterprise => enterprise.Employees); //mostrar toda la lista
            bool vacio = enterprises.Any(); //verifica si existe datos dentro de la lista
            bool hasEmployee = enterprises.Any(emp => emp.Employees.Any()); //verifica si existe datos dentro de la lista empleados
            bool hasSalary = enterprises.Any(i => i.Employees.Any(s => s.Salary > 1000));

        }
        static public void LinqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c", "d", "e", "f", "g" };
            var secondList = new List<string>() { "a", "b", "e", "f", "g" };
            //JOIN V1
            var result = from element in firstList join secondElement in secondList on element equals secondElement select new { element, secondElement };
            //JOIN V2
            var result2 = firstList.Join(
                secondList, element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );
            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };



            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };


            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }
        static public void SkipTakeLinq()
        {

            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // SKIP

            var skipTwoFirstValues = myList.Skip(2); // { 3,4,5,6,7,8,9,10 }

            var skipLastTwoValues = myList.SkipLast(2); // {1,2,3,4,5,6,7,8 }

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // { 4,5,6,7,8 }

            // TAKE

            var takeFirstTwoValues = myList.Take(2); // { 1,2 }

            var takeLastTwoValues = myList.TakeLast(2); // { 9,10 }

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // { 1,2,3 }

        }
    }
}