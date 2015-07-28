using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ScoreManageSystem.Domain;

namespace ScoreManageSystem.Core.Domain
{
    public class Customer:BaseEntity
    {
        [DisplayName("姓名")]
        [MaxLength(4, ErrorMessage = "姓名不能超过4个字")]
        public string Name { get; set; }

        [MaxLength(12, ErrorMessage = "不能超过12个字符")]
        public string UserName { get; set; }
        public string Password { get; set; }

        public DateTime? LastLoginTime { get; set; }

    }
}