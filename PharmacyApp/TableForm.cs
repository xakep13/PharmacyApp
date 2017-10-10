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
    public partial class TableForm : Form
    {
       static PharmacyContext db;
        string selectedState;

        public TableForm()
        {
            InitializeComponent();

            db = new PharmacyContext();
            db.Customers.Load();
            db.Drugs.Load();
            db.Sellers.Load();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;   
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             selectedState = comboBox1.SelectedItem.ToString();

            switch (selectedState)
            {
                case "Ліки":
                    dataGridView1.DataSource = db.Drugs.Local.ToBindingList();
                    break;
                case "Продавці":
                    dataGridView1.DataSource = db.Sellers.Local.ToBindingList();
                    break;
                case "Клієнти":
                    dataGridView1.DataSource = db.Customers.Local.ToBindingList();
                    break;
            }
        }

        //редагуання
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                if (converted == false)
                    return;

                switch (selectedState)
                {
                    case "Ліки":
                        DrugChange(id);
                        break;
                    case "Продавці":
                        SellerChange(id);
                        break;
                    case "Клієнти":
                        CustomerChange(id);
                        break;
                }
            }
            
        }

        private void CustomerChange(int id)
        {
            Customer customer = db.Customers.Find(id);

            CustomerForm customerForm = new CustomerForm();

            customerForm.textBox1.Text = customer.Name;

            DialogResult result = customerForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            customer.Name = customerForm.textBox1.Text;

            db.SaveChanges();

            dataGridView1.Refresh();

            MessageBox.Show("Об'ект обновлений");
        }

        private void SellerChange(int id)
        {
            Seller seller = db.Sellers.Find(id);

            SellerForm sellerForm = new SellerForm();

            sellerForm.textBox1.Text = seller.Name;

            DialogResult result = sellerForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            seller.Name = sellerForm.textBox1.Text;

            db.SaveChanges();

            dataGridView1.Refresh();

            MessageBox.Show("Об'ект обновлений");
        }

        private  void DrugChange(int id)
        {
            Drug drug = db.Drugs.Find(id);

            DrugForm drugForm = new DrugForm();

            drugForm.textBox1.Text = drug.Title;
            drugForm.textBox2.Text = drug.description;
            drugForm.textBox3.Text = Convert.ToString(drug.Price);

            DialogResult result = drugForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                 return;

            drug.Title = drugForm.textBox1.Text;
            drug.description = drugForm.textBox2.Text;
            drug.Price =Convert.ToDouble( drugForm.textBox3.Text);

            db.SaveChanges();

            dataGridView1.Refresh();

            MessageBox.Show("Об'ект обновлений");
        }
        //додавання
        private void button3_Click(object sender, EventArgs e)
        {
            switch (selectedState)
            {
                case "Ліки":
                    DrugAdd();
                    break;
                case "Продавці":
                    SellerAdd();
                    break;
                case "Клієнти":
                    CustomerAdd();
                    break;
            }
        }

        private void CustomerAdd()
        {
            CustomerForm customerForm = new CustomerForm();

            DialogResult result = customerForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Customer customer = new Customer();

            customer.Name = customerForm.textBox1.Text;

            db.Customers.Add(customer);
            db.SaveChanges();

            MessageBox.Show("Новий об'єкт додано");
        }

        private void SellerAdd()
        {
            SellerForm sellerForm = new SellerForm();

            DialogResult result = sellerForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Seller seller = new Seller();

            seller.Name = sellerForm.textBox1.Text;

            db.Sellers.Add(seller);
            db.SaveChanges();

            MessageBox.Show("Новий об'єкт додано");
        }

        private void DrugAdd()
        {
            DrugForm drugForm = new DrugForm();

            DialogResult result = drugForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Drug drug = new Drug();

            drug.Title = drugForm.textBox1.Text;
            drug.description = drugForm.textBox2.Text;
            drug.Price = Convert.ToDouble(drugForm.textBox3.Text);

            db.Drugs.Add(drug);
            db.SaveChanges();

            MessageBox.Show("Новий об'єкт додано");
        }
        //видалення
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                if (converted == false)
                    return;

                switch (selectedState)
                {
                    case "Ліки":
                        DrugRemove(id);
                        break;
                    case "Продавці":
                        SellerRemove(id);
                        break;
                    case "Клієнти":
                        CustomerRemove(id);
                        break;
                }
            }
        }

        private void CustomerRemove(int id)
        {
            Customer customer = db.Customers.Find(id);

            db.Customers.Remove(customer);
            db.SaveChanges();

            MessageBox.Show("Об`єкт видалено");
        }

        private void SellerRemove(int id)
        {
            Seller seller = db.Sellers.Find(id);

            db.Sellers.Remove(seller);
            db.SaveChanges();

            MessageBox.Show("Об`єкт видалено");
        }

        private void DrugRemove(int id)
        {
            Drug drug = db.Drugs.Find(id);

            db.Drugs.Remove(drug);
            db.SaveChanges();

            MessageBox.Show("Об`єкт видалено");
        }
    }
}