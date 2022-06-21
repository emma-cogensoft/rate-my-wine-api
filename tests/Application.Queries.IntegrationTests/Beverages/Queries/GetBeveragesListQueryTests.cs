using Application.Beverages.Queries;
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
        var query = new GetBeveragesListQuery();

        // Act
        var result = await _testFixture.SendAsync(query);

        // Assert
        var expectedCount = await _testFixture.CountAsync<Beverage>();
        expectedCount.Should().Be(expectedCount);
        
        result.Select(r => r.Id).Distinct().Count().Should().Be(expectedCount);
        result.Select(r => r.Name).Distinct().Count().Should().Be(expectedCount);
        result.Select(r => r.Manufacturer).Distinct().Count().Should().Be(expectedCount);
    }
}