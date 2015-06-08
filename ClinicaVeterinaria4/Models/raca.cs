namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("raca")]
    public partial class raca
    {
        public raca()
        {
            animal = new HashSet<animal>();
        }

        [Key]
        public int cd_raca { get; set; }

        [StringLength(50)]
        public string nm_raca { get; set; }

        [StringLength(20)]
        public string st_raca { get; set; }

        public virtual ICollection<animal> animal { get; set; }
    }
}
