using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_thuc_tap_chuyen_de_1.Models
{
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.Cart = new HashSet<Cart>();
        }

        public int MaKH { get; set; }

        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        public string SDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NgaySinh { get; set; }

        [Display(Name = "Ngày Đăng Ký")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NgayDangKy { get; set; }

        [Display(Name = "Trạng Thái")]
        public Nullable<bool> TrangThai { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
