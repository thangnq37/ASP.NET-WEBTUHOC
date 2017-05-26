namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiBaiHoc")]
    public partial class LoaiBaiHoc
    {
        public long ID { get; set; }

        [Display(Name ="Tên")]
        [StringLength(150)]
        public string Ten { get; set; }
        [Display(Name = "Thứ Tự")]
        public int? ThuTu { get; set; }

        [Display(Name ="Mô Tả")]
        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [Display(Name ="ID cha")]
        public long? IDCha { get; set; }

        [Display(Name ="Ẩn Hiện")]
        public bool AnHien { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [Display(Name ="Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name ="Tạo Bởi")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(255)]
        public string MetaKeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? ShowOnHome { get; set; }
    }
}
