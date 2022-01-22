using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetMama
{
    public partial class PetMamaWeb : System.Web.UI.Page
    {
        Panel pnl = new Panel();
        Button btn2 = new Button();
        Button btn3 = new Button();
        Table tbl = new Table();

        TextBox txtBox1 = new TextBox();
        TextBox txtBox2 = new TextBox();
        TextBox txtBox3 = new TextBox();
        protected void Page_Load(object sender, EventArgs e)
        {

            form1.Controls.Add(new LiteralControl("<h1> * Hungry Friends *</h1>"));
            Label lbl = new Label();
            pnl.Controls.Add(lbl);
            lbl.ID = "lbl";
            Image img = new Image();

            form1.Controls.Add(pnl);
            
            TableRow tblRw = new TableRow();
            TableCell tbCel = new TableCell();
            //  tbl.Controls.Add(tblRw);


            //   img.ImageUrl.Split()
            for (int h = 0; h < 10; h++)
            {
                pnl.Controls.Add(img);
            }

            pnl.Controls.Add(tbl);

            string[] str = { "1.jpg", "Köpek Maması", "Acana", "Somon, Pirinç, Mısır Gluteni, Hayvansal Yağlar", "729,00 TL" };
            string[] str1 = { "2.jpg", "Köpek Maması", "Pro Plan", "Taze tavuk eti (% 16), tavuk eti (% 15), hindi eti (% 14)", "1.251,00 TL" };
            string[] str2 = { "3.jpg", "Kedi Maması", "Hills", "Tavuklu ( % 36, Toplam kanatlı ürünü %56)", "923,00 TL" };
            string[] str3 = { "4.jpg", "Kedi Maması", "Royal Canin", "Tavuk unu, pirinç, mısır gluteni, mısır, tavuk yağı", "692,00 TL" };
            crRow(tbl, str);
            crRow(tbl, str1);
            crRow(tbl, str2);
            crRow(tbl, str3);
            int sayac = 0;
            
            foreach (TableRow row in tbl.Rows)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Ekle";
                btn.ID = "btn_" + sayac.ToString();
                btn.Click += crButtonIslem;
                btnCell.Controls.Add(btn);
                row.Cells.Add(btnCell);

                TableCell btnCellImg = new TableCell();
                ImageButton imgbtn = new ImageButton();
                imgbtn.ImageUrl = "images/icon32.png";
                imgbtn.ID = "imgbtn_" + (sayac++).ToString();
                imgbtn.Click += crButtonIslem;
                btnCellImg.Controls.Add(imgbtn);
                row.Cells.Add(btnCellImg);
            }

            btn2.ID = "b2";
            btn2.Text = "İşlem";
            btn2.Click += crButton;
            //    btn2.Enabled=false;
            pnl.Controls.Add(btn2);

            btn3.ID = "b3";
            btn3.Text = "Deneme";
            btn3.Click += crButton;
            btn3.Enabled = false;
            pnl.Controls.Add(btn3);

            pnl.Controls.Add(new LiteralControl("<br>"));
            pnl.Controls.Add(txtBox1);
            pnl.Controls.Add(new LiteralControl("<br>"));
            pnl.Controls.Add(txtBox2);
            pnl.Controls.Add(new LiteralControl("<br>"));
            pnl.Controls.Add(txtBox3);

            //  tbl.Rows[0].Cells[0].
        }


        void crCell(TableRow tr, string str)
        {
            TableCell tbCell = new TableCell();
            tbCell.CssClass = "cell";
            tbCell.Controls.Add(new LiteralControl(str));
            tbCell.Text = str;
            tr.Controls.Add(tbCell);
            tbCell.BorderWidth = 4;
            tbCell.BorderColor = System.Drawing.Color.GreenYellow;
           
        }

        void crRow(Table tbl, string[] str)
        {
            TableRow tblRow = new TableRow();
            crImg(tblRow, str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                crCell(tblRow, str[i]);
                tbl.Controls.Add(tblRow);
            }

        }

        void crImg(TableRow tr, string str)
        {
            TableCell tbCell = new TableCell();
            tbCell.CssClass = "cell";

            Image img = new Image();
            img.ImageUrl = "images/" + str;
            img.CssClass = "img";

            tbCell.Controls.Add(img);
            tr.Controls.Add(tbCell);
            tbCell.BorderWidth = 4;
            tbCell.BorderColor = System.Drawing.Color.GreenYellow;
        }

        void crButton(object obj, EventArgs e)
        {
            pnl.Controls.Add(new LiteralControl("Tuşa Basıldı"));
            Button btDurum = (Button)obj;
            if (btDurum.ID.Equals("b2"))
            {
                btn2.Enabled = false;
                btn3.Enabled = true;
            }
            else if (btDurum.ID.Equals("b3"))
            {
                btn3.Enabled = false;
                btn2.Enabled = true;
            }

            int tbox1 = int.Parse(txtBox1.Text);
            int tbox2 = int.Parse(txtBox2.Text);
            int sonuc = tbox1 + tbox2;
            txtBox3.Text = sonuc.ToString();
            
        }

        
    }
}
