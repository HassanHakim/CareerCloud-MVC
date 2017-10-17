using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table ("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        public ApplicantProfilePoco()
        {
            ApplicantEducations = new HashSet<ApplicantEducationPoco>();
            ApplicantJobApplications = new HashSet<ApplicantJobApplicationPoco>();
            ApplicantResumes = new HashSet<ApplicantResumePoco>();
            ApplicantSkills = new HashSet<ApplicantSkillPoco>();
            ApplicantWorkHistory = new HashSet<ApplicantWorkHistoryPoco>();
        }
        [Key]
        public Guid Id { get; set; }

        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }

        [Column("Country_Code")]
        public string Country { get; set; }

        [Column("State_Province_Code")]
        public string Province { get; set; }
        
        [Column("Street_Address")]
        public string Street { get; set; }

        [Column("City_Town")]
        public string City { get; set; }

        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public Guid Login { get; set; }

        public string Currency { get; set; }

        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
        public virtual SecurityLoginPoco SecurityLogin { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }


    }
}
