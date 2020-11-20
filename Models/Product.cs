namespace CRUDLayout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int id { get; set; }

        [StringLength(50), Display(Name ="Name")]
        public string name { get; set; }
        [Column(TypeName = "text"), Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Price"), Required(ErrorMessage = "Enter feild")]
        public decimal? price { get; set; }
        [Column(TypeName = "text"), Display(Name = "ImgUrl")]
        public string imgurl { get; set; }
        [Display(Name = "Category")]
        public int? idcategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
