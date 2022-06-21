using Application.Manufacturers.Commands.Create;
using Application.Manufacturers.Commands.Update;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Manufacturers.Commands;

[Collection("Commands Test fixture collection")]
public class UpdateManufacturerCommandTests
{
    private readonly TestFixture _testFixture;

    public UpdateManufacturerCommandTests(TestFixture testFixture)
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
        var created = await _testFixture.SendAsync(new CreateManufacturerCommand
        {
            Name = "New Manufacturer"
        });

        var command = new UpdateManufacturerCommand
        {
            Id = created.Id,
            Name = "Updated manufacturer name"
        };

        // Act
        await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Manufacturer>(command.Id);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
    }
}