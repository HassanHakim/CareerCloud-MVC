﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        public SecurityLoginPoco()
        {
            ApplicantProfiles = new HashSet<ApplicantProfilePoco>();
            SecurityLoginsLogs = new HashSet<SecurityLoginsLogPoco>();
            SecurityLoginsRoles = new HashSet<SecurityLoginsRolePoco>();
        }
        [Key]
        public Guid Id { get; set; }

        [Column("Created_Date")]
        public DateTime Created { get; set; }

        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }


        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]
        public bool IsLocked { get; set; }


        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column("Email_Address")]
        public string EmailAddress { get; set; }

        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }

        [Column("Full_Name")]
        public string FullName { get; set; }

        [Column("Force_Change_Password")]
        public bool ForceChangePassword { get; set; }

        [Column("Prefferred_Language")]
        public string PrefferredLanguage { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles{ get; set;}

        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set;}

        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }


    }
}