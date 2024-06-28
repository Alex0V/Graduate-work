using Application.DTO.Meditation.Requests;
using Application.DTO.Meditation.Responses;
using Application.Interfaces.Services;
using Application.Mappers;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using ErrorOr;

namespace Infrastructure.Services;

public class MeditationService : IMeditationService
{
    private readonly IMeditationRepository _meditationRepository;
    private readonly IStorageService _storageService;
    private readonly MeditationMapper _meditationMapper;

    public MeditationService(
        IMeditationRepository meditationRepository, 
        MeditationMapper meditationMapper,
        IStorageService storageService)
    {
        _meditationRepository = meditationRepository;
        _meditationMapper = meditationMapper;
        _storageService = storageService;
    }

    public async Task<ErrorOr<List<MeditationListItemResponse>>> GetAllMeditations()
    {
        var response = await _meditationRepository.GetAllAsync();
        if (response == null)
        {
            return Error.NotFound(description: "Meditations not found");
        }

        return _meditationMapper.MeditationListToMeditationResponseList(response);
    }

    public async Task<ErrorOr<MeditationResponse>> GetMeditationById(int id)
    {
        var response = await _meditationRepository.GetByIdAsync(id);
        if (response == null)
        {
            return Error.NotFound(description: "Meditation not found");
        }

        return _meditationMapper.MeditationToMeditationResponse(response);
    }

    // в нас каскадне видалення, після видалення медитації з бд всі повязані записи будуть видалені
    // але файли з повязаними записами не видалються
    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var meditation = await _meditationRepository.GetByIdAsync(id);

        if(meditation == null)
        {
            return Error.NotFound(description: "Meditation not found");
        }
        await _meditationRepository.DeleteByIdAsync(id);

        return Result.Deleted;
    }

    public async Task<ErrorOr<Created>> Add(MeditationRequest request)
    {
        var meditation = _meditationMapper.MeditationRequestToMeditation(request);
        var result = await _storageService.UploadFileAsync(request.File);
        meditation.CreationDate = DateTime.Now;
        meditation.FotoKey = result.FileName;
        meditation.S3UrlFoto = $"https://medi-coursework.s3.eu-west-2.amazonaws.com/{result.FileName}";
        await _meditationRepository.AddAsync(meditation);

        return Result.Created;
    }
}
