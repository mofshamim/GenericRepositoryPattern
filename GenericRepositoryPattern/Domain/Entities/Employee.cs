using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRepositoryPattern.Domain.Entities
{

    public class BaseEntity
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public User UpdatedByUser { get; set; }
    }

    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string SKU { get; set; }
        public int Age { get; set; }
    }

    public class Supplier : BaseEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Address { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}
