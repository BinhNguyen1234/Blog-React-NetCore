using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_vite_react.Model
{
    [Table("Enrollments", Schema = "dbo"),]
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid EnrollmentID { get; set; }
        public required string Grade { get; set; }
        //FK Course
        public Guid CourseID { get; set; }
        public Course? Course { get; set; }
        // FK Student
        public Guid StudentID { get; set; }
        public Student? Student { get; set; }
    }
}
