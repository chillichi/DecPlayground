using DecPlayground.DAL;
using DecPlayground.Models;
using DecPlayground.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DecPlayground.Services
{
    public class VoteService : IVote
    {
        private DecPlaygroundContext db = new DecPlaygroundContext();

        public List<VoteResult> GetVoteResults()
        {
            return db.VoteResults.ToList();
        }

        public bool IsExists(string email)
        {
            return db.VoteResults.Where(result => result.Email.Trim() == email.Trim()).FirstOrDefault()!=null;
        }

        public void AddVote(VoteResult result)
        {
            db.VoteResults.Add(result);
            db.SaveChanges();
        }

        public IList GetPieChart() {
            return db.VoteResults.Where(result=>result.Answer!=null)
                                 .GroupBy(result => result.Answer)
                                 .Select(group => new
                                 {
                                     TrueOrFalse = (bool)group.Key? "true" : "false",
                                     HeadCount = group.Count()
                                 }).ToList();
        }
    }
}