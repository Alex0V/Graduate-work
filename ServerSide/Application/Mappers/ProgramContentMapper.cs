using Application.DTO.ProgramContent.Requests;
using Application.DTO.ProgramContent.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class ProgramContentMapper
{
    public partial List<ProgramContentResponse> ProgramContentsToProgramContentsResponse(List<ProgramContent> programContent);
    public partial ProgramContent ProgramContentRequestToProgramContent(ProgramContentRequest programContentRequest);
}
