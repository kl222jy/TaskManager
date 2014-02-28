<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="TaskManager.Pages.ProjectPages.ProjectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="col-md-12">
            <h2>My Projects</h2>
            <p>Click on a project to activate it, by default your newest project is active.</p>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ValidationSummary ID="InsertSummary" ShowModelStateErrors="false" runat="server" ValidationGroup="insert" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ListView ID="ProjectListView" runat="server" EnableModelValidation="true" InsertItemPosition="FirstItem"
                ItemType="TaskManager.Model.Project" 
                SelectMethod="ProjectListView_GetData" 
                UpdateMethod="ProjectListView_UpdateItem" 
                InsertMethod="ProjectListView_InsertItem" 
                DeleteMethod="ProjectListView_DeleteItem" 
                DataKeyNames="ProjectId">
                <LayoutTemplate>
                    <table class="table table-hover table-responsive">
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th colspan="2">Edit</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.ProjectName %></td>
                        <td><%#: Item.ProjectDescription %></td>
                        <td><asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Edit" CausesValidation="false" /></td>
                        <td><asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you wish to delete this project?');" /></td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td><asp:DynamicControl ID="ProjectNameDynamicControl" runat="server" DataField="ProjectName" Mode="Insert" ValidationGroup="insert" /></td>
                        <td><asp:DynamicControl ID="ProjectDescriptionDynamicControl" runat="server" DataField="ProjectDescription" Mode="Insert" ValidationGroup="insert" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Insert" Text="Spara" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" /></td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td><asp:DynamicControl ID="ProjectNameDynamicControl" runat="server" DataField="ProjectName" Mode="Edit" /></td>
                        <td><asp:DynamicControl ID="ProjectDescriptionDynamicControl" runat="server" DataField="ProjectDescription" Mode="Edit" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Update" Text="Spara" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" /></td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
