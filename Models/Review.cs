using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models {
    public class Review {
        public int ID {get;set;}
        
        [DataType(DataType.Date)]
        public DateTime Date;

        public int rating;

        [Display(Name = "You're review")]
        public string UserReview {get;set;}

    }
}