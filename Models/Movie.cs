using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models {
    public class Movie {
        public int ID {get;set;}

        [Required]
        [StringLength(100)]
        public string Title {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate {get;set;}

        [Required]
        [StringLength(30)]
        public string Genre {get;set;}

        [Required]
        [StringLength(50)]
        public string Director {get;set;}

        [StringLength(20)]
        public string Budget {get;set;}

        [Required]
        [StringLength(500)]
        public string Synopsis {get;set;}

        public double Rating {get;set;}

        public ArrayList Reviews {get;set;}
    }
}