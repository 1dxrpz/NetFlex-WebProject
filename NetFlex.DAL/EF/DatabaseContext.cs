using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetFlex.DAL.EF
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<GenreVideo> GenreVideos { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var film1 = Guid.NewGuid();
            var film2 = Guid.NewGuid();
            var film3 = Guid.NewGuid();
            var film4 = Guid.NewGuid();
            var film5 = Guid.NewGuid();
            var film6 = Guid.NewGuid();
            var film7 = Guid.NewGuid();
            var film8 = Guid.NewGuid();
            var film9 = Guid.NewGuid();
            var film10 = Guid.NewGuid();

            var serial1 = Guid.NewGuid();
            var serial2 = Guid.NewGuid();
            var serial3 = Guid.NewGuid();
            var serial4 = Guid.NewGuid();
            var serial5 = Guid.NewGuid();
            var serial6 = Guid.NewGuid();
            var serial7 = Guid.NewGuid();
            var serial8 = Guid.NewGuid();

            builder.Entity<GenreVideo>().HasData(
                new GenreVideo[]
                {
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial1
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial2
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial3
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial4
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial5
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial6
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial7
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = serial8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = serial8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = serial8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = serial8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = serial8
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film1
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film1
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film2
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film2
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film3
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film3
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film4
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film4
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film5
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film5
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film6
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film6
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film7
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film7
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film8
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film8
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film9
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film9
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film9
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film9
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film9
                    },

                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Фантастика",
                        ContentId = film10
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Ужасы",
                        ContentId = film10
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Триллер",
                        ContentId = film10
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Драма",
                        ContentId = film10
                    },
                    new GenreVideo{
                        Id = Guid.NewGuid(),
                        GenreName = "Детектив",
                        ContentId = film10
                    },



                });

            builder.Entity<Genre>().HasData(
                new Genre[]
                {
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Комедия"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Мультфильм"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Ужасы"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Фантастика"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Триллер"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Боевик"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Мелодрама"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Детектив"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Приключение"},
                    new Genre{ Id = Guid.NewGuid(), GenreName = "Аниме"},
                });

            builder.Entity<Film>().HasData(
            new Film[]
            {
                new Film {
                    Id= film1,
                    Title ="Побег из Шоушенка",
                    Poster="https://upload.wikimedia.org/wikipedia/ru/thumb/d/de/Movie_poster_the_shawshank_redemption.jpg/317px-Movie_poster_the_shawshank_redemption.jpg",
                    Duration=142,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Aмериканский художественный фильм-драма 1994 года, снятый режиссёром Фрэнком Дарабонтом по его же сценарию, и рассказывающий историю Энди Дюфрейна, незаслуженно приговорённого к пожизненному заключению и пробывшего в заключении почти 20 лет. Основой сюжета послужила повесть Стивена Кинга «Рита Хейуорт и спасение из Шоушенка». Главные роли сыграли Тим Роббинс и Морган Фримен",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film2,
                    Title ="Бегущий по лезвию 2049",
                    Poster = "https://m.media-amazon.com/images/I/A1cLrVccuTL._AC_SL1500_.jpg",
                    Duration=163,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Действие фильма происходит в футуристическом Лос-Анджелесе, где рядом с обычными людьми сосуществуют искусственные создания — «репликанты». Главный герой, полицейский-репликант Кей, случайно вскрывает старый секрет, способный нарушить существующий порядок, и вынужден разыскивать Рика Декарда, героя первого фильма. ",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film3,
                    Title ="Начало",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/thumb/b/bc/Poster_Inception_film_2010.jpg/318px-Poster_Inception_film_2010.jpg",
                    Duration=148,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Доминик Кобб и Артур — «извлекатели»: они занимаются корпоративным шпионажем, используя экспериментальные военные технологии, чтобы проникнуть в подсознание своих «целей» и извлечь информацию через общий мир снов. Их последняя цель, Сайто, рассказывает, что устроил встречу, чтобы проверить: сможет ли Кобб выполнить кажущуюся невозможной работу — внедрение идеи в подсознание человека, или «начало». Сайто хочет, чтобы Кобб убедил Роберта Фишера, сына больного конкурента Сайто, Мориса Фишера, развалить компанию его отца. Взамен Сайто обещает «всего одним звонком» помочь Коббу, над которым «висит» ложное обвинение в убийстве жены, легально вернуться в США, где остались его дети. ",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film4,
                    Title ="Назад в будущее",
                    Poster = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/21b866100905361.5f130219321ac.jpg",
                    Duration=116,
                    AgeRating=12,
                    UserRating=0,
                    Description ="Марти Макфлай — обычный семнадцатилетний американский подросток, живущий в 1985 году в неблагополучной семье Макфлаев в городке Хилл-Вэлли (штат Калифорния). Его отец Джордж постоянно терпит издевательства и насмешки своего шефа Биффа Таннена, а мать Лоррейн — алкоголичка с избыточным весом. Утром 25 октября 1985 года Марти по дороге в школу заходит домой к своему другу-учёному, доктору Эмметту Брауну по прозвищу Док, но самого его не застаёт. Док звонит Марти и просит встретиться в 1:15 ночи на автостоянке у торгового центра «Две сосны», дабы показать ему нечто удивительное.",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film5,
                    Title ="Унесённые призраками",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/6/61/Spirited_away.jpg",
                    Duration=163,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Отец Акио, мать Юко и их десятилетняя дочь Тихиро переезжают в новый дом, расположенный где-то в глубинке Японии. Перепутав дорогу к новому дому и проехав через странный лес, они попадают в тупик: останавливаются перед высокой стеной, в которой темнеет вход. Войдя туда и проследовав по длинному тёмному туннелю, они попадают в здание, похожее на вокзал, выйдя из которого, оказываются в пустующем городке, почти полностью состоящем из пустующих ресторанов. Нигде нет ни души.",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film6,
                    Title ="Шоу Трумана",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/c/cd/Trumanshow.jpg",
                    Duration=103,
                    AgeRating=12,
                    UserRating=0,
                    Description ="Труман Бёрбанк — обычный человек, работающий страховым агентом и живущий обычной жизнью. Однако он не знает, что за каждым его движением наблюдают многочисленные скрытые камеры, а его жизнь круглосуточно передаётся в прямом эфире по всему миру. Родина Трумана — город Сихэвэн (Seahaven, дословно – «Морская гавань») на острове вблизи материка — на самом деле искусно выполненные декорации, а всё население — нанятые актёры. Исполнительный продюсер «Шоу Трумана», Кристоф, с помощью своей команды может даже изменять погоду в городе с помощью технологий под огромным куполом киностудии. ",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film7,
                    Title ="1+1",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/b/b9/Intouchables.jpg",
                    Duration=112,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Парализованный богатый аристократ Филипп, ставший инвалидом после того, как разбился на параплане, ищет себе помощника, который должен за ним ухаживать. Одного из кандидатов, чернокожего Дрисса, работа не интересует — ему нужен формальный письменный отказ, чтобы продолжать получать пособие по безработице.",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

                new Film {
                    Id= film8,
                    Title ="V — значит вендетта",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/a/ae/V_For_Vendetta_2006_Poster_01.jpg",
                    Duration=132,
                    AgeRating=18,
                    UserRating=0,
                    Description ="Во время комендантского часа поздним вечером 4 ноября неизвестного года человек, носящий маску Гая Фокса и называющий себя «V» («Ви»), спасает из рук Службы Безопасности Norsefire (в фильме её сотрудники именуются Пальцами) ассистентку британского телеканала British Television Network (BTN) Иви Хэммонд. V сообщает Иви, что он «музыкант» и приглашает её послушать его «выступление» на крышу здания около центрального уголовного суда Лондона — Олд-Бейли.",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },


                new Film {
                    Id= film9,
                    Title ="Властелин колец: Две крепости",
                    Poster = "https://upload.wikimedia.org/wikipedia/ru/f/f0/The_Lord_of_the_Rings._The_Two_Towers_%E2%80%94_movie.jpg",
                    Duration=235,
                    AgeRating=12,
                    UserRating=0,
                    Description ="Фродо с Сэмом продолжают путь в Мордор. Фродо видит в ночных кошмарах Гэндальфа, упавшего вместе с Балрогом на дно бездны. Хоббиты заблудились в скалистой местности. Ночью они захватывают в плен преследовавшего их Голлума. Он соглашается отвести героев в Мордор. Саруман после общения с Сауроном посредством палантира посылает отряды урук-хай и горцев Дунланда на земли Рохана.",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },


                new Film {
                    Id= film10,
                    Title ="Звёздные войны. Эпизод V: Империя наносит ответный удар",
                    Poster = "https://www.teahub.io/photos/full/257-2575326_star-wars-the-empire-strikes-back-star-wars.jpg",
                    Duration=124,
                    AgeRating=16,
                    UserRating=0,
                    Description ="Гражданская война продолжается. Несмотря на уничтожение «Звезды смерти», Галактическая Империя захватила базу повстанцев на планете Явин IV и продолжает поиски мятежников. Альянс повстанцев устраивает новую базу на далёкой замёрзшей планете Хот, на самом краю Галактики. Дарт Вейдер лично руководит поиском повстанцев. По его приказу во все уголки Галактики рассылаются зонды-разведчики. ",
                    VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4" },

            });

            builder.Entity<Serial>().HasData(
                new Serial[]
                {
                    new Serial{ 
                        Id= serial8, 
                        Title="Сверхъестественное",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/c2c45ca9-0270-4bb2-bb82-5de3f01effbc/300x450",
                        NumEpisodes=24,
                        AgeRating=16,
                        UserRating=0,
                        Description="Братья Винчестеры стараются не выпустить демонов. Фантастический сериал, вдохновленный «Сумеречной зоной»",
                    },

                    new Serial{
                        Id= serial1,
                        Title="Гравити Фолз",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/04954219-061a-4646-a7d6-054fdc34b053/300x450",
                        NumEpisodes=48,
                        AgeRating=12,
                        UserRating=0,
                        Description="Близнецы проводят каникулы у странного прадядюшки. Тайны и аномалии в захватывающем мультсериале Алекса Хирша",
                    },

                    new Serial{
                        Id= serial2,
                        Title="Во все тяжкие",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/1900788/fb35416f-3b0d-4b96-bc65-cf6923f9e329/300x450",
                        NumEpisodes=34,
                        AgeRating=18,
                        UserRating=0,
                        Description="Умирающий учитель химии начинает варить мет ради благополучия семьи. Выдающийся драматический сериал 2010-х",
                    },

                    new Serial{
                        Id= serial3,
                        Title="Очень странные дела",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/4639b97f-1ff6-4f63-b7f6-02ea1a14f553/300x450",
                        NumEpisodes=12,
                        AgeRating=16,
                        UserRating=0,
                        Description="1980-е годы, тихий провинциальный американский городок. Благоприятное течение местной жизни нарушает загадочное исчезновение подростка по имени Уилл.",
                    },

                    new Serial{
                        Id= serial4,
                        Title="Шерлок",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/1629390/f28c1ea2-47b0-49d5-b11c-9608744f0233/300x450",
                        NumEpisodes=64,
                        AgeRating=12,
                        UserRating=0,
                        Description="Адаптация книг Артура Конан Дойля о детективе Шерлоке Холмсе и его напарнике Джоне Ватсоне, в которой действие перенесено в XXI век",
                    },

                    new Serial{
                        Id= serial5,
                        Title="Токийский гуль",
                        Poster="https://animego.org/media/cache/thumbs_250x350/upload/anime/images/5a662e7da753f.jpg",
                        NumEpisodes=12,
                        AgeRating=16,
                        UserRating=0,
                        Description="История данного сериала пойдет про гулей и борьбу с ними. Гуль – это некое животное, которое питается людьми, и сейчас все Токио просто кишит ними.",
                    },

                    new Serial{
                        Id= serial6,
                        Title="Игра престолов",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/dd78edfd-6a1f-486c-9a86-6acbca940418/300x450",
                        NumEpisodes=1000,
                        AgeRating=18,
                        UserRating=0,
                        Description="Семь Королевств борются за Железный трон. Самый масштабный и обсуждаемый сериал 2010-х годов",
                    },

                    new Serial{
                        Id= serial7,
                        Title="Доктор Стоун",
                        Poster="https://avatars.mds.yandex.net/get-kinopoisk-image/1773646/54aae4e5-62b8-4572-8f97-3761743be082/300x450",
                        NumEpisodes=24,
                        AgeRating=16,
                        UserRating=0,
                        Description="Друзья пытаются оживить окаменевшее человечество, но у них есть противник. Сай-фай-аниме о борьбе идеологий",
                    },
                });

            builder.Entity<Episode>().HasData(
                new Episode[]
                {
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial1,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial1,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial1,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial2,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial2,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial2,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial3,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial3,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial3,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial4,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial4,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial4,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial5,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial5,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial5,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial6,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial6,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial6,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial7,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial7,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial7,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },

                     new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial8,
                        Duration = 24,
                        Number = 1,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial8,
                        Duration = 24,
                        Number = 2,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                    new Episode
                    {
                        Id = Guid.NewGuid(),
                        Title = "Красный эпизод",
                        PreviewVideo ="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/Netflix%20icon.svg",
                        SerialId = serial8,
                        Duration = 24,
                        Number = 3,
                        VideoLink="https://raw.githubusercontent.com/1dxrpz/video-player-test-js/main/videos/Blend%20S%20OP%20Opening%E3%80%8CUHD%2060FPS%E3%80%8D.mp4",
                    },
                });
        }
    }
}