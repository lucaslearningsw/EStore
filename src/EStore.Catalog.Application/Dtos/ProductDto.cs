
using System.ComponentModel.DataAnnotations;


namespace EStore.Catalog.Application.Dtos
{
    public  class ProductDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Active { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DateTimeCreation { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Image { get;  set; }

        [Range(1,10000, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtyStock { get;  set; }


        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Height { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Width { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Profundity { get; set; }

        public IEnumerable<CategoryDto> Categories;

    }
}
