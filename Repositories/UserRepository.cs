using Common.DTO.User;
using Entity.Data;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories;

public class UserRepository : IUserRepository
{
    private readonly SchoolDbContext _context;
    public UserRepository(SchoolDbContext schoolDbContext)
    {
        _context = schoolDbContext;
    }

    public async Task<IEnumerable<UserDto>> GetUser()
    {
        return await _context.Users.Select(user => new UserDto()
        {
            UserId = user.UserId,
            Email = user.Email,
            UserName = user.UserName,
            Role = user.Role,
            IsActive = user.IsActive,
        }).ToListAsync();
    }
}
