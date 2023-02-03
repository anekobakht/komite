using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace komite.Models
{
    public class onvan_komite
    {
        [Key]
        public Int64 id_onvan_komite { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان کمیته")]
        [Required(ErrorMessage = "لطفا عنوان کمیته را مشخص نمایید")]
        public string? name { get; set; }
        //**********************************************************************
        public Int64? id_user { get; set; }


    }
}
