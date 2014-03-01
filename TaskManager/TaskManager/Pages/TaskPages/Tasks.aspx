<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="TaskManager.Pages.TaskPages.Tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Tasks</h2>
            <p>List of all tasks that need to be done.</p>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData" DataKeyNames="TaskID">
                <LayoutTemplate>
                    <ul class="list-group">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="list-group-item">
                        <asp:LinkButton runat="server" CommandName="RemoveTask" CommandArgument="<%#: Item.TaskID %>" OnCommand="RemoveTaskLinkButton_Command" ID="RemoveTaskLinkButton" CssClass="btn btn-danger btn-xs"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="JoinTask" CommandArgument="<%#: Item.TaskID %>" OnCommand="WorkOnTaskLinkButton_Command" ID="WorkOnTaskLinkButton" CssClass="btn btn-primary btn-xs"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                        - <%#: Item.TaskDescription %>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
