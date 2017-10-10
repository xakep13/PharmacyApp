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
            db.Orders.Load();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            dataGridView1.DataSource = db.Orders.Local.ToBindingList();
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show(selectedState);
        }

    }

}
