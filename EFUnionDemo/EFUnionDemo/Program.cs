using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.NorthwindEntities db = new Model.NorthwindEntities();

            var employees = db.Employees.AsQueryable();
            var customers = db.Customers.AsQueryable();

            // 正確 兩個集合的欄位數量跟順序都要一致
            var people1 = employees.Select(e => new SearchPerson()
            {
                Name = e.FirstName + e.LastName,
                Title = e.Title,
                Category = PersonCategory.Employee,
                Birthday = e.BirthDate
            });

            var people2 = customers.Select(c => new SearchPerson()
            {
                Name = c.ContactName,
                Title = c.ContactTitle,
                Category = PersonCategory.Customer,
                Birthday = null
            });

            /*
            // 錯誤 兩個集合的欄位數量跟順序都不一樣 就會出錯
            var people1 = employees.Select(e => new SearchPerson()
            {
                Category = PersonCategory.Employee,
                Title = e.Title,
                Name = e.FirstName + e.LastName,
                Birthday = e.BirthDate
            });

            var people2 = customers.Select(c => new SearchPerson()
            {
                Name = c.ContactName,
                Title = c.ContactTitle,
                Category = PersonCategory.Customer
            });
            */

            var people = people1.Union(people2);
            Console.WriteLine(people.ToList());
        }

        public class SearchPerson
        {
            public string Name { get; set; }

            public string Title { get; set; }

            public DateTime? Birthday { get; set; }

            public PersonCategory Category { get; set; }
        }

        public enum PersonCategory
        {
            Employee,
            Customer
        }
    }

    
}
