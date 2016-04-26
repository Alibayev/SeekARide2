using SeekARide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeekARide.DataAccess.Repository
{
    public class RequestRepository :Repository<Request>
    {
        public void CreateRequest(Request request)
        {
            Add(request);
            Context.SaveChanges();
        }

        public void UpdateRequest(Request request)
        {
            Update(request);
            Context.SaveChanges();
        }

        public List<Request> GetByUserId(int userId)
        {
            return Model.Where(x => x.User.UserId == userId).ToList();
        }
        public List<Request> GetByOwnerId(int userId)
        {
            return Model.Where(x => x.Owner.UserId == userId).ToList();
        }
    }
}