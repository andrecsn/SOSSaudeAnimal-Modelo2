<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Site1.Master" AutoEventWireup="true" CodeBehind="semPermissao.aspx.cs" Inherits="ClinicaVeterinaria.Presentation.semPermissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Sem permissão!</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-red">
                <div class="panel-heading">
                    Permissão de acesso a página
                </div>
                <div class="panel-body">
                    <br />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-xs-4">
                        </div>
                        <div class="col-xs-4">
                            <img src="../App_Themes/Bootstrap/images/sem_acesso.gif" width="400" height="400" class="img-responsive" />
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                    <div class="alert alert-danger text-center">
                        Você não tem permissão para acessar essa página, entre em contato com o Administrador do sistema
                           
                    </div>

                </div>
            </div>
        </div>
    </div>


</asp:Content>
