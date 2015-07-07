using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class CadastrarHistVacina : Business.Historico_vacina_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!IsPostBack)
            {
                listarVacina();

                int cd_animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
                HttpContext.Current.Session["cd_animal"] = cd_animal;

                if (cd_animal != 0)
                {
                    listarHistVacinas(cd_animal);
                }
            }
        }

        protected void listarVacina()
        {
            //Adiconando o resposanvél na na combo
            var vacina = from c in contexto.vacina where c.st_vacina == "Ativo" select new { c.cd_vacina, c.nm_vacina };
            cboVacina.DataSource = vacina.ToList();
            cboVacina.DataValueField = "cd_vacina";
            cboVacina.DataTextField = "nm_vacina";
            cboVacina.DataBind();
            cboVacina.Items.Insert(0, "--Select--");
        }

        private void listarGrid(int cd_animal)
        {
            var dados = from a in contexto.historico_vacina
                        where a.cd_animal == cd_animal
                        select new
                        {
                            cd_hist_Vacina = a.cd_hist_vacina,
                            nm_vacina = a.vacina.nm_vacina,
                            dt_hist_vacina = a.dt_hist_vacina,
                            dt_vencimento = a.dt_vencimento, 
                            nm_funcionario = a.funcionario.nm_funcionario
                        };
            this.gridHistVacina.DataSource = dados.ToList();
            this.gridHistVacina.DataBind();
        }

        protected void listarHistVacinas(int parametro)
        {
            Models.animal animal = contexto.animal.First(x => x.cd_animal == parametro);

            if (animal != null)
            {
                //listando animal
                lblAnimal.Text = animal.nm_animal;

                //listando resposável
                Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == animal.cd_responsavel);
                lblResponsavel.Text = responsavel.nm_responsavel;

                listarGrid(parametro);
            }
            else
            {
                //lblMensagem.Text = "Animal não encontrado!!";
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
            int cd_vacina = Convert.ToInt32(cboVacina.SelectedValue.ToString());
            int cd_funcionario = Convert.ToInt32(HttpContext.Current.Session["cd_usuario"]);
            DateTime dt_aplicacao = Convert.ToDateTime(txtDt_aplicacao.Text);
            DateTime dt_vencimento = Convert.ToDateTime(txtDt_vencimento.Text);

            cadastrarHistoricoVacina(animal, cd_vacina, dt_aplicacao, dt_vencimento, cd_funcionario, "CadastrarHistVacina.aspx");
            listarHistVacinas(animal);
        }

        protected void gridHistVacina_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int cd_animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
                int index = int.Parse((string)e.CommandArgument);
                int cd_vacina = Convert.ToInt32(gridHistVacina.DataKeys[index]["cd_hist_vacina"].ToString());

                detalheModal(cd_vacina);
                modal("#modalExcluir", "show");
            }
        }

        protected void detalheModal(int cd_vacina)
        {
            Models.historico_vacina detalheVacina = contexto.historico_vacina.First(x => x.cd_hist_vacina == cd_vacina);

            lblNomeModal.Text = detalheVacina.vacina.nm_vacina.ToString();
            HttpContext.Current.Session["cd_vacina"] = cd_vacina;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int cd_animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
            int cd_vacina = Convert.ToInt32(HttpContext.Current.Session["cd_vacina"]);

            excluirHistVacina(cd_vacina, cd_animal, "");
            listarGrid(cd_animal);
            modal("#modalExcluir", "hide");
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarAnimal_Responsavel.aspx");
        }
    }
}