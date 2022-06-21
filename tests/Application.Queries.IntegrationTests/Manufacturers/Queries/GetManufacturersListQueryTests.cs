using Application.Manufacturers.Queries;
using Application.Manufacturers.Queries.GetList;
using Domain.Entities;
using FluentAssertions;

namespace ApiTests.Manufacturers.Queries;

[Collection("Queries Test fixture collection")]
public class GetManufacturersListQueryTests
{
    private readonly TestFixture _testFixture;

    public GetManufacturersListQueryTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldGetAllManufacturers()
    {
        // Arrange
        var query = new GetManufacturersListQuery();

        // Act
        var result = await _testFixture.SendAsync(query);

        // Assert
        var expectedCount = await _testFixture.CountAsync<Manufacturer>();
        expectedCount.Should().Be(expectedCount);
        
        result.Select(r => r.Id).Distinct().Count().Should().Be(expectedCount);
        result.Select(r => r.Name).Distinct().Count().Should().Be(expectedCount);
    }
}