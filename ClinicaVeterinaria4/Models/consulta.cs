namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("consulta")]
    public partial class consulta
    {
        public consulta()
        {
            pagamento = new HashSet<pagamento>();
            tratamento = new HashSet<tratamento>();
        }

        [Key]
        public int cd_consulta { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_agendamento { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_consulta { get; set; }

        public string ds_consulta { get; set; }

        [MaxLength(20)]
        public byte[] st_consulta { get; set; }

        [Column(TypeName = "money")]
        public decimal? varlor_total { get; set; }

        public int? cd_veterinaria { get; set; }

        public int? cd_animal { get; set; }

        public virtual animal animal { get; set; }

        public virtual veterinaria veterinaria { get; set; }

        public virtual ICollection<pagamento> pagamento { get; set; }

        public virtual ICollection<tratamento> tratamento { get; set; }
    }
}
