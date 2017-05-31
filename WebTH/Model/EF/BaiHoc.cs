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

        [Display(Name ="Tiêu đề")]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Display(Name ="Tóm tắt")]
        [StringLength(1200)]
        public string TomTat { get; set; }

        [StringLength(200)]
        public string UrlHinh { get; set; }

        [Display(Name ="Nôi dung")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public int? SoLanXem { get; set; }

        [Display(Name ="Hiện")]
        public bool AnHien { get; set; }

        [Display(Name ="IDLoai")]
        public long? IDLoaiBaiHoc { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

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
