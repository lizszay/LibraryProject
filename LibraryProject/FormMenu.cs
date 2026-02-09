using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class FormMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormMenu(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            // lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
            lblUserName.Text = CurrentUser.FullName;

            //РЕАЛИЗОВАТЬ ПЕРЕКЛЮЧЕНИЕ: ЕСЛИ ГОСТЬ -> НА ФОРМУ КНИГ
            /*if(IsGuest)
            {
                btn
            }*/
        }

        private void BtnBooks_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
