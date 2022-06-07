using Application.Reviews.Queries.GetById;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Reviews.Queries;

[Collection("Test fixture collection")]
public class GetReviewsByIdTests
{
    private readonly TestFixture _testFixture;

    public GetReviewsByIdTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new GetReviewByIdQuery(0);

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldGetReviewById()
    {
        // Arrange
        var reviewId = 1;
        var expectedReview = await _testFixture.FindAsync<Review>(reviewId);
        Assert.NotNull(expectedReview);

        var query = new GetReviewByIdQuery(reviewId);

        // Act
        var item = await _testFixture.SendAsync(query);

        // Assert
        item.Should().NotBeNull();
        item!.Id.Should().Be(reviewId);
        item.Rating.Should().Be(expectedReview!.Rating);
    }
}