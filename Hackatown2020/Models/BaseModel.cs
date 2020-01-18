using Hackatown2020.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackatown2020.Models
{
    public class BaseModel : AuditInfo, IBaseModel
    {
        public int Id { get; set; }
    }
}