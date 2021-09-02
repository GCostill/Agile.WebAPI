using Agile.Models;
using Agile.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agile.WebAPI.Controllers.AgileControllers
{
    public class EmailController : ApiController
    {
        private EmailService StartEmailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var emailService = new EmailService(userId);
            return emailService;
        }

        [HttpPost]
        [Route("api/Email/Send")]
        public IHttpActionResult Post([FromBody] EmailCreate emailSend)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = StartEmailService();
            var userEmail = User.Identity.GetUserName();

            if (!service.SendEmail(emailSend, userEmail))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPost]
        [Route("api/Email/Recieve")]
        public IHttpActionResult PostEmailRecieve([FromBody] EmailRecieve emailRecieve)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = StartEmailService();
            var userEmail = User.Identity.GetUserName();

            if (!service.RecieveEmail(emailRecieve, userEmail))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPost]
        [Route("api/Email/Reply")]
        public IHttpActionResult PostReplyEmail([FromBody] EmailReply emailReply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = StartEmailService();
            var userEmail = User.Identity.GetUserName();

            if (!service.ReplyEmail(emailReply, userEmail))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Email")]
        public IHttpActionResult GetAllEmails()
        {

            EmailService service = StartEmailService();
            var emails = service.GetAllEmails();

            if (emails is null)
            {
                return BadRequest("No emails exist in the database!");
            }

            if (emails.Count == 0)
            {
                return BadRequest("No emails exist in the database!");
            }

            return Ok(emails);
        }

        [HttpDelete]
        [Route("api/Email")]
        public IHttpActionResult DeleteEmail([FromUri] int emailId)
        {

            EmailService service = StartEmailService();

            if (!service.DeleteEmail(emailId))
            {
                return InternalServerError();
            }

            return Ok();

        }
    }
}
