using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hangars
{
    public partial class Form1 : Form
    {
        public static SqlConnection connect;

        public Form1()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\Stephen\documents\visual studio 2013\Projects\Hangars\Hangars\localTest.mdf;Integrated Security=True");
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designAddCustomer());
        }

        private void Clear()
        {
            while (toolStripContainer1.ContentPanel.Controls.Count > 0)
                toolStripContainer1.ContentPanel.Controls.RemoveAt(0);
        }

        private void hangarBuildingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designAddHangarBuilding());
        }

        private void hangarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designAddHangars());
        }

        private void hangarSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designEditHangars());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designSearchCustomer());
        }

        public static void changeAcceptButton(Control c)
        {
            
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designCreateInvoice());
        }

        private void aircraftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designEditAircraft());
        }

        private void monthlyBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designCreateMonthlyBill());
        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clear();
            toolStripContainer1.ContentPanel.Controls.Add(FormDesigner.designSearchInvoice());
        }
    }
}
