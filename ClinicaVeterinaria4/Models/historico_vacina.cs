namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class historico_vacina
    {
        [Key]
        public int cd_hist_vacina { get; set; }

        public int? cd_animal { get; set; }

        public int? cd_vacina { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_hist_vacina { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_vencimento { get; set; }

        public virtual animal animal { get; set; }

        public virtual vacina vacina { get; set; }
    }
}
