using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models.ViewModel
{
    public class ReviewViewModel
    {
        public int ProductId { get; set; }
       
        public string UserId { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }
    }
}