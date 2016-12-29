using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TvSeriesApp.Models
{
    public class Serie
    {
        public int SerieID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime ReleasedDate { get; set; }
        [Display(Name = "Seasons")]
        [Range(1, 12)]
        public int NumberOfSeasons { get; set; }
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        [StringLength(5)]
        public string Rating { get; set; }
    }
}