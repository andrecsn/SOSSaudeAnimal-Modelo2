namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("especie")]
    public partial class especie
    {
        public especie()
        {
            animal = new HashSet<animal>();
        }

        [Key]
        public int cod_especie { get; set; }

        [StringLength(100)]
        public string nm_especie { get; set; }

        [StringLength(20)]
        public string st_especie { get; set; }

        public virtual ICollection<animal> animal { get; set; }
    }
}
