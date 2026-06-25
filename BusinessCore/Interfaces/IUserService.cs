using Common.DTO.User;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<UserDto>> GetUser();
}
