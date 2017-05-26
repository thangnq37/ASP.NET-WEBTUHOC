namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập họ tên")]
        [Display(Name ="Họ Tên")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập username")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập Password")]
        [DataType(DataType.Password)]
        [StringLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name ="Ẩn Hiện")]
        public bool AnHien { get; set; }

        [Display(Name ="Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name ="Tạo bởi")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
