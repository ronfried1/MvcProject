using Microsoft.AspNetCore.Http;
using MvcProject.Data;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MvcProject.Reposetorys
{
    public class Repository : IRepository
    {
        private ShopContext _context;
        public Repository(ShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList(); ;
        }
        public IEnumerable<Animal> GetTwoAnimalWithHighComments()
        {
            IEnumerable<Animal> animals = _context.Animals.OrderBy(a => a.Comments.Count()).Reverse().ToList();
            return animals.Take(2);
        }
        public IEnumerable<Animal> GetAnimalsByCategoryId(int id)
        {
            IEnumerable<Animal> animals = _context.Animals.Where(a => a.CategoryId == id);
            return animals;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals.ToList();
        }
        public Animal GetAnimalById(int id)
        {
            Animal animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
            return animal;
        }
        public Category GetCategoryById(int id)
        {
            _context.Categories.Find(id);
            return _context.Categories.Find(id); ;
        }
        public void AddComment(string comment, int id)
        {
            _context.Comments.Add(new Comment { CommentDescription = comment, AnimalId = id });
            _context.SaveChanges();
        }
        public void EditAnimal(Animal animal, IFormFile file, int id, string wwwPath)
        {
            Animal oldAnimal = GetAnimalById(id);
            if (file != null)
            {
                string path = wwwPath + "\\Images\\";
                using (var filestream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    file.CopyToAsync(filestream);
                }
                File.Delete(wwwPath + "\\Images" + oldAnimal.PictureName);
                animal.PictureName = file.FileName;
                oldAnimal.PictureName = animal.PictureName;
            }
            oldAnimal.Name = animal.Name;
            oldAnimal.Comments = animal.Comments;
            oldAnimal.Description = animal.Description;
            oldAnimal.Category = animal.Category;
            oldAnimal.CategoryId = animal.CategoryId;
            oldAnimal.Age = animal.Age;
            _context.Animals.Update(oldAnimal);
            _context.SaveChanges();
        }
        public void AddNewAnimal(Animal animal, IFormFile file, string wwwPath)
        {

            string filename = Path.GetFileName(file.FileName);
            animal.PictureName = file.FileName;
            string path = wwwPath + "\\Images";
            using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
            {              
                file.CopyToAsync(filestream);
            }
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }
        public void DeleteAnimal(int id, string wwwPath)
        {
            Animal animal = GetAnimalById(id);
            string photo = animal.PictureName;
            string path = wwwPath + "\\Images\\";
            _context.Animals.Remove(animal);
            IEnumerable<Animal> animalsWithSamePic = _context.Animals.Where(a => a.PictureName == photo);
            if (animalsWithSamePic.Count() == 1)
            {
                File.Delete(path + photo);
            }
            _context.SaveChanges();
        }
    }
}
