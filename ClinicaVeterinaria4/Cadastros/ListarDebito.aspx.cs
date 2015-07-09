using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarDebito : Business.Prontuario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listarGrid("", "");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            listarGrid(txtAnimal.Text, txtResponsavel.Text);
        }

        private void listarGrid(string nm_animal, string nm_responsavel)
        {
            var dados = from a in contexto.consulta
                        where a.animal.nm_animal.Contains(nm_animal) 
                        & a.animal.responsavel.nm_responsavel.Contains(nm_responsavel)
                        & a.saldo_devedor > 0
                        select new
                        {
                            cd_consulta = a.cd_consulta,
                            cd_animal = a.cd_animal,
                            cd_responsavel = a.animal.cd_responsavel,
                            nm_animal = a.animal.nm_animal,
                            nm_raca = a.animal.raca.nm_raca,
                            nm_especie = a.animal.especie.nm_especie,
                            nm_responsavel = a.animal.responsavel.nm_responsavel,
                            celular = a.animal.responsavel.celular,
                            valor_debito = a.saldo_devedor
                        };
            this.gridAnimal.DataSource = dados.ToList();
            this.gridAnimal.DataBind();
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            int cd_consulta = Convert.ToInt32(gridAnimal.DataKeys[index]["cd_consulta"]);

            if (e.CommandName == "New")
            {
                detalheModal(cd_consulta);
                modal("#pagamento", "show");
            }
        }

        protected void detalheModal(int cd_consulta)
        {
            Models.consulta consulta = contexto.consulta.First(x => x.cd_consulta == cd_consulta);

            lblSaldoDevetor.Text = string.Format("{0:C}", consulta.saldo_devedor);
            HiddenSaldoDevedor.Value = consulta.saldo_devedor.ToString();
            HiddenConsulta.Value = cd_consulta.ToString();
        }

        protected void btnPagamento_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(HiddenConsulta.Value);

            realizarPagamento(codigo);
        }

        private void realizarPagamento(int codigo)
        {
            Models.consulta consulta = contexto.consulta.First(x => x.cd_consulta == codigo);

            double valor_total = Convert.ToDouble(consulta.valor_total);
            double dinheiro = Convert.ToDouble(consulta.pg_dinheiro);
            double debito = Convert.ToDouble(consulta.pg_debito);
            double credito = Convert.ToDouble(consulta.pg_credito);

            double dinheiroPg = txtDinheiro.Text == "" ? 0 : Convert.ToDouble(txtDinheiro.Text);
            double debitoPg = txtDebito.Text == "" ? 0 : Convert.ToDouble(txtDebito.Text);
            double creditoPg = txtCredito.Text == "" ? 0 : Convert.ToDouble(txtCredito.Text);

            double dinheiroNovo = dinheiro + dinheiroPg;
            double debitoNovo = debito + debitoPg;
            double creditoNovo = credito + creditoPg;

            double saldo_devedor = (valor_total - (dinheiroNovo + debitoNovo + creditoNovo));

            realizarPagamentoDivida(codigo, dinheiroNovo, debitoNovo, creditoNovo, saldo_devedor);

            listarGrid("", "");
            modal("#pagamento", "hide");
        }
    }
}