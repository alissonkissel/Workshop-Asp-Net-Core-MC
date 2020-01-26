using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Department Departments { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double salary, Department departments)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
            Departments = departments;
        }

        public void addSales(SalesRecord sr)
        {
            if (sr != null)
                Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            if (sr != null)
                Sales.Remove(sr);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(c => (c.Date >= initial) && (c.Date <= final)).Sum(c => c.Amount);
        }
    }
}
