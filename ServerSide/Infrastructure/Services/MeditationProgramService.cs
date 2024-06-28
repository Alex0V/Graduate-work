using Application.DTO.MeditationProgram.Requests;
using Application.DTO.MeditationProgram.Responses;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Interfaces.Repositories;
using ErrorOr;

namespace Infrastructure.Services;

public class MeditationProgramService : IMeditationProgramService
{
    private readonly IMeditationProgramRepository _meditationProgramRepository;
    private readonly IStorageService _storageService;
    private readonly MeditationProgramMapper _meditationProgramMapper;

    public MeditationProgramService(
        IMeditationProgramRepository meditationProgramRepository, 
        IStorageService storageService, 
        MeditationProgramMapper meditationProgramMapper)
    {
        _meditationProgramRepository = meditationProgramRepository;
        _storageService = storageService;
        _meditationProgramMapper = meditationProgramMapper;
    }

    public async Task<ErrorOr<List<MeditationProgramResponse>>> GetAllMeditationPrograms()
    {
        var response = await _meditationProgramRepository.GetAllAsync();
        if (response == null)
        {
            return Error.NotFound(description: "Program not found");
        }

        return _meditationProgramMapper.MeditationProgramsToMeditationProgramResponses(response);
    }

    public async Task<ErrorOr<MeditationProgramWithContentResponse>> GetMeditationProgramWithContenById(int id)
    {
        var response = await _meditationProgramRepository.GetWtihContentById(id);
        if (response == null)
        {
            return Error.NotFound(description: "Program not found");
        }

        return _meditationProgramMapper.MeditationProgramToMeditationProgramResponse(response);
    }

    public async Task<ErrorOr<List<MeditationProgramResponse>>> GetListMeditationProgramsByIds(List<int> ids)
    {
        var response = await _meditationProgramRepository.GetAllByIdsAsync(ids);
        if (response == null)
        {
            return Error.NotFound(description: "Program not found");
        }

        return _meditationProgramMapper.MeditationProgramsToMeditationProgramResponses(response);
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var meditation = await _meditationProgramRepository.GetByIdAsync(id);

        if (meditation == null)
        {
            return Error.NotFound(description: "Program not found");
        }
        await _meditationProgramRepository.DeleteByIdAsync(id);

        return Result.Deleted;
    }

    public async Task<ErrorOr<Created>> Add(MeditationProgramRequest meditationRequest)
    {
        var meditation = _meditationProgramMapper.MeditationProgramRequestToMeditationProgram(meditationRequest);
        var result = await _storageService.UploadFileAsync(meditationRequest.File);
        meditation.FotoKey = result.FileName;
        meditation.S3UrlFoto = $"https://medi-coursework.s3.eu-west-2.amazonaws.com/{result.FileName}";
        await _meditationProgramRepository.AddAsync(meditation);
        return Result.Created;
    }
}
