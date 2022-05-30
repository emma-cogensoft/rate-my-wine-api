using Application.Manufacturers.Commands.Create;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using static ApiTests.TestFixture;

namespace ApiTests.Manufacturers.Commands;

public class CreateManufacturerTests : IClassFixture<TestFixture>
{
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateManufacturerCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
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
        var result = await SendAsync(command);

        // Assert
        var item = await FindAsync<Manufacturer>(result.Id);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}