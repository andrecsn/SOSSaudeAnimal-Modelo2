namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("animal")]
    public partial class animal
    {
        public animal()
        {
            consulta = new HashSet<consulta>();
            historico_vacina = new HashSet<historico_vacina>();
        }

        [Key]
        public int cd_animal { get; set; }

        [StringLength(100)]
        public string nm_animal { get; set; }

        [StringLength(20)]
        public string cor { get; set; }

        [StringLength(20)]
        public string peso { get; set; }

        [StringLength(20)]
        public string sexo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_nascimento { get; set; }

        public string inf_animal { get; set; }

        [StringLength(100)]
        public string foto { get; set; }

        public int? cd_raca { get; set; }

        public int? cd_especie { get; set; }

        public int? cd_responsavel { get; set; }

        public virtual raca raca { get; set; }

        public virtual especie especie { get; set; }

        public virtual responsavel responsavel { get; set; }

        public virtual ICollection<consulta> consulta { get; set; }

        public virtual ICollection<historico_vacina> historico_vacina { get; set; }
    }
}
