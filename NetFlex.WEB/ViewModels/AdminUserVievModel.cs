﻿using NetFlex.DAL.Enums;

namespace NetFlex.WEB.ViewModels
{
    public class AdminUserVievModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool LockoutEnabled { get; set; }
        public string Avatar { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}   