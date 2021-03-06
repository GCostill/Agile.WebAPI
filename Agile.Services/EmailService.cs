using Agile.Data;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Services
{
    public class EmailService
    {
        private readonly Guid _userId;
        private readonly string[] _categories = { "Sent", "Recieved" };

        public EmailService(Guid userId)
        {
            _userId = userId;
        }

        public bool SendEmail(EmailCreate model, string userEmail)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    new EmailData()
                    {
                        To = model.To,
                        From = userEmail,
                        Subject = model.Subject,
                        Body = model.Body,
                        HasAttachment = model.HasAttachment,
                        Time = DateTime.Now,
                        Category = _categories[0]
                    };

                ctx.Emails.Add(entity);

                return ctx.SaveChanges() > 0;
            }
        }

        public bool RecieveEmail(EmailRecieve model, string userEmail)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    new EmailData()
                    {
                        To = userEmail,
                        From = model.From,
                        Subject = model.Subject,
                        Body = model.Body,
                        HasAttachment = model.HasAttachment,
                        Time = DateTime.Now,
                        Category = _categories[1]
                    };

                ctx.Emails.Add(entity);

                return ctx.SaveChanges() > 0;
            }
        }

        public bool ReplyEmail(EmailReply model, string userEmail)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allEmails = ctx.Emails.ToList();

                EmailData emailToReplyTo = new EmailData();

                foreach(EmailData email in allEmails)
                {
                    if(email.Category == _categories[1] && model.EmailId == email.Id)
                    {
                        emailToReplyTo = email;
                    }
                }
                
                if (emailToReplyTo is null)
                {
                    return false;
                }

                var entity =
                    new EmailData()
                    {
                        From = userEmail,
                        To = emailToReplyTo.From,
                        Subject = emailToReplyTo.Subject,
                        Body = model.Body,
                        HasAttachment = model.HasAttachment,
                        Time = DateTime.Now,
                        Category = _categories[0]
                    };

                ctx.Emails.Add(entity);

                return ctx.SaveChanges() > 0;
            }
        }

        public List<EmailList> GetAllEmails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var emails = ctx.Emails.ToList();

                if (emails is null)
                {
                    return null;
                }

                List<EmailList> allEmailsList = new List<EmailList>();

                foreach (EmailData email in emails)
                {

                    EmailList emailListInbox = new EmailList
                    {
                        EmailID = email.Id,
                        From = email.From,
                        To = email.To,
                        Subject = email.Subject,
                        HasAttachment = email.HasAttachment,
                        Time = email.Time,
                        Category = email.Category
                    };

                    allEmailsList.Add(emailListInbox);

                }

                return allEmailsList;
            }
        }

        public bool DeleteEmail(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allEmails = ctx.Emails.ToList();

                EmailData emailToDelete = new EmailData();

                foreach (EmailData email in allEmails)
                {
                    if (ID == email.Id)
                    {
                        emailToDelete = email;
                    }
                }

                if (emailToDelete is null)
                {
                    return false;
                }

                ctx.Emails.Remove(emailToDelete);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
