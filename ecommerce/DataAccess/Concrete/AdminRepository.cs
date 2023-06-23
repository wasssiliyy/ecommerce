using ecommerce.DataAccess.Abstractions;
using ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.DataAccess.Concrete
{
    public class AdminRepository : IAdminRepository
    {
        private EECommerceDataContext _context;
        public AdminRepository()
        {
            _context = new EECommerceDataContext();
        }

        public void AddData(Admin data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Admin data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Admin> GetAll()
        {
            var admins = from a in _context.Admins
                         orderby a.Username
                         select a;
            return new ObservableCollection<Admin>(admins);
        }

        public Admin GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}
