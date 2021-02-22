using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RentalCar
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.FirstName = textBox1.Text;
            user.LastName = textBox2.Text;
            user.Email = textBox3.Text;
            user.Password = textBox4.Text;
            UserManager manager = new UserManager(new EfUserDal());
            manager.Add(user);
            MessageBox.Show(Messages.UserAdded);

        }
    }
}
