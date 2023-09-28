using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCompany.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(200)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        public Company() { }
        public Company(string name, string description) {
        
            this.Name = name;
            this.Description = description;
        }
    }
}
