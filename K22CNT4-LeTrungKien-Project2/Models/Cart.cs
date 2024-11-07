using System;
using System.ComponentModel.DataAnnotations;

namespace Web_thuc_tap_chuyen_de_1.Models
{
    public partial class Cart
    {
        public int Id { get; set; }

        [Display(Name = "ID Sách")]
        public Nullable<int> IdSach { get; set; }

        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        public Nullable<int> SoLuong { get; set; }

        [Display(Name = "Đơn Giá")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> DonGia { get; set; }

        [Display(Name = "Tổng")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Tong { get; set; }

        [Display(Name = "ID Khách Hàng")]
        public Nullable<int> IdKH { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string Img { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
