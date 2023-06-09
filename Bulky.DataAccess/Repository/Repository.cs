﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _db;
        internal DbSet<T> _dbSet;
        public Repository(DataContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>>? filter, string? includeProps = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (!string.IsNullOrEmpty(includeProps))
            {
                string[] propList = includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < propList.Length; i++)
                {
                    query = query.Include(propList[i]);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProps = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);

            }
           
            if (!string.IsNullOrEmpty(includeProps))
            {
                string[] propList = includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < propList.Length; i++)
                {
                    query = query.Include(propList[i]);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }
    }
}
