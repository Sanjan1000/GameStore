using GameStoreWeb.Data.Base;
using GameStoreWeb.Data;
using GameStoreWeb.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace GameStoreWeb.Data.Services
{
    public class DeveloperService : EntityBaseRepository<Developer>, IDeveloperService
    {
        public DeveloperService(AppDbContext context) : base(context) { }
    }
}