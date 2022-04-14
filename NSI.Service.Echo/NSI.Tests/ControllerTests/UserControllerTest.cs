﻿using System;
using System.Collections.Generic;
using NSI.BusinessLogic.Interfaces;
using NSI.DataContracts.Models;
using NSI.Common.Enumerations;
using NSI.REST.Controllers;
using NSI.DataContracts.Request;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using NSI.Common.DataContracts.Enumerations;
using NSI.Common.Collation;
using NSI.DataContracts.Dto;

namespace NSI.Tests.ControllerTests
{
    public class UserControllerTest
    {

        [Fact]
        public void UserControllerTest1()
        {
            var authMock = new Mock<IAuthManipulation>();
            authMock.Setup(AuthMockItem => AuthMockItem.GetRoleFromEmail(null)).Returns(() => null);
            var empController = new UserController(authMock.Object, null, null, null, null);

            var result = empController.GetUserRoleFromEmail("email@email.com");

            Assert.Null(result.Error.Errors);
            Assert.Equal(ResponseStatus.Succeeded, result.Success);
        }


        [Fact]
        public void UserControllerTest2()
        {
            var authMock = new Mock<IAuthManipulation>();
            authMock.Setup(AuthMockItem => AuthMockItem.GetRoleFromEmail(null)).Returns(() => null);
            var empController = new UserController(authMock.Object, null, null, null, null);

            var result = empController.GetUserRoleFromEmail("badEmail");

            Assert.Equal(ResponseStatus.Failed, result.Success);
        }

        [Fact]
        public void UserControllerTest3()
        {
            var userMock = new Mock<IUsersManipulation>();
            userMock.Setup(UserMockItem => UserMockItem.RemoveUser(null)).Returns(ResponseStatus.Succeeded);
            var empController = new UserController(null, userMock.Object, null, null, null);

            var result = empController.RemoveUser("email@email.com");

            Assert.Null(result.Error.Errors);
        }


        [Fact]
        public void UserControllerTest4()
        {
            var userMock = new Mock<IUsersManipulation>();
            userMock.Setup(UserMockItem => UserMockItem.RemoveUser(null)).Returns(ResponseStatus.Succeeded);
            var empController = new UserController(null, userMock.Object, null, null, null);

            var result = empController.RemoveUser("badEmail");

            Assert.Equal(ResponseStatus.Failed, result.Success);
        }
    }
}
