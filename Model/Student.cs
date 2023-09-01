using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_vite_react.Model;

namespace dotnet_vite_react.Model
{
	[Table("Students", Schema = "dbo"), ]
	public class Student
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
		public Guid StudentID { get; set; }
		[Required]
		public required string LastName { get; set; }
		[Required]
		public required string FirstName { get; set; }
		public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}

