using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    #region Testes Positivos de produto
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParemeters_ResultObejectsValidState()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", 20, 5, "abcd");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

       /* [Fact(DisplayName = "Create Product With Product Name Alone Parameter.")]
        public void CreateProduct_WithValidParemetersName_ResultObejectsValidState()
        {
            Action action = () => new Product("Eletronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }*/
        #endregion

        #region Testes Negativos de produto 

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidParemetersPrice_ResultException()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", -20, 5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidParemetersStock_ResultException()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", 20, -5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Product(-1, "Detergente", "Detergente da marca X", 20, 5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Name Too Short Parameter")]
        public void CreateProduct_WithNameTooShortParameter_ResultException()
        {
            Action action = () => new Product(1, "Ba", "Detergente da marca X", 20, 5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Name Null Parameter")]
        public void CreateProduct_WithNameNullParameter_ResultException()
        {
            Action action = () => new Product(1, null, "Detergente da marca X", 20, 5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Name Missing Parameter")]
        public void CreateProduct_WithNameMissingParameter_ResultException()
        {
            Action action = () => new Product(1, "", "Detergente da marca X", 20, 5, "abcd");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Image Too Long Parameter")]
        public void CreateProduct_WithImageTooLongParameter_ResultException()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", 20, 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sit amet dolor nisi. Ut sodales, orci ut tempor pharetra, neque tortor fringilla eros, quis dignissim augue purus sed est. Pellentesque ligula eros, maximus eget est in, consequat hendrerit mauris. Aenean lacinia nulla in mi accumsan, a vestibulum est pharetra. Vivamus vitae lectus neque. Praesent sollicitudin massa a rutrum volutpat. Fusce venenatis ante eget erat sollicitudin tempus. Suspendisse sollicitudin, diam id faucibus fermentum, orci felis suscipit lorem, vitae ultricies enim sapien sit amet risus. Phasellus a tellus at nulla laoreet posuere. Curabitur venenatis sollicitudin quam, ut ornare arcu viverra sit amet.\r\n\r\nAliquam id diam ut turpis imperdiet semper eu finibus enim. Suspendisse eget eros a erat efficitur tempus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla malesuada mi ut lorem maximus eleifend. Nulla euismod aliquam massa et mollis. In facilisis pellentesque risus. Cras at urna ornare, tempor nunc in, fringilla neque. Nunc sapien turpis, pellentesque non egestas hendrerit, porta eu quam. Praesent suscipit ultricies nisi. Donec et dolor in velit eleifend commodo imperdiet et purus.\r\n\r\nVestibulum vitae mauris ut tortor sodales blandit. Donec velit augue, pharetra id dui non, vehicula vulputate tellus. In at quam mattis, elementum ex eu, tincidunt sapien. Fusce ut erat id risus condimentum tempus at sed nisi. Morbi malesuada pretium faucibus. Fusce in sem hendrerit, rutrum orci non, pulvinar metus. Morbi ac elit eu nunc efficitur ullamcorper a ut eros. Duis consequat mattis risus, et vestibulum odio euismod eu. Integer sem arcu, commodo eu fringilla ut, ultricies eget urna. Donec vitae.");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Image Null Parameter")]
        public void CreateProduct_WithImageNullParameter_ResultException()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", 20, 5, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, image is required!");
        }

        [Fact(DisplayName = "Create Product With Image Missing Parameter")]
        public void CreateProduct_WithImageMissingParameter_ResultException()
        {
            Action action = () => new Product(1, "Detergente", "Detergente da marca X", 20, 5, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image URL, image is required!");
        }

    }
    #endregion
}