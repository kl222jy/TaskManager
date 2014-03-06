<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="TaskManager.Pages.TaskPages.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Create Tasks</h2>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:FormView ID="FormView1" runat="server" ItemType="TaskManager.Model.Task" InsertMethod="FormView1_InsertItem" DefaultMode="Insert" RenderOuterTable="false">
             <InsertItemTemplate>
                 <div class="form-group create-task">
                    <label for="TaskDescriptionTextBox">Task Description</label>
                     <%-- DynamicControl ensures that validation will follow through from model to clientside based on data annotations --%>
                     <asp:DynamicControl ID="TaskDescriptionDC" DataField="TaskDescription" Mode="Insert" runat="server" />
                 </div>
                 <asp:Button ID="InsertButton" runat="server" Text="Create" CommandName="Insert" CssClass="btn btn-default" />
             </InsertItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
