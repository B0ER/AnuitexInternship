using Store.DataAccess.AppContext;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Base;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        private IGenericRepository<Author> _authors;
        public IGenericRepository<Author> Authors => _authors ?? (_authors = new BaseRepository<Author>(_dbContext));


        private IGenericRepository<AuthorInBook> _autorInBooks;
        public IGenericRepository<AuthorInBook> AutorInBooks => _autorInBooks ?? (_autorInBooks = new BaseRepository<AuthorInBook>(_dbContext));


        private IGenericRepository<Order> _orders;
        public IGenericRepository<Order> Orders => _orders ?? (_orders = new BaseRepository<Order>(_dbContext));


        private IGenericRepository<OrderItem> _orderItems;
        public IGenericRepository<OrderItem> OrderItems => _orderItems ?? (_orderItems = new BaseRepository<OrderItem>(_dbContext));



        private IGenericRepository<Payment> _payments;
        public IGenericRepository<Payment> Payments => _payments ?? (_payments = new BaseRepository<Payment>(_dbContext));



        private IGenericRepository<PrintingEdition> _printingsEditions;
        public IGenericRepository<PrintingEdition> PrintingsEditions => _printingsEditions ?? (_printingsEditions = new BaseRepository<PrintingEdition>(_dbContext));
    }
}
