using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_dim_equipe")]
    public class Equipe
    {
        [Key]
        [Column("co_seq_dim_equipe")]
        public int Id { get; set; }
        [Column("nu_ine")]
        public string Ine { get; set; }
        [Column("no_equipe")]
        public string Nome { get; set; }
    }
}
