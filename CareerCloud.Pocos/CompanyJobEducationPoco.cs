using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public Guid Job { get; set; }

        public string Major { get; set; }

        public Int16 Importance { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set;}

    }
}
