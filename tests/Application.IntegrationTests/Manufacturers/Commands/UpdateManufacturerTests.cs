using Application.Manufacturers.Commands.Create;
using Application.Manufacturers.Commands.Update;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Manufacturers.Commands;

[Collection("Test fixture collection")]
public class UpdateManufacturerTests
{
    private readonly TestFixture _testFixture;

    public UpdateManufacturerTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }
        
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new UpdateManufacturerCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task ShouldUpdateManufacturer()
    {
        // Arrange
        var createdId = await _testFixture.SendAsync(new CreateManufacturerCommand
        {
            Name = "New Manufacturer"
        });

        var command = new UpdateManufacturerCommand
        {
            Id = createdId,
            Name = "Updated manufacturer name"
        };

        // Act
        await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Manufacturer>(createdId);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}