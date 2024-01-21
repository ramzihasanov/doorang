using DoorangWorld.Business.CustomException.AccountException;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Business.ViewModel;
using DoorangWorld.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Implementes
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task Login(LoginViewModel loginViewModel)
        {
            AppUser user = null;
              user= await userManager.FindByNameAsync(loginViewModel.username);
            if(user == null) { throw new InvalidLoginException("","error"); }
              var result= await signInManager.PasswordSignInAsync(user,loginViewModel.password,false,false);
            if(!result.Succeeded) { throw new InvalidLoginException("","error"); }
            
        }
    }
}
