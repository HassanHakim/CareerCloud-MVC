using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext(bool createProxy = true)
              : base (ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)      
            // : base("name = dbconnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Configuration.ProxyCreationEnabled = createProxy;
        }

        public CareerCloudContext()
        : base("name = dbconnection")
        
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);          
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Applicant_Educations
            modelBuilder.Entity<ApplicantEducationPoco>()
            .Property(e => e.TimeStamp)
            .IsRowVersion()
            .IsFixedLength();
            #endregion

            #region Applicant_Job_Applications
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Applicant Profile
            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.CurrentSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.Country)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.Province)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.PostalCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(p => p.ApplicantEducations)
                .WithRequired(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(p => p.ApplicantJobApplications)
                .WithRequired(j => j.ApplicantProfile)
                .HasForeignKey(j => j.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(p => p.ApplicantResumes)
                .WithRequired(r => r.ApplicantProfile)
                .HasForeignKey(r => r.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(p => p.ApplicantSkills)
                .WithRequired(s => s.ApplicantProfile)
                .HasForeignKey(s => s.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(p => p.ApplicantWorkHistory)
                .WithRequired(h => h.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);
            #endregion

            #region Applicant Skills
            modelBuilder.Entity<ApplicantSkillPoco>()
                .Property(e => e.SkillLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Applicant Work History
                  modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                      .Property(e => e.CountryCode)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                      .Property(e => e.TimeStamp)
                      .IsRowVersion()
                      .IsFixedLength();
            #endregion

            #region Company Descriptions
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .Property(e => e.LanguageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Company Job Descriptions
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Company Job Education
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Company Jobs
            modelBuilder.Entity<CompanyJobPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobSkills)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobDescriptions)
                .WithRequired(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);
            #endregion

            #region Company Job Skills
            modelBuilder.Entity<CompanyJobSkillPoco>()
                .Property(e => e.SkillLevel)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyJobSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Company Locations
            modelBuilder.Entity<CompanyLocationPoco>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyLocationPoco>()
                .Property(e => e.Province)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyLocationPoco>()
                .Property(e => e.PostalCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyLocationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Company Profile
            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.CompanyWebsite)
                .IsUnicode(false);
            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.ContactName)
                .IsUnicode(false);
            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.ContactPhone)
                .IsUnicode(false);
            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(d => d.CompanyProfile)
                .HasForeignKey(d => d.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyJobs)
                .WithRequired(j => j.CompanyProfile)
                .HasForeignKey(j => j.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyLocations)
                .WithRequired(l => l.CompanyProfile)
                .HasForeignKey(l => l.Company)
                .WillCascadeOnDelete(false);
            #endregion


            #region Security Logins

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.PrefferredLanguage)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithRequired(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsLogs)
                .WithRequired(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);
            #endregion

            #region Security Logins Log
            modelBuilder.Entity<SecurityLoginsLogPoco>()
                .Property(e => e.SourceIP)
                .IsFixedLength()
                .IsUnicode(false);
            #endregion

            #region Security Logins Roles
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsFixedLength();
            #endregion

            #region Security Roles
            modelBuilder.Entity<SecurityRolePoco>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityRole)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);
            #endregion


            #region System Country Codes
            modelBuilder.Entity<SystemCountryCodePoco>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithOptional(e => e.SystemCountryCode)
                .HasForeignKey(e => e.Country);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantWorkHistory)
                .WithRequired(e => e.SystemCountryCode)
                .HasForeignKey(e => e.CountryCode)
                .WillCascadeOnDelete(false);
            #endregion

            #region System Language Codes
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .Property(e => e.LanguageID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithRequired(e => e.SystemLanguageCode)
                .WillCascadeOnDelete(false);
            #endregion
        }

    }
}
