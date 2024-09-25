using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos de Produto
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParemeters_ResultObjectsValidState()
        {
            Action action = () => new Product("Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, 5, "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Produto

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParametersId_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(-1, "Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_With_Empty_Description_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Embreagem", "", 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_With_Short_Description_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Embreagem", "", 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With null Name")]
        public void CreateProduct_WithNullName_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, null, "Kit de embreagem Luk para carros 1.4", 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With invalid Name")]
        public void CreateProduct_WithNameTooShortParameter_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Em", "Kit de embreagem Luk para carros 1.4", 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With null image URL")]
        public void CreateProduct_WithNullImageUrl_ResultException()
        {
            Action action = () => new Product(1, "Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, 5, null);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_With_Negative_Price_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Embreagem", "Kit de embreagem Luk para carros 1.4", -800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_With_Negative_Stock_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, -5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With too long image URL")]
        public void CreateProduct_With_Too_Long_Image_URL_ResultException()
        {
            var longImageUrl = "https://www.google.com/search?q=url+com+muito+catacter&oq=url+com+muito+catacter&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIJCAEQIRgKGKABMgkIAhAhGAoYoAHSAQgzMzU0ajBqN6gCALACAA&sourceid=chrome&ie=UTF-8eqweqweqwweeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
            Action action = () => new Product(1, "Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, 5, longImageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Null description")]
        public void CreateProduct_With_Null_Description_ResultException()
        {
            var imageUrl = "https://http2.mlstatic.com/D_NQ_NP_991618-MLB72580269543_102023-O.webp";
            Action action = () => new Product(1, "Embreagem", null, 800.00, 5, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With empty image URL")]
        public void CreateProduct_With_Empty_Image_URL_ResultException()
        {
            var emptyImageUrl = "";
            Action action = () => new Product(1, "Embreagem", "Kit de embreagem Luk para carros 1.4", 800.00, 5, emptyImageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid URL, URL is required!");
        }

        #endregion
    }
}
