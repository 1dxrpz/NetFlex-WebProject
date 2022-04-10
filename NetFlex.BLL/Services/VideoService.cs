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

        public EpisodeDTO GetEpisode(Guid id)
        {

            if (id == null)
                throw new ValidationException("Эпизод с таким id не найден", "");

            var episode = Database.Episodes.Get(id);

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

        public FilmDTO GetFilm(Guid id)
        {
            if (id == null)
                throw new ValidationException("Фильм с таким id не найден", "");
            var film = Database.Films.Get(id);
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

        public SerialDTO GetSerial(Guid id)
        {
            if (id == null)
                throw new ValidationException("Фильм с таким id не найден", "");
            var serial = Database.Serials.Get(id);
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

        public IEnumerable<EpisodeDTO> GetEpisodes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Episode, EpisodeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Episode>, List<EpisodeDTO>>(Database.Episodes.GetAll());
        }

        public IEnumerable<FilmDTO> GetFilms()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Film, FilmDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Film>, List<FilmDTO>>(Database.Films.GetAll());
        }

        public IEnumerable<SerialDTO> GetSerials()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Serial, SerialDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Serial>, List<SerialDTO>>(Database.Serials.GetAll());
        }

        public void UploadEpisode(EpisodeDTO episodeDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeDTO, Episode>());
            var mapper = new Mapper(config);
            var episode = mapper.Map<EpisodeDTO, Episode>(episodeDTO);

            Database.Episodes.Create(episode);
            Database.Save();
        }

        public void UploadFilm(FilmDTO filmDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, Film>());
            var mapper = new Mapper(config);
            var film = mapper.Map<FilmDTO, Film>(filmDTO);

            Database.Films.Create(film);
            Database.Save();
        }

        public void UploadSerial(SerialDTO serialDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, Serial>());
            var mapper = new Mapper(config);
            var serial = mapper.Map<SerialDTO, Serial>(serialDTO);

            Database.Serials.Create(serial);
            Database.Save();
        }

        public IEnumerable<GenreDTO> GetGenres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(Database.Genres.GetAll());
        }

        public IEnumerable<GenreVideoDTO> GetGenres(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideo, GenreVideoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GenreVideo>, List<GenreVideoDTO>>(Database.GenreVideos.GetAll().Where(c => c.ContentId == id));
        }

        public void SetGenres(GenreVideoDTO genres)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideoDTO, GenreVideo>()).CreateMapper();
            var res = mapper.Map<GenreVideoDTO, GenreVideo>(genres);

            Database.GenreVideos.Create(res);
            Database.Save();
        }

        public void AddGenre(string genre)
        {
            Database.Genres.Create(new Genre
            {
                Id = Guid.NewGuid(),
                GenreName = genre
            });

            Database.Save();
        }

        public void RemoveGenre(Guid id)
        {
            Database.Genres.Delete(id);
            Database.Save();
        }

        public void UpdateGenre(GenreDTO editedGenre)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>());
            var mapper = new Mapper(config);
            var temp = mapper.Map<GenreDTO, Genre>(editedGenre);

            var g = Database.Genres.Get(editedGenre.Id);
            g = temp;

            Database.Save();

        }
        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
