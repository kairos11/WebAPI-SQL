﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogin.Models;

namespace UserLogin.DataProvider
{
    public interface IUserDataProvider
    {

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int UserId);

        Task AddUser(User product);

        Task UpdateUser(User product);

        Task DeleteUser(int UserId);

        Task AddQRScan(string product);
    }
}
