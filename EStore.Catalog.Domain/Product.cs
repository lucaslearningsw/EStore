using EStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateTimeCreation { get; private set; }
        public string Image { get; private set; }
        public int QtyStock { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, string description, bool active, decimal price, Guid categoryId, DateTime dateCreation, string image)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            DateTimeCreation = dateCreation;
            Image = image;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;


        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            QtyStock -= quantity;
        }

        public void ReplaceStock(int quantity)
        {
            QtyStock += quantity;
        }

        public bool HasStock(int quantity)
        {
            return QtyStock >= quantity;
        }

        public void Validate()
        { 

        }
          
        
    }

    public class Category : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

    }
}
