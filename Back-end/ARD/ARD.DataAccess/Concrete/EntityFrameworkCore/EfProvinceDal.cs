﻿using ARD.Core.DataAccess.EntityFrameworkCore;
using ARD.DataAccess.Abstract;
using ARD.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARD.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProvinceDal : EfEntityRepositoryBase<Province, ARDDataContext>, IProvinceDal
    {
        public async Task<List<Province>> GetListWithDistrictsAsync(Expression<Func<Province, bool>> filter = null)
        {
            using (var context = new ARDDataContext())
            {
                if (filter == null)
                    return await context.Set<Province>().Include(p => p.Districts).ToListAsync();
                return await context.Set<Province>().Include(p => p.Districts).Where(filter).ToListAsync();
            }
        }

        public async Task<Province> GetWithDistrictsAsync(Expression<Func<Province, bool>> filter)
        {
            using (var context = new ARDDataContext())
            {
                return await context.Set<Province>().Include(p => p.Districts).Where(filter).SingleOrDefaultAsync();
            }
        }
    }
}
