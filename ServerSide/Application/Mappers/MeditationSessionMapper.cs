using Application.DTO.MeditationSession.Requests;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class MeditationSessionMapper
{
    public partial MeditationSession MeditationSessionRequestToMeditationSession(MeditationSessionRequest meditationSessionRequest);
}
