using Application.DTO.Music.Requests;
using Application.DTO.Music.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class MusicMapper
{
    public partial MusicResponse MusicToMusicResponse(Music music);
    public partial Music MusicRequestToMusic(MusicRequest music);
    public partial List<MusicResponse> MusicsToMusicResponses(List<Music> musics);
}
