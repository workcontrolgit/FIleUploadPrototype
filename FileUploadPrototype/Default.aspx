<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadPrototype._Default" %>

<%@ Register Src="~/Controls/FileUpload.ascx" TagPrefix="uc" TagName="FileUpload" %>

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
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Filename</th>
                            <th scope="col">Content Type</th>
                            <th scope="col">File Size</th>
                            <th scope="col">Description</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Literal ID="litFileName" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="litContentType" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="litFileSize" runat="server"></asp:Literal></td>                            
                            <td>
                                <asp:Literal ID="litDescription" runat="server"></asp:Literal></td>
                            <td>
                                <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click" Text="Download" Visible="false"></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
    <uc:FileUpload runat="server" id="FileUpload" />

</asp:Content>
