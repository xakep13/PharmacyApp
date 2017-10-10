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
        PharmacyContext db;

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
            string selectedState = comboBox1.SelectedItem.ToString();

            switch(selectedState)
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

    }

}
