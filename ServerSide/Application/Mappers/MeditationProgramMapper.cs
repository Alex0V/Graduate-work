using Application.DTO.MeditationProgram.Requests;
using Application.DTO.MeditationProgram.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class MeditationProgramMapper
{
    public partial List<MeditationProgramResponse> MeditationProgramsToMeditationProgramResponses(List<MeditationProgram> meditationPrograms);
    public partial MeditationProgramWithContentResponse MeditationProgramToMeditationProgramResponse(MeditationProgram meditationPrograms);
    public partial MeditationProgram MeditationProgramRequestToMeditationProgram(MeditationProgramRequest meditationProgramRequest);
}
