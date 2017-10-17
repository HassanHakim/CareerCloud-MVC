using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Skill_Level")]
        public string SkillLevel { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public string Skill { get; set; }

        public int Importance { get; set; }

        public Guid Job { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
