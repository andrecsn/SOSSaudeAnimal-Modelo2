namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("perfil_acesso")]
    public partial class perfil_acesso
    {
        [Key]
        public int cd_perfilAcesso { get; set; }

        [StringLength(100)]
        public string nm_tela { get; set; }

        public int? perfil_atendente { get; set; }

        public int? perfil_veterinaria { get; set; }

        public int? perfil_administrador { get; set; }
    }
}
