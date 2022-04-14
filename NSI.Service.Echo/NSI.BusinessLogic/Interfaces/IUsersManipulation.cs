﻿using System;
using NSI.Common.Collation;
using NSI.Common.DataContracts.Enumerations;
using NSI.DataContracts.Models;
using NSI.DataContracts.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSI.BusinessLogic.Interfaces
{
    public interface IUsersManipulation
    {
        User GetById(Guid id);
        
        User GetByEmail(string email);

        User SaveUser(NewUserRequest userRequest);

        ResponseStatus RemoveUser(string email);

        Task<IList<User>> GetUsers(Paging paging, IList<SortCriteria> sortCriteria, IList<FilterCriteria> filterCriteria);

        Task<IList<User>> GetAllPerson();
    }
}
