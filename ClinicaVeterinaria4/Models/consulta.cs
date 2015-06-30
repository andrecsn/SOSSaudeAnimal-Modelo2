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

        [MaxLength(50)]
        public string st_consulta { get; set; }

        public int? cd_funcionario { get; set; }

        public int? cd_animal { get; set; }

        [Column(TypeName = "float")]
        public double? valor_consulta { get; set; }

        [Column(TypeName = "float")]
        public double? valor_cirurgia { get; set; }

        [Column(TypeName = "float")]
        public double? valor_soroterapia { get; set; }

        [Column(TypeName = "float")]
        public double? valor_tartarectomia { get; set; }

        [Column(TypeName = "float")]
        public double? valor_medicamentos { get; set; }

        [Column(TypeName = "float")]
        public double? valor_vacinas { get; set; }

        [Column(TypeName = "float")]
        public double? valor_outros { get; set; }

        public string ds_outros { get; set; }

        [Column(TypeName = "float")]
        public double? valor_exame { get; set; }

        public string ds_exame { get; set; }

        [Column(TypeName = "float")]
        public double? valor_vendas { get; set; }

        public string ds_vendas { get; set; }

        [Column(TypeName = "float")]
        public double? valor_total { get; set; }

        [Column(TypeName = "float")]
        public double? pg_dinheiro { get; set; }

        [Column(TypeName = "float")]
        public double? pg_debito { get; set; }

        [Column(TypeName = "float")]
        public double? pg_credito { get; set; }

        [Column(TypeName = "float")]
        public double? saldo_devedor { get; set; }

        public virtual funcionario funcionario { get; set; }

        public virtual animal animal { get; set; }

        public virtual ICollection<pagamento> pagamento { get; set; }

        public virtual ICollection<tratamento> tratamento { get; set; }
    }
}
