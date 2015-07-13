using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Prontuario_Business : Business.Historico_vacina_Business
    {
        protected void cadastrarConsulta(DateTime dt_consulta, string ds_consulta, string st_consulta, int cd_funcionario, int cd_animal, double consultaValor, double cirurgiaValor, double soroterapiaValor, double medicamentosValor, double vacinasValor, double tartarectomiaValor, double outrosValor, string ds_outros, double exameValor, string ds_exame, double vendasValor, string ds_vendas, double valorTotal, double saldoDevedor, double pg_dinheiro, double pg_credito, double pg_debito)
        {
            Models.consulta consulta = new Models.consulta()
            {
                //informações consulta
                dt_consulta = dt_consulta,
                ds_consulta = ds_consulta,
                st_consulta = st_consulta,
                cd_funcionario = cd_funcionario,
                cd_animal = cd_animal,

                //valores e informações
                valor_consulta = consultaValor,
                valor_cirurgia = cirurgiaValor,
                valor_soroterapia = soroterapiaValor,
                valor_tartarectomia = tartarectomiaValor,
                valor_medicamentos = medicamentosValor,
                valor_vacinas = vacinasValor,
                valor_outros = outrosValor,
                ds_outros = ds_outros,
                valor_exame = exameValor,
                ds_exame = ds_exame,
                valor_vendas = vendasValor,
                ds_vendas = ds_vendas,
                valor_total = valorTotal,
                pg_dinheiro = pg_dinheiro,
                pg_debito = pg_debito,
                pg_credito = pg_credito,
                saldo_devedor = saldoDevedor
            };

            contexto.consulta.Add(consulta);
            contexto.SaveChanges();
        }

        protected void editarConsulta(int cd_consulta, string ds_consulta, double valor_total)
        {
            Models.consulta consulta = contexto.consulta.First(x => x.cd_consulta == cd_consulta);

            consulta.ds_consulta = ds_consulta;

            contexto.SaveChanges();
        }

        protected void realizarPagamentoDivida(int cd_consulta, double dinheiro, double debito, double credito, double saldo_devedor, string st_consulta)
        {
            Models.consulta consulta = contexto.consulta.First(x => x.cd_consulta == cd_consulta);

            consulta.pg_dinheiro = dinheiro;
            consulta.pg_debito = debito;
            consulta.pg_credito = credito;
            consulta.saldo_devedor = saldo_devedor;
            consulta.st_consulta = st_consulta;

            contexto.SaveChanges();
        }
    }
}