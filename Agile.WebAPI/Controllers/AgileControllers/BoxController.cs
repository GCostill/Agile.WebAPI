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

        public IHttpActionResult Get()
        {
            BoxService boxService = CreateBoxService();
            var boxes = boxService.GetEmails();
            return Ok(boxes);
        }   

       public IHttpActionResult Get(string category)
        {
            BoxService boxService = CreateBoxService();
            var box = boxService.GetBoxByCategory(category);
            return Ok(box);
        }

        public IHttpActionResult Post (BoxCreate box)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateBoxService();

            if (!service.CreateBox(box))
                return InternalServerError();

            return Ok();
        }
        private BoxService CreateBoxService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var boxService = new BoxService(userId);
            return boxService;
        }
    }
}
