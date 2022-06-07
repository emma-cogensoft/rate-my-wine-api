using Application.Reviews.Commands.Create;
using Application.Reviews.Commands.Update;
using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;

namespace ApiTests.Reviews.Commands;

[Collection("Test fixture collection")]
public class UpdateReviewTests
{
    private readonly TestFixture _testFixture;

    public UpdateReviewTests(TestFixture testFixture)
    {
        _testFixture = testFixture;
    }

    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new UpdateReviewCommand();

        await FluentActions.Invoking(() =>
            _testFixture.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task ShouldUpdateReview()
    {
        // Arrange
        var created = await _testFixture.SendAsync(new CreateReviewCommand
        {
            BeverageId = 1,
            Rating = new Rating(2),
            ReviewText = "This is some review text"
        });

        var command = new UpdateReviewCommand
        {
            Id = created.Id,
            BeverageId = 1,
            Rating = new Rating(4),
            ReviewText = "This is some review text which has been updated"
        };

        // Act
        await _testFixture.SendAsync(command);

        // Assert
        var item = await _testFixture.FindAsync<Review>(command.Id);

        item.Should().NotBeNull();
        item!.Rating.Should().Be(command.Rating);
        item.ReviewText.Should().Be(command.ReviewText);
        item.BeverageId.Should().Be(command.BeverageId);
    }
}