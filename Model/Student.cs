using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet_vite_react.Model;

namespace dotnet_vite_react.Model
{
	[Table("Students", Schema = "dbo"), ]
	public class StudentEntity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
		public Guid StudentID { get; set; }
		[Required]
		public required string LastName { get; set; }
		[Required]
		public required string FirstName { get; set; }
		[Column(TypeName = "date")]
		public DateTime? EnrollmentDate { get; set; }
		public virtual ICollection<EnrollmentEntity>? Enrollments { get; set; }
    }
}

