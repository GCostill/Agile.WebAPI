using Agile.Data;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Services
{
    public class ContactService
    {
        public bool CreateContact(ContactCreate model)
        {
            var entity = new ContactData()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                StreetAddress = model.StreetAddress
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
