namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tratamento")]
    public partial class tratamento
    {
        [Key]
        public int cd_tratamento { get; set; }

        public string ds_tratamento { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_inicio { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_termino { get; set; }

        public int? cd_consulta { get; set; }

        public virtual consulta consulta { get; set; }
    }
}
