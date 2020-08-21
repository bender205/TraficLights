using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace TraficLightsRazorPages.Models
{
    public enum Color
    {
        red,
        yellow,
        green
    }
    public class TraficLightsEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Color")]
        [MaxLength(10)]
        public string Color { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="0:yyyy\\MM\\dd HH:mm")]
        public DateTime? Time { get; set; }
    }
}
