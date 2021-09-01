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
        private EmailService SendEmailService()
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

            var service = SendEmailService();
            var userEmail = User.Identity.GetUserName();
            bool emailSendResult = service.SendEmail(emailSend, userEmail);

            if (!emailSendResult)
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

            var service = SendEmailService();
            var userEmail = User.Identity.GetUserName();
            bool emailRecieveResult = service.RecieveEmail(emailRecieve, userEmail);

            if (!emailRecieveResult)
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

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = SendEmailService();
            var userEmail = User.Identity.GetUserName();
            bool emailSendResult = service.ReplyEmail(emailReply, userEmail);

            if (!emailSendResult)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
