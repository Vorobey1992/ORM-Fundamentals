using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ORM_Fundamentals.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
