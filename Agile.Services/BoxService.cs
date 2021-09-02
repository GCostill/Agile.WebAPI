using Agile.Data;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Services
{
    public class BoxService
    {
        private readonly Guid _userId;

        public BoxService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBox(BoxCreate model)
        {
            var entity =
                new BoxData()
                {
                    OwnerId = _userId,
                    Category = model.Category,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Boxes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BoxListItem> GetEmails()
        {
            using (var ctx = new ApplicationDbContext())
            {
            var query =
                ctx
                    .Boxes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e =>
                        new BoxListItem
                        {
                            BoxId = e.Id,
                            From = e.From,
                            Subject = e.Subject,
                        }
                );

                return query.ToArray(); 
            }
        }

        public IEnumerable<BoxListItem> GetEmailsByCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Boxes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new BoxListItem
                            {
                                BoxId = e.Id,
                                From = e.From,
                                Subject = e.Subject,
                            }
                    );

                return query.ToArray();
            }
        }
}
