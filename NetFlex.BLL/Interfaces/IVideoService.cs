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
        Task UploadFilm(FilmDTO filmDTO);
        Task UploadEpisode(EpisodeDTO episodeDTO);
        Task UploadSerial(SerialDTO serialDTO);

        Task<FilmDTO> GetFilm(Guid id);
        Task<SerialDTO> GetSerial(Guid id);
        Task<EpisodeDTO> GetEpisode(Guid id);

        Task<IEnumerable<FilmDTO>> GetFilms();
        Task<IEnumerable<SerialDTO>> GetSerials();
        Task<IEnumerable<EpisodeDTO>>GetEpisodes();

        Task UpdateFilm(FilmDTO updatedFilm);
        Task UpdateSerial(SerialDTO updatedSerial);
        Task UpdateEpisode(EpisodeDTO updatedEpisode);

        Task AddGenre (string genre);
        Task<IEnumerable<GenreDTO>> GetGenres();
        Task<IEnumerable<GenreVideoDTO>> GetGenres(Guid id);
        Task SetGenres(GenreVideoDTO genres);
        Task RemoveGenre(Guid id);
        Task UpdateGenre(GenreDTO editedGenre);
        void Dispose();
    }
}
