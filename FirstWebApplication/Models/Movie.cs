using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FirstWebApplication.Models
{
    public class Movie
    {
        public int ID { get; set; }
        
        [StringLength(60,MinimumLength =3)]
        public string Title { get; set; }

        [Display(Name="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime ReleasedDate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(60,MinimumLength =3)]
        public string Genre { get; set; }


        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set;}
    }
}