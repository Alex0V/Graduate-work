using Application.DTO.Meditation.Requests;
using Application.DTO.Meditation.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;


namespace Application.Mappers;

[Mapper]
public partial class MeditationMapper
{
    public partial List<MeditationListItemResponse> MeditationListToMeditationResponseList(List<Meditation> meditations);
    public partial MeditationResponse MeditationToMeditationResponse(Meditation meditation);
    public partial Meditation MeditationRequestToMeditation(MeditationRequest meditationRequest);
}
