﻿using System;
using NSI.BusinessLogic.Interfaces;
using NSI.DataContracts.Models;
using NSI.DataContracts.Request;
using NSI.Repository.Interfaces;
using NSI.Common.DataContracts.Enumerations;
using System.Threading.Tasks;
using System.Collections.Generic;
using NSI.Common.Collation;
using System.Linq;
using NSI.Common.Extensions;

namespace NSI.BusinessLogic.Implementations
{
    public class UsersManipulation : IUsersManipulation
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManipulation(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public User GetById(Guid id)
        {
            return _usersRepository.GetById(id);
        }

        public User GetByEmail(string email)
        {
            return _usersRepository.GetByEmail(email);
        }

        public User SaveUser(NewUserRequest userRequest)
        {
            Common.Enumerations.Gender g = Common.Enumerations.Gender.Male;

            if (userRequest.Gender == 2) {
                g = Common.Enumerations.Gender.Female;
            }

            User newUser = new User(userRequest.FirstName, userRequest.LastName, g, userRequest.Email, userRequest.Username, userRequest.PlaceOfBirth, userRequest.DateOfBirth, userRequest.Country);

            return _usersRepository.SaveUser(newUser);
        }

        public ResponseStatus RemoveUser(string email)
        {
            return _usersRepository.RemoveUser(email);
        }

        public async Task<IList<User>> GetUsers(Paging paging, IList<SortCriteria> sortCriteria, IList<FilterCriteria> filterCriteria)
        {
            var results = await _usersRepository.GetUsersAsync();

            if (paging != null)
            {
                results = results.AsQueryable().DoPaging(paging).ToList();
            }

            return results;
        }

        public async Task<IList<User>> GetAllPerson()
        {
            return await _usersRepository.GetAllPersonAsync();
        }
    }
}
