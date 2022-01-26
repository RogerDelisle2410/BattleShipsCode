using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

//Battle ships 

public partial class Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetUpPlayer1Board();
            SetUpPlayer2Board();
            PlaceShipsOnBoard();
            startAtRandom();
        }
    }

    protected void PlaceShipsOnBoard()
    {
        PlaceShipsOnBoards(dgvPlayer1, shipLocationPlayer1);
        PlaceShipsOnBoards(dgvPlayer2, shipLocationPlayer2);
    }
    protected void startAtRandom()
    {
        Random rnd = new Random();
        var whoStart = rnd.Next(1, 3);
        Player1 = false;
        Player2 = false;
        if (whoStart == 1)
        {
            Player1 = true;
        }
        else
        {
            Player2 = true;
        }
        setStartUpPlayer(Player1, Player2);
    }
    //protected void setStartUp(bool Player1, bool Player2)
    //{
    //    labelPlayer1Turn.Visible = false;
    //    labelPlayer2Turn.Visible = false;
    //    if (Player1)
    //    {
    //        labelPlayer1Turn.Visible = true;
    //        labelPlayer2Turn.Visible = false;
    //    }
    //    if (Player2)
    //    {
    //        labelPlayer1Turn.Visible = false;
    //        labelPlayer2Turn.Visible = true;
    //    }
    //}
    protected void setStartUpPlayer(bool Player1, bool Player2)  
    {
        labelPlayer1Turn.Visible = false;    
        labelPlayer2Turn.Visible = false;
        if (Player1)
        {
            labelPlayer1Turn.Visible = true;
            labelPlayer2Turn.Visible = false;
        }
        if (Player2)
        {
            labelPlayer1Turn.Visible = false;
            labelPlayer2Turn.Visible = true;
        }
    }
    protected void SetUpPlayer1Board()
    {
        DataTable dt1 = new DataTable();
        dt1.Columns.AddRange(new DataColumn[9] {
            new DataColumn("ID1"),
            new DataColumn("A1"),
            new DataColumn("B1"),
            new DataColumn("C1"),
            new DataColumn("D1"),
            new DataColumn("E1"),
            new DataColumn("F1"),
            new DataColumn("G1"),
            new DataColumn("H1")
            });

        for (var r = 1; r < 9; r++)
        {
            dt1.Rows.Add(r, "", "", "", "", "", "", "", "");
        }

        dgvPlayer1.DataSource = dt1;
        dgvPlayer1.DataBind();
    }

    protected void SetUpPlayer2Board()
    {
        DataTable dt2 = new DataTable();
        dt2.Columns.AddRange(new DataColumn[9] {
            new DataColumn("ID2"),
            new DataColumn("A2"),
            new DataColumn("B2"),
            new DataColumn("C2"),
            new DataColumn("D2"),
            new DataColumn("E2"),
            new DataColumn("F2"),
            new DataColumn("G2"),
            new DataColumn("H2")
            });

        for (var r = 1; r < 9; r++)
        {
            dt2.Rows.Add(r, "", "", "", "", "", "", "", "");
        }

        dgvPlayer2.DataSource = dt2;
        dgvPlayer2.DataBind();
    }

    protected void dgvPlayer1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
            if (selectedColumnIndex > 1 && Player1 && !PickedLocationPlayer1.Contains(selectedRowIndex + "" + selectedColumnIndex))
            {
                PickedLocationPlayer1.Add(selectedRowIndex + "" + selectedColumnIndex);
                ProcessRowCommand(sender, e, dgvPlayer1, shipLocationPlayer1);
                Player1 = false; Player2 = true;

                if (ship1NumberOfHits == 3)
                {
                    player1Wins = player1Wins + 1;
                    txtboxPlayer1Wins.Text = (Convert.ToInt32(ViewState["player1Wins"]).ToString());
                    Player1 = true; Player2 = false;
                    Winner = "Player 1";
                    lblWinnerMessage.Visible = true;

                    displayWinnerShip(dgvPlayer2, shipLocationPlayer2);
                }
                setStartUpPlayer(Player1, Player2);
            }
        }
        catch (Exception ex)
        {
            LabelErrorMessage.Text = ex.ToString();
        }
    }

    protected void dgvPlayer2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
            if (selectedColumnIndex > 1 && Player2 && !PickedLocationPlayer2.Contains(selectedRowIndex + "" + selectedColumnIndex))
            {
                PickedLocationPlayer2.Add(selectedRowIndex + "" + selectedColumnIndex);
                ProcessRowCommand(sender, e, dgvPlayer2, shipLocationPlayer2);
                Player1 = true; Player2 = false;

                if (ship2NumberOfHits == 3)
                {
                    player2Wins = player2Wins + 1;
                    txtboxPlayer2Wins.Text = (Convert.ToInt32(ViewState["player2Wins"]).ToString());
                    Player1 = false; Player2 = true;
                    Winner = "Player 2";
                    lblWinnerMessage.Visible = true;

                    displayWinnerShip(dgvPlayer1, shipLocationPlayer1);
                }
                setStartUpPlayer(Player1, Player2);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction1", "showShip1();showShip2();", true);
            }
        }
        catch (Exception ex)
        {
            LabelErrorMessage.Text = ex.ToString();
        }
    }
    protected void ProcessRowCommand(object sender, GridViewCommandEventArgs e, GridView dgvPlayer, List<string> shipLocation)
    {
        try
        {
            if (shipLocation.Contains(selectedRowIndex + "" + selectedColumnIndex))
            {
                shipLocation.Remove((selectedRowIndex + "" + selectedColumnIndex));

                switch (dgvPlayer.ID)
                {
                    case "dgvPlayer1":
                        ship1NumberOfHits++;
                        dgvPlayer.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Blue;";
                        break;
                    case "dgvPlayer2":
                        ship2NumberOfHits++;
                        dgvPlayer.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Red;";
                        break;
                }
            }
            else
            {
                dgvPlayer.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Green;";
            }
        }
        catch (Exception ex)
        {
            LabelErrorMessage.Text = ex.ToString();
        }
    }

    public void displayWinnerShip(GridView dgvPlayer, List<string> shipLocation)
    {
        for (var i = 0; i < shipLocation.Count; i++)
        {
            var shipLoc = shipLocation.ElementAt(i);
            int shipRow = Convert.ToInt16(shipLoc.Substring(0, 1));
            int shipColumn = Convert.ToInt16(shipLoc.Substring(1, 1));

            switch (dgvPlayer.ID)
            {
                case "dgvPlayer1":
                    dgvPlayer.Rows[shipRow].Cells[shipColumn].Attributes["style"] += "background-color:Blue;";
                    break;
                case "dgvPlayer2":
                    dgvPlayer.Rows[shipRow].Cells[shipColumn].Attributes["style"] += "background-color:Red;";
                    break;
            }
        }
    }

    public void DisplayHideShipsLocations(bool showShips, GridView dgvPlayer, List<string> shipLocation)
    {
        var display_X = "";
        if (showShips)
        {
            display_X = "X";
        }
        for (var i = 0; i < shipLocation.Count; i++)
        {
            var shipLoc = shipLocation.ElementAt(i);
            int shipRow = Convert.ToInt16(shipLoc.Substring(0, 1));
            int shipColumn = Convert.ToInt16(shipLoc.Substring(1, 1));

            switch (dgvPlayer.ID)
            {
                case "dgvPlayer1":
                    dgvPlayer.Rows[shipRow].Cells[shipColumn].Text = display_X;
                    break;
                case "dgvPlayer2":

                    dgvPlayer.Rows[shipRow].Cells[shipColumn].Text = display_X;
                    break;
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear_Boards(sender, e);
    }

    protected void Clear_Boards(object sender, EventArgs e)
    {
        shipLocationPlayer1.Clear();
        shipLocationPlayer2.Clear();
        PickedLocationPlayer1.Clear();
        PickedLocationPlayer2.Clear();

        dgvPlayer1.DataSource = null;
        dgvPlayer2.DataSource = null;
        dgvPlayer1.DataBind();
        dgvPlayer2.DataBind();
        SetUpPlayer1Board();
        SetUpPlayer2Board();
        PlaceShipsOnBoard();

        ship1NumberOfHits = 0;
        ship2NumberOfHits = 0;

        lblWinnerMessage.Visible = false;
        // startAtRandom();
        setStartUpPlayer(Player1, Player2);
    }

    protected void OnRowDataBoundPlayer1(object sender, GridViewRowEventArgs e)
    {
        ProcessOnRowDataBound(sender, e);
    }
    protected void OnRowDataBoundPlayer2(object sender, GridViewRowEventArgs e)
    {
        ProcessOnRowDataBound(sender, e);
    }

    protected void ProcessOnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _isSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    string js = _isSingle.Insert(_isSingle.Length - 2, columnIndex.ToString());
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                    e.Row.Cells[columnIndex].Enabled = false;
                }
            }
        }
    }

    protected void viewShips_CheckedChanged(object sender, EventArgs e)
    {
        ViewShips = false;

        if (viewShips.Checked)
        {
            ViewShips = true;
        }
        DisplayHideShipsLocations(ViewShips, dgvPlayer1, shipLocationPlayer1);
        DisplayHideShipsLocations(ViewShips, dgvPlayer2, shipLocationPlayer2);
    }

    protected void PlaceShipsOnBoards(GridView dgvPlayer, List<string> shipLocation)
    {
        Random shiprnd = new Random();
        int rowMax = dgvPlayer.Rows.Count;
        int colMax = dgvPlayer.Columns.Count;
        if (rowMax > 0 && colMax > 0)
        {
            shiprow = shiprnd.Next(0, rowMax);
            shipcolumn = shiprnd.Next(2, colMax);
            shipDirectionHorz = shiprnd.Next(1, 3);
            Thread.Sleep(100);
            if (ViewShips) { dgvPlayer.Rows[shiprow].Cells[shipcolumn].Text = "X"; }
            shipLocation.Add(shiprow.ToString() + shipcolumn.ToString());
            if (shipDirectionHorz == 1)
            {
                if (shipcolumn + 1 >= colMax - 1)
                {
                    if (ViewShips)
                    {
                        dgvPlayer.Rows[shiprow].Cells[shipcolumn - 1].Text = "X";
                        dgvPlayer.Rows[shiprow].Cells[shipcolumn - 2].Text = "X";
                    }
                    shipLocation.Add(shiprow.ToString() + (shipcolumn - 1).ToString());
                    shipLocation.Add(shiprow.ToString() + (shipcolumn - 2).ToString());
                }
                else
                {
                    if (ViewShips)
                    {
                        dgvPlayer.Rows[shiprow].Cells[shipcolumn + 1].Text = "X";
                        dgvPlayer.Rows[shiprow].Cells[shipcolumn + 2].Text = "X";
                    }
                    shipLocation.Add(shiprow.ToString() + (shipcolumn + 1).ToString());
                    shipLocation.Add(shiprow.ToString() + (shipcolumn + 2).ToString());
                }
            }
            else
            {
                if (shiprow + 1 >= rowMax - 1)
                {
                    if (ViewShips)
                    {
                        dgvPlayer.Rows[shiprow - 1].Cells[shipcolumn].Text = "X";
                        dgvPlayer.Rows[shiprow - 2].Cells[shipcolumn].Text = "X";
                    }
                    shipLocation.Add((shiprow - 1).ToString() + shipcolumn.ToString());
                    shipLocation.Add((shiprow - 2).ToString() + shipcolumn.ToString());
                }
                else
                {
                    if (ViewShips)
                    {
                        dgvPlayer.Rows[shiprow + 1].Cells[shipcolumn].Text = "X";
                        dgvPlayer.Rows[shiprow + 2].Cells[shipcolumn].Text = "X";
                    }
                    shipLocation.Add((shiprow + 1).ToString() + shipcolumn.ToString());
                    shipLocation.Add((shiprow + 2).ToString() + shipcolumn.ToString());
                }
            }
        }
    }

    private List<string> shipLocationPlayer1
    {
        get
        {
            List<string> result = ViewState["shipLocationPlayer1"] as List<string>;
            if (result == null)
            {
                ViewState["shipLocationPlayer1"] = result = new List<string>();
            }
            return result;
        }

    }
    private List<string> shipLocationPlayer2
    {
        get
        {
            List<string> result = ViewState["shipLocationPlayer2"] as List<string>;
            if (result == null)
            {
                ViewState["shipLocationPlayer2"] = result = new List<string>();
            }
            return result;
        }
    }
    private List<string> PickedLocationPlayer1
    {
        get
        {
            List<string> result = ViewState["PickedLocationPlayer1"] as List<string>;
            if (result == null)
            {
                ViewState["PickedLocationPlayer1"] = result = new List<string>();
            }
            return result;

        }
    }
    private List<string> PickedLocationPlayer2
    {
        get
        {
            List<string> result = ViewState["PickedLocationPlayer2"] as List<string>;
            if (result == null)
            {
                ViewState["PickedLocationPlayer2"] = result = new List<string>();
            }
            return result;

        }
    }
    public string Winner
    {
        get
        {
            string winner = (string)ViewState["Winner"];
            if (winner == null) return "";
            return winner;
        }
        set
        {
            ViewState["Winner"] = value;
        }
    }
    public bool ViewShips
    {
        get
        {
            return ViewState["ViewShips"] == null ? false : (bool)ViewState["ViewShips"];
        }
        set
        {
            ViewState["ViewShips"] = value;
        }
    }
    public bool Player1
    {
        get
        {
            return ViewState["Player1"] == null ? false : (bool)ViewState["Player1"];
        }
        set
        {
            ViewState["Player1"] = value;
        }
    }
    public bool Player2
    {
        get
        {
            return ViewState["Player2"] == null ? false : (bool)ViewState["Player2"];
        }
        set
        {
            ViewState["Player2"] = value;
        }
    }
    private int shiprow
    {
        get
        {
            return (ViewState["shiprow"] != null) ? (int)ViewState["shiprow"] : 0;
        }
        set
        {
            ViewState["shiprow"] = value;
        }
    }
    private int shipcolumn
    {
        get
        {
            return (ViewState["shipcolumn"] != null) ? (int)ViewState["shipcolumn"] : 0;
        }
        set
        {
            ViewState["shipcolumn"] = value;
        }
    }
    private int shipDirectionHorz
    {
        get
        {
            return (ViewState["shipDirectionHorz"] != null) ? (int)ViewState["shipDirectionHorz"] : 0;
        }
        set
        {
            ViewState["shipDirectionHorz"] = value;
        }
    }
    private int ship1NumberOfHits
    {
        get
        {
            return (ViewState["ship1NumberOfHits"] != null) ? (int)ViewState["ship1NumberOfHits"] : 0;
        }
        set
        {
            ViewState["ship1NumberOfHits"] = value;
        }
    }
    private int ship2NumberOfHits
    {
        get
        {
            return (ViewState["ship2NumberOfHits"] != null) ? (int)ViewState["ship2NumberOfHits"] : 0;
        }
        set
        {
            ViewState["ship2NumberOfHits"] = value;
        }
    }
    private int player1Wins
    {
        get
        {
            return (ViewState["player1Wins"] != null) ? (int)ViewState["player1Wins"] : 0;
        }
        set
        {
            ViewState["player1Wins"] = value;
        }
    }
    private int player2Wins
    {
        get
        {
            return (ViewState["player2Wins"] != null) ? (int)ViewState["player2Wins"] : 0;
        }
        set
        {
            ViewState["player2Wins"] = value;
        }
    }
    private int selectedRowIndex
    {
        get
        {
            return (ViewState["selectedRowIndex"] != null) ? (int)ViewState["selectedRowIndex"] : 0;
        }
        set
        {
            ViewState["selectedRowIndex"] = value;
        }
    }
    private int selectedColumnIndex
    {
        get
        {
            return (ViewState["selectedColumnIndex"] != null) ? (int)ViewState["selectedColumnIndex"] : 0;
        }
        set
        {
            ViewState["selectedColumnIndex"] = value;
        }
    }
}
