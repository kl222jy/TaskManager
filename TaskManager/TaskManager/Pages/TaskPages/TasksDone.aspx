<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TasksDone.aspx.cs" Inherits="TaskManager.Pages.TaskPages.TasksDone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Done Tasks</h2>
            <p>List of all tasks that are finished.</p>

            <%-- Handles message for successful operations --%>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>

            <%-- Errormessages --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />

            <%-- Shows list of tasks that are marked as done --%>
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData" DataKeyNames="TaskID">
                <LayoutTemplate>
                    <ul class="list-group tasklist">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="list-group-item">
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Put this task back in work(mark it as not done)." CommandName="MarkNotDone" CommandArgument="<%#: Item.TaskID %>" OnCommand="MarkNotDoneLinkButton_Command" ID="MarkNotDoneLinkButton" CssClass="btn btn-danger btn-xs"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                        - <%#: Item.TaskDescription %>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
