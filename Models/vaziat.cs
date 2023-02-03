using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace komite.Models
{
    public class vaziat
    {
        [Key]
        public Int64 id_vaziat { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا عنوان وضعیت را مشخص نمایید")]
        public string onvan_vaziat { get; set; }
        //**********************************************************************
       


    }
}
