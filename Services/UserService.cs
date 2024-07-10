﻿using BOs.Entities;
using Repos;
using Repos.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository=null;    
        public UserService()
        {
            if(userRepository==null)
            {
                userRepository = new UserRepository();
            }
        }

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public User Login(string username, string password)
        {
            return userRepository.GetUser(username, password);
        }

        public void Remove(string userId)
        {
            userRepository.Remove(userId);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}
