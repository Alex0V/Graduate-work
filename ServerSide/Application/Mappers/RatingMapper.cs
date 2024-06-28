using Application.DTO.Rating;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class RatingMapper
{
    public partial Rating RatingRequestToRating(RatingRequest ratingRequest);
    public partial RatingResponse RatingToRatingResponse(Rating rating);
}
