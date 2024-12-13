using HotelManagement_DAL.Repositories;
using HotelManagement_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelManagement_BLL
{
    public class ServicesService
    {
        private readonly ServiceRepository _repository;

        public ServicesService(ServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public List<Service> GetServices()
        {
            return _repository.GetAllServices();
        }

        public bool AddService(Service service)
        {
            return _repository.AddService(service);
        }
        public bool UpdateService(Service updatedService)
        {
            return _repository.UpdateService(updatedService);
        }

        public bool DeleteService(int serviceId)
        {
            return _repository.DeleteService(serviceId);
        }
    }
}
