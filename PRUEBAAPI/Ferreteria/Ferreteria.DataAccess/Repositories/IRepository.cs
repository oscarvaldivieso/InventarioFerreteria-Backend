﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    interface IRepository<T>
    {
        public IEnumerable<T> List();
        public RequestStatus Insert(T item);
        public RequestStatus Update(T item);
        public T Find(int? id);
        public RequestStatus Delete(T item);

    }
}