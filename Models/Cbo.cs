using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_dim_cbo")]
    public class Cbo
    {
        [Key]
        [Column("co_seq_dim_cbo")]
        public int Id { get; set; }
        [Column("nu_cbo")]
        public string Codigo { get; set; }
        [Column("no_cbo")]
        public string Nome { get; set; }
    }
}
