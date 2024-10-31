using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_thuc_tap_chuyen_de_1.Models
{
    public partial class DanhMucSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSach()
        {
            this.Sach = new HashSet<Sach>();
        }

        public int Id { get; set; }

        [Display(Name = "Tên Danh Mục")]
        [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
        public string TenDanhMuc { get; set; }

        [Display(Name = "Trạng Thái")]
        public Nullable<bool> TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
