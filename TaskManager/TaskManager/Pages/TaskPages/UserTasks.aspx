<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTasks.aspx.cs" Inherits="TaskManager.Pages.TaskPages.UserTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>My Tasks</h2>
            <p>List of all tasks i'm currently working on.</p>

            <%-- Panel to show message after a successful operation --%>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>

            <%-- Errormessages --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />

            <%-- Lists tasks the user is currently working on --%>
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData" DataKeyNames="TaskID">
                <LayoutTemplate>
                    <ul class="list-group tasklist">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="list-group-item">
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Quit working on this task." CommandName="StopWorkingOnTask" CommandArgument="<%#: Item.TaskID %>" OnCommand="StopWorkingOnTaskLinkButton_Command" ID="StopWorkingOnTaskLinkButton" CssClass="btn btn-danger btn-xs"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Mark this task as done." CommandName="MarkTaskAsDone" CommandArgument="<%#: Item.TaskID %>" OnCommand="MarkAsDoneLinkButton_Command" ID="MarkAsDoneLinkButton" CssClass="btn btn-success btn-xs"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                        - <%#: Item.TaskDescription %>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
