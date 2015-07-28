using System.ComponentModel.DataAnnotations;
using ScoreManageSystem.Core.Domain.Teachers;
using ScoreManageSystem.Domain;

namespace ScoreManageSystem.Core.Domain.Students
{
    public class Subject:BaseEntity
    {
        [Required]
        public string SubjectName { get; set; }
        public double? Score { get; set; }

        public virtual Student Student { get; set; }
        /// <summary>
        /// 只要此学科中的学生、老师都属于该学校
        /// </summary>
        public virtual School School { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}