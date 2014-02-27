<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TasksDone.aspx.cs" Inherits="TaskManager.Pages.TaskPages.TasksDone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Done Tasks</h2>
            <p>List of all tasks that are finished.</p>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li><%#: Item.TaskDescription %></li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
