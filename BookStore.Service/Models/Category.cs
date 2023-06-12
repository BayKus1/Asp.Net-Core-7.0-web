using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }


		[DisplayName("Ad")]
		[Required(ErrorMessage ="Ad Alanı Zorunludur")]
		public required string Name { get; set; }

		public virtual ICollection<Book>? Books { get; set; }
	}
}
