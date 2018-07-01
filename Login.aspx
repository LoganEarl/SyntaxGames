<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/Layout.master" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="center"> 
        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">Please sign in</h2>
            <h4 style="color:red" visible="false" id="badPskLbl" runat="server">Invalid Credentials</h4>
            <label for="inputUserID" class="sr-only">Email address</label>
            <input type="text" id="inputUserID" runat="server" class="form-control" placeholder="User ID" required autofocus>
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" id="inputPassword" runat="server" class="form-control" placeholder="Password" required>
            <div class="checkbox">
                <label>
                    <input type="checkbox" value="remember-me">
                    Remember me
                </label>
            </div>
            <asp:Button class="btn btn-lg btn-primary btn-block" runat="server" type="button" Text="Sign In"></asp:Button>
        </form>
        <br /><br /><br /><br />
        <br /><br /><br /><br />
    </div>
</asp:Content>
