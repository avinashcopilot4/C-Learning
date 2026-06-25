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
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetUser()
    {
        return await _userRepository.GetUser();
    }
}
