using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBSecurityMVC.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public string TestResult { get; set; }
        public DateTime TestDate { get; set; }
    }
}