﻿using Agile.Models;
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

            var service = StartEmailService();
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

            var service = StartEmailService();
            var userEmail = User.Identity.GetUserName();
            bool emailSendResult = service.ReplyEmail(emailReply, userEmail);

            if (!emailSendResult)
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
                return BadRequest("No replys exist in the database!");
            }

            if (emails.Count == 0)
            {
                return BadRequest("No replys exist in the database!");
            }

            return Ok(emails);
        }

        [HttpDelete]
        [Route("api/Email")]
        public IHttpActionResult DeleteEmail([FromUri] int emailId)
        {

            EmailService service = StartEmailService();
            var emailDelete = service.DeleteEmail(emailId);

            if (!emailDelete)
            {
                return InternalServerError();
            }

            return Ok();

        }
    }
}
