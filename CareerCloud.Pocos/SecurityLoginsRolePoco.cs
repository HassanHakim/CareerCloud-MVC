using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public Guid Login { get; set; }
        public Guid Role { get; set; }
        
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        public  virtual SecurityRolePoco SecurityRole { get; set; }     
    }
}
