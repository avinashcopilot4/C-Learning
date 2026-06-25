using Common.DTO.User;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<UserDto>> GetUser();
}
