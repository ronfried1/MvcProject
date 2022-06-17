using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public int CategoryId { get; set; }      
        public virtual Category Category { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only please")]
        [MinLength((2), ErrorMessage = "Please enter a name with more then 2 notes")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Range (0,100)]
        [Required(ErrorMessage = "Please enter a valid age")]
        public int Age { get; set; }
        public string PictureName { get; set; }

        [Display(Name = "Description:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Please enter some description")]
        public string Description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
