//using AstroPharm.Service.DTOs.Users;
//using AstroPharm.Service.Interfaces.Users;
//using Moq;
//using Xunit;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using AstroPharm.Service.DTOs.UserRoles;
//using AstroPharm.Domain.Enums;

//namespace Test.UserTests
//{
//    public class UserServiceTest
//    {
//        private readonly Mock<IUserInterface> _userServiceMock;

//        public UserServiceTest()
//        {
//            _userServiceMock = new Mock<IUserInterface>();
//        }

//        [Fact]
//        public async Task AddUser_Mock_Test()
//        {
//            var userDto = new UserForCreationDto
//            {
//                Email = "blabla@gmail.com",
//                FirstName = "ZUC",
//                LastName = "zus",
//                Password = "HashedPassword4",
//                PhoneNumber = "998991234567",
//                LanguageId = 1
//            };

//            var expectedResult = new UserForResultDto
//            {
//                Id = 1,
//                Email = userDto.Email,
//                FirstName = userDto.FirstName,
//                LastName = userDto.LastName,
//                PhoneNumber = userDto.PhoneNumber
//            };

//            _userServiceMock
//                .Setup(service => service.AddAsync(It.IsAny<UserForCreationDto>()))
//                .ReturnsAsync(expectedResult);

//            var result = await _userServiceMock.Object.AddAsync(userDto);

//            Assert.NotNull(result);
//            Assert.Equal("ZUC", result.FirstName);
//            Assert.Equal("zus", result.LastName);
//            Assert.Equal("blabla@gmail.com", result.Email);
//        }

//        [Fact]
//        public async Task RetrieveUserById_Mock_Test()
//        {
//            var expectedUser = new UserForResultDto
//            {
//                Id = 1,
//                Email = "zuc@gmail.com",
//                FirstName = "Zuc",
//                LastName = "Zucc"
//            };

//            _userServiceMock
//                .Setup(service => service.RetrieveByIdAsync(1))
//                .ReturnsAsync(expectedUser);

//            var result = await _userServiceMock.Object.RetrieveByIdAsync(1);

//            Assert.NotNull(result);
//            Assert.Equal("Zuc", result.FirstName);
//            Assert.Equal(1, result.Id);
//        }

//        [Fact]
//        public async Task RetrieveAllUsers_Mock_Test()
//        {
//            var expectedList = new List<UserForResultDto>
//            {
//                new UserForResultDto { Id = 1, FirstName = "Zuc" },
//                new UserForResultDto { Id = 2, FirstName = "Bosit" }
//            };

//            _userServiceMock
//                .Setup(service => service.RetrieveAllAsync())
//                .ReturnsAsync(expectedList);

//            var result = await _userServiceMock.Object.RetrieveAllAsync();

//            Assert.NotNull(result);
//            Assert.Equal(2, (result as List<UserForResultDto>).Count);
//        }

//        //[Fact]
//        //public async Task ModifyUser_Mock_Test()
//        //{
//        //    var updateDto = new UserForUpdateDto
//        //    {
//        //        FirstName = "Zuc",
//        //        LastName = "ZucZuc"
//        //    };

//        //    var expectedResult = new UserForResultDto
//        //    {
//        //        Id = 1,
//        //        FirstName = "Zuc",
//        //        LastName = "ZucZuc"
//        //    };

//        //    _userServiceMock
//        //        .Setup(service => service.ModifyAsync(1, It.IsAny<UserForUpdateDto>()))
//        //        .ReturnsAsync(expectedResult);

//        //    var result = await _userServiceMock.Object.ModifyAsync(1, updateDto);

//        //    Assert.NotNull(result);
//        //    Assert.Equal("UpdatedZuc", result.FirstName);
//        //}

//        [Fact]
//        public async Task RemoveUser_Mock_Test()
//        {
//            _userServiceMock
//                .Setup(service => service.RemoveAsync(1))
//                .ReturnsAsync(true);

//            var result = await _userServiceMock.Object.RemoveAsync(1);

//            Assert.True(result);
//        }

//        [Fact]
//        public async Task ForgotPassword_Mock_Test()
//        {
//            string email = "zuc@gmail.com";
//            string expectedPassword = "secret123";

//            _userServiceMock
//                .Setup(service => service.ForgotPassword(email))
//                .ReturnsAsync(expectedPassword);

//            var result = await _userServiceMock.Object.ForgotPassword(email);

//            Assert.Equal(expectedPassword, result);
//        }
//    }
//}   
