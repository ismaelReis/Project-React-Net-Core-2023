using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_fat_cidadao_pec")]
    public class Cidadao
    {
        [Key]
        [Column("co_seq_fat_cidadao_pec")]
        public int Id { get; set; }
        [Column("no_cidadao")]
        public string Nome { get; set; }

    }
}
