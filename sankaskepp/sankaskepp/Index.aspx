<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="sankaskepp.Index" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">
        How good are you?
    </h1>

    <div id="buttonWrapper">
        <asp:Button ID="ButtonEasy" runat="server" Text="Noob" CssClass="btn-success difficultyButton" OnClick="ButtonEasy_Click" />
        <br />
        <asp:Button ID="ButtonMedium" runat="server" Text="Intermediate" CssClass="btn-warning difficultyButton" OnClick="ButtonMedium_Click" />
        <br />

        <asp:Button ID="ButtonHard" runat="server" Text="Showoff" CssClass="btn-danger difficultyButton" OnClick="ButtonHard_Click" />
        <br />
    </div>

</asp:Content>
