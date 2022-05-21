using AutoMapper;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Entities;
using NetFlex.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
       
        IUnitOfWork Database { get; set; }

        public SubscriptionService(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<IEnumerable<SubscriptionDTO>> GetSubs()
        {
            var subs = await Database.Subscriptions.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Subscription, SubscriptionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Subscription>, List<SubscriptionDTO>>(subs);
        }

        public async Task<SubscriptionDTO> GetSub(string id)
        {
            var sub = await Database.Subscriptions.Get(Guid.Parse(id));

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Subscription, SubscriptionDTO>()).CreateMapper();
            return mapper.Map<Subscription, SubscriptionDTO>(sub);
        }

        public async Task Create(SubscriptionDTO subDTO)
        {
            var subs = await Database.Subscriptions.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SubscriptionDTO, Subscription>()).CreateMapper();
            var sub = mapper.Map<SubscriptionDTO, Subscription>(subDTO);

            if(subs.Contains(sub))
                throw new ValidationException("Такой план уже существует");

            await Database.Subscriptions.Create(sub);
            Database.Save();

        }

        public async Task Delete(string id)
        {
            await Database.Subscriptions.Delete(Guid.Parse(id));
            Database.Save();
        }

        public async Task Update(SubscriptionDTO editedSub)
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SubscriptionDTO, Subscription>()).CreateMapper();
            var sub = mapper.Map<SubscriptionDTO, Subscription>(editedSub);

            await Database.Subscriptions.Update(sub);
            Database.Save();
        }

        public async Task<SubscriptionDTO> GetUserSub(string id)
        {
            var userSubs = await Database.UserSubscriptions.GetAll();

            var userSub = userSubs.Where(u => u.Id == Guid.Parse(id)).FirstOrDefault();

            var sub = await Database.Subscriptions.Get(userSub.Id);


            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Subscription, SubscriptionDTO>()).CreateMapper();
            return mapper.Map<Subscription, SubscriptionDTO>(sub);

        }

        public async Task SetSub(string userId, string subId)
        {

            var startDate = DateTime.Now;
            var finishDate = startDate.AddDays(30);

            var newUserSub = new UserSubscription()
            {
                UserId = Guid.Parse(userId),
                SubscriptionId = Guid.Parse(subId),
                StartDate = startDate,
                FinishDate = finishDate
            };

            var userSubs = await Database.UserSubscriptions.GetAll();

            if(userSubs.Contains(newUserSub))
                throw new ValidationException("Пользователь уже подписан. Сначала нужно отменить текущею подписку");

            await Database.UserSubscriptions.Create(newUserSub);
            Database.Save();
        }

        public async Task CancelSub(string userId)
        {
            var userSubs = await Database.UserSubscriptions.GetAll();

            var userSub = userSubs.Where(u => u.Id == Guid.Parse(userId)).FirstOrDefault();

            await Database.UserSubscriptions.Delete(userSub.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
