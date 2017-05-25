namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        public long ID { get; set; }

        [Display(Name ="Nội Dung")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(10)]
        public string BaiHocID { get; set; }

        [Display(Name ="Ẩn Hiện")]
        public bool? AnHien { get; set; }
    }
}
