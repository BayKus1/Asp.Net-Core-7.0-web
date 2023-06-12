using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Service.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }	

		
		public int CategoryId { get; set; }

		public string Name { get; set; }

		
		public string Writer { get; set; }

		
		public int Year { get; set; }

        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;

        [ForeignKey("CategoryId")]
		public Category Category { get; set; }

	}
}
