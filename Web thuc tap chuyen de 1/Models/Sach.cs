using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_thuc_tap_chuyen_de_1.Models
{
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.Cart = new HashSet<Cart>();
        }

        public int MaSach { get; set; }

        [Display(Name = "Tên Sách")]
        [Required(ErrorMessage = "Tên sách là bắt buộc.")]
        public string TenSach { get; set; }

        [Display(Name = "Danh Mục")]
        public Nullable<int> IdDM { get; set; }

        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        public Nullable<int> SoLuong { get; set; }

        [Display(Name = "Đơn Giá")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> DonGia { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string Img { get; set; }

        [Display(Name = "Tác Giả")]
        [Required(ErrorMessage = "Tác giả là bắt buộc.")]
        public string TacGia { get; set; }

        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual DanhMucSach DanhMucSach { get; set; }
    }
}
