<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadPrototype._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="btn-group">
            <asp:Button ID="btnFileUpload" class="btn-info" runat="server" Text="File Upload"
                OnClick="btnFileUpload_Click"></asp:Button>
        </div>
        <div class="row">
            <asp:Label runat="server" CssClass="text-success" ID="StatusLabel" Text="Status: " />
        </div>
    </div>


    <!-- Bootstrap Modal Dialog -->
    <asp:UpdatePanel ID="upFileUploadModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">File Upload</asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal">X</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:Label ID="lblModalBody" runat="server">Description:</asp:Label>
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                <small id="uploadDescription" class="form-text text-muted">Enter a maximum 100 characters</small>

                                <asp:RequiredFieldValidator ID="rfvDescription" CssClass="text-danger" ControlToValidate="txtDescription"
                                    runat="server" ErrorMessage="Description is required" Enabled="false" Display="Dynamic"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="revDescription" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtDescription"
                                    ValidationExpression="^[\s\S]{0,100}$" runat="server"
                                    ErrorMessage="Maximum 100 characters allowed."></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblFileUpload" runat="server" Text=""></asp:Label>
                                <asp:FileUpload class="form-control-file" ID="fuDocument" runat="server" aria-describedby="uploadHelp" placeholder="Enter email" />
                                <small id="uploadHelp" class="form-text text-muted">Choose a file on your computer to upload.</small>
                                <asp:RequiredFieldValidator CssClass="text-danger"
                                    ID="rfvFileSelection"
                                    runat="server"
                                    ControlToValidate="fuDocument"
                                    ErrorMessage="Choose File is required" Enabled="false">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator CssClass="text-danger" Display="Dynamic" ControlToValidate="fuDocument" ID="revFileType"
                                    ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.PDF|.pdf)$" runat="server" ErrorMessage="Only PDF file is allowed for upload"></asp:RegularExpressionValidator>

                                <asp:CustomValidator ID="cvFileUpload" runat="server"
                                    Text="*" ToolTip="FileSize should not exceed 4MB"
                                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files."
                                    ControlToValidate="fuDocument"
                                    OnServerValidate="checkfilesize" Enabled="false"></asp:CustomValidator>
                                <asp:ValidationSummary ID="vsFileUpload" runat="server" />


                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btn btn-primary" ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" data-dismiss="modal" CausesValidation="False" UseSubmitBehavior="False" OnClick="btnCancel_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnCancel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
