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
        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateContact(ContactCreate model)
        {
            var entity = new ContactData()
            {
                ContactId = _userId,
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
                //Sql Exception "Invalid column name 'ContactId'"
            }

        }

        public IEnumerable<ContactListItem> GetContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Contacts
                                .Where(e => e.ContactId == _userId)
                                .Select(e => new ContactListItem
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    EmailAddress = e.EmailAddress
                                });
                return query.ToList();
                //Sql Exception "Invalid column name 'ContactId'"
            }
        }

        public ContactEdit GetContactByFirstName(string firstName)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Contacts
                                .Single(e => e.FirstName == firstName && e.ContactId == _userId);
                return new ContactEdit
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    EmailAddress = entity.EmailAddress,
                    PhoneNumber = entity.PhoneNumber,
                    StreetAddress = entity.StreetAddress
                };
            }
        }

        public bool UpdateContact(ContactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Contacts
                                .Single(e => e.Id == model.Id && e.ContactId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.StreetAddress = model.StreetAddress;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContact(string contactFirstName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Contacts
                                .Single(e => e.FirstName == contactFirstName && e.ContactId == _userId);

                ctx.Contacts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
