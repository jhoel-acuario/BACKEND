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

                }
            };
        }
    }
}