using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Core.DomainObjects;

namespace EStore.Catalog.Domain
{
    public class Dimensions
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Profundity{ get; set; }

        public Dimensions(decimal height, decimal width, decimal profundity)
        {
            Validations.ValidateLessThan(height, 1, "O campo altura não pode ser menor ou igual a 0");
            Validations.ValidateLessThan(width, 1, "O campo altura não pode ser menor ou igual a 0");
            Validations.ValidateLessThan(profundity, 1, "O campo profundidade não pode ser menor ou igual a 0");

            Height = height;
            Width = width;
            Profundity = profundity;
        }

        public string FormatedDescription()
        {
            return $"LxAxP: {Width} x {Height} X {Profundity}";
        }

        public override string ToString()
        {
            return FormatedDescription();
        }
    }
}
