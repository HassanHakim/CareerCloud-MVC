using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco 
    {
        public SystemLanguageCodePoco()
        {
            CompanyDescriptions = new HashSet<CompanyDescriptionPoco>();
        }
        [Key]
        public string LanguageID { get; set; }
        
        [Column("Native_Name")]
        public string NativeName { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}
