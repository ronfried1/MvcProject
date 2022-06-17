using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class Comment
    {

        public int CommentId{ get; set; }
        public int AnimalId{ get; set; } 
        public virtual Animal Animal { get; set; }

        [Display(Name ="Comment")]
        [Required(ErrorMessage = "Please enter some comment")]
        [MinLength(2)]
        public string  CommentDescription{ get; set; }
    }
}
