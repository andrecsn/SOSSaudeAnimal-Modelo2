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
            if (!IsPostBack)
            {
                listarVacina();
            }
        }

        protected void listarVacina()
        {
            //Adiconando o resposanvél na na combo
            var vacina = from c in contexto.vacina select new { c.cd_vacina, c.nm_vacina };
            cboVacina.DataSource = vacina.ToList();
            cboVacina.DataValueField = "cd_vacina";
            cboVacina.DataTextField = "nm_vacina";
            cboVacina.DataBind();
            cboVacina.Items.Insert(0, "--Select--");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                int parametro = Convert.ToInt32(txtCodigoAnimal.Text);
                HttpContext.Current.Session["cd_animal"] = parametro;
                listarHistVacinas(parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void listarHistVacinas(int parametro)
        {
            Models.animal animal = contexto.animal.First(x => x.cd_animal == parametro);

            if (animal != null)
            {
                //habilitando campos
                lblTituloVacina.Visible = true;
                lblTituloAplicacao.Visible = true;
                lblTituloVencimento.Visible = true;
                cboVacina.Visible = true;
                txtDt_aplicacao.Visible = true;
                txtDt_vencimento.Visible = true;
                btnCadastrar.Visible = true;

                //listando animal
                lblAnimal.Visible = true;
                lblAnimal.Text = animal.nm_animal;

                //listando resposável
                Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == animal.cd_responsavel);
                lblResponsavel.Visible = true;
                lblResponsavel.Text = responsavel.nm_responsavel;

                this.gridHistVacina.DataSource = contexto.historico_vacina.Where(x => x.cd_animal == parametro).ToList();
                this.gridHistVacina.DataBind();
            }
            else
            {
                lblMensagem.Text = "Animal não encontrado!!";
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
            int cd_vacina = Convert.ToInt32(cboVacina.SelectedValue.ToString());
            DateTime dt_aplicacao = Convert.ToDateTime(txtDt_aplicacao.Text);
            DateTime dt_vencimento = Convert.ToDateTime(txtDt_vencimento.Text);

            cadastrarHistoricoVacina(animal, cd_vacina, dt_aplicacao, dt_vencimento);
            listarHistVacinas(animal);
            Session.Remove("cd_animal");
        }
    }
}