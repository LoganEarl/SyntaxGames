<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGame.aspx.cs" Inherits="AddGame" MasterPageFile="~/Layout.master" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="center">
        <script>
            function loadImage(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('#thumbnailPreview')
                            .attr('src', e.target.result)
                            .width(500)
                            .height(500);
                    };

                    reader.readAsDataURL(input.files[0]);
                }
            }</script>

        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">Register New Game</h2>
            <label for="inputGameName" class="sr-only">Game Name</label>
            <input type="text" id="inputGameName" runat="server" class="form-control" placeholder="Game Name" required autofocus>
            <br />
            <label for="inputScreenshot"class="sr-only">Game Thumbnail</label>
            <input id="inputScreenshot" type="file" runat="server" accept="image/png" title="Choose Thumbnail" onchange="loadImage(this)" required/>
            <img  id="thumbnailPreview" src="#" alt="Your Thumbnail"/>
            <br /><br />
            <label for="inputSourceCode" class="sr-only">Source Code</label>
            <textarea type="text" style="height:500px" id="inputSourceCode" runat="server" class="form-control" placeholder="Source Code" required></textarea>
            <br />
            <asp:Button class="btn btn-lg btn-primary btn-block" runat="server" type="button" Text="Submit"></asp:Button>
        </form>

    </div>
</asp:Content>
