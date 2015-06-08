namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("responsavel")]
    public partial class responsavel
    {
        public responsavel()
        {
            animal = new HashSet<animal>();
        }

        [Key]
        public int cd_responsavel { get; set; }

        [StringLength(100)]
        public string nm_responsavel { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [StringLength(15)]
        public string telefone { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(20)]
        public string cidade { get; set; }

        [StringLength(20)]
        public string estado { get; set; }

        public virtual ICollection<animal> animal { get; set; }
    }
}
