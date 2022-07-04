using Application.Beverages.Queries.GetList;
using Domain.Entities;
using FluentAssertions;

namespace ApiTests.Beverages.Queries;

[Collection("Queries Test fixture collection")]
public class GetBeveragesListQueryTests
{
    private readonly TestFixture _testFixture;

    public GetBeveragesListQueryTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldGetAllBeverages()
    {
        // Arrange
        var query = new GetListBeveragesQuery();

        // Act
        var result = await _testFixture.SendAsync(query);

        // Assert
        var expectedCount = await _testFixture.CountAsync<Beverage>();
        expectedCount.Should().Be(expectedCount);
        
        result.Select(b => b.Id).Distinct().Count().Should().Be(expectedCount);
        result.Select(b => b.Name).Distinct().Count().Should().Be(expectedCount);
        result.Select(b => b.ManufacturerId).Distinct().Count().Should().Be(expectedCount);
        result.Select(b => b.Manufacturer).Distinct().Count().Should().Be(expectedCount);
    }
}