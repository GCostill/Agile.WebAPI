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
    [Authorize]
    public class BoxController : ApiController
    {
        private BoxService CreateBoxService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var boxService = new BoxService(userId);
            return boxService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            BoxService boxService = CreateBoxService();
            var boxes = boxService.GetAllEmails();
            return Ok(boxes);
        }   

        [HttpPost]
        public IHttpActionResult Post (BoxCreate box)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateBoxService();

            if (!service.CreateBox(box))
                return InternalServerError();

            return Ok();
        }
        
        public IHttpActionResult Get(string category)
        {
            BoxService boxService = CreateBoxService();
            var box = boxService.GetBoxByCategory(category);
            return Ok(box);
        }
    }
}
