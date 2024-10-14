using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;
using Xunit.Sdk;

namespace HelpStockApp.Domain.Test
{
    #region Testes Positivos de Categoria
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParemeters_ResultObejectsValidState()
        {
            Action action = () => new Product("Placa Mãe", "Placa mãe Asrock steel legend am4", 600, 3, "http://surl.li/ycatry");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParemetersId_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(-1, "Placa Mãe", "Placa mãe Asrock steel legend am4", 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Product With invalid Name")]
        public void CreateProduct_WithNameTooShortParameter_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Pl", "Placa mãe Asrock steel legend am4", 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }
        [Fact(DisplayName = "Create Product With null Name")]
        public void CreateProduct_WithNullName_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, null, "Placa mãe Asrock steel legend am4", 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }
        [Fact(DisplayName = "Create Product With too long image URL")]
        public void CreateProduct_With_Too_Long_Image_URL_ResultException()
        {
            var longImageUrl = "https://www.google.com/search?q=url+com++de+251+caracteres&sca_esv=60dc7b8df89f0db7&sca_upv=1&rlz=1C1GCEU_pt-BRBR1123BR1123&ei=dXPxZta5IvDc5OUP2Jem6Aw&ved=0ahUKEwiWyJKAnNmIAxVwLrkGHdiLCc0Q4dUDCA8&uact=5&oq=url+com++de+251+caracteres&gs_lp=Egxnd3Mtd2l6LXNlcnAiGnVybCBjb20gIGRlIDI1MSBjYXJhY3RlcmVzMggQIRigARjDBEi9D1CuA1jFDXADeAGQAQCYAbIBoAG_BqoBAzAuNrgBA8gBAPgBAZgCCKACoAXCAgoQABiwAxjWBBhHwgIIEAAYgAQYogTCAgQQIRgKmAMAiAYBkAYIkgcDMy41oAesDw&sclient=gws-wiz-serp";
            Action action = () => new Product(1, "Placa Mãe", "Placa mãe Asrock steel legend am4", 600, 3, longImageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }
        [Fact(DisplayName = "Create Product With null image URL")]
        public void CreateProduct_WithNullImageUrl_ResultException()
        {
            Action action = () => new Product(1, "Placa Mãe", "Placa mãe Asrock steel legend am4", 600, 3, null);
            action.Should().Throw<NullReferenceException>();

        }
        [Fact(DisplayName = "Create Product With empty image URL")]
        public void CreateProduct_With_Empty_Image_URL_ResultException()
        {
            var emptyImageUrl = "";
            Action action = () => new Product(1, "Placa Mãe", "Placa mãe Asrock steel legend am4", 600, 3, emptyImageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid URL, URL is required!");
        }
        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_With_Negative_Stock_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Placa Mãe", "Placa mãe Asrock steel legend am4", 600, -3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }
        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_With_Negative_Price_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Placa Mãe", "Placa mãe Asrock steel legend am4", -600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }
        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_With_Empty_Description_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Placa Mãe", "", 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");

        }
        [Fact(DisplayName = "Create Product With Null description")]
        public void CreateProduct_With_Null_Description_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Placa Mãe", null, 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");

        }
        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_With_Short_Description_ResultException()
        {
            var imageUrl = "http://surl.li/ycatry";
            Action action = () => new Product(1, "Placa Mãe", "Pla", 600, 3, imageUrl);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 5 characters!");

        }

    }
    #endregion
}
