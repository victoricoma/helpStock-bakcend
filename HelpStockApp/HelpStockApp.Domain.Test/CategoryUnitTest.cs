using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    #region Testes Positivos de Categoria
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParemeters_ResultObejectsValidState()
        {
            Action action = () => new Category(1, "Eletronics");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria (Criature of Darkness !! Evil of Moria!! You sehll not pass!!)
        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
    }
    #endregion
}
