using Application.DTO.Music.Requests;
using Application.DTO.Music.Responses;
using ErrorOr;

namespace Application.Interfaces.Services;

public interface IMusicService
{
    Task<ErrorOr<List<MusicResponse>>> GetAllUserMusic(string userName);
    Task<ErrorOr<Success>> AddMusic(MusicRequest request);
    Task<ErrorOr<Success>> RemoveMusic(int id);
}
