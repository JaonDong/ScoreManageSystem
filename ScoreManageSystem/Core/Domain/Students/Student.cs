using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScoreManageSystem.Core.Domain.Students
{
    public class Student:Customer
    {
        [Required]
        public string StuNo { get; set; }

    }
}