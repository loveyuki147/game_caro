using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro_Game
{
    public partial class FormName : Form
    {
        int _mod;
        string nameP1;
        string nameP2;
        FormMenu _formMenu;
        // FormPlayGame formPlayGame;
        public int Mod { get => _mod; set => _mod = value; }
        public string NameP1 { get => nameP1; set => nameP1 = value; }
        public string NameP2 { get => nameP2; set => nameP2 = value; }
        //   public FormMenu FormMenu { get => _formMenu; }

        public FormName(FormMenu formMenu, int mod)
        {
            InitializeComponent();
            _mod = mod;
            _formMenu = formMenu;
            loadForm();
            displayNof();
           
        }

        void displayNof()
        {
            if (!isValidName(tbPlayer1.Text) || !isValidName(tbPlayer2.Text))
            {
                lbNof.Visible = true;
                btnStartGame.Enabled = false;
            }
            else
            {
                btnStartGame.Enabled = true;
                lbNof.Visible = false;
            }
        }

        public void loadForm()
        {
            if (Mod == 1)
            {
                tbPlayer1.Text = "Computer";
                tbPlayer1.Enabled = false;
            }
            else
            {
                nameP1 = _formMenu.NameP1;
                tbPlayer1.Text = nameP1;
            }
            nameP2 = _formMenu.NameP2;
            tbPlayer2.Text = nameP2;
        }





        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (Mod == 2)
                _formMenu.NameP1 = nameP1 = tbPlayer1.Text;
            else
                nameP1 = tbPlayer1.Text;
            _formMenu.NameP2 = nameP2 = tbPlayer2.Text;

            FormPlayGame formPlayGameNew = new FormPlayGame(Mod, _formMenu, this);
            
            formPlayGameNew.Show();
            formPlayGameNew.Enabled = true;

            //formPlayGame
            _formMenu.Hide();
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _formMenu.Show();
            this.Close();
        }

        private void FormName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Mod == 2)
                _formMenu.NameP1 = nameP1 = tbPlayer1.Text;
            _formMenu.NameP2 = nameP2 = tbPlayer2.Text;
            _formMenu.Enabled = true;
            
        }

        private void BtnStartGame_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Khaki;
        }

        private void BtnStartGame_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.BurlyWood;
            Thread.Sleep(50);
        }
        bool isValidName(string name)
        {
            if (name.Length > 10 || name.Length < 2)
                return false;
            char[] arrayChar = name.ToCharArray();
            foreach (char item in arrayChar)
            {
                if (((item < 'a' || item > 'z') && (item < 'A' || item > 'Z')) && item != ' ' && (item < '0' || item > '9'))
                    return false;
            }
            return true;
        }

        private void TbPlayer1_TextChanged(object sender, EventArgs e)
        {
            displayNof();
        }

        private void TbPlayer2_TextChanged(object sender, EventArgs e)
        {
            displayNof();
        }
    }
}
