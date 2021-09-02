using Agile.Data;
using Agile.Models;
using Agile.Services;
using Agile.WebAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agile.WebAPI.Controllers.AgileControllers
{
    [Authorize]
    public class ContactController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(ContactCreate contact)
        {
            if (contact is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContactService();

            if (!service.CreateContact(contact))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            ContactService contactService = CreateContactService();
            var contacts = contactService.GetContacts();
            return Ok(contacts);
        }
        public ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contactService = new ContactService(userId);
            return contactService;
        }
    }
}
