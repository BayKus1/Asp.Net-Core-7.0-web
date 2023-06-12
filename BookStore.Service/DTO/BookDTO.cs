using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Models
{
    public  class BookDTO
    {
       
        public int Id { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Kategori Alanı Zorunludur")]

        
        public int CategoryId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        public string? Name { get; set; }

        [DisplayName("Yazar")]
        [Required(ErrorMessage = "Yazar Alanı Zorunludur")]
        public string? Writer { get; set; }

        [DisplayName("Yayın Yılı")]
        [Required(ErrorMessage = "Yayın Yılı Alanı Zorunludur")]
        public int Year { get; set; }

        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;

        public string? CategoryName { get; set; }

        public  List<Category>? CategoryList { get; set; }
    }
}
