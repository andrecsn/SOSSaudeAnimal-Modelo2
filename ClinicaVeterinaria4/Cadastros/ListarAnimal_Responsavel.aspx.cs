using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarAnimal : Business.Animal_Responsavel_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                listarGrid("", "");
            }
        }

        private void listarGrid(string nm_animal, string nm_responsavel)
        {
            var dados = from a in contexto.animal
                        where a.nm_animal.Contains(nm_animal) & a.responsavel.nm_responsavel.Contains(nm_responsavel)
                        select new
                        {
                            cd_animal = a.cd_animal,
                            cd_responsavel = a.cd_responsavel,
                            nm_animal = a.nm_animal,
                            nm_raca = a.raca.nm_raca,
                            nm_especie = a.especie.nm_especie,
                            nm_responsavel = a.responsavel.nm_responsavel,
                            celular = a.responsavel.celular
                        };
            this.gridAnimal.DataSource = dados.ToList();
            this.gridAnimal.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string animal = txtAnimal.Text;
            string responsavel = txtResponsavel.Text;

            listarGrid(animal, responsavel);
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridAnimal.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Session["cd_animal"] = cd_animal;

            string cd_responsavel = gridAnimal.DataKeys[index]["cd_responsavel"].ToString();
            HttpContext.Current.Session["cd_responsavel"] = cd_responsavel;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Response.Redirect("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "New")
            {
                detalheModal(cd_animal);
                modal("#modalExcluir", "show");
            }

            if (e.CommandName == "Edit")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["novo"] = "NovoAnimal";
                Response.Redirect("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para histórico de vacinas
                Response.Redirect("CadastrarHistVacina.aspx");
            }
        }

        protected void detalheModal(string cd_animal)
        {
            int cd_animal2 = Convert.ToInt32(cd_animal);
            Models.animal detalheAnimal = contexto.animal.First(x => x.cd_animal == cd_animal2);

            hiddenCodigo.Value = detalheAnimal.cd_animal.ToString();
            lblNomeModal.Text = detalheAnimal.nm_animal.ToString();
            HttpContext.Current.Session["cd_animal"] = cd_animal2;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);

                excluirAnimal(codigo);
                listarGrid("", "");
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CadastroAnimal_Responsavel.aspx");
        }
    }
}