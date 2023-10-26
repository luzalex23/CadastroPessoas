using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoas.Model
{
    [Table("pessoas")]
    public class Pessoas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idPessoa { get; private set; }
        public string name {  get; private set; }
        public int age {  get; private set; }
        public string? photo {  get; private set; }

        public Pessoas(string name, int age, string? photo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;

        }

    }
    
}
