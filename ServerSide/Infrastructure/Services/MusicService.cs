using Application.DTO.Music.Responses;
using Application.DTO.Music.Requests;
using Application.Interfaces.Services;
using Application.Mappers;
using Domain.Interfaces.Repositories;
using ErrorOr;
using Application.Interfaces;

namespace Infrastructure.Services;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;
    private readonly IStorageService _storageService;
    private readonly IUserRepository _userRepository;
    private readonly MusicMapper _musicMapper;

    public MusicService(IMusicRepository musicRepository, IStorageService storageService, MusicMapper musicMapper, IUserRepository userRepository)
    {
        _musicRepository = musicRepository;
        _storageService = storageService;
        _musicMapper = musicMapper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<MusicResponse>>> GetAllUserMusic(string userName)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userName);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        var response = await _musicRepository.GetAllByUserIdAsync(user.Id);
        if (!response.Any())
        {
            return Error.NotFound(description: "Music not found");
        }

        return _musicMapper.MusicsToMusicResponses(response);
    }

    public async Task<ErrorOr<Success>> AddMusic(MusicRequest request)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.userName);
        if (user is null)
        {
            return Error.NotFound(description: "Music not found");
        }
        var music = _musicMapper.MusicRequestToMusic(request);
        music.UserId = user.Id;
        var result = await _storageService.UploadFileAsync(request.File);
        music.AudioKey = result.FileName;
        music.S3UrlAudio = $"https://medi-coursework.s3.eu-west-2.amazonaws.com/{result.FileName}";
        await _musicRepository.AddAsync(music);
        return Result.Success;
    }
    public async Task<ErrorOr<Success>> RemoveMusic(int id)
    {
        var medit_result = await _musicRepository.GetByIdAsync(id);
        if (medit_result is null)
        {
            return Error.NotFound(description: "Music not found");
        }
        //await _storageService.DeleteFileAsync(medit_result.AudioKey);
        await _musicRepository.DeleteByIdAsync(id);
        return Result.Success;
    }
}
