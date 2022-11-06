using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>();

            Person p1 = new Person();
            p1.PersonID = 1;
            p1.Name = "Taha";
            p1.Family = "Amin Ghafuri";
            p1.Age = 17;
            People.Add(p1);

            Person p2 = new Person()
            {
                PersonID = 2,
                Name = "Taha",
                Family = "Amin Ghafuri",
                Age = 17
            };
            People.Add(p2);

            People.Add(new Person()
            {
                PersonID = 3,
                Name = "Taha",
                Family = "Amin Ghafuri",
                Age = 17
            });

            // var result = People.ToList();
            // var result = People.OrderByDescending(p => p.PersonID).ToList();
            // var result = People.Where(p => p.Name.ToLower() == "taha").ToList();

            var result1 = People.Where(p => p.Age == 17).ToList();
            var result2 = People.Select(p => p.Name).ToList();
            var result3 = People.Select(p => new { p.Name, p.Age }).ToList();

            foreach (var p in result3)
            {
                Console.WriteLine($"ID:{p.PersonID} - Name:{p.Name} - Family:{p.Family} - Age:{p.Age}");
            }

            List<PersonCar> Cars = new List<PersonCar>()
            {
                new PersonCar(){PersonID=1,CarName="Khar",CarModel="none"},
                new PersonCar(){PersonID=2,CarName="Olaq",CarModel="none"}
            };

            var join = (from p in People
                        join c in Cars on p.PersonID equals c.PersonID
                        select new
                        {
                            p.PersonID,
                            p.Name,
                            p.Family,
                            p.Age,
                            c.CarName,
                            c.CarModel
                        }).ToList();

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var res1 = nums.Distinct().ToArray();
            var res2 = nums.OrderByDescending(n => n).Take(3).ToArray();
            var res3 = nums.OrderByDescending(n => n).Skip(3).ToArray();

            Console.ReadKey();
        }
    }
}
