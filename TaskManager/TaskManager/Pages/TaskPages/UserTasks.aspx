<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTasks.aspx.cs" Inherits="TaskManager.Pages.TaskPages.UserTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>My Tasks</h2>
            <p>List of all tasks i'm currently working on.</p>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData" UpdateMethod="TaskListView_UpdateItem" DataKeyNames="TaskId">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:LinkButton runat="server" CommandName="Update" OnClientClick="return confirm('Are you sure you wish to mark this task as done?');"><%#: Item.TaskDescription %></asp:LinkButton></li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
