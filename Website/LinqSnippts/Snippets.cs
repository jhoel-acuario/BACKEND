using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
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
        //PAGINACION
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int numberPage, int resultPage)
        {
            int startIndex = (numberPage -1) * resultPage;
            return collection.Skip(startIndex).Take(resultPage);
        }
        //VARIABLES 
        static public void LinqVariable()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 };

            var result = from number in numbers
                         let numberValue = numbers.Average()
                         let nSquard = Math.Pow(number, 2)
                         where nSquard > numberValue
                         select number;
            foreach (var item in result)
            {
                Console.WriteLine("Number :{0} Square: {1}", item, Math.Pow(item, 2));
            }
        }
        //ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5};
            string[] stringNumber = { "uno", "dos", "tres", "cuatro", "cinco" };

            IEnumerable<string> zipNumber = numbers.Zip(stringNumber, (number, word)=> number +"="+ word); //{"1=uno", "2=dos"}
        }
        //REPEAT && RANGE  
        static public void RepeatLinq()
        {
            //Generar una colecion de 1 a 100
            IEnumerable<int> valor = Enumerable.Range(0, 1000);

            IEnumerable<string> repeatValue = Enumerable.Repeat("x", 5); // result {"x",x,x,x,x}
        }
        static public void StudentLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id=1,
                    Name="jhoel",
                    Grade = 90,
                    Certifed= true
                },
                new Student
                {
                    Id=3,
                    Name="Ana",
                    Grade = 50,
                    Certifed= true
                },
                new Student
                {
                    Id=4,
                    Name="hyto",
                    Grade = 100,
                    Certifed= false
                },
                new Student
                {
                    Id=5,
                    Name="tuyo",
                    Grade = 80,
                    Certifed= true
                }
            };
            var result = from student in classRoom
                         where student.Certifed
                         select student;
            var result1 = from student in classRoom
                          where student.Certifed ==false
                          select student;
            var reusl2 = from student in classRoom
                         where student.Grade >= 60 && student.Certifed == true
                         select student.Name; //Devuelve todos los nombres de los aprobados
        }
        //ALL
        static public void AllLinq()
        {
            var number = new List<int>() { 1, 2, 3, 4, 56, 4,5, 5 };

            bool result = number.All(n => n < 10); //true
            bool result2 = number.All(n => n >= 2); //false

            var numberValue = new List<int>(); //lista vacia

            bool result3 = number.All(x => x >= 0); //true

        }
        //AGREGACION
        static public void AgregateLinq()
        {
            var number = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = number.Aggregate((prev, current) => prev + current);
            //0,1 =1
            //1,2 =3
            //3,4= 7

            string[] work = { "hola", "como estas", "jhoel" };
            var result = work.Aggregate((prev, current) => prev + current);
            //"", "hola"=> hola
            //"hola", "como estas"=> hola como estas
            //"hola como estas", "jhoel" => hola como estas jhoel
        }
        //DISCTINCT
        static public void DisctinctLinq()
        {
            var number = new List<int>() { 1, 2, 3, 55, 75,9, 8, 20, 10 };

            IEnumerable<int> numberValue = number.Distinct();
        }
        //GROUPBY - AGRUPACION

        static public void GroupByLinq()
        {
            int[] numbers= { 1, 2, 3, 4, 5, 6, 78, 9 };
            var result = numbers.GroupBy(x => x % 2 == 0);
            foreach (var item in result)
            {
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);//1,2,3,55,9 -- 8,10,20
                    
                }
            }
            var classRoom = new[]
           {
                new Student
                {
                    Id=1,
                    Name="jhoel",
                    Grade = 90,
                    Certifed= true
                },
                new Student
                {
                    Id=3,
                    Name="Ana",
                    Grade = 50,
                    Certifed= true
                },
                new Student
                {
                    Id=4,
                    Name="hyto",
                    Grade = 100,
                    Certifed= false
                },
                new Student
                {
                    Id=5,
                    Name="tuyo",
                    Grade = 80,
                    Certifed= true
                }
            };
            var VertifiedValue = classRoom.GroupBy(x => x.Certifed);

            foreach (var item in VertifiedValue)
                Console.WriteLine("------------{0}---------------", item.Key);
            {
                foreach (var item1 in classRoom)
                {
                    Console.WriteLine(item1.Name);
                    
                }


            }

        }

        static public void RelationLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post
                {
                    Id=1,
                    Title="ni idea",
                    Description="hola como estan",
                    Created=DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=1,
                            Title= "Titulo 01",
                            Content="lorem",
                            Created= DateTime.Now

                        }

                    }
                },
                 new Post
                {
                    Id=1,
                    Title="ni idea 02",
                    Description="hola como estan",
                    Created=DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=1,
                            Title= "Titulo 002",
                            Content="lorem",
                            Created= DateTime.Now

                        }

                    }
                },
                  new Post
                  {
                    Id=1,
                    Title="ni idea 03",
                    Description="hola como estan",
                    Created=DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=1,
                            Title= "Titulo 03",
                            Content="lorem",
                            Created= DateTime.Now

                        }

                    }
                  }
            };

            var result = posts.SelectMany(p => p.Comments, (p, comment) => new { postId = p.Id, CommentContent = comment.Content });
            //muestra el id 1 --> con el comentario de id 1
        }
    }
}