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

        [StringLength(150)]
        public string Ten { get; set; }

        public int? ThuTu { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public long? IDCha { get; set; }

        public bool? AnHien { get; set; }

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

        public bool? ShowOnHome { get; set; }
    }
}
