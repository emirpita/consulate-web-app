﻿using System;
using NSI.Common.DataContracts.Enumerations;
using NSI.DataContracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSI.Repository.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        User SaveUser(User user);
        ResponseStatus RemoveUser(string email);
        Task<IList<User>> GetUsersAsync();
        Task<IList<User>> GetAllPersonAsync();
    }
}
