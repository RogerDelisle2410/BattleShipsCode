<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" EnableEventValidation="false" %>

<!DOCTYPE html>

<style type="text/css">
    .title {
        font-weight: bold;
        font-family: Arial;
        color: white;
        text-align: center;
        font-size: x-large;  
    }

    .title2 {
        font-weight: bold;
        font-family: Arial;
        color: white;
        text-align: center;
        font-size: small;
    }

    .title3 {
        font-family: Arial;
        color: white;
        font-size: small;
    }

    .title4 {
        font-weight: bold;
        font-family: Arial;
        color: white;
        text-align: center;
        font-size: small;
    }

    p {
        font-weight: bold;
        font-family: Arial;
        color: white;
    }

    label {
        font-weight: bold;
        font-family: Verdana;
        font-size: 20px;
        color: white;
        text-align: center;
    }

    GridView {
        border: 11px solid black;
    }

    #gridViewContainer1 {
        display: inline-block;
    }

    #gridViewContainer2 {
        display: inline-block;
    }

    #buttonContainer {
        text-align: center;
        float: left;
        align-content: center;
        display: inline-block;
    }

    #btnReset {
        width: 75px;
        Height: 35px;
        font-weight: bold;
    }

    .boardHolder1 {
        text-align: center;
        display: inline-block;
        margin-left: auto;
        margin-right: auto;
    }

    .boardHolder2 {
        text-align: center;
        display: inline-block;
        margin-left: auto;
        margin-right: auto;
    }

    body {
        background: url("Images/space.png") repeat scroll 0 0 #121210;
        font-family: Verdana,Geneva,sans-serif;
        font-size: 12px;
        margin: 0;
        padding: 0;
    }

    .cellStyle {
        Height: 35px;
        Width: 35px;
        font-weight: bold;
        font-size: medium;
        color: white;
        text-align: center;
    }

    .HeaderStyle th {
        Height: 35px;
        Width: 35px;
        font-weight: bold;
        font-size: medium;
        color: white;
        text-align: center;
    }

    #checkbox {
        font-size: xx-small;
        color: black;
    }
</style>

<%--<script type="text/javascript">

    //function showShip1() { background: url("Images/ships.png") repeat scroll 0 0 #121210;
    //    var context;
    //    var dx = Math.random() < 0.5 ? -1 : 1;

    //    var ctx;
    //    var img;

    //    function setCanvas1() {
    //        var canvas = document.getElementById('canvas1');
    //        if (canvas.width < window.innerWidth) {
    //            canvas.width = window.innerWidth;
    //        }

    //        if (canvas.height < window.innerHeight) {
    //            canvas.height = 30;
    //        }
    //        if (canvas.getContext) {
    //            ctx = canvas.getContext('2d');
    //            img = new Image();
    //            img.onload = function (e) { draw(); }
    //            img.src = '/Images/SpaceshipRed.ico';
    //            draw();
    //        }
    //    }
    /*background: url("Images/space.png") repeat scroll 0 0 #121210;
    //    var startPos = 1500;
    //    var endPos = -150;
    //    var x = 1000;
    //    var y = 10;

    //    function draw() {
    //        ctx.clearRect(0, 0, 1500, 1500);
    //        if (dx > 0) {
    //            ctx.drawImage(img, x, y);
    //        }
    //        else {
    //            ctx.save();
    //            ctx.scale(-1, 1);
    //            ctx.translate(-x - img.width, y);
    //            ctx.drawImage(img, 0, 0);
    //            ctx.restore();
    //        }
    //        x += dx;

    //        if (x < endPos || x > startPos) {
    //            dx = -dx;
    //        }
    //        setTimeout(draw, 1);
    //    }
    //    setCanvas1();
    //};


    //function showShip2() {
    //    var context2;
    //    var dx2 = Math.random() < 0.5 ? -1 : 1;

    //    var ctx2;
    //    var img2;

    //    function setCanvas2() {
    //        var canvas2 = document.getElementById('canvas2');
    //        if (canvas2.width < window.innerWidth) {
    //            canvas2.width = window.innerWidth;
    //        }

    //        if (canvas2.height < window.innerHeight) {
    //            canvas2.height = 30;
    //        }
    //        if (canvas2.getContext) {
    //            ctx2 = canvas2.getContext('2d');
    //            img2 = new Image();
    //            img2.onload = function (f) { draw(); }
    //            img2.src = '/Images/SpaceshipBlue.ico';
    //            draw();
    //        }
    //    }

    //    var startPos2 = 150;
    //    var endPos2 = -1500;
    //    var x2 = 1;
    //    var y2 = 10;

    //    function draw() {
    //        ctx2.clearRect(0, 0, 1500, 1500);
    //        if (dx2 > 0) {
    //            ctx2.drawImage(img2, -x2, y2);
    //        }
    //        else {
    //            ctx2.save();
    //            ctx2.scale(-1, 1);
    //            ctx2.translate(x2 - img2.width, y2);
    //            ctx2.drawImage(img2, 0, 0);
    //            ctx2.restore();
    //        }
    //        x2 += dx2;

    //        if (x2 < endPos2 || x2 > startPos2) {
    //            dx2 = -dx2;
    //        }
    //        setTimeout(draw, 1);
    //    }
    //    setCanvas2(); style="background-color:aquamarine;"
    //};

</script>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Battleships</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

</head>

<body class="container-fluid" style="background-color: aquamarine">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-3 title2" style="border-style: solid; border-color: white; margin-top: 10px;">
                <p>Roger Delisle</p>
                <p>403-710-5817</p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mailto:JRD.Consulting@hotmail.com" Text="JRD.Consulting@hotmail.com"></asp:HyperLink>
            </div>
             
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="container-fluid">
                    <h2 class="title">Space Battleship Project</h2>
                    <%--<h4 class="title2">A ship has been placed, at a random location, on each grid.<br />
                        <br />
                        The first player to start is set at random.          
                    </h4>--%>
                    <h4 class="title2">You have dispatched a cloaked spaceship in each other's Worthless Pathetic Zone.<br />
                        Under the Futile Agreement, you have the right to attack and destroy any intruder.
                        <br />
                        Start firing your poutine torpedoes at will!
                        <%--The first player to start is set at random.--%>          
                    </h4>
                </div>
            </div>
            <div class="col-lg-3 title3 " style="margin-top: 10px;">
                <asp:CheckBox ID="viewShips" runat="server"
                    AutoPostBack="True" class="title3"
                    OnCheckedChanged="viewShips_CheckedChanged" />&nbsp Show/Hide Ships Locations.
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-2 title2">Repugnant Zone</div>

                    <div id="gridViewContainer1" class="col-lg-3 boardHolder1">
                        <asp:Label ID="label2" runat="server" Text="Player 1 " Font-Bold="true" ForeColor="White" Font-Size="Large"></asp:Label>&nbsp&nbsp
                        <asp:Label ID="labelPlayer1Turn" runat="server" Text="Your Turn" Font-Bold="true" ForeColor="white" Font-Size="Large" Visible="false"></asp:Label>

                        <asp:GridView ID="dgvPlayer1" DataKeyNames="ID1"
                            runat="server" AutoGenerateColumns="False"
                            OnRowDataBound="OnRowDataBoundPlayer1" AutoPostback="flash"
                            OnRowCommand="dgvPlayer1_RowCommand"
                            HeaderStyle-CssClass="HeaderStyle">
                            <Columns>
                                <asp:ButtonField CommandName="Player1Click" Visible="False" />
                                <asp:BoundField DataField="ID1" HeaderText="" ItemStyle-BackColor="Red" ReadOnly="true">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="A1" HeaderText=" A">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="B1" HeaderText=" B">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C1" HeaderText=" C">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="D1" HeaderText="D">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="E1" HeaderText="E">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="F1" HeaderText="F">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="G1" HeaderText="G">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="H1" HeaderText="H">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="Red"></HeaderStyle>
                        </asp:GridView>
                        <%-- <asp:Label ID="labelPlayer1Wins" CssClass="title2" runat="server">Player 1 Wins:</asp:Label>--%>
                        <asp:Label ID="labelPlayer1Wins" CssClass="title2" runat="server">Player 1 Wins:</asp:Label>
                        <asp:TextBox ID="txtboxPlayer1Wins" Width="50px" Font-Size="Medium" Font-Bold="true" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-2 title2">
                        <asp:Label CssClass="title2" ID="lblWinnerMessage" runat="server" Visible="false">
                         <h4>  <%= Winner %>    You have achieved <br /><br />"Victory in space!"  <br /><br />
                             Your worthless zone is despicable again!<br /><br />
                             Your enemy feeble space bucket of bolts has been viciously destroyed.<br /><br />
                         </h4> 
                         <h4>   Click ''Reset'' to play again </h4>
                        </asp:Label>
                    </div>
                    <div id="gridViewContainer2" class="col-lg-3 boardHolder2">
                        <asp:Label ID="label1" runat="server" Text="Player 2 " Font-Bold="true" ForeColor="white" Font-Size="Large"></asp:Label>&nbsp&nbsp
                        <asp:Label ID="labelPlayer2Turn" runat="server" Text="Your Turn" Font-Bold="true" ForeColor="white" Font-Size="Large" Visible="false"></asp:Label>

                        <asp:GridView ID="dgvPlayer2"
                            DataKeyNames="ID2" runat="server" AutoGenerateColumns="False" AutoPostback="flash"
                            OnRowDataBound="OnRowDataBoundPlayer2" OnRowCommand="dgvPlayer2_RowCommand"
                            HeaderStyle-CssClass="HeaderStyle">
                            <Columns>
                                <asp:ButtonField CommandName="Player2Click" Visible="False" />
                                <asp:BoundField DataField="ID2" HeaderText="" ItemStyle-BackColor="Blue" ReadOnly="true">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="A2" HeaderText="A">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="B2" HeaderText="B">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="C2" HeaderText="C">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="D2" HeaderText="D">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="E2" HeaderText="E">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="F2" HeaderText="F">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="G2" HeaderText="G">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="H2" HeaderText="H">
                                    <ItemStyle CssClass="cellStyle" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="Blue"></HeaderStyle>
                        </asp:GridView>
                        <asp:Label ID="labelPlayer2Wins" CssClass="title2" runat="server">Player 2 Wins:</asp:Label>
                        <asp:TextBox ID="txtboxPlayer2Wins" Width="50px" Font-Size="Medium" Font-Bold="true" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-lg-2 title2">
                        Reeking Zone
                    </div>
                </div>
            </div>
        </div>
        <div id="buttonContainer" class="col-lg-12">
            <asp:Button ID="btnReset" CssClass="Button" runat="server" Text="Reset" OnClick="btnReset_Click" />
        </div>
         <div class="col-lg-12">
       <%--     <asp:Label CssClass="title2" ID="lblWinnerMessage" runat="server" Visible="false">
                         <h3>  <%= Winner %>    You have achieved <br /><br />"Victory in space!"  <br /><br />
                             Your worthless zone is despicable again!<br />
                             Your ennemy feeble space bucket of boltshas been viciously destroyed.<br /><br />
                         </h3> 
                         <h4>   Click ''Reset'' to play again </h4>
            </asp:Label>

           <%-- <asp:Label CssClass="title2" ID="lblWinnerMessage" runat="server" Visible="false">
                         <h3>  <%= Winner %>    You win!  </h3> 
                         <h4>   Click ''Reset'' to play again </h4>
            </asp:Label>--%>
        </div> 

        <%-- <div class="row">
            <div class="col-lg-12">
                <canvas id='canvas1'></canvas>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <canvas id='canvas2'></canvas>
            </div>
        </div>--%>
        <div class="col-lg-12">
            <asp:Label ID="LabelErrorMessage" class="title" Width="50px" Font-Size="Medium" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
