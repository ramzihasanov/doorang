﻿using DoorangWorld.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginViewModel loginViewModel);
    }
}
