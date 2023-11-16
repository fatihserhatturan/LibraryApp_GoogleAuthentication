using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool Status { get; set; }


    }
}
