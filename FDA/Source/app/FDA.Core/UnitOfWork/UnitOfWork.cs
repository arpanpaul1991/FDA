using FDA.Core.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDA.Core.Repository;
using FDA.Core.Models;


namespace FDA.Core.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {

        #region private member variables

        private DatabaseContext _context = null;

        private GenericRepository<Admin> _AdminRepository { get; set; }
        private GenericRepository<Cart> _CartRepository { get; set; }
        private GenericRepository<Customer> _CustomerRepository { get; set; }
        private GenericRepository<Establishment> _EstablishmentRepository { get; set; }
        private GenericRepository<EstablishmentStatus> _EstablishmentStatusRepository { get; set; }
        private GenericRepository<MenuList> _MenuListRepository { get; set; }
        private GenericRepository<MenuStatus> _MenuStatusRepository { get; set; }
        private GenericRepository<OrderStatus> _OrderStatusRepository { get; set; }
        private GenericRepository<Permission> _PermissionRepository { get; set; }
        private GenericRepository<Rating> _RatingRepository { get; set; }
        private GenericRepository<Order> _OrderRepository { get; set; }
        private GenericRepository<OrderDetail> _OrderDetailRepository { get; set; }
        private GenericRepository<Category> _CategoryRepository { get; set; }
        private GenericRepository<OrderHistory> _OrderHistoryRepository { get; set; }
        private GenericRepository<OrderDetailHistory> _OrderDetailHistoryRepository { get; set; }

        #endregion

        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }


        #region public repository creation properties

        public GenericRepository<Admin> AdminRepository
        {
            get
            {
                if (this._AdminRepository == null)
                    this._AdminRepository = new GenericRepository<Admin>(_context);
                return _AdminRepository;
            }
        }

        public GenericRepository<Cart> CartRepository
        {
            get
            {
                if (this._CartRepository == null)
                    this._CartRepository = new GenericRepository<Cart>(_context);
                return _CartRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (this._CustomerRepository == null)
                    this._CustomerRepository = new GenericRepository<Customer>(_context);
                return _CustomerRepository;
            }
        }
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this._OrderRepository == null)
                    this._OrderRepository = new GenericRepository<Order>(_context);
                return _OrderRepository;
            }
        }

        public GenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (this._OrderDetailRepository == null)
                    this._OrderDetailRepository = new GenericRepository<OrderDetail>(_context);
                return _OrderDetailRepository;
            }
        }
        public GenericRepository<Establishment> EstablishmentRepository
        {
            get
            {
                if (this._EstablishmentRepository == null)
                    this._EstablishmentRepository = new GenericRepository<Establishment>(_context);
                return _EstablishmentRepository;
            }
        }

        public GenericRepository<EstablishmentStatus> EstablishmentStatusRepository
        {
            get
            {
                if (this._EstablishmentStatusRepository == null)
                    this._EstablishmentStatusRepository = new GenericRepository<EstablishmentStatus>(_context);
                return _EstablishmentStatusRepository;
            }
        }

        public GenericRepository<MenuList> MenuListRepository
        {
            get
            {
                if (this._MenuListRepository == null)
                    this._MenuListRepository = new GenericRepository<MenuList>(_context);
                return _MenuListRepository;
            }
        }

        public GenericRepository<MenuStatus> MenuStatusRepository
        {
            get
            {
                if (this._MenuStatusRepository == null)
                    this._MenuStatusRepository = new GenericRepository<MenuStatus>(_context);
                return _MenuStatusRepository;
            }
        }


        public GenericRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                if (this._OrderStatusRepository == null)
                    this._OrderStatusRepository = new GenericRepository<OrderStatus>(_context);
                return _OrderStatusRepository;
            }
        }

        public GenericRepository<Permission> PermissionRepository
        {
            get
            {
                if (this._PermissionRepository == null)
                    this._PermissionRepository = new GenericRepository<Permission>(_context);
                return _PermissionRepository;
            }
        }

        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (this._RatingRepository == null)
                    this._RatingRepository = new GenericRepository<Rating>(_context);
                return _RatingRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._CategoryRepository == null)
                    this._CategoryRepository = new GenericRepository<Category>(_context);
                return _CategoryRepository;
            }
        }

        public GenericRepository<OrderHistory> OrderHistoryRepository
        {
            get
            {
                if (this._OrderHistoryRepository == null)
                    this._OrderHistoryRepository = new GenericRepository<OrderHistory>(_context);
                return _OrderHistoryRepository;
            }
        }

        public GenericRepository<OrderDetailHistory> OrderDetailHistoryRepository
        {
            get
            {
                if (this._OrderDetailHistoryRepository == null)
                    this._OrderDetailHistoryRepository = new GenericRepository<OrderDetailHistory>(_context);
                return _OrderDetailHistoryRepository;
            }
        }

        #endregion


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
