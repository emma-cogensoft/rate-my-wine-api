using Application.Beverages.Commands.Create;
using Application.Beverages.Queries.GetById;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Beverages.Queries;

[Collection("Test fixture collection")]
public class GetBeverageByIdTests
{
    private readonly TestFixture _testFixture;

    public GetBeverageByIdTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new GetBeverageByIdQuery(0);

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldGetBeverageById()
    {
        // Arrange
        var beverageName = "New Beverage";
        var manufacturerId = 1;
        var expectedManufacturer = await _testFixture.FindAsync<Manufacturer>(manufacturerId);
        Assert.NotNull(expectedManufacturer);
        
        var createdId = await _testFixture.SendAsync(new CreateBeverageCommand
        {
            ManufacturerId = manufacturerId,
            Name = beverageName
        });

        var query = new GetBeverageByIdQuery(createdId);

        // Act
        var item = await _testFixture.SendAsync(query);

        // Assert
        item.Should().NotBeNull();
        item!.BeverageId.Should().Be(createdId);
        item.Name.Should().Be(beverageName);
        item.ManufacturerName.Should().Be(expectedManufacturer!.Name);
    }
}