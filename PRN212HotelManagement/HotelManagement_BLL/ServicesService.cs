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

        public ServicesService()
        {
            _repository = new ServiceRepository();
        }

        public List<Service> GetServices()
        {
            return _repository.GetAllServices();
        }

        public void AddService(Service service)
        {
            _repository.AddService(service);
        }
        public void UpdateService(Service updatedService)
        {
            _repository.UpdateService(updatedService);
        }

        public void DeleteService(int serviceId)
        {
            _repository.DeleteService(serviceId);
        }
    }
}
