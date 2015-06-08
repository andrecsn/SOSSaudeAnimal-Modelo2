namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("veterinaria")]
    public partial class veterinaria
    {
        public veterinaria()
        {
            consulta = new HashSet<consulta>();
        }

        [Key]
        public int cd_veterinaria { get; set; }

        [StringLength(100)]
        public string nm_veterinaria { get; set; }

        [StringLength(20)]
        public string cpf { get; set; }

        [StringLength(20)]
        public string telefone { get; set; }

        [StringLength(50)]
        public string celular { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string cep { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        public virtual ICollection<consulta> consulta { get; set; }
    }
}
