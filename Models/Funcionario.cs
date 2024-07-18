using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_dim_profissional")]
    public class Funcionario
    {
        [Key]
        [Column("co_seq_dim_profissional")]
        public int Id { get; set; }
        [Column("nu_cns")]
        public string Cns { get; set; }
        [Column("no_profissional")]
        public string Nome { get; set; }
    }
}
