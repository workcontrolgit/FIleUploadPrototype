<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadPrototype._Default" %>

<%@ Register Src="~/Controls/UploadModal.ascx" TagPrefix="uc" TagName="FileUpload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br />

        <div class="card">
            <div class="card-header">
                <p class="card-text">Instruction:  Click on File Upload to get started. </p>
            </div>
            <div class="card-body">
                <asp:Button ID="btnFileUpload" class="btn btn-primary" runat="server" Text="File Upload" OnClick="btnFileUpload_Click"></asp:Button>
            </div>
            <div class="card-footer">
                <h5>File Upload Status</h5>
                <asp:GridView ID="gridFiles" runat="server" CssClass="table table-borderless" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <asp:LinkButton  ID="lnkFileName" runat="server"  Text='<%# Eval("FileName") %>' CommandArgument='<%# Eval("FileName") %>' OnClick="lnkFileName_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContentType" HeaderText="Content Type" />
                        <asp:BoundField DataField="ContentLength" HeaderText="Content Length" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
    <uc:FileUpload runat="server" id="FileUploadControl" />

</asp:Content>
