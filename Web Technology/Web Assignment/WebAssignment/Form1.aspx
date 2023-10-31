﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="WebAssignment.Form1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store Application</title>
    <style>
        h1{
            text-align:center;
        }
        .images{
           margin-left:15ex;
        }
        .Itemslist{
            margin-top:-10ex;
     
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1> Welcome to Electronics Store</h1>
        <asp:Button ID="btnShowCost" runat="server" Text="Show Cost" OnClick="btnShowCost_Click" />

        <asp:DropDownList ID="Itemslist" Class="Itemslist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Itemslist_SelectedIndexChanged">
            <asp:ListItem Text="Select an item" Value="default.jpg" />
            <asp:ListItem Text="SmartPhones" Value="smartphone.jpg" />
            <asp:ListItem Text="Laptops" Value="laptop.jpeg"/>
            <asp:ListItem Text="Headphones" Value="headphones.jpg" />
            <asp:ListItem Text="Earbuds" Value="earbuds.jpg" />
        </asp:DropDownList>
        <asp:Image ID="imgItem" Class="images" runat="server" Width="300px" Height="300px"/>
        <asp:Label ID="lblCost" Class="lblCost" runat="server" Text="" />
    </form>
</body>
</html>