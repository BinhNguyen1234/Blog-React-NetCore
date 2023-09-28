using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace dotnet_vite_react.Model
{
    [Table("Courses", Schema = "dbo"),]
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CourseID { get; set; }
        [Required]
        public required string Title { get; set; }
        public required string Credits { get; set; }
        public virtual ICollection<EnrollmentEntity>? Enrollments { get; set; }
    }
}