using PersonalLifeOS.Domain.Finance;
using Xunit;

namespace PersonalLifeOS.UnitTests;

public class ArchitectureSmokeTests
{
    [Fact]
    public void FinanceDomain_CanCreateCategory()
    {
        var category = new Category
        {
            CategoryName = "Food"
        };

        Assert.Equal("Food", category.CategoryName);
    }
}
