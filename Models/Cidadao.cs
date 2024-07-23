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
        [Column("nu_cns")]
        public string Cns { get; set; }
        [Column("nu_cpf_cidadao")]
        public string Cpf { get; set; }
        [Column("st_faleceu")]
        public int? Faleceu { get; set; }
        [Column("co_dim_sexo")]
        public int? Sexo { get; set; }
        [Column("nu_telefone_celular")]
        public string Telefone { get; set; }
        [Column("co_dim_tempo_nascimento")]
        public int? Nascimento { get; set; }
        [Column("co_dim_unidade_saude_vinc")]
        public int? EstabelecimentoId { get; set; }
        [Column("co_dim_equipe_vinc")]
        public int? EquipeId { get; set; }


    }
}
