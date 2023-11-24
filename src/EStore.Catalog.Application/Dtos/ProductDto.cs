
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EStore.Catalog.Application.Dtos
{
    public  class ProductDto
    {
        [Key]
        public Guid Id { get; set; }


        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get;  set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get;  set; }


        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoryId { get; set; }


        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Active { get;  set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DateTimeCreation { get;  set; }

        public string Image { get;  set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImageUpload { get; set; }


        [DisplayName("Quantidade em Estoque")]
        [Range(1,10000, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtyStock { get;  set; }


        [DisplayName("Altura")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Height { get; set; }

        [DisplayName("Largura")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Width { get; set; }

        [DisplayName("Profundidade")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor minimo de {1} e o máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Profundity { get; set; }

        public IEnumerable<CategoryDto> Categories;

    }
}
