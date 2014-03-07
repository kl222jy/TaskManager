<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="TaskManager.Pages.TaskPages.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Create Tasks</h2>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="validation-summary-errors alert alert-danger" />
            <asp:FormView ID="CreateTaskFormView" runat="server" ItemType="TaskManager.Model.Task" InsertMethod="CreateTaskFormView_InsertItem" DefaultMode="Insert" RenderOuterTable="false">
             <InsertItemTemplate>
                 <div class="form-group create-task">
                    <label for="TaskDescriptionTextBox">Task Description</label>
                     <%--<asp:DynamicControl ID="TaskDescriptionDC" DataField="TaskDescription" Mode="Insert" runat="server" />--%>

                     <%-- DataType.MultilineText doesn't work, so in this case i had to do it this way. The only other choice would be to fix the implementation of dynamiccontrols, this is faster. --%>
                     <asp:TextBox ID="TaskDescriptionTextBox" runat="server" Text="<%#: BindItem.TaskDescription %>" CssClass="form-control createTask" placeholder="Enter description" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                     <asp:RequiredFieldValidator ControlToValidate="TaskDescriptionTextBox" runat="server" ErrorMessage="Task Description cannot be empty." Display="None" />
                 </div>
                 <asp:Button ID="InsertButton" runat="server" Text="Create" CommandName="Insert" CssClass="btn btn-default" />
             </InsertItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
