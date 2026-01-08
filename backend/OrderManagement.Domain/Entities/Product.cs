using OrderManagement.Domain.Entities.Exceptions;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; private set; }
        [Required]
        public Money Price { get; private set; }
        public string? Description { get; private set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        private Product() { }

        public Product(string name, Money price, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
        }
    }

}
