using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SidimEsus.Models
{
    [Table("tb_fat_visita_domiciliar")]
    public class VisitaDomiciliar
    {
        [Key]
        [Column("co_seq_fat_visita_domiciliar")]
        public int Id { get; set; }
        [Column("co_dim_profissional")]
        public int FuncionarioId { get; set; }
        [Column("co_fat_cidadao_pec")]
        public int? CidadaoId { get; set; }
        [Column("co_dim_unidade_saude")]
        public int? EstabelecimentoId { get; set; }
        [Column("co_dim_equipe")]
        public int? EquipeId { get; set; }
        [Column("co_dim_tempo")]
        public int? Data { get; set; }
        [Column("co_dim_turno")]
        public int? Turno { get; set; }
        [Column("co_dim_cbo")]
        public int? CboId { get; set; }
        [Column("nu_micro_area")]
        public string MicroArea { get; set; }
        [Column("nu_cns")]
        public string Cns { get; set; }
        [Column("dt_nascimento")]
        public DateTime? Nascimento { get; set; }

    }
}
