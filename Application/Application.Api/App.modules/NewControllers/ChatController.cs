using Application.Bal.Viewmodels;
using Application.Dal.DataModel;
using Aylien.TextApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.ModelBinding;
using static Application.Bal.Viewmodels.Message;

namespace Application.Api.App.modules.NewControllers
{
    public class ChatController : ApiController
    {
        ChatAppEntities db = new ChatAppEntities();
        public async Task<List<ChatConversation>> SendMessage(Messages message)
        {
            ChatConversation CC = new ChatConversation()
            {
                FromId = message.FromUser,
                ToId = message.ToUser,
                Message = message.message,
                Date = DateTime.Now,
                ////Type="sent"
            };
            db.ChatConversations.Add(CC);
            await db.SaveChangesAsync();
            var msg = await Task.Run(() => db.ChatConversations.Where(c => c.ToId == message.ToUser && c.FromId == message.FromUser || c.FromId == message.ToUser && c.ToId == message.FromUser).ToList());
            if (msg.Count != 0)
            {
                for (int i = 0; i < msg.Count; i++)
                {
                    if (msg[i].FromId == message.FromUser)
                    {
                        msg[i].Type = "sent";
                    }
                    else
                    {
                        msg[i].Type = "received";

                    }
                }
                return msg;

            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<List<UsersList>> Users(UserInfo User)
        {
            List<UsersList> UL = new List<UsersList>();
            var users = db.A_U_Management.Where(c => c.StudentId != User.UserId).ToList();
            foreach (var item in users)
            {
                var Session = await Task.Run(() => db.SessionDetails.Where(c => c.UserId == item.StudentId).OrderByDescending(c=>c.Id).FirstOrDefault());
                if (Session != null)
                {
                    UsersList ul = new UsersList()
                    {
                        FullName = item.FullName,
                        UserUID = item.UserUID,
                        CustomerID = item.StudentId,
                        LoggedIn = Session.LoggedIn,
                        LoggedInTime = Session.LoggedInTime,
                        LoggedOutTime = Session.LoggedOutTime

                    };
                    UL.Add(ul);
                }


            }
            return UL;
        }

        public async Task<List<ChatConversation>> UsersMessage(GetMessage User)
        {
            if (User.FromUser != null && User.ToUser != null)
            {
                var msg = await Task.Run(() => db.ChatConversations.Where(c => c.ToId == User.ToUser && c.FromId == User.FromUser || c.FromId == User.ToUser && c.ToId == User.FromUser).ToList());
                if (msg.Count != 0)
                {
                    for (int i = 0; i < msg.Count; i++)
                    {
                        if (msg[i].FromId == User.FromUser)
                        {
                            msg[i].Type = "sent";
                        }
                        else
                        {
                            msg[i].Type = "received";

                        }
                    }
                    return msg;

                }
                else
                {
                    return null;
                }

            }
            return null;
        }

        public async void UsersLogged(GetMessage User)
        {
            var logs = db.SessionDetails.Where(c => c.UserId == User.FromUser && c.LoggedOutTime==null).ToList();
            for (int i = 0; i < logs.Count; i++)
            {
                logs[i].LoggedOutTime = DateTime.Now;
                logs[i].LoggedIn = false;
                db.Entry(logs[i]).State = EntityState.Modified;
                db.SaveChanges();
            }
   
        }

        public async Task<string> AnalaysTest(TextAnalysis User)
        {
            Client client = new Client("628daf0f", "3ba512d6bf32a4642de2bca8e89a4e59");
            Sentiment sentiment = client.Sentiment(text: User.Texts);
            return sentiment.Polarity;
        }


    }
}
