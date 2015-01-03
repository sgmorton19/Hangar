using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Hangars
{
    class EditHangarRow
    {
        static EditHangars edit;
        public ComboBox customerComboBox { get; set; }
        public Label hangarSlotLabel { get; set; }

        public EditHangarRow(EditHangars e)
        {
            edit = e;
        }

        public EditHangarRow(int i, string[] cNames)
        {
            customerComboBox = new ComboBox();
            hangarSlotLabel = new Label();

            // 
            // hangarSlotLabel
            // 
            hangarSlotLabel.AutoSize = true;
            hangarSlotLabel.Dock = DockStyle.Fill;
            hangarSlotLabel.Location = new Point(3, 0);
            hangarSlotLabel.Name = "label2";
            hangarSlotLabel.Size = new Size(144, 28);
            hangarSlotLabel.TabIndex = 1;
            hangarSlotLabel.Text = Util.getHangarNames()[i];
            hangarSlotLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // customerComboBox
            // 
            customerComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            customerComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            customerComboBox.FormattingEnabled = true;
            customerComboBox.Items.AddRange(Util.getCustomerNames(true));
            customerComboBox.Location = new Point(153, 3);
            customerComboBox.Name = "comboBox1";
            customerComboBox.Size = new Size(121, 21);
            customerComboBox.TabIndex = 0;
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(cNames[i].ToString());
            customerComboBox.SelectedIndexChanged += new System.EventHandler(delegate
            {
                string xx;
                if (customerComboBox.SelectedItem != null)
                    xx = customerComboBox.SelectedItem.ToString();
                else
                    xx = "";
                edit.updateArray(xx, edit.rows.IndexOf(this));
            });
        }
    }

    class PaymentsRow
    {
        public FlowLayoutPanel paymentsExamplePanel { get; set; }
        public TextBox paymentEamountTextBox { get; set; }
        public TextBox paymentECheckNumberTextBox { get; set; }
        public TextBox paymentsENotesTextBox { get; set; }
        public Button paymentsEdeleteButton { get; set; }
        public static CreateInvoice c { get; set; }

        public PaymentsRow(CreateInvoice create)
        {
            c = create;
        }

        public PaymentsRow()
        {
            paymentsExamplePanel = new FlowLayoutPanel();
            paymentEamountTextBox = new TextBox();
            paymentECheckNumberTextBox = new TextBox();
            paymentsENotesTextBox = new TextBox();
            paymentsEdeleteButton = new Button();
            paymentsEdeleteButton.Click += new EventHandler(delegate
            {
                c.payments.Remove(this);
                paymentsExamplePanel.Parent.Controls.Remove(paymentsExamplePanel);
            });

            // 
            // paymentsExamplePanel
            // 
            paymentsExamplePanel.AutoSize = true;
            paymentsExamplePanel.Controls.Add(paymentEamountTextBox);
            paymentsExamplePanel.Controls.Add(paymentECheckNumberTextBox);
            paymentsExamplePanel.Controls.Add(paymentsENotesTextBox);
            paymentsExamplePanel.Controls.Add(paymentsEdeleteButton);
            paymentsExamplePanel.Location = new System.Drawing.Point(0, 16);
            paymentsExamplePanel.Margin = new Padding(0);
            paymentsExamplePanel.Name = "paymentsExamplePanel";
            paymentsExamplePanel.Size = new System.Drawing.Size(441, 26);
            paymentsExamplePanel.TabIndex = 3;
            paymentsExamplePanel.WrapContents = false;
            // 
            // paymentEamountTextBox
            // 
            paymentEamountTextBox.Location = new System.Drawing.Point(3, 3);
            paymentEamountTextBox.Name = "paymentEamountTextBox";
            paymentEamountTextBox.Size = new System.Drawing.Size(100, 20);
            paymentEamountTextBox.TabIndex = 4;
            // 
            // paymentECheckNumberTextBox
            // 
            paymentECheckNumberTextBox.Location = new System.Drawing.Point(109, 3);
            paymentECheckNumberTextBox.Multiline = true;
            paymentECheckNumberTextBox.Name = "paymentECheckNumberTextBox";
            paymentECheckNumberTextBox.Size = new System.Drawing.Size(100, 20);
            paymentECheckNumberTextBox.TabIndex = 5;
            // 
            // textBox1
            // 
            paymentsENotesTextBox.Location = new System.Drawing.Point(215, 3);
            paymentsENotesTextBox.Multiline = true;
            paymentsENotesTextBox.Name = "textBox1";
            paymentsENotesTextBox.Size = new System.Drawing.Size(200, 20);
            paymentsENotesTextBox.TabIndex = 6;
            // 
            // paymentsEdeleteButton
            // 
            paymentsEdeleteButton.Location = new System.Drawing.Point(418, 3);
            paymentsEdeleteButton.Margin = new Padding(0, 3, 3, 3);
            paymentsEdeleteButton.Name = "paymentsEdeleteButton";
            paymentsEdeleteButton.Size = new System.Drawing.Size(20, 20);
            paymentsEdeleteButton.TabIndex = 7;
            paymentsEdeleteButton.Text = "X";
            paymentsEdeleteButton.UseVisualStyleBackColor = true;
        }
    }

    class ChargesRow
    {
        public FlowLayoutPanel chargesExamplePanel { get; set; }
        public TextBox chargesEitemTextBox { get; set; }
        public TextBox chargesEpriceTextBox { get; set; }
        public TextBox chargesEnotesTextBox { get; set; }
        public Button chargesEdeleteButton { get; set; }
        public static CreateInvoice c { get; set; }

        public ChargesRow(CreateInvoice create)
        {
            c = create;
        }

        public ChargesRow()
        {
            chargesExamplePanel = new FlowLayoutPanel();
            chargesEitemTextBox = new TextBox();
            chargesEpriceTextBox = new TextBox();
            chargesEnotesTextBox = new TextBox();
            chargesEdeleteButton = new Button();
            chargesEdeleteButton.Click += new EventHandler(delegate
            {
                c.charges.Remove(this);
                chargesExamplePanel.Parent.Controls.Remove(chargesExamplePanel);
            });


            // 
            // chargesExamplePanel
            // 
            chargesExamplePanel.AutoSize = true;
            chargesExamplePanel.Controls.Add(chargesEitemTextBox);
            chargesExamplePanel.Controls.Add(chargesEpriceTextBox);
            chargesExamplePanel.Controls.Add(chargesEnotesTextBox);
            chargesExamplePanel.Controls.Add(chargesEdeleteButton);
            chargesExamplePanel.Location = new System.Drawing.Point(0, 16);
            chargesExamplePanel.Margin = new Padding(0);
            chargesExamplePanel.Name = "chargesExamplePanel";
            chargesExamplePanel.Size = new System.Drawing.Size(441, 26);
            chargesExamplePanel.TabIndex = 3;
            chargesExamplePanel.WrapContents = false;
            // 
            // chargesEitemTextBox
            // 
            chargesEitemTextBox.Location = new System.Drawing.Point(3, 3);
            chargesEitemTextBox.Name = "chargesEitemTextBox";
            chargesEitemTextBox.Size = new System.Drawing.Size(100, 20);
            chargesEitemTextBox.TabIndex = 3;
            // 
            // chargesEpriceTextBox
            // 
            chargesEpriceTextBox.Location = new System.Drawing.Point(109, 3);
            chargesEpriceTextBox.Name = "chargesEpriceTextBox";
            chargesEpriceTextBox.Size = new System.Drawing.Size(100, 20);
            chargesEpriceTextBox.TabIndex = 4;
            // 
            // chargesEnotesTextBox
            // 
            chargesEnotesTextBox.Location = new System.Drawing.Point(215, 3);
            chargesEnotesTextBox.Multiline = true;
            chargesEnotesTextBox.Name = "chargesEnotesTextBox";
            chargesEnotesTextBox.Size = new System.Drawing.Size(200, 20);
            chargesEnotesTextBox.TabIndex = 5;
            // 
            // chargesEdeleteButton
            // 
            chargesEdeleteButton.Location = new System.Drawing.Point(418, 3);
            chargesEdeleteButton.Margin = new Padding(0, 3, 3, 3);
            chargesEdeleteButton.Name = "chargesEdeleteButton";
            chargesEdeleteButton.Size = new System.Drawing.Size(20, 20);
            chargesEdeleteButton.TabIndex = 6;
            chargesEdeleteButton.Text = "X";
            chargesEdeleteButton.UseVisualStyleBackColor = true;
        }
    }

    class AircraftRow
    {
        public TextBox aircraftNumberTextBox { get; set; }
        public TextBox aircraftTypeTextBox { get; set; }
        public Button aircraftDeleteButton { get; set; }

        public AircraftRow(AddCustomer c)
        {
            aircraftNumberTextBox = new TextBox();
            aircraftNumberTextBox.Validating += new CancelEventHandler(delegate
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Aircraft WHERE Tail_Number = N'" + aircraftNumberTextBox.Text + "'", Form1.connect))
                {
                    SqlDataAdapter aircraftDataAdapter = new SqlDataAdapter(command);
                    DataTable aircraftTable = new DataTable();
                    aircraftDataAdapter.Fill(aircraftTable);
                    if (aircraftTable.Rows.Count > 0)
                    {
                        aircraftTypeTextBox.Enabled = false;
                        aircraftTypeTextBox.Text = aircraftTable.Rows[0]["Type"].ToString();
                    }
                    else
                    {
                        aircraftTypeTextBox.Enabled = true;
                        aircraftTypeTextBox.Focus();
                    }
                }
            });
            aircraftTypeTextBox = new TextBox();
            aircraftTypeTextBox.Enabled = false;
            aircraftDeleteButton = new Button();
            aircraftDeleteButton.Click += new EventHandler(delegate
            {
                aircraftDeleteButton.Parent.Controls.Remove(aircraftDeleteButton);
                aircraftNumberTextBox.Parent.Controls.Remove(aircraftNumberTextBox);
                aircraftTypeTextBox.Parent.Controls.Remove(aircraftTypeTextBox);
                c.aircrafts.Remove(this);
            });


            // 
            // aircraftDeleteButton
            // 
            aircraftDeleteButton.FlatStyle = FlatStyle.Flat;
            aircraftDeleteButton.Location = new Point(3, 23);
            aircraftDeleteButton.Name = "aircraftDeleteButton";
            aircraftDeleteButton.Size = new Size(20, 20);
            aircraftDeleteButton.TabStop = false;
            aircraftDeleteButton.Text = "X";
            aircraftDeleteButton.UseVisualStyleBackColor = true;
            // 
            // aircraftNumberTextBox
            // 
            aircraftNumberTextBox.Location = new Point(3, 23);
            aircraftNumberTextBox.Name = "aircraftNumberTextBox";
            aircraftNumberTextBox.Size = new Size(100, 20);
            aircraftNumberTextBox.TabIndex = 0;
            // 
            // aircraftTypeTextBox
            // 
            aircraftTypeTextBox.Location = new Point(3, 23);
            aircraftTypeTextBox.Name = "aircraftTypeTextBox";
            aircraftTypeTextBox.Size = new Size(100, 20);
            aircraftTypeTextBox.TabIndex = 1;
        }

        public override bool Equals(object o)
        {
            try
            {
                return ((AircraftRow)o).aircraftNumberTextBox.Text == aircraftNumberTextBox.Text;
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(AircraftRow a, AircraftRow b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(AircraftRow a, AircraftRow b)
        {
            return !a.Equals(b);
        }
    }

    class SelectRow
    {
        Button b;
        List<string> l;
        public delegate Control buttonClick(string x);

        public List<string> L
        {
            get
            {
                return l;
            }
        }
        public Button button
        {
            get
            {
                return b;
            }
        }

        public SelectRow(List<string> list, string display, string nextScreenKey, Control marginPanel, buttonClick click)
        {
            l = list;
            b = new Button();
            b.Click += new System.EventHandler(delegate
            {
                Control temp = marginPanel.Parent;
                marginPanel.Parent.Controls.RemoveAt(0);
                temp.Controls.Add(click(nextScreenKey));
            });
            // 
            // contentButton
            // 
            b.FlatAppearance.BorderColor = SystemColors.Control;
            b.FlatStyle = FlatStyle.Flat;
            b.Location = new Point(0, 0);
            b.Margin = new Padding(0);
            b.Name = "contentButton";
            b.TabIndex = 0;
            b.Size = new Size(500, 24);
            b.Text = display;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.UseVisualStyleBackColor = true;
            
        }
    }

    class HangarSlots
    {
        public string[] cNames { get; set; }
        public string[] hNames { get; set; }
        private string[] cNamesSaved;
        public int Length { get { return cNames.Length; } private set { int i = value; } }

        // sortType is false for sorting by hangarName, true for sorting by customerName
        bool sortType;

        public HangarSlots(string[] c, string[] h)
        {
            cNames = c;
            hNames = h;
            cNamesSaved = new string[cNames.Length];
            cNames.CopyTo(cNamesSaved, 0);
            sortType = false;
        }

        private void flip()
        {
            int i = this.Length / 2;
            int j = 0;
            while (j < i)
            {
                swap(this.Length - j - 1, j);
                j++;
            }
        }

        private void swap(int i, int j)
        {
            if (i != j)
            {
                string temp = cNames[i];
                cNames[i] = cNames[j];
                cNames[j] = temp;
                temp = hNames[i];
                hNames[i] = hNames[j];
                hNames[j] = temp;
            }
        }

        public void sortBy(bool names)
        {
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = i + 1; j < this.Length; j++)
                {
                    if (names)
                    {
                        if (cNames[j] != "" && (String.CompareOrdinal(cNames[i], cNames[j]) > 0 || cNames[i] == ""))
                        {
                            swap(j, i);
                        }
                    }
                    else
                    {
                        if (String.CompareOrdinal(hNames[i], hNames[j]) > 0)
                        {
                            swap(j, i);
                        }
                    }
                }
            }
            sortType = names;
        }

        public void sort(bool sortT)
        {
            if (sortT == sortType)
                flip();
            else
                sortBy(sortT);
        }

        public string[] getcNamesSaved()
        {
            return cNamesSaved;
        }
    }



    static class Util
    {
        static string[] states = new string[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
        static string[] phoneTypes = new string[] { "Work", "Home", "Cell", "Other" };
        static string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "October", "November", "December" };
        static string[] shortMonths = new string[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUNE", "JULY", "AUG", "SEPT", "OCT", "NOV", "DEC" };

        static public string[] States
        {
            get
            {
                return states;
            }
        }
        static public string[] PhoneTypes
        {
            get
            {
                return phoneTypes;
            }
        }
        static public string[] Months
        {
            get
            {
                return months;
            }
        }
        static public string[] Years
        {
            get
            {
                return generateYears();
            }
        }

        private static string[] generateYears()
        {
            List<string> retval = new List<string>();
            int x = 2010;
            while (x < 2100)
            {
                retval.Add(x.ToString());
                x++;
            }

            return retval.ToArray();
        }

        public static string shortenMonth(string m)
        {
            int i = 0;
            while (i < months.Length)
            {
                if (String.CompareOrdinal(months[i], m) == 0)
                {
                    return shortMonths[i];
                }
            }
            throw new Exception("Invalid Month");
        }

        static public string intToMonth(int m)
        {
            switch (m)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    throw new Exception("invalid input");
            }
        }

        static public string[] getHangarBuildings()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HangarPrice", Form1.connect);
            SqlDataAdapter hangarBuildingDataAdapter = new SqlDataAdapter(command);
            DataTable hangarBuildingTable = new DataTable();
            hangarBuildingDataAdapter.Fill(hangarBuildingTable);


            List<string> x = new List<string>();

            foreach (DataRow r in hangarBuildingTable.Rows)
            {
                x.Add(r["Building"].ToString());
            }

            return x.ToArray();
        }

        static public DataTable getAllCustomerInfo(string n)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE Full_Name = N'" + n + "'", Form1.connect);
            SqlDataAdapter customerDataAdapter = new SqlDataAdapter(command);
            DataTable customerTable = new DataTable();
            customerDataAdapter.Fill(customerTable);

            return customerTable;
        }

        static public DataTable getAllAircraftInfoByCustomer(string n)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Aircraft JOIN Aircraft_Owners ON Aircraft_Owners.Tail_Number = Aircraft.Tail_Number WHERE Aircraft_Owners.Customer_Name = N'" + n + "'", Form1.connect);
            SqlDataAdapter aircraftDataAdapter = new SqlDataAdapter(command);
            DataTable aircraftTable = new DataTable();
            aircraftDataAdapter.Fill(aircraftTable);

            return aircraftTable;
        }

        static public DataTable getAllAircraftInfoByTailNumber(string n)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Aircraft  WHERE Tail_Number = N'" + n + "'", Form1.connect);
            SqlDataAdapter aircraftDataAdapter = new SqlDataAdapter(command);
            DataTable aircraftTable = new DataTable();
            aircraftDataAdapter.Fill(aircraftTable);

            return aircraftTable;
        }

        static public DataTable getAllHangarSlots()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Hangars", Form1.connect);
            SqlDataAdapter hangarDataAdapter = new SqlDataAdapter(command);
            DataTable hangarTable = new DataTable();
            hangarDataAdapter.Fill(hangarTable);

            return hangarTable;
        }

        static public decimal getHangarPrice(string hangar)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM HangarPrice WHERE Building = N'" + hangar + "'", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(com);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            return Convert.ToDecimal(namesTable.Rows[0]["Price"].ToString());
        }

        static public decimal getCustomerBalance(string fullname)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM Customer WHERE Full_Name = N'" + fullname + "'", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(com);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            return Convert.ToDecimal(namesTable.Rows[0]["Balance"].ToString());
        }

        static public string getNextInvoiceID()
        {
            int idnum;
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Invoice ORDER BY InvoiceID desc", Form1.connect))
            {
                SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
                DataTable namesTable = new DataTable();
                namesDataAdapter.Fill(namesTable);
                idnum = (Convert.ToInt32(namesTable.Rows[0]["InvoiceID"].ToString().Split(new char[] { '-' })[1]) + 1);
            }

            return "H" + removeFirstTwoDigits(DateTime.Now.Year) + "-" + idnum;
        }

        static public DataTable getInvoices(string date)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1000 * FROM Invoice ORDER BY InvoiceID desc", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            return namesTable;
        }

        static public DataTable getInvoice(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Invoice WHERE InvoiceID = N'" + id + "'", Form1.connect);
            SqlDataAdapter invoiceDataAdapter = new SqlDataAdapter(command);
            DataTable invoiceTable = new DataTable();
            invoiceDataAdapter.Fill(invoiceTable);

            return invoiceTable;
        }

        static public DataTable getItems(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Item WHERE InvoiceID = N'" + id + "'", Form1.connect);
            SqlDataAdapter itemDataAdapter = new SqlDataAdapter(command);
            DataTable itemTable = new DataTable();
            itemDataAdapter.Fill(itemTable);

            return itemTable;
        }

        static public DataTable getPayments(string id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Payment WHERE InvoiceID = N'" + id + "'", Form1.connect);
            SqlDataAdapter paymentDataAdapter = new SqlDataAdapter(command);
            DataTable paymentTable = new DataTable();
            paymentDataAdapter.Fill(paymentTable);

            return paymentTable;
        }

        static public string[] datatableTOarray(DataTable t, string s)
        {
            List<string> x = new List<string>();
            foreach (DataRow r in t.Rows)
            {
                x.Add(r[s].ToString());
            }
            return x.ToArray();
        }

        static public int removeFirstTwoDigits(int x)
        {
            double d = DateTime.Now.Year / 100.00;
            while (d > 1)
                d -= 1;
            return Convert.ToInt32(d * 100);
        }

        static public string getTailNumberFromName(string n)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Aircraft_Owners WHERE Customer_Name = N'" + n + "'", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            if (namesTable.Rows.Count > 1)
            {
                return "Multiple";
            }
            else
            {
                return namesTable.Rows[0]["Tail_Number"].ToString();
            }
        }

        static public string[] getCustomerNames(bool t)
        {
            SqlCommand command = new SqlCommand("SELECT Full_Name FROM Customer", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            List<string> x = new List<string>();
            foreach (DataRow r in namesTable.Rows)
            {
                x.Add(r[0].ToString());
            }

            if (t)
                x.Add("");

            return x.ToArray();
        }

        static public string[] getCustomerNames()
        {
            return getCustomerNames(false);
        }

        static public string[] getAircraftNumbers()
        {
            SqlCommand command = new SqlCommand("SELECT Tail_Number FROM Aircraft", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);

            List<string> x = new List<string>();
            foreach (DataRow r in namesTable.Rows)
            {
                x.Add(r[0].ToString());
            }

            return x.ToArray();
        }

        static public string[] getHangaredCustomers()
        {
            SqlCommand command = new SqlCommand("SELECT Customer_Name FROM Hangars", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);


            List<string> x = new List<string>();

            foreach (DataRow r in namesTable.Rows)
            {
                x.Add(r[0].ToString());
            }

            return x.ToArray();
        }

        static public string[] getHangarNames()
        {
            SqlCommand command = new SqlCommand("SELECT Hangar FROM Hangars", Form1.connect);
            SqlDataAdapter namesDataAdapter = new SqlDataAdapter(command);
            DataTable namesTable = new DataTable();
            namesDataAdapter.Fill(namesTable);


            List<string> x = new List<string>();

            foreach (DataRow r in namesTable.Rows)
            {
                x.Add(r[0].ToString());
            }

            return x.ToArray();
        }

        static public string[] toDistinct(string[] old)
        {
            List<string> newlist = new List<string>();
            for (int i = 0; i < old.Length; i++)
            {
                if (!newlist.Contains(old[i]))
                    newlist.Add(old[i]);
            }
            return newlist.ToArray();
        }

        static public void updateCustomerBalance(string fullname, decimal amount_due)
        {
            decimal oldbalance = Util.getCustomerBalance(fullname);

            using (SqlCommand com = new SqlCommand("UPDATE Customer SET balance = @b WHERE Full_Name = @fullname", Form1.connect))
            {
                com.Parameters.AddWithValue("@b", oldbalance + amount_due);
                com.Parameters.AddWithValue("@fullname", fullname);
                com.ExecuteNonQuery();
            }
        }

        static public bool searchButtonVisible(string stopper, List<string> l)
        {

            if (l.Count == 0)
                return false;
            int stop = stopper.Length;
            string test = l.First();
            if (stop <= test.Length ? test.Substring(0, stop).Equals(stopper, StringComparison.InvariantCultureIgnoreCase) : false)
            {
                return true;
            }
            else
            {
                List<string> newl = new List<string>();
                foreach (string x in l)
                {
                    if (string.CompareOrdinal(l.First(), x) != 0)
                        newl.Add(x);
                }
                return searchButtonVisible(stopper, newl);
            }
        }

    }
}
