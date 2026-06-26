using BusinessCore.Interfaces;
using Common.DTO.User;
using Entity.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserDto userDto;
    public UserService(IUserRepository userRepository, UserDto user)
    {
        _userRepository = userRepository;
        userDto = user;
    }

    public async Task<IEnumerable<UserDto>> GetUser()
    {
        return await _userRepository.GetUser();
    }
}
