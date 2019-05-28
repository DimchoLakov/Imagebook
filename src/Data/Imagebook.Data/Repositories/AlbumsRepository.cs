using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Imagebook.Data.Models;
using Imagebook.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Imagebook.Data.Repositories
{
    public class AlbumsRepository : GenericRepository<Album>, IAlbumsRepository
    {
        public AlbumsRepository(ImagebookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
