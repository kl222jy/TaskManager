﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="TaskManager.Pages.ProjectPages.ProjectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="col-md-12">
            <h2>My Projects</h2>
            <p>Click on a project to activate it, by default your newest project is active.</p>
            <%-- Success messages --%>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <%-- Error messages --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ValidationSummary ID="InsertSummary" ShowModelStateErrors="false" runat="server" validationgroup="InsertProjectItem" CssClass="validation-summary-errors alert alert-danger" />
            <%-- Projectlist --%>
            <asp:ListView ID="ProjectListView" runat="server"  InsertItemPosition="FirstItem"
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
                        <td><asp:LinkButton ID="chooseProject" runat="server" CommandName="chooseProject" CausesValidation="false" OnCommand="chooseProject_Command" CommandArgument="<%#: Item.ProjectId %>"><%#: Item.ProjectName %></asp:LinkButton></td>
                        <td><%#: Item.ProjectDescription %></td>
                        <td><asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" Text="Edit" CausesValidation="false" /></td>
                        <td><asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you wish to delete this project?');" /></td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <%-- Tragically, validationgroup also seems to break the functionality of dynamiccontrols.. --%>
                        <td>
                            <%--<asp:DynamicControl ID="ProjectNameInsert" runat="server" DataField="ProjectName" Mode="Insert" validationgroup="InsertProjectItem" />--%>
                            <asp:TextBox ID="ProjectNameInsertTextBox" runat="server" Text="<%# BindItem.ProjectName %>" MaxLength="30" />
                            <asp:RequiredFieldValidator ID="ProjectNameRequiredFieldValidator" validationgroup="InsertProjectItem" ControlToValidate="ProjectNameInsertTextBox" runat="server" ErrorMessage="Project name cannot be empty" Display="None" />
                        </td>
                        <td>
                            <%--<asp:DynamicControl ID="ProjectDescriptionInsert" runat="server" DataField="ProjectDescription" Mode="Insert" validationgroup="InsertProjectItem" />--%>
                            <asp:TextBox ID="ProjectDescriptionInsertTextBox" runat="server" Text="<%# BindItem.ProjectDescription %>" MaxLength="500" />
                            <asp:RequiredFieldValidator ID="ProjectDescriptionRequiredFieldValidator" runat="server" validationgroup="InsertProjectItem" ControlToValidate="ProjectDescriptionInsertTextBox" ErrorMessage="Project description cannot be empty" Display="None" />
                        </td>
                        <td><asp:LinkButton runat="server" CommandName="Insert" ValidationGroup="InsertProjectItem" Text="Save" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" /></td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <%-- DynamicControl ensures validation based on data annotations --%>
                        <td><asp:DynamicControl ID="ProjectNameEdit" runat="server" DataField="ProjectName" Mode="Edit" /></td>
                        <td><asp:DynamicControl ID="ProjectDescriptionEdit" runat="server" DataField="ProjectDescription" Mode="Edit" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Update" Text="Save" /></td>
                        <td><asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" /></td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
