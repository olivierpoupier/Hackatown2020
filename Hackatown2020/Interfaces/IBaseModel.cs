using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackatown2020.Interface
{
    public interface IBaseModel
    {
        [Key]
        int Id { get; set; }
    }
}
