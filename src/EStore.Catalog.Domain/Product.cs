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

        public Dimensions Dimensions { get; private set; }



        public Product(string name, string description, bool active, decimal price, Guid categoryId, DateTime dateCreation, string image, Dimensions dimensions)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            DateTimeCreation = dateCreation;
            Image = image;
            Dimensions = dimensions;
            Validate();
            
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
            Validations.ValidateIsNull(description,"O campo descrição do Produto não pode estar vazio");
            Description = description;
        }

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            if (!HasStock(quantity)) throw new DomainException("Estoque insuficiente");
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
            Validations.ValidateIsNull(Name, "O campo Nome do produto não pode estar vazio");
            Validations.ValidateIsNull(Description, "O campo Descrição do produto não pode estar vazio");
            Validations.ValidateIsEqual(CategoryId,Guid.Empty, "O campo Categoria do produto deve ser informado");
            Validations.ValidateLessThan(Price,1,"O campo valor do produto não pode ser menor igual a 0");
            Validations.ValidateIsNull(Image, "O campo Imagem não pode estar vazio");
        }
          
        
    }
}
