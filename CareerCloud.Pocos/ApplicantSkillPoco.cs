using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Skill_Level")]
        public string SkillLevel { get; set; }

        [Column("Start_Month")]
        public byte StartMonth { get; set; }


        [Column("Start_Year")]
        public int StartYear { get; set; }


        [Column("End_Month")]
        public byte EndMonth { get; set; }


        [Column("End_Year")]
        public int EndYear { get; set; }


        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public Guid Applicant { get; set; }

        public string Skill { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
