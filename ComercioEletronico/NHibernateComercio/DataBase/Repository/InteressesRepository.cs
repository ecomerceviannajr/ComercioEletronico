﻿using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace NHibernateComercio.DataBase.Repository
{
    public class InteressesRepository : RepositoryBase<Interesses>
    {
        public InteressesRepository(ISession session) : base(session)
        {
        }
    }
}
