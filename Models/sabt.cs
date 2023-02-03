using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace komite.Models
{
    public class sabt
    {
        [Key]
        public Int64 id_sabt { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان مصوبه")]
        [Required(ErrorMessage = "لطفا عنوان مصوبه را مشخص نمایید")]
        public string? onvan { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ برگزاری جلسه")]
        [Required(ErrorMessage = "لطفا تاریخ برگزاری جلسه را وارد نمایید")]
        public string? date_jalase { get; set; }
        //**********************************************************************
        [Display(Name = "مسئول انجام یا اجرا")]
        [Required(ErrorMessage = "لطفا انجام یا اجرا را وارد نمایید")]
        public string? masul_anjam { get; set; }
        //**********************************************************************
        [Display(Name = "مسئول پیگیری")]
        [Required(ErrorMessage = "لطفا مسئول پیگیری را وارد نمایید")]
        public string? masul_peygiri { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ شروع اجرای مصوبه")]
        [Required(ErrorMessage = "لطفا تاریخ شروع اجرای مصوبه را وارد نمایید")]
        public string? date_shoru { get; set; }
        //**********************************************************************
        [Display(Name = "مهلت زمانی اجرای مصوبه")]
        [Required(ErrorMessage = "لطفا مهلت زمانی اجرای مصوبه را وارد نمایید")]
        public string? date_mohlat { get; set; }
        //**********************************************************************
        [Display(Name = "وضعیت اجرایی شدن")]
        [Required(ErrorMessage = "لطفا وضعیت اجرایی شدن را مشخص نمایید")]
        public Int64 id_vaziat { get; set; }
        //**********************************************************************
        [Display(Name = "توضیحات")]
        //[Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public string? tozihat { get; set; }
        //**********************************************************************
        [Display(Name = "درصد تحقق")]
        //[Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public Int64? darsad { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان کمیته")]
        [Required(ErrorMessage = "لطفا عنوان کمیته را وارد نمایید")]
        public Int64? id_onvan_komite { get; set; }
        //**********************************************************************
        [Display(Name = "سال")]
        [Required(ErrorMessage = "لطفا سال را وارد نمایید")]
        public Int64? sal { get; set; }
        //**********************************************************************



    }
}
