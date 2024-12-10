using HotelManagement_DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_DAL.Repositories
{
    public class ServiceRepository
    {
        private Prn212hotelManagementContext _context;

        public ServiceRepository()
        {
            _context = new Prn212hotelManagementContext();
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void DeleteService(int serviceId)
        {
            var service = _context.Services.Find(serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }


    }
}
