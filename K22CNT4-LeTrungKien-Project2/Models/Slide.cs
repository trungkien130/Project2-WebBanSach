using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_thuc_tap_chuyen_de_1.Models
{
    public partial class Slide
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "Hình ảnh là bắt buộc.")]
        public string Img { get; set; }

        [Display(Name = "Tiêu Đề")]
        [Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự.")]
        public string Title { get; set; }
    }
}
