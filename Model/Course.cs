using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace dotnet_vite_react.Model
{
    [Table("Course", Schema = "dbo"),]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CourseID { get; set; }
        [Required]
        public required string Title { get; set; }
        public required string Credits { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}