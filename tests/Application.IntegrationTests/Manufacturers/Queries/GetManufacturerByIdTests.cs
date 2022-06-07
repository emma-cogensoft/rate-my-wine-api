using Application.Manufacturers.Queries.GetById;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Manufacturers.Queries;

[Collection("Test fixture collection")]
public class GetManufacturerByIdTests
{
    private readonly TestFixture _testFixture;

    public GetManufacturerByIdTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new GetManufacturerByIdQuery(0);

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldGetManufacturerById()
    {
        // Arrange
        var manufacturerId = 1;
        var expectedManufacturer = await _testFixture.FindAsync<Manufacturer>(manufacturerId);
        Assert.NotNull(expectedManufacturer);

        var query = new GetManufacturerByIdQuery(manufacturerId);

        // Act
        var item = await _testFixture.SendAsync(query);

        // Assert
        item.Should().NotBeNull();
        item!.Id.Should().Be(manufacturerId);
        item.Name.Should().Be(expectedManufacturer!.Name);
    }
}