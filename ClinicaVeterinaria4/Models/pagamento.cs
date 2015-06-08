namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pagamento")]
    public partial class pagamento
    {
        [Key]
        public int cd_pagamento { get; set; }

        [StringLength(50)]
        public string forma_pagamento { get; set; }

        [Column(TypeName = "money")]
        public decimal? valor { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_pagamento { get; set; }

        public int? cd_consulta { get; set; }

        public virtual consulta consulta { get; set; }
    }
}
