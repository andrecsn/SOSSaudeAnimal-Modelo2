using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroAnimal_Novo : Business.Animal_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarRaca();
                listarEspecie();

                int cd_responsavel = Convert.ToInt32(HttpContext.Current.Items["cd_responsavel"]);
                var cd_animal = HttpContext.Current.Items["cd_animal"];
                var cmdNovoAnimal = HttpContext.Current.Session["novo"];
                var cmdAlterar = HttpContext.Current.Session["alterar"];
                var cmdExcluir = HttpContext.Current.Session["excluir"];

                //Listando animais do responsável no Grid
                this.gridAnimal.DataSource = contexto.animal.Where(x => x.cd_responsavel == cd_responsavel).ToList();
                this.gridAnimal.DataBind();

                if (cmdNovoAnimal == "NovoAnimal" && cd_responsavel != null)
                    exibirResponsavel(Convert.ToInt32(cd_responsavel));

                if (cmdAlterar == "Alterar" && cd_animal != null && cd_responsavel != null)
                {
                    exibirEditarAnimal(Convert.ToInt32(cd_animal));
                    exibirEditarResponsavel(cd_responsavel);
                }

                if (cmdExcluir == "Excluir" && cd_animal != null)
                {
                    exibirExcluirAnimal(Convert.ToInt32(cd_animal));
                    exibirResponsavel(cd_responsavel);
                }

            }
        }

        public void exibirExcluirAnimal(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

                lblNome.Text = animal.nm_animal;
                lblCor.Text = animal.cor;
                lblPeso.Text = animal.peso;
                lblNascimento.Text = Convert.ToDateTime(animal.dt_nascimento).ToShortDateString();
                lblSexo.Text = animal.sexo;
                lblEspecie.Text = animal.especie.nm_especie;
                lblraca.Text = animal.raca.nm_raca;
                lblInformacoes.Text = animal.inf_animal;
                lblFoto.Text = animal.foto;

                lblNome.Visible = true;
                lblCor.Visible = true;
                lblPeso.Visible = true;
                lblNascimento.Visible = true;
                lblSexo.Visible = true;
                lblraca.Visible = true;
                lblEspecie.Visible = true;
                lblInformacoes.Visible = true;
                lblFoto.Visible = true;

                txtNome.Visible = false;
                txtCor.Visible = false;
                txtPeso.Visible = false;
                txtNascimento.Visible = false;
                cboSexo.Visible = false;
                cboEspecie.Visible = false;
                cboRaca.Visible = false;
                txtInformacoes.Visible = false;
                arqFoto.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Animal";

                Session.Remove("excluir");
                Session.Remove("alterar");
                Session.Remove("novo");
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
            lblFoto.Text = animal.foto;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

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
        }

        protected void listarRaca()
        {
            //Adicionando a raça na combo
            var raca = from c in contexto.raca select new { c.cd_raca, c.nm_raca };
            cboRaca.DataSource = raca.ToList();
            cboRaca.DataValueField = "cd_raca";
            cboRaca.DataTextField = "nm_raca";
            cboRaca.DataBind();
            cboRaca.Items.Insert(0, "--Select--");
        }

        protected void listarEspecie()
        {
            //Adicionando a especie na combo
            var especie = from c in contexto.especie select new { c.cod_especie, c.nm_especie };
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
                string foto = arqFoto.FileName.ToString();

                cadastrarAnimal(nm_animal, cor, peso, dt_nascimento, sexo, responsavel, raca, especie, inf_animal, foto);
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
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(lblCodigo.Text);

                excluirAnimal(codigo);
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
            Server.Transfer("listarAnimal.aspx");
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
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }
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
                string foto = arqFoto.FileName.ToString();

                editarAnimal(codigo, nm_animal, cor, peso, dt_nascimento, sexo, responsavel, raca, especie, inf_animal, foto);
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