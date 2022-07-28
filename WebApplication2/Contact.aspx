<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FileUploadPrototype.Contact" %>

<asp:content ID="cHead" runat="server" ContentPlaceHolderID="cphHead">
 <link rel="stylesheet" type="text/css" href="Content/toastr.css" />
 <script type="text/javascript" src="Scripts/toastr.js"></script>
</asp:content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

 <%--<link media="screen" rel="stylesheet" type="text/css" href="Content/toastr.css" />
 <script type="text/javascript" src="Scripts/toastr.js"></script>--%>


  <script type="text/javascript">

      function success(msg) {

          toastr.options = {
              "closeButton": true,
              "debug": false,
              "newestOnTop": false,
              "progressBar": false,
              "positionClass": "toast-top-right",
              "preventDuplicates": false,
              "onclick": null,
              "showDuration": "300",
              "hideDuration": "1000",
              "timeOut": "5000",
              "extendedTimeOut": "1000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut"
          }

          toastr.success(msg, "Success");

          return false;

      }



  </script>

  <script type="text/javascript">

      function error(msg) {

          toastr.options = {
              "closeButton": true,
              "debug": false,
              "newestOnTop": false,
              "progressBar": false,
              "positionClass": "toast-top-right",
              "preventDuplicates": false,
              "onclick": null,
              "showDuration": "300",
              "hideDuration": "1000",
              "timeOut": "5000",
              "extendedTimeOut": "1000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut"
          }

          toastr.error(msg, "Error");

          return false;

      }



  </script>


    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
