using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DecPlayground.Models
{
    public class VoteResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool? Answer { get; set; }


        public DateTime CreatedDateTime { get; set; }

        //deafult value
        public VoteResult() {
            this.CreatedDateTime = DateTime.Now;
        }
    }


}