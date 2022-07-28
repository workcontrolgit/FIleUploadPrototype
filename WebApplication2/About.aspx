<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FileUploadPrototype.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#MyPopup">
            Open Modal</button>
    </center>
    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        Fruit
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:DropDownList ID="ddlFruits" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <asp:ListItem Text="Select" Value="0" />
                        <asp:ListItem Text="Mango" Value="1" />
                        <asp:ListItem Text="Apple" Value="2" />
                        <asp:ListItem Text="Banana" Value="3" />
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Popup -->
</asp:Content>
