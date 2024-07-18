using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_dim_unidade_saude")]
    public class Estabelecimento
    {
        [Key]
        [Column("co_seq_dim_unidade_saude")]
        public int Id { get; set; }
        [Column("nu_cnes")]
        public string Cnes { get; set; }
        [Column("no_unidade_saude")]
        public string Nome { get; set; }
        [Column("no_bairro")]
        public string Bairro { get; set; }
    }
}
