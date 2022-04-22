using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using NetFlex.DAL.Entities;

namespace NetFlex.BLL.Services
{
    public class VideoService : IVideoService
    {
        
        IUnitOfWork Database { get; set; }

        public VideoService(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<EpisodeDTO> GetEpisode(Guid id)
        {

            if (id == null)
                throw new ValidationException("Эпизод с таким id не найден", "");

            var episode = await Database.Episodes.Get(id);

            if (episode == null)
                throw new ValidationException("Эпизод не найден", "");

            return new EpisodeDTO 
            { 
                Id = episode.Id,
                Title = episode.Title,
                SerialId = episode.SerialId,
                Number = episode.Number,
                VideoLink = episode.VideoLink,

            };
        }

        public async Task<FilmDTO> GetFilm(Guid id)
        {
            if (id == null)
                throw new ValidationException("Фильм с таким id не найден", "");
            var film = await Database.Films.Get(id);
            if (film == null)
                throw new ValidationException("Фильм не найден", "");

            return new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                Duration = film.Duration,
                AgeRating = film.AgeRating,
                UserRating = film.UserRating,
                Description = film.Description,
                VideoLink = film.VideoLink,

            };
        }

        public async Task<SerialDTO> GetSerial(Guid id)
        {
            if (id == null)
                throw new ValidationException("Фильм с таким id не найден", "");
            var serial = await Database.Serials.Get(id);
            if (serial == null)
                throw new ValidationException("Фильм не найден", "");

            return new SerialDTO
            {
                Id = serial.Id,
                Title = serial.Title,
                NumEpisodes = serial.NumEpisodes,
                AgeRating = serial.AgeRating,
                UserRating = serial.UserRating,
                Description = serial.Description,

            };
        }

        public async Task<IEnumerable<EpisodeDTO>> GetEpisodes()
        {
            var episodes = await Database.Episodes.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Episode, EpisodeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Episode>, List<EpisodeDTO>>(episodes);
        }

        public async Task<IEnumerable<FilmDTO>> GetFilms()
        {
            var films = await Database.Films.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Film, FilmDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Film>, List<FilmDTO>>(films);
        }

        public async Task<IEnumerable<SerialDTO>> GetSerials()
        {
            var serials = await Database.Serials.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Serial, SerialDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Serial>, List<SerialDTO>>(serials);
        }

        public async Task UploadEpisode(EpisodeDTO episodeDTO)
        {
            var episodes = await Database.Episodes.GetAll();

            if (episodes.FirstOrDefault(f => f.Title == episodeDTO.Title) != null)
            {
                throw new ValidationException("Епи с таким названием уже существует", "");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeDTO, Episode>());
            var mapper = new Mapper(config);
            var episode = mapper.Map<EpisodeDTO, Episode>(episodeDTO);

           await  Database.Episodes.Create(episode);
        }

        public async Task UploadFilm(FilmDTO filmDTO)
        {
            var films = await Database.Films.GetAll();

            if(films.FirstOrDefault(f => f.Title == filmDTO.Title) != null)
            {
                throw new ValidationException("Фильм с таким названием уже существует", "");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, Film>());
            var mapper = new Mapper(config);
            var film = mapper.Map<FilmDTO, Film>(filmDTO);

            await Database.Films.Create(film);
            Database.Save();
        }

        public async Task UploadSerial(SerialDTO serialDTO)
        {
            var serials = await Database.Serials.GetAll();

            if (serials.FirstOrDefault(f => f.Title == serialDTO.Title) != null)
            {
                throw new ValidationException("Сериал с таким названием уже существует", "");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, Serial>());
            var mapper = new Mapper(config);
            var serial = mapper.Map<SerialDTO, Serial>(serialDTO);

            await Database.Serials.Create(serial);
            Database.Save();
        }

        public async Task UpdateFilm(FilmDTO updatedFilm)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, Film>());
            var mapper = new Mapper(config);
            var film = mapper.Map<FilmDTO, Film>(updatedFilm);

            await Database.Films.Update(film);

            Database.Save();

        }

        public async Task UpdateSerial(SerialDTO updatedSerial)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, Serial>());
            var mapper = new Mapper(config);
            var serial = mapper.Map<SerialDTO, Serial>(updatedSerial);

            await Database.Serials.Update(serial);

            Database.Save();

        }

        public async Task UpdateEpisode(EpisodeDTO updatedSerial)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeDTO, Episode>());
            var mapper = new Mapper(config);
            var episode = mapper.Map<EpisodeDTO, Episode>(updatedSerial);

            await Database.Episodes.Update(episode);

            Database.Save();

        }

        public async Task<IEnumerable<GenreDTO>> GetGenres()
        {
            var genres = await Database.Genres.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(genres);
        }

        public async Task<IEnumerable<GenreVideoDTO>> GetGenres(Guid id)
        {
            var gerners = await Database.GenreVideos.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideo, GenreVideoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GenreVideo>, List<GenreVideoDTO>>(gerners.Where(c => c.ContentId == id));
        }
        public async Task SetGenres(GenreVideoDTO genres)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideoDTO, GenreVideo>()).CreateMapper();
            var res = mapper.Map<GenreVideoDTO, GenreVideo>(genres);

            var allTable = await Database.GenreVideos.GetAll();
            if (allTable.FirstOrDefault(g => g.ContentId == genres.ContentId && g.GenreName == genres.GenreName) == null)
            {
                await Database.GenreVideos.Create(res);
                Database.Save();
            }
        }

        public async Task AddGenre(string genre)
        {
            await Database.Genres.Create(new Genre
            {
                Id = Guid.NewGuid(),
                GenreName = genre
            });

            Database.Save();
        }

        public async Task RemoveGenre(Guid id)
        {
            await Database.Genres.Delete(id);
            Database.Save();
        }

        public async Task UpdateGenre(GenreDTO editedGenre)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>());
            var mapper = new Mapper(config);
            var temp = mapper.Map<GenreDTO, Genre>(editedGenre);

            var g = await Database.Genres.Get(editedGenre.Id);
            g.GenreName = temp.GenreName;
            await Database.Genres.Update(g);

            Database.Save();

        }

		public async Task RemoveFilm(Guid id)
		{
            await Database.Films.Delete(id);
            Database.Save();
        }

		public async Task RemoveSerial(Guid id)
		{
            await Database.Serials.Delete(id);
            Database.Save();
        }

		public async Task RemoveEpisode(Guid id)
		{
            await Database.Episodes.Delete(id);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }

		public async Task TakeAwayGenres(string id, List<string> genres)
		{
            var genresVideos = await Database.GenreVideos.GetAll();

            foreach (var item in genres)
            {
                await Database.GenreVideos.Delete(genresVideos
                    .FirstOrDefault(g => g.GenreName == item && g.ContentId == Guid.Parse(id)).Id );
            }
            Database.Save();

        }
    }
}
