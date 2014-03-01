<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="TaskManager.Pages.PersonPages.PersonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>TaskManager</h2>
            <p>Choose a user to be logged in as(default setup is Kristoffer Lind and ProjIO).</p>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ListView ID="PersonListView" runat="server" ItemType="TaskManager.Model.Person" SelectMethod="PersonListView_GetData" DataKeyNames="PersonId">
                <LayoutTemplate>
                    <table class="table table-hover table-responsive">
                        <tr>
                            <th>Name</th>
                            <th>Email</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><asp:LinkButton ID="chooseUser" runat="server" CommandName="chooseUser" OnCommand="chooseUser_Command" CommandArgument="<%#: Item.PersonId %>"><%#: Item.FName %>&nbsp;<%#: Item.LName %></asp:LinkButton></td>
                        <td><a href="mailto:<%#: Item.Email %>"><%#: Item.Email %></a></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
