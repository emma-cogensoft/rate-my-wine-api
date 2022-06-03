using Application.Beverages.Commands;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Beverages.Commands;

[Collection("Test fixture collection")]
public class CreateBeverageTests
{
    private readonly TestFixture _testFixture;

    public CreateBeverageTests(TestFixture testFixture)
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
        var command = new CreateBeverageCommand
        {
            Name = "New Beverage"
        };

        // Act
        var result = await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Beverage>(result.Id);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}