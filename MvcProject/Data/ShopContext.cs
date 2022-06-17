using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Data
{
    public class ShopContext : DbContext
    {

        public ShopContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
             new { AnimalId = 1, Name = "Spotted flycatcher", Age = 6, PictureName = "Bird.jpg", Description = "The spotted flycatcher is a small passerine bird in the Old World flycatcher family. It breeds in most of Europe and in the Palearctic to Siberia, and is migratory, wintering in Africa and south western Asia. It is declining in parts of its range.", CategoryId = 2 },
             new { AnimalId = 2, Name = "Cat", Age = 3,  PictureName = "Cat.jpg", Description = "The cat is a domestic species of small carnivorous mammal. It is the only domesticated species in the family Felidae and is often referred to as the domestic cat to distinguish it from the wild members of the family. A cat can either be a house cat, a farm cat or a feral cat; the latter ranges freely and avoids human contact. Domestic cats are valued by humans for companionship and their ability to kill rodents. About 60 cat breeds are recognized by various cat registries.", CategoryId = 1 },
             new { AnimalId = 3, Name = "Bear", Age = 2,  PictureName = "Bear.jpg", Description = "Bears are carnivoran mammals of the family Ursidae. They are classified as caniforms, or doglike carnivorans. Although only eight species of bears are extant, they are widespread, appearing in a wide variety of habitats throughout the Northern Hemisphere and partially in the Southern Hemisphere. Bears are found on the continents of North America, South America, Europe, and Asia. Common characteristics of modern bears include large bodies with stocky legs, long snouts, small rounded ears, shaggy hair, plantigrade paws with five nonretractile claws, and short tails.", CategoryId = 1 },
             new { AnimalId = 4, Name = "Lion", Age = 10, PictureName = "Lion.jpg", Description = "The lion is a large cat of the genus Panthera native to Africa and India. It has a muscular, deep-chested body, short, rounded head, round ears, and a hairy tuft at the end of its tail. It is sexually dimorphic; adult male lions are larger than females and have a prominent mane. It is a social species, forming groups called prides. A lion's pride consists of a few adult males, related females, and cubs. Groups of female lions usually hunt together, preying mostly on large ungulates. The lion is an apex and keystone predator; although some lions scavenge when opportunities occur and have been known to hunt humans, the species typically does not.", CategoryId = 1 },
             new { AnimalId = 5, Name = "Snake", Age = 4, PictureName = "Snake.jpg", Description = "This snake is called Python. it is also a programming language ", CategoryId = 3 },
             new { AnimalId = 6, Name = "Lizard", Age = 10, PictureName = "Lizard.jpeg", Description = "Lizards (suborder Lacertilia) are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica, as well as most oceanic island chains. The group is paraphyletic as it excludes the snakes and Amphisbaenia; some lizards are more closely related to these two excluded groups than they are to other lizards. Lizards range in size from chameleons and geckos a few centimeters long to the 3 meter long Komodo dragon.", CategoryId = 3 },
             new { AnimalId = 7, Name = "Eagle", Age = 3, PictureName = "Eagle.jpg", Description = "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 60 species of eagle are from Eurasia and Africa. Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia.", CategoryId = 2 }
            );

            modelBuilder.Entity<Comment>().HasData(
            new { AnimalId = 1, CommentDescription = "This bird looks Dead!", CommentId =1 },
            new { AnimalId = 1, CommentDescription = "OMG, gotta have it for my sister", CommentId =2 },
            new { AnimalId = 1, CommentDescription = "It look like it's a small bird", CommentId =3 },
            new { AnimalId = 1, CommentDescription = "I love birds!", CommentId =4 },
            new { AnimalId = 2, CommentDescription = "This cat it soo cute", CommentId =5 },
            new { AnimalId = 2, CommentDescription = "Why don't you have dogs also?", CommentId =6 },
            new { AnimalId = 2, CommentDescription = "I want to buy this cat and put my whole life in hold just to make him happy  ", CommentId =7 },
            new { AnimalId = 2, CommentDescription = "Soo where is this cat right now?? i think you guys not treating your pets right!", CommentId =8 },
            new { AnimalId = 3, CommentDescription = "Can he drink cock right next to me at the table? I've heared there's a bear in bolivia that can fo that", CommentId =9 },
            new { AnimalId = 3, CommentDescription = "Can i buy a samll size bear also?", CommentId =10 },
            new { AnimalId = 3, CommentDescription = "This bear is pefect for me. just took a fur art course ", CommentId =11},
            new { AnimalId = 4, CommentDescription = "The lion can kill you! don't buy this lion", CommentId =12},
            new { AnimalId = 4, CommentDescription = "There's also a lion on my cereal box.", CommentId =13},
            new { AnimalId = 4, CommentDescription = "I love big big cats ya'll", CommentId =14},
            new { AnimalId = 5, CommentDescription = "Well well... it is a programming language ", CommentId =15},
            new { AnimalId = 5, CommentDescription = "My python wants a new friend", CommentId =16},
            new { AnimalId = 5, CommentDescription = "This snake doesn't have venom.", CommentId =17},
            new { AnimalId = 6, CommentDescription = "I love lizards.", CommentId =18},
            new { AnimalId = 6, CommentDescription = "King lizzard and the wizard lizzard.", CommentId =19},
            new { AnimalId = 6, CommentDescription = "Yess .", CommentId =20},
            new { AnimalId = 6, CommentDescription = "I want to be with this lizard forever.", CommentId =21},
            new { AnimalId = 6, CommentDescription = "Sometimes lizard can be cool.", CommentId =22},
            new { AnimalId = 6, CommentDescription = "It's better then snakes.", CommentId =23},
            new { AnimalId = 7, CommentDescription = "Eagle is good good", CommentId =24},
            new { AnimalId = 1, CommentDescription = "Bird it's a word", CommentId =25},
            new { AnimalId = 1, CommentDescription = "Sooo cute", CommentId =26},
            new { AnimalId = 1, CommentDescription = "Ok i want this burd now!!", CommentId =27}
            );
            modelBuilder.Entity<Category>().HasData(
             new { CategoryId =1,Name = "Mammal" },
             new { CategoryId =2,Name = "Bird" },
             new { CategoryId =3,Name = "Reptile"}
             );
        }

    }
}
