using Application.Reviews.Commands.Create;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Reviews.Commands;

[Collection("Test fixture collection")]
public class CreateReviewTests
{
    private readonly TestFixture _testFixture;

    public CreateReviewTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }
    
    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateReviewCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ShouldCreateReview()
    {
        // Arrange
        var command = new CreateReviewCommand
        {
            BeverageId = 1,
            Rating = new Rating(2),
            ReviewText = "This is some review text"
        };

        // Act
        var result = await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Review>(result.Id);

        item.Should().NotBeNull();
        item!.Rating.Should().Be(command.Rating);
        item.ReviewText.Should().Be(command.ReviewText);
        item.BeverageId.Should().Be(command.BeverageId);
    }
}