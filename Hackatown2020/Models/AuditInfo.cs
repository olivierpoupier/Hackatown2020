using Hackatown2020.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hackatown2020.Models
{
    public class AuditInfo : IAuditInfo
    {
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
