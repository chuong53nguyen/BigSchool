namespace BigShool.Models
{
    using System;
    using System.Data.Entity.Spatial;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Course")]
    public partial class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string LecturerId { get; set; }

        [Required]
        [StringLength(250)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public string Name { set; get; }

        public List<Category> ListCategory = new List<Category>();
    }
}
