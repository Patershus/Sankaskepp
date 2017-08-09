<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="sankaskepp.Game" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="gameBoardWrapper">
    <asp:Literal ID="gameBoardLiteral" runat="server"></asp:Literal>

        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="ShotLabel" runat="server" Text="Shots"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ShotCounter" runat="server" Text="0"></asp:Label>
                </td>
                
            </tr>
      
            <tr>
                <td>
                    <asp:Label ID="ScoreLabel" runat="server" Text="Score"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ScoreCounterLabel" runat="server" Text="0"></asp:Label>
                </td>
               
            </tr>
        </table>

        </div>
</asp:Content>
