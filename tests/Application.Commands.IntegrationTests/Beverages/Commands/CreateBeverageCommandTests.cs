using Application.Beverages.Commands.Create;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Beverages.Commands;

[Collection("Commands Test fixture collection")]
public class CreateBeverageCommandTests
{
    private readonly TestFixture _testFixture;

    public CreateBeverageCommandTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }
    
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateBeverageCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldCreateBeverage()
    {
        // Arrange
        var manufacturerId = 1;
        var beverageName = "New Beverage";
        var command = new CreateBeverageCommand
        {
            ManufacturerId = manufacturerId,
            Name = beverageName
        };

        // Act
        var result = await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Beverage>(result);

        item.Should().NotBeNull();
        item!.Name.Should().Be(beverageName);
        item.ManufacturerId.Should().Be(manufacturerId);
    }
}