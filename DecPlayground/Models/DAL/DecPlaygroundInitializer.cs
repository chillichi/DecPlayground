using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DecPlayground.Models;

namespace DecPlayground.DAL
{
    public class DecPlaygroundInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DecPlaygroundContext>
    {
        protected override void Seed(DecPlaygroundContext context)
        {
            var VoteResults = new List<VoteResult>
            {
            new VoteResult{Email="aaa@gmail.com",Answer=true,CreatedDateTime=new DateTime(2014, 01, 01, 08, 00, 00)},
            new VoteResult{Email="bbb@gmail.com",Answer=true,CreatedDateTime=new DateTime(2014, 01, 01, 08, 00, 00)},
            new VoteResult{Email="ccc@gmail.com",Answer=true,CreatedDateTime= DateTime.Now},
            };

            VoteResults.ForEach(v => context.VoteResults.Add(v));
            context.SaveChanges();

            var Tasks = new List<Task>{
                  new Task() { Id = 1, Desc = "Buy a sandwich", CreatedDateTime = new DateTime(2014, 01, 01, 08, 00, 00) },
                  new Task() { Id = 2, Desc = "check email",    CreatedDateTime = new DateTime(2014, 01, 01, 09, 15, 00) },
                  new Task() { Id = 3, Desc = "Do something",   CreatedDateTime = new DateTime(2014, 01, 02, 09, 30, 00) }
              };
            Tasks.ForEach(v => context.Tasks.Add(v));
            context.SaveChanges();
           
        }
    }
}