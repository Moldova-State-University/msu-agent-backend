using Microsoft.EntityFrameworkCore;
using MSUAgent.Application.Interfaces;
using MSUAgent.Domain.Entities;
using MSUAgent.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUAgent.Infrastructure.Repositories;

public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}