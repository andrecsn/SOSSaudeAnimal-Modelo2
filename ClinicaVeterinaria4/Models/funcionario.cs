namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("funcionario")]
    public partial class funcionario
    {
        public funcionario()
        {
            consulta = new HashSet<consulta>();
        }

        [Key]
        public int cd_funcionario { get; set; }

        [StringLength(100)]
        public string nm_funcionario { get; set; }

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

        [StringLength(50)]
        public string login { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        public virtual ICollection<consulta> consulta { get; set; }
    }
}
