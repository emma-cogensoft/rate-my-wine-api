﻿using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reviews.Commands;

public class UpdateReviewCommand : IRequest<Review>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Beverage? Beverage { get; set; }
    public string ReviewText { get; set; } = string.Empty;
    public Rating Rating { get; set; }
}