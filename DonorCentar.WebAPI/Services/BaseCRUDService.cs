﻿using AutoMapper;
using DonorCentar.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.WebAPI.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class where TDb : class
    {
        public BaseCRUDService(BazaPodataka context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var set = Context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            _mapper.Map(request, entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Delete(int id)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
            {
                set.Remove(entity);

                Context.SaveChanges();
            }

            return _mapper.Map<T>(entity);
        }
    }
}