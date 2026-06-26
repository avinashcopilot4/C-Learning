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
    public UserRepository(SchoolDbContext schoolDbContext, UserDto user)
    {
        _context = schoolDbContext;
    }

    public async Task<IEnumerable<UserDto>> GetUser()
    {
        ////1 query
        //var quiz = _context.Quizzes
        //    .Include(qz => qz.Questions)
        //    .Where(q => q.QuizId == 900)
        //    .FirstOrDefault();

        //var quizQuestions = quiz.Questions;

        ////n times
        //foreach(var q in quizQuestions)
        //{
        //    //lazyloading
        //    var questionAttempts = q.AttemptDetails.ToList();
        //}

        ////1 query
        //var quiz3 = _context.Quizzes
        //    .Include(qz => qz.Questions)
        //    .ThenInclude(qn => qn.AttemptDetails)
        //    .Where(q => q.QuizId == 900)
        //    .AsSplitQuery()
        //    .FirstOrDefault();

        //var quiz3Questions = quiz.Questions;

        //foreach (var q in quiz3Questions)
        //{

        //    var questionAttempts = q.AttemptDetails.ToList();
        //}


        //var quiz2 = _context.Quizzes
        //    .Where(q => q.QuizId == 900)
        //    .FirstOrDefault();

        

        //Console.WriteLine("Hii Avinash");
        //Console.WriteLine("Hii Avinash");

        ////Lazy loading
        //var quiz2Questions = quiz2.Questions.ToList();

        //_context.SaveChanges();
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
