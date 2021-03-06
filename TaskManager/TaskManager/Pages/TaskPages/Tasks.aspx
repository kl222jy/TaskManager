﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="TaskManager.Pages.TaskPages.Tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Tasks</h2>
            <p>List of all tasks that need to be done.</p>
            <%-- Success messages --%>
            <asp:Panel ID="MessagePanel" runat="server" Visible="False">
                <div class="alert alert-success successbox">
                    <a class="close" data-dismiss="alert">x</a>
                    <asp:Literal ID="MessageLiteral" runat="server" />
                </div>
            </asp:Panel>
            <%-- Error messages --%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <%-- List of tasks that need to be done --%>
            <asp:ListView ID="TaskListView" runat="server" ItemType="TaskManager.Model.Task" SelectMethod="TaskListView_GetData" UpdateMethod="TaskListView_UpdateItem" DataKeyNames="TaskID">
                <LayoutTemplate>
                    <ul class="list-group tasklist">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="list-group-item">
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Delete this task." CommandName="RemoveTask" CommandArgument="<%#: Item.TaskID %>" OnCommand="RemoveTaskLinkButton_Command" ID="RemoveTaskLinkButton" CssClass="btn btn-danger btn-xs"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Edit description." CommandName="Edit" ID="EditDescriptionLinkButton" CssClass="btn btn-default btn-xs"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Start working on this task." CommandName="JoinTask" CommandArgument="<%#: Item.TaskID %>" OnCommand="WorkOnTaskLinkButton_Command" ID="WorkOnTaskLinkButton" CssClass="btn btn-primary btn-xs"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                        - <%#: Item.TaskDescription %>
                    </li>
                </ItemTemplate>
                <EditItemTemplate>
                    <li class="list-group-item">
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Cancel editing." CommandName="Cancel" ID="CancelLinkButton" CausesValidation="false" CssClass="btn btn-danger btn-xs"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                        <asp:LinkButton runat="server" data-toggle="tooltip" data-original-title="Save changes." CommandName="Update" ID="SaveLinkButton" CssClass="btn btn-success btn-xs"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                        <%-- DynamicControl makes sure clientside validation will be implemented based on data annotations --%>
                        - <asp:DynamicControl DataField="TaskDescription" ID="EditTaskDescription" runat="server" Mode="Edit" />
                    </li>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>


