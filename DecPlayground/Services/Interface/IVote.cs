using DecPlayground.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecPlayground.Services.Interface
{
    public interface IVote
    {
        List<VoteResult> GetVoteResults();
        bool IsExists(string email);
        void AddVote(VoteResult result);

        IList GetPieChart();
    }
}
