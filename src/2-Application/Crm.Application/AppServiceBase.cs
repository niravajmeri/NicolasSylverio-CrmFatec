﻿using Crm.Application.Interface;
using System;
using System.Collections.Generic;

namespace Crm.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IAppServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IAppServiceBase<TEntity> ServiceBase)
        {
            _serviceBase = ServiceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}