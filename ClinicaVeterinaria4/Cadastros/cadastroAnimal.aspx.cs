using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroAnimal : Business.Animal_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarResponsavel();
                listarRaca();
                listarEspecie();
            }
            
            var cd_animal = HttpContext.Current.Items["cd_animal"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_animal != null)
                exibirEditarAnimal(Convert.ToInt32(cd_animal));

            if (cmdExcluir == "Excluir" && cd_animal != null)
                exibirExcluirAnimal(Convert.ToInt32(cd_animal));
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
                lblResponsavel.Text = animal.responsavel.nm_responsavel;
                lblEspecie.Text = animal.especie.nm_especie;
                lblraca.Text = animal.raca.nm_raca;
                lblInformacoes.Text = animal.inf_animal;
                lblFoto.Text = animal.foto;

                lblNome.Visible = true;
                lblCor.Visible = true;
                lblPeso.Visible = true;
                lblNascimento.Visible = true;
                lblSexo.Visible = true;
                lblResponsavel.Visible = true;
                lblraca.Visible = true;
                lblEspecie.Visible = true;
                lblInformacoes.Visible = true;
                lblFoto.Visible = true;

                txtNome.Visible = false;
                txtCor.Visible = false;
                txtPeso.Visible = false;
                txtNascimento.Visible = false;
                cboSexo.Visible = false;
                cboResponsavel.Visible = false;
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
            cboResponsavel.SelectedValue = animal.cd_responsavel.ToString();
            cboEspecie.SelectedValue = animal.cd_especie.ToString();
            cboRaca.SelectedValue = animal.cd_raca.ToString();
            txtInformacoes.Text = animal.inf_animal;
            lblFoto.Text = animal.foto;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Animal";
        }

        protected void listarResponsavel()
        {
            //Adiconando o resposanvél na na combo
            var responsavel = from c in contexto.responsavel select new { c.cd_responsavel, c.nm_responsavel };
            cboResponsavel.DataSource = responsavel.ToList();
            cboResponsavel.DataValueField = "cd_responsavel";
            cboResponsavel.DataTextField = "nm_responsavel";
            cboResponsavel.DataBind();
            cboResponsavel.Items.Insert(0, "--Select--");
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
                string nm_animal = txtNome.Text;
                string cor = txtCor.Text;
                string peso = txtPeso.Text;
                DateTime dt_nascimento = Convert.ToDateTime(txtNascimento.Text);
                string sexo = cboSexo.SelectedValue;
                int responsavel = Convert.ToInt32(cboResponsavel.SelectedValue.ToString());
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
            try
            {
                int codigo = Convert.ToInt32(lblCodigo.Text);
                string nm_animal = txtNome.Text;
                string cor = txtCor.Text;
                string peso = txtPeso.Text;
                DateTime dt_nascimento = Convert.ToDateTime(txtNascimento.Text);
                string sexo = cboSexo.SelectedValue;
                int responsavel = Convert.ToInt32(cboResponsavel.SelectedValue);
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
            Server.Transfer("listarAnimal.aspx");
        }

    }
}