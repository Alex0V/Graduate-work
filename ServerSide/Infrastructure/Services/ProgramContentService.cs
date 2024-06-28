using Application.DTO.ProgramContent.Requests;
using Application.DTO.ProgramContent.Responses;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Interfaces.Repositories;
using ErrorOr;

namespace Infrastructure.Services;

public class ProgramContentService : IProgramContentService
{
    private readonly IProgramContentRepository _programContentRepository;
    private readonly IStorageService _storageService;
    private readonly ProgramContentMapper _programContentMapper;

    public ProgramContentService(IProgramContentRepository programContentRepository,IStorageService storageService, ProgramContentMapper programContentMapper)
    {
        _programContentRepository = programContentRepository;
        _storageService = storageService;
        _programContentMapper = programContentMapper;
    }

    public async Task<ErrorOr<List<ProgramContentResponse>>> GetAllProgramContentByProgramId(int programId)
    {
        var response = await _programContentRepository.GetAllByProgramId(programId);
        if (response == null)
        {
            return Error.NotFound(description: "ProgramContent not found");
        }

        return _programContentMapper.ProgramContentsToProgramContentsResponse(response);
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var programContent = await _programContentRepository.GetByIdAsync(id);

        if (programContent == null)
        {
            return Error.NotFound(description: "programContent not found");
        }
        await _storageService.DeleteFileAsync(programContent.AudioKey);
        await _programContentRepository.DeleteByIdAsync(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Created>> Add(ProgramContentRequest programContentRequest)
    {
        var meditation = _programContentMapper.ProgramContentRequestToProgramContent(programContentRequest);
        var result = await _storageService.UploadFileAsync(programContentRequest.File);
        meditation.AudioKey = result.FileName;
        meditation.S3UrlAudio = $"https://medi-coursework.s3.eu-west-2.amazonaws.com/{result.FileName}";
        await _programContentRepository.AddAsync(meditation);
        return Result.Created;
    }
}
