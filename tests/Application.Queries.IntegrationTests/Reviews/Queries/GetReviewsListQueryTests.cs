using Application.Reviews.Queries;
using Domain.Entities;
using FluentAssertions;

namespace ApiTests.Reviews.Queries;

[Collection("Queries Test fixture collection")]
public class GetReviewsListQueryTests
{
    private readonly TestFixture _testFixture;

    public GetReviewsListQueryTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldGetAllReviews()
    {
        // Arrange
        var query = new GetReviewsListQuery();

        // Act
        var result = await _testFixture.SendAsync(query);

        // Assert
        var expectedCount = await _testFixture.CountAsync<Review>();
        expectedCount.Should().Be(expectedCount);
        
        result.Select(r => r.Id).Distinct().Count().Should().Be(expectedCount);
        result.Select(r => r.Rating).Distinct().Count().Should().Be(expectedCount);
    }
}