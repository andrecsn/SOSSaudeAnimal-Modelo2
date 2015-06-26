namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vacina")]
    public partial class vacina
    {
        public vacina()
        {
            historico_vacina = new HashSet<historico_vacina>();
        }

        [Key]
        public int cd_vacina { get; set; }

        [StringLength(100)]
        public string nm_vacina { get; set; }

        [StringLength(10)]
        public string st_vacina { get; set; }

        [Column(TypeName = "float")]
        public double? valor { get; set; }

        public virtual ICollection<historico_vacina> historico_vacina { get; set; }
    }
}
