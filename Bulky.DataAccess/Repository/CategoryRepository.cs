﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DtatContext _db;

        public CategoryRepository(DtatContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
