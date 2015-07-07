using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroAnimal_Novo : Business.Animal_Responsavel_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!IsPostBack)
            {
                listarRaca();
                listarEspecie();

                int cd_responsavel = Convert.ToInt32(HttpContext.Current.Session["cd_responsavel"]);
                var cd_animal = HttpContext.Current.Session["cd_animal"];
                var cmdNovoAnimal = HttpContext.Current.Session["novo"];
                var cmdAlterar = HttpContext.Current.Session["alterar"];

                listarGrid(cd_responsavel);

                if (cmdNovoAnimal == "NovoAnimal" && cd_responsavel != null)
                    exibirResponsavel(Convert.ToInt32(cd_responsavel));

                if (cmdAlterar == "Alterar" && cd_animal != null && cd_responsavel != null)
                {
                    exibirEditarAnimal(Convert.ToInt32(cd_animal));
                    exibirEditarResponsavel(cd_responsavel);
                }

            }
        }

        public void exibirEditarAnimal(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

            txtNome.Text = animal.nm_animal;
            txtCor.Text = animal.cor;
            txtPeso.Text = animal.peso;
            txtNascimento.Text = Convert.ToDateTime(animal.dt_nascimento).ToShortDateString();
            cboSexo.Text = animal.sexo;
            cboEspecie.SelectedValue = animal.cd_especie.ToString();
            cboRaca.SelectedValue = animal.cd_raca.ToString();
            txtInformacoes.Text = animal.inf_animal;
            hiddenFoto.Value = animal.foto;

            if (animal.foto != "")
            {
                foto.ImageUrl = "~/App_Themes/Bootstrap/images/imagens_upload/" + animal.foto;
            }
            else
            {
                foto.ImageUrl = "~/App_Themes/Bootstrap/images/sem-foto.jpg";
            }

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;

            lblTitulo.Text = "Alterar Animal";
        }

        public void exibirEditarResponsavel(int codigo)
        {
            lblCodigoResp.Text = codigo.ToString();
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            txtNomeResp.Text = responsavel.nm_responsavel;
            txtCPFResp.Text = responsavel.CPF;
            txtTelefoneResp.Text = responsavel.telefone;
            txtCelularResp.Text = responsavel.celular;
            txtEmailResp.Text = responsavel.email;
            txtEnderecoResp.Text = responsavel.endereco;
            txtBairroResp.Text = responsavel.bairro;
            txtCidadeResp.Text = responsavel.cidade;
            cboEstadoResp.SelectedValue = responsavel.estado;
        }

        public void exibirResponsavel(int codigo)
        {
            lblCodigoResp.Text = codigo.ToString();
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            txtNomeResp.Visible = false;
            txtCPFResp.Visible = false;
            txtTelefoneResp.Visible = false;
            txtCelularResp.Visible = false;
            txtEmailResp.Visible = false;
            txtEnderecoResp.Visible = false;
            txtBairroResp.Visible = false;
            txtCidadeResp.Visible = false;
            cboEstadoResp.Visible = false;

            lblNomeResp.Visible = true;
            lblCPFResp.Visible = true;
            lblTelefoneResp.Visible = true;
            lblCelularResp.Visible = true;
            lblEmailResp.Visible = true;
            lblEnderecoResp.Visible = true;
            lblBairroResp.Visible = true;
            lblCidadeResp.Visible = true;
            lblEstadoResp.Visible = true;

            lblNomeResp.Text = responsavel.nm_responsavel;
            lblCPFResp.Text = responsavel.CPF;
            lblTelefoneResp.Text = responsavel.telefone;
            lblCelularResp.Text = responsavel.celular;
            lblEnderecoResp.Text = responsavel.endereco;
            lblBairroResp.Text = responsavel.bairro;
            lblCidadeResp.Text = responsavel.cidade;
            lblEstadoResp.Text = responsavel.estado;

            foto.ImageUrl = "~/App_Themes/Bootstrap/images/sem-foto.jpg";
        }

        private void listarGrid(int cd_responsavel)
        {
            var dados = from a in contexto.animal
                        where a.cd_responsavel == cd_responsavel
                        select new
                        {
                            cd_animal = a.cd_animal,
                            cd_responsavel = a.cd_responsavel,
                            nm_animal = a.nm_animal,
                            nm_raca = a.raca.nm_raca,
                            nm_especie = a.especie.nm_especie,
                            inf_animal = a.inf_animal
                        };
            this.gridAnimal.DataSource = dados.ToList();
            this.gridAnimal.DataBind();
        }

        protected void listarRaca()
        {
            //Adicionando a raça na combo
            var raca = from c in contexto.raca where c.st_raca == "Ativo" select new { c.cd_raca, c.nm_raca };
            cboRaca.DataSource = raca.ToList();
            cboRaca.DataValueField = "cd_raca";
            cboRaca.DataTextField = "nm_raca";
            cboRaca.DataBind();
            cboRaca.Items.Insert(0, "--Select--");
        }

        protected void listarEspecie()
        {
            //Adicionando a especie na combo
            var especie = from c in contexto.especie where c.st_especie == "Ativo" select new { c.cod_especie, c.nm_especie };
            cboEspecie.DataSource = especie.ToList();
            cboEspecie.DataValueField = "cod_especie";
            cboEspecie.DataTextField = "nm_especie";
            cboEspecie.DataBind();
            cboEspecie.Items.Insert(0, "--Select--");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int responsavel = Convert.ToInt32(lblCodigoResp.Text);
                string nm_animal = txtNome.Text;
                string cor = txtCor.Text;
                string peso = txtPeso.Text;
                DateTime dt_nascimento = Convert.ToDateTime(txtNascimento.Text);
                string sexo = cboSexo.SelectedValue;
                int raca = Convert.ToInt32(cboRaca.SelectedValue.ToString());
                int especie = Convert.ToInt32(cboEspecie.SelectedValue.ToString());
                string inf_animal = txtInformacoes.Text;
                string nomeFoto = "";

                if (arqFoto.HasFile)
                {
                    arqFoto.SaveAs(MapPath("~/App_Themes/Bootstrap/images/imagens_upload/" + arqFoto.FileName));
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(MapPath("~/App_Themes/Bootstrap/images/imagens_upload/") + arqFoto.FileName);
                    nomeFoto = arqFoto.FileName;
                }

                cadastrarAnimal(nm_animal, cor, peso, dt_nascimento, sexo, responsavel, raca, especie, inf_animal, nomeFoto);
                limparCamposAnimal();
                listarGrid(responsavel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            alterarResponsavel();
            alterarAnimal();

            int responsavel = Convert.ToInt32(lblCodigoResp.Text);
            limparCamposAnimal();
            listarGrid(responsavel);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int cd_responsavel = Convert.ToInt32(HttpContext.Current.Session["cd_responsavel"]);
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);

                excluirAnimal(codigo);
                listarGrid(cd_responsavel);
                limparCamposAnimal();
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Session.Remove("excluir");
            Session.Remove("alterar");
            Session.Remove("novo");
            Session.Remove("cd_responsavel");
            Session.Remove("cd_animal");
            Response.Redirect("ListarAnimal_Responsavel.aspx");
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridAnimal.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Items["cd_animal"] = cd_animal;

            string cd_responsavel = gridAnimal.DataKeys[index]["cd_responsavel"].ToString();
            HttpContext.Current.Items["cd_responsavel"] = cd_responsavel;

            if (e.CommandName == "Select")
            {
                exibirEditarAnimal(Convert.ToInt32(cd_animal));
            }

            if (e.CommandName == "New")
            {
                detalheModal(cd_animal);
                modal("#modalExcluir", "show");
            }
        }

        protected void detalheModal(string cd_animal)
        {
            int cd_animal2 = Convert.ToInt32(cd_animal);
            Models.animal detalheAnimal = contexto.animal.First(x => x.cd_animal == cd_animal2);

            lblNomeModal.Text = detalheAnimal.nm_animal.ToString();
            HttpContext.Current.Session["cd_animal"] = cd_animal2;
        }

        private void limparCamposAnimal()
        {
            lblTitulo.Text = "Dados do novo animal";
            txtNome.Text = "";
            txtCor.Text = "";
            txtPeso.Text = "";
            txtNascimento.Text = "";
            cboSexo.Text = "";
            cboEspecie.SelectedValue = "--Select--";
            cboRaca.SelectedValue = "--Select--";
            txtInformacoes.Text = "";
            hiddenFoto.Value = "";
            foto.ImageUrl = "~/App_Themes/Bootstrap/images/sem-foto.jpg";

            txtNome.Focus();
            btnAlterar.Visible = false;
            btnCadastrar.Visible = true;
        }

        protected void alterarAnimal()
        {
            try
            {
                int codigo = Convert.ToInt32(lblCodigo.Text);
                int responsavel = Convert.ToInt32(lblCodigoResp.Text);
                string nm_animal = txtNome.Text;
                string cor = txtCor.Text;
                string peso = txtPeso.Text;
                DateTime dt_nascimento = Convert.ToDateTime(txtNascimento.Text);
                string sexo = cboSexo.SelectedValue;
                int raca = Convert.ToInt32(cboRaca.SelectedValue);
                int especie = Convert.ToInt32(cboEspecie.SelectedValue);
                string inf_animal = txtInformacoes.Text;
                string nomeFoto = "";

                if (arqFoto.HasFile)
                {
                    arqFoto.SaveAs(MapPath("~/App_Themes/Bootstrap/images/imagens_upload/" + arqFoto.FileName));
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(MapPath("~/App_Themes/Bootstrap/images/imagens_upload/") + arqFoto.FileName);
                    nomeFoto = arqFoto.FileName;
                }
                else
                    nomeFoto = hiddenFoto.Value;

                editarAnimal(codigo, nm_animal, cor, peso, dt_nascimento, sexo, responsavel, raca, especie, inf_animal, nomeFoto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void alterarResponsavel()
        {
            try
            {
                int codigo = Convert.ToInt32(lblCodigoResp.Text);
                string nome = txtNomeResp.Text;
                string cpf = txtCPFResp.Text;
                string telefone = txtTelefoneResp.Text;
                string celular = txtCelularResp.Text;
                string email = txtEmailResp.Text;
                string endereco = txtEnderecoResp.Text;
                string bairro = txtBairroResp.Text;
                string cidade = txtCidadeResp.Text;
                string estado = cboEstadoResp.Text;

                editarResponsavel(codigo, nome, cpf, telefone, celular, email, endereco, bairro, cidade, estado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

    }
}