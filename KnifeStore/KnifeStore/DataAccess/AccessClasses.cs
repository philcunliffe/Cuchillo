using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KnifeStore.Models;

namespace KnifeStore.DataAccess
{
    public class AccessClasses
    {
        private KnifeStoreContext db;

        public AccessClasses(KnifeStoreContext db)
        {
            this.db = db;
        }

        public UserProfile GetUserFromId(int Id)
        {
            var profile = db.UserProfiles.Where(x => x.UserId == Id);
            var ret = profile.ToList<UserProfile>()[0];
            return ret;
        }

        public List<int> GetUserRequestsFromId(int Id)
        {
            var subscriptions = db.Subscriptions.Where(x => x.UserProfileId == Id).ToList<Subscription>();
            List<int> ret = new List<int>();
            foreach (var subscription in subscriptions)
            {
                ret.Add(subscription.ProductId);
            }

            return ret;
        }
    }
}