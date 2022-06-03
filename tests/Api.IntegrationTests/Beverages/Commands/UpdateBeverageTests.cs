using Application.Beverages.Commands;
using Application.Beverages.Commands.Create;
using Application.Beverages.Commands.Update;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Beverages.Commands;

[Collection("Test fixture collection")]
public class UpdateBeverageTests
{
    private readonly TestFixture _testFixture;

    public UpdateBeverageTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }
    
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new UpdateBeverageCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task ShouldUpdateBeverage()
    {
        // Arrange
        var created = await _testFixture.SendAsync(new CreateBeverageCommand
        {
            Name = "New Beverage"
        });

        var command = new UpdateBeverageCommand
        {
            Id = created.Id,
            Name = "Updated beverage name"
        };

        // Act
        await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Beverage>(command.Id);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}