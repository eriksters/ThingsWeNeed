using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels {
    public class UserViewModel : ViewModel {
        public UserViewModel(string title) : base(title)
        {
            Purchases = new List<Purchase>();
            Households = new List<Household>();
            MadeWishes = new List<Wish>();
            GrantedWishes = new List<Wish>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Fname { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Household> Households { get; set; }
        public ICollection<Wish> MadeWishes { get; set; }
        public ICollection<Wish> GrantedWishes { get; set; }


    }
}