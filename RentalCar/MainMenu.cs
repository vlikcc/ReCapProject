using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCar
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

       

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddUser  AddUser = new AddUser();
            AddUser.Show();
            this.Hide();

        }
    }
}
