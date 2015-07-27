

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreManageSystem.Domain
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("姓名")]
        [MaxLength(4,ErrorMessage = "姓名不能超过4个字")]
        public string Name { get; set; }

        [MaxLength(12, ErrorMessage = "不能超过12个字符")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}