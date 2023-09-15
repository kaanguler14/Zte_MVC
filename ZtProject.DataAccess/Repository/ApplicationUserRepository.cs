using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUser
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(ApplicationUser obj)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Surname = obj.Surname;
                objFromDb.UserName = obj.UserName;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.EmailConfirmed = obj.EmailConfirmed;
                objFromDb.CardRequest = obj.CardRequest;
                objFromDb.CitizenID = obj.CitizenID;
                objFromDb.City = obj.City;
                objFromDb.Email = obj.Email;
                objFromDb.PostalCode = obj.PostalCode;
                objFromDb.State = obj.State;
                objFromDb.StreetAdress = obj.StreetAdress;
               
            }


        }
    }
}
