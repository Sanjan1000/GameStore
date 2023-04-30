
using GameStoreWeb.Data.Base;
using GameStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace GameStoreWeb.Data.Services
{
    public interface IDeveloperService : IEntityBaseRepository<Developer>
    {
    }
}