using EStore.Core.DomainObjects;

namespace EStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validations_ValidationWithException()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
            {
                new Product(string.Empty, "Descrição", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem",
                    new Dimensions(height: 2, width: 1, profundity: 2));
            });

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem",
                    new Dimensions(height: 2, width: 1, profundity: 2));
            });

            Assert.Equal("O campo Descrição do produto não pode estar vazio", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, 100, Guid.Empty, DateTime.Now, "Imagem",
                    new Dimensions(height: 2, width: 1, profundity: 2));
            });

            Assert.Equal("O campo Categoria do produto deve ser informado", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, -1221, Guid.NewGuid(), DateTime.Now, "Imagem",
                    new Dimensions(height: 2, width: 1, profundity: 2));
            });

            Assert.Equal("O campo valor do produto não pode ser menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, 10, Guid.NewGuid(), DateTime.Now, "",
                    new Dimensions(height: 2, width: 1, profundity: 2));
            });

            Assert.Equal("O campo Imagem não pode estar vazio", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, 10, Guid.NewGuid(), DateTime.Now, "TEST",
                    new Dimensions(height: 0, width: 1, profundity: 2));
            });

            Assert.Equal("O campo altura não pode ser menor ou igual a 0", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, 10, Guid.NewGuid(), DateTime.Now, "TEST",
                    new Dimensions(height: 1, width: 0, profundity: 2));
            });

            Assert.Equal("O campo altura não pode ser menor ou igual a 0", ex.Message);



            ex = Assert.Throws<DomainException>(() =>
            {
                new Product("Teste", "Descrição", false, 10, Guid.NewGuid(), DateTime.Now, "TEST",
                    new Dimensions(height: 1, width: 1, profundity: 0));
            });

            Assert.Equal("O campo profundidade não pode ser menor ou igual a 0", ex.Message);
        }
    }
}