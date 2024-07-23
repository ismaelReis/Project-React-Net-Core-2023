using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_cds_domicilio")]
    public class Domicilio
    {
        [Key]
        [Column("co_seq_cds_domicilio")]
        public int Id { get; set; }
        [Column("co_unico_domicilio")]
        public string Codigo { get; set; }
        [Column("no_bairro")]
        public string Bairro { get; set; }
        [Column("no_logradouro")]
        public string Logradouro { get; set; }
        [Column("nu_domicilio")]
        public string Numero { get; set; }
        [Column("ds_complemento")]
        public string Completo { get; set; }
        [Column("ds_cep")]
        public string Cep { get; set; }
    }
}
