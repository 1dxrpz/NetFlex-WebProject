using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFlex.BLL.ModelsDTO;

namespace NetFlex.BLL.Interfaces
{
    public interface IVideoService
    {
        void UploadFilm(FilmDTO filmDTO);
        void UploadEpisode(EpisodeDTO episodeDTO);
        void UploadSerial(SerialDTO serialDTO);
        FilmDTO GetFilm(Guid id);
        SerialDTO GetSerial(Guid id);
        EpisodeDTO GetEpisode(Guid id);
        IEnumerable<FilmDTO> GetFilms();
        IEnumerable<SerialDTO> GetSerials();
        IEnumerable<EpisodeDTO> GetEpisodes();

        void AddGenre (string genre);
        IEnumerable<GenreDTO> GetGenres();
        IEnumerable<GenreVideoDTO> GetGenres(Guid id);
        void SetGenres(GenreVideoDTO genres);
        void Dispose();
    }
}
