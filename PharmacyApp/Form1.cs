using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();

            tableForm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PharmacyContext db = new PharmacyContext();
            db.Orders.Load();

            OrderForm orderForm = new OrderForm();

            var sellers = db.Sellers.Select(p => p.Name);

            foreach(string s in sellers)
                orderForm.comboBox1.Items.Add(s);

            var customers = db.Customers.Select(p => p.Name);

            foreach (string s in customers)
                orderForm.comboBox2.Items.Add(s);

            var drugs = db.Drugs.Select(p => p.Title);

            foreach (string s in drugs)
                orderForm.comboBox3.Items.Add(s);


            DialogResult dialogResult = orderForm.ShowDialog(this);

            if (dialogResult == DialogResult.Cancel)
                return;

            Order order = new Order();

            order.Date = orderForm.dateTimePicker1.Value;

            Drug drug = new Drug();
            drug.Title = orderForm.comboBox3.Text;
            order.Drugs.Add(drug);

            Seller seller = new Seller();
            seller.Name = orderForm.comboBox1.Text;
            order.Sellers.Add(seller);

            Customer customer = new Customer();
            customer.Name = orderForm.comboBox2.Text;
            order.Customers.Add(customer);

            

            db.Orders.Add(order);
            db.SaveChanges();

            MessageBox.Show("Успішно додано");
        }
    }
}
