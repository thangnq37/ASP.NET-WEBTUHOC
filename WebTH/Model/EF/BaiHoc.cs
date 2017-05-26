namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiHoc")]
    public partial class BaiHoc
    {
        public long ID { get; set; }

        [StringLength(255)]
        [Display(Name ="Tiêu Đề")]
        public string TieuDe { get; set; }

        [Display(Name ="Tóm Tắt")]
        [StringLength(1200)]
        public string TomTat { get; set; }

        [StringLength(200)]
        public string UrlHinh { get; set; }

        [Display(Name ="Nội Dung")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [Display(Name ="Số Lần Xem")]
        public int? SoLanXem { get; set; }

        [Display(Name ="Ẩn Hiện")]
        public bool AnHien { get; set; }

        public int? IDLoaiBaiHoc { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [Display(Name ="Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name ="Tạo Bởi")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(255)]
        public string MetaKeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [StringLength(550)]
        public string Tags { get; set; }
    }
}
