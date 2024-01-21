using DoorangWorld.Business.CustomException.ExploreException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Core.Entities;
using DoorangWorld.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Implementes
{
    
    public class ExploreWorldService : IExploreWorldService
    {
        private readonly IExploreWorldRepository _repository;
        private readonly IWebHostEnvironment env;

        public ExploreWorldService(IExploreWorldRepository repository,IWebHostEnvironment env)
        {
            this._repository = repository;
            this.env = env;
        }
        public async Task CreateAsync(ExploreWorld explore)
        {           
            if(explore.Image == null) { throw new ExploreNullException(); }
            if(explore.Image.Length > 2095417) { throw new InvalidImageSizeException("image", "image size must be lower than 2 mb"); }
            if(explore.Image.ContentType!="image/jpeg" &&  explore.Image.ContentType!="image/png") { throw new InvalidImageTypeException("image", "image type must be png or jpej"); }
            explore.Imageurl = Helpers.Helper.Save(env.WebRootPath, "uploads", explore.Image);
            explore.CreateDate = DateTime.Now;
            explore.Updatedate = DateTime.Now;
            await _repository.CreateAsync(explore);
            await _repository.CommitAsync();
        }

      

        public async Task<ExploreWorld> GetAsync(Expression<Func<ExploreWorld, bool>>? expression = null, params string[]? includes)
        {
          return await  _repository.GetByIdAsync(expression, includes);
        }

        public async Task<List<ExploreWorld>> GettAllAsync(Expression<Func<ExploreWorld, bool>>? expression = null, params string[]? includes)
        {
           return await _repository.GetAllAsync(expression, includes);
        }

        public async Task HardDeleteAsync(int Id)
        {
            if (Id < 0) throw new Exception();
            var exites = await _repository.GetByIdAsync(x => x.Id == Id);
            if (exites == null) { throw new Exception(); }
            var world=await _repository.GetByIdAsync(x=>x.Id == Id);
            Helpers.Helper.Remove(env.WebRootPath, "uploads", world.Imageurl);
             _repository.Delete(exites);
            await _repository.CommitAsync();
        }

        public async Task SoftDeleteAsync(int Id)
        {
            if (Id < 0) throw new Exception();
            var exites = await _repository.GetByIdAsync(x => x.Id == Id);
            if (exites == null) { throw new Exception(); }
            exites.Isdeleted = !exites.Isdeleted;
            exites.DeleteDate = DateTime.UtcNow;
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(ExploreWorld explore)
        {
            var world=await _repository.GetByIdAsync(x=>x.Id == explore.Id);

            if(world == null) throw new Exception();
            if (explore.Image != null)
            {
                if (explore.Image == null) { throw new ExploreNullException(); }
                if (explore.Image.Length > 2095417) { throw new InvalidImageSizeException("image", "image size must be lower than 2 mb"); }
                if (explore.Image.ContentType != "image/jpeg" && explore.Image.ContentType != "image/png") { throw new InvalidImageTypeException("image", "image type must be png or jpej"); }
                Helpers.Helper.Remove(env.WebRootPath, "uploads", world.Imageurl);
                world.Imageurl =  Helpers.Helper.Save(env.WebRootPath, "uploads", explore.Image);
              
            }

            world.Updatedate = DateTime.Now;
            world.Desccription = explore.Desccription;
            world.Text1 = explore.Text1;
            world.Text2 = explore.Text2;
            world.Title = explore.Title;
            
            await _repository.CommitAsync();
        }
    }
}
