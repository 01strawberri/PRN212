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
            using (var context = new Prn212hotelManagementContext())
            {
                try
                {
                    // Fetch the existing service from the database
                    var serviceInDb = context.Services.SingleOrDefault(s => s.ServiceId == updatedService.ServiceId);

                    if (serviceInDb == null)
                    {
                        throw new Exception("Service not found in the database.");
                    }

                    // Update the values
                    context.Entry(serviceInDb).CurrentValues.SetValues(updatedService);
                    context.Entry(serviceInDb).State = EntityState.Modified;

                    // Save changes
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Log inner exception
                    Debug.WriteLine($"Database update error: {ex.InnerException?.Message}", "Update Error");
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle generic errors
                    Debug.WriteLine($"Error: {ex.Message}", "Update Error");
                    throw;
                }
            }
        }




        public void DeleteService(int serviceId)
        {
            _repository.DeleteService(serviceId);
        }
    }
}
