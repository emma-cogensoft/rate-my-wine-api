using Application.Manufacturers.Commands.Create;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Manufacturers.Commands;

[Collection("Commands Test fixture collection")]
public class CreateManufacturerCommandTests
{
    private readonly TestFixture _testFixture;

    public CreateManufacturerCommandTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }
    
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateManufacturerCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldCreateManufacturer()
    {
        // Arrange
        var command = new CreateManufacturerCommand
        {
            Name = "New Manufacturer"
        };

        // Act
        var result = await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Manufacturer>(result.Id);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}