<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadPrototype._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="btn-group">
            <asp:Button ID="btnSubmit" class="btn-info" runat="server" Text="File Upload"
                OnClick="btnSubmit_Click"></asp:Button>
        </div>
        <div class="row">
            <asp:Label runat="server" CssClass="text-success" id="StatusLabel" text="Status: " /> 
        </div>
    </div>


    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">File Upload</asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal">X</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                             <asp:Label ID="lblModalBody" runat="server" Text="">Type:</asp:Label>
                            <asp:TextBox ID="txtFileType" runat="server" Text="PDAT Form"></asp:TextBox>
                                <small id="uploadType" class="form-text text-muted">Specify a file type.</small>

                            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="txtFileType" ID="rfvFileType" 
                                runat="server" ErrorMessage="File Type is required" Enabled="false" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblFileUpload" runat="server" Text=""></asp:Label>
                                <asp:FileUpload class="form-control-file" ID="fuSelectFile" runat="server" aria-describedby="uploadHelp" placeholder="Enter email" />
                                <small id="uploadHelp" class="form-text text-muted">Select a file on your computer to upload.</small>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btn btn-primary" ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" data-dismiss="modal" CausesValidation="False" UseSubmitBehavior="False" OnClick="btnCancel_Click" />

                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnUpload" />
                    <asp:PostBackTrigger ControlID="btnCancel" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
