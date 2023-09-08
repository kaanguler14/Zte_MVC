﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;

namespace ZtProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository Account { get; private set; }
        public ICardRepository Card { get; private set; }
        public ICardHistoryRepository CardHistory { get; private set; }
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Account = new AccountRepository(_db);
            Card = new CardRepository(_db);
            CardHistory = new CardHistoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
