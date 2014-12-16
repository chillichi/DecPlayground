using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DecPlayground.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}