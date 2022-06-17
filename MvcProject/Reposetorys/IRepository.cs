using Microsoft.AspNetCore.Http;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Reposetorys
{
    public interface IRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAnimals();
        public Category GetCategoryById(int id);
        Animal GetAnimalById(int id);
        void AddNewAnimal(Animal animal, IFormFile file ,string wwwPath);
        void EditAnimal(Animal animal, IFormFile file, int id, string wwwPath);
        void DeleteAnimal(int id, string wwwPath);
        IEnumerable<Animal> GetTwoAnimalWithHighComments();
        IEnumerable<Animal> GetAnimalsByCategoryId(int id);
        void AddComment(string comment, int id);
    }
}
