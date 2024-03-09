﻿using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class UserMapping
    {
        public static User ToEntity(this UserDto userDto)
        {
            User user = new User();

            user.Id = userDto.Id;
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.DateOfCreation = userDto.DateOfCreation;

            return user;
        }

        public static UserDto ToDto(this User user)
        {
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.UserName = user.UserName;
            userDto.Email = user.Email;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.DateOfCreation = user.DateOfCreation;

            return userDto;
        }
    }
}
