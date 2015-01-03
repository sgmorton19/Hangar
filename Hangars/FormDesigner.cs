using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hangars
{
    static class FormDesigner
    {
        static public Control designAddCustomer()
        {
            return new AddCustomer().Add();
        }

        static public Control designEditCustomer(string n)
        {
            return new AddCustomer().Edit(n);
        }

        static public Control designAddHangarBuilding()
        {
            return new AddHangarBuilding().Add();
        }

        static public Control designAddHangars()
        {
            return new AddHangars().Add();
        }

        static public Control designEditHangars()
        {
            return new EditHangars().Add();
        }

        static public Control designSearchCustomer()
        {
            return new Search().Customer();
        }

        static public Control designCreateInvoice()
        {
            return new CreateInvoice().Add();
        }

        static public Control designEditInvoice(string n)
        {
            return new CreateInvoice().Edit(n);
        }

        static public Control designEditAircraft()
        {
            return new EditAircraft().Add();
        }

        static public Control designCreateMonthlyBill()
        {
            return new CreateMonthlyBill().Add();
        }

        static public Control designSearchInvoice()
        {
            return new Search().Invoice();
        }
    }

    class AddCustomer
    {
        #region Globals
        TableLayoutPanel marginPanel;
        FlowLayoutPanel flowLayoutPanel1;
        Label firstNameLabel;
        TextBox firstNameTextBox;
        FlowLayoutPanel flowLayoutPanel2;
        Label lastNameLabel;
        TextBox lastNameTextBox;
        FlowLayoutPanel buttonFlowLayoutPanel;
        Button addButton;
        Button deleteButton;
        FlowLayoutPanel flowLayoutPanel4;
        Label line1Label;
        TextBox line1TextBox;
        FlowLayoutPanel flowLayoutPanel5;
        Label line2Label;
        TextBox line2TextBox;
        FlowLayoutPanel flowLayoutPanel6;
        Label cityLabel;
        TextBox cityTextBox;
        Label stateLabel;
        ComboBox stateComboBox;
        Label zipLabel;
        TextBox zipTextBox;
        FlowLayoutPanel flowLayoutPanel7;
        Label phone1Label;
        TextBox phone1TextBox;
        ComboBox phone1ComboBox;
        FlowLayoutPanel flowLayoutPanel8;
        Label phone2Label;
        TextBox phone2TextBox;
        ComboBox phone2ComboBox;
        EventHandler addClick;
        EventHandler editClick;
        BackgroundWorker backgroundWorker1;

        TableLayoutPanel columnsTableLayoutPanel;
        FlowLayoutPanel deleteFlowLayoutPanel;
        Label blankLabel;
        FlowLayoutPanel aircraftTypeFlowLayoutPanel;
        Label aircraftTypeLabel;
        FlowLayoutPanel tailNumberFlowLayoutPanel;
        Label tailNumberLabel;
        Button addAircraftButton;
        public List<AircraftRow> aircrafts;
        #endregion

        public AddCustomer()
        {
            backgroundWorker1 = new BackgroundWorker();
            marginPanel = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            addButton = new Button();
            deleteButton = new Button();
            addClick = new EventHandler(delegate
            {
                if (lastNameTextBox.Text != string.Empty && firstNameTextBox.Text != string.Empty)
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO Customer (Full_Name, First_Name, Last_Name, Balance, Line1, Line2, City, State, Zip, Phone1, Phone1Type, Phone2, Phone2Type) Values(@fullN, @firstN, @lastN, @balance, @line1, @line2, @city, @state, @zip, @phone1, @phone1type, @phone2, @phone2type)", Form1.connect))
                    {
                        com.Parameters.AddWithValue("@fullN", lastNameTextBox.Text + ", " + firstNameTextBox.Text);
                        com.Parameters.AddWithValue("@firstN", firstNameTextBox.Text);
                        com.Parameters.AddWithValue("@lastN", lastNameTextBox.Text);
                        com.Parameters.AddWithValue("@balance", 0m);
                        com.Parameters.AddWithValue("@line1", line1TextBox.Text);
                        com.Parameters.AddWithValue("@line2", line2TextBox.Text);
                        com.Parameters.AddWithValue("@city", cityTextBox.Text);
                        string temp = "";
                        if (phone1ComboBox.SelectedIndex > 0) { temp = stateComboBox.SelectedItem.ToString(); }
                        com.Parameters.AddWithValue("@state", temp);
                        com.Parameters.AddWithValue("@zip", zipTextBox.Text);
                        com.Parameters.AddWithValue("@phone1", phone1TextBox.Text);
                        temp = "";
                        if (phone1ComboBox.SelectedIndex > 0) { temp = phone1ComboBox.SelectedItem.ToString(); }
                        com.Parameters.AddWithValue("@phone1type", temp);
                        com.Parameters.AddWithValue("@phone2", phone2TextBox.Text);
                        temp = "";
                        if (phone1ComboBox.SelectedIndex > 0) { temp = phone1ComboBox.SelectedItem.ToString(); }
                        com.Parameters.AddWithValue("@phone2type", temp);

                        com.ExecuteNonQuery();
                        MessageBox.Show("Account for " + lastNameTextBox.Text + ", " + firstNameTextBox.Text + " was created");
                    }

                    List<AircraftRow> newaircrafts = aircrafts.Distinct<AircraftRow>().ToList<AircraftRow>();
                    foreach (AircraftRow r in newaircrafts)
                    {
                        using (SqlCommand com = new SqlCommand("INSERT INTO Aircraft_Owners (Customer_Name, Tail_Number) Values(@fullname, @tailn)", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@fullname", lastNameTextBox.Text + ", " + firstNameTextBox.Text);
                            com.Parameters.AddWithValue("@tailn", r.aircraftNumberTextBox.Text);
                            com.ExecuteNonQuery();
                        }
                    }

                    foreach (AircraftRow r in newaircrafts)
                    {
                        if (r.aircraftTypeTextBox.Enabled == true)
                        {
                            using (SqlCommand com = new SqlCommand("INSERT INTO Aircraft (Tail_Number, Type, Heaters) Values(@tailn, @type, @heaters)", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@tailn", r.aircraftNumberTextBox.Text);
                                com.Parameters.AddWithValue("@type", r.aircraftTypeTextBox.Text);
                                com.Parameters.AddWithValue("@heaters", 0);
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
            });
            addButton.Click += addClick;
            buttonFlowLayoutPanel = new FlowLayoutPanel();

            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();

            flowLayoutPanel4 = new FlowLayoutPanel();
            line1Label = new Label();
            line1TextBox = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            line2Label = new Label();
            line2TextBox = new TextBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            cityLabel = new Label();
            cityTextBox = new TextBox();
            stateLabel = new Label();
            zipLabel = new Label();
            zipTextBox = new TextBox();
            stateComboBox = new ComboBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            phone1Label = new Label();
            phone1TextBox = new TextBox();
            phone1ComboBox = new ComboBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            phone2Label = new Label();
            phone2TextBox = new TextBox();
            phone2ComboBox = new ComboBox();
            columnsTableLayoutPanel = new TableLayoutPanel();
            deleteFlowLayoutPanel = new FlowLayoutPanel();
            blankLabel = new Label();
            aircraftTypeFlowLayoutPanel = new FlowLayoutPanel();
            aircraftTypeLabel = new Label();
            tailNumberFlowLayoutPanel = new FlowLayoutPanel();
            tailNumberLabel = new Label();
            addAircraftButton = new Button();
            addAircraftButton.Click += new EventHandler(delegate
                {
                    AircraftRow row = new AircraftRow(this);
                    aircrafts.Add(row);

                    tailNumberFlowLayoutPanel.Controls.Add(row.aircraftNumberTextBox);
                    aircraftTypeFlowLayoutPanel.Controls.Add(row.aircraftTypeTextBox);
                    deleteFlowLayoutPanel.Controls.Add(row.aircraftDeleteButton);

                });
            aircrafts = new List<AircraftRow>();


            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(flowLayoutPanel1, 1, 1);
            marginPanel.Controls.Add(flowLayoutPanel2, 1, 2);
            marginPanel.Controls.Add(columnsTableLayoutPanel, 1, 4);
            marginPanel.Controls.Add(addAircraftButton, 1, 5);
            marginPanel.Controls.Add(flowLayoutPanel4, 1, 7);
            marginPanel.Controls.Add(flowLayoutPanel5, 1, 8);
            marginPanel.Controls.Add(flowLayoutPanel6, 1, 9);
            marginPanel.Controls.Add(flowLayoutPanel7, 1, 11);
            marginPanel.Controls.Add(flowLayoutPanel8, 1, 12);
            marginPanel.Controls.Add(buttonFlowLayoutPanel, 1, 13);
            marginPanel.Dock = DockStyle.Fill;
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "tableLayoutPanel1";
            marginPanel.RowCount = 13;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.Size = new Size(410, 305);

            // 
            // firstNameLabel
            // 
            firstNameLabel.Location = new Point(3, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 23);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            firstNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(89, 3);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(100, 20);
            firstNameTextBox.TabIndex = 0;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Location = new Point(3, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(80, 23);
            lastNameLabel.TabIndex = 1;
            lastNameLabel.Text = "Last Name";
            lastNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(89, 3);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(100, 20);
            lastNameTextBox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(firstNameLabel);
            flowLayoutPanel1.Controls.Add(firstNameTextBox);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(20, 20);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Size = new Size(390, 30);
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lastNameLabel);
            flowLayoutPanel2.Controls.Add(lastNameTextBox);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(20, 50);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(390, 30);

            // 
            // flowLayoutPanel1
            // 
            buttonFlowLayoutPanel.Controls.Add(addButton);
            buttonFlowLayoutPanel.Dock = DockStyle.Fill;
            buttonFlowLayoutPanel.Location = new Point(20, 20);
            buttonFlowLayoutPanel.Margin = new Padding(0);
            buttonFlowLayoutPanel.Size = new Size(390, 30);
            // 
            // addButton
            // 
            addButton.Location = new Point(23, 113);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 13;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(23, 113);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 13;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;

            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(line1Label);
            flowLayoutPanel4.Controls.Add(line1TextBox);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(20, 20);
            flowLayoutPanel4.Margin = new Padding(0);
            flowLayoutPanel4.Size = new Size(390, 30);
            // 
            // line1Label
            // 
            line1Label.Location = new Point(3, 0);
            line1Label.Name = "line1Label";
            line1Label.Size = new Size(80, 23);
            line1Label.Text = "Line 1";
            line1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // line1TextBox
            // 
            line1TextBox.Location = new Point(89, 3);
            line1TextBox.Name = "line1TextBox";
            line1TextBox.Size = new Size(200, 20);
            line1TextBox.TabIndex = 4;


            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(line2Label);
            flowLayoutPanel5.Controls.Add(line2TextBox);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.Location = new Point(20, 20);
            flowLayoutPanel5.Margin = new Padding(0);
            flowLayoutPanel5.Size = new Size(390, 30);
            // 
            // line2Label
            // 
            line2Label.Location = new Point(3, 0);
            line2Label.Name = "line2Label";
            line2Label.Size = new Size(80, 23);
            line2Label.Text = "Line 2";
            line2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // line2TextBox
            // 
            line2TextBox.Location = new Point(89, 3);
            line2TextBox.Name = "line2TextBox";
            line2TextBox.Size = new Size(200, 20);
            line2TextBox.TabIndex = 5;

            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(cityLabel);
            flowLayoutPanel6.Controls.Add(cityTextBox);
            flowLayoutPanel6.Controls.Add(stateLabel);
            flowLayoutPanel6.Controls.Add(stateComboBox);
            flowLayoutPanel6.Controls.Add(zipLabel);
            flowLayoutPanel6.Controls.Add(zipTextBox);
            flowLayoutPanel6.Dock = DockStyle.Fill;
            flowLayoutPanel6.Location = new Point(20, 20);
            flowLayoutPanel6.Margin = new Padding(0);
            flowLayoutPanel6.Size = new Size(390, 30);
            // 
            // cityLabel
            // 
            cityLabel.Location = new Point(3, 0);
            cityLabel.Name = "line2Label";
            cityLabel.Size = new Size(35, 23);
            cityLabel.Text = "City";
            cityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(89, 3);
            cityTextBox.Name = "line2TextBox";
            cityTextBox.Size = new Size(100, 20);
            cityTextBox.TabIndex = 6;
            // 
            // stateLabel
            // 
            stateLabel.Location = new Point(3, 0);
            stateLabel.Name = "line2Label";
            stateLabel.Size = new Size(40, 23);
            stateLabel.Text = "State";
            stateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stateComboBox
            // 
            stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(3, 33);
            stateComboBox.Name = "comboBox1";
            stateComboBox.Size = new Size(40, 21);
            stateComboBox.Items.AddRange(Util.States);
            stateComboBox.TabIndex = 7;
            // 
            // zipLabel
            // 
            zipLabel.Location = new Point(3, 0);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(50, 23);
            zipLabel.Text = "Zip Code";
            zipLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zipTextBox
            // 
            zipTextBox.Location = new Point(89, 3);
            zipTextBox.Name = "line2TextBox";
            zipTextBox.Size = new Size(50, 20);
            zipTextBox.TabIndex = 8;

            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(phone1Label);
            flowLayoutPanel7.Controls.Add(phone1TextBox);
            flowLayoutPanel7.Controls.Add(phone1ComboBox);
            flowLayoutPanel7.Dock = DockStyle.Fill;
            flowLayoutPanel7.Location = new Point(20, 20);
            flowLayoutPanel7.Margin = new Padding(0);
            flowLayoutPanel7.Size = new Size(390, 30);
            // 
            // phone1Label
            // 
            phone1Label.Location = new Point(3, 0);
            phone1Label.Name = "phone1Label";
            phone1Label.Size = new Size(80, 23);
            phone1Label.Text = "Phone 1";
            phone1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // phone1TextBox
            // 
            phone1TextBox.Location = new Point(89, 3);
            phone1TextBox.Name = "phone1TextBox";
            phone1TextBox.Size = new Size(100, 20);
            phone1TextBox.TabIndex = 9;
            //
            // phone1ComboBox
            //
            phone1ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            phone1ComboBox.FormattingEnabled = true;
            phone1ComboBox.Location = new Point(3, 33);
            phone1ComboBox.Name = "comboBox1";
            phone1ComboBox.Size = new Size(60, 21);
            phone1ComboBox.Items.AddRange(Util.PhoneTypes);
            phone1ComboBox.TabIndex = 10;

            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(phone2Label);
            flowLayoutPanel8.Controls.Add(phone2TextBox);
            flowLayoutPanel8.Controls.Add(phone2ComboBox);
            flowLayoutPanel8.Dock = DockStyle.Fill;
            flowLayoutPanel8.Location = new Point(20, 20);
            flowLayoutPanel8.Margin = new Padding(0);
            flowLayoutPanel8.Size = new Size(390, 30);
            // 
            // phone2Label
            // 
            phone2Label.Location = new Point(3, 0);
            phone2Label.Name = "phone2Label";
            phone2Label.Size = new Size(80, 23);
            phone2Label.Text = "Phone 2";
            phone2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // phone1TextBox
            // 
            phone2TextBox.Location = new Point(89, 3);
            phone2TextBox.Name = "phone2TextBox";
            phone2TextBox.Size = new Size(100, 20);
            phone2TextBox.TabIndex = 11;
            //
            // phone2ComboBox
            //
            phone2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            phone2ComboBox.FormattingEnabled = true;
            phone2ComboBox.Location = new Point(3, 33);
            phone2ComboBox.Name = "phone2ComboBox";
            phone2ComboBox.Size = new Size(60, 21);
            phone2ComboBox.Items.AddRange(Util.PhoneTypes);
            phone2ComboBox.TabIndex = 12;
            // 
            // columnsTableLayoutPanel
            // 
            columnsTableLayoutPanel.ColumnCount = 3;
            columnsTableLayoutPanel.AutoSize = true;
            columnsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            columnsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            columnsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            columnsTableLayoutPanel.Controls.Add(deleteFlowLayoutPanel, 2, 0);
            columnsTableLayoutPanel.Controls.Add(aircraftTypeFlowLayoutPanel, 1, 0);
            columnsTableLayoutPanel.Controls.Add(tailNumberFlowLayoutPanel, 0, 0);
            columnsTableLayoutPanel.Location = new Point(50, 30);
            columnsTableLayoutPanel.Name = "columnsTableLayoutPanel";
            columnsTableLayoutPanel.RowCount = 1;
            columnsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            columnsTableLayoutPanel.TabIndex = 0;
            // 
            // deleteFlowLayoutPanel
            // 
            deleteFlowLayoutPanel.Controls.Add(blankLabel);
            deleteFlowLayoutPanel.AutoSize = true;
            deleteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            deleteFlowLayoutPanel.Location = new Point(227, 3);
            deleteFlowLayoutPanel.Name = "deleteFlowLayoutPanel";
            deleteFlowLayoutPanel.TabIndex = 2;
            // 
            // blankLabel
            // 
            blankLabel.Location = new Point(3, 0);
            blankLabel.Name = "blankLabel";
            blankLabel.Size = new Size(1, 20);
            blankLabel.TabIndex = 2;
            blankLabel.Text = "Aircraft Type";
            blankLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // aircraftTypeFlowLayoutPanel
            // 
            aircraftTypeFlowLayoutPanel.Controls.Add(aircraftTypeLabel);
            aircraftTypeFlowLayoutPanel.AutoSize = true;
            aircraftTypeFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            aircraftTypeFlowLayoutPanel.Location = new Point(115, 3);
            aircraftTypeFlowLayoutPanel.Name = "aircraftTypeFlowLayoutPanel";
            aircraftTypeFlowLayoutPanel.TabIndex = 1;
            // 
            // aircraftTypeLabel
            // 
            aircraftTypeLabel.Location = new Point(3, 0);
            aircraftTypeLabel.Name = "aircraftTypeLabel";
            aircraftTypeLabel.Size = new Size(100, 20);
            aircraftTypeLabel.TabIndex = 1;
            aircraftTypeLabel.Text = "Aircraft Type";
            aircraftTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tailNumberFlowLayoutPanel
            // 
            tailNumberFlowLayoutPanel.Controls.Add(tailNumberLabel);
            tailNumberFlowLayoutPanel.AutoSize = true;
            tailNumberFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            tailNumberFlowLayoutPanel.Location = new Point(3, 3);
            tailNumberFlowLayoutPanel.Name = "tailNumberFlowLayoutPanel";
            tailNumberFlowLayoutPanel.TabIndex = 0;
            // 
            // tailNumberLabel
            // 
            tailNumberLabel.Location = new Point(3, 0);
            tailNumberLabel.Name = "tailNumberLabel";
            tailNumberLabel.Size = new Size(100, 20);
            tailNumberLabel.TabIndex = 0;
            tailNumberLabel.Text = "Tail Number";
            tailNumberLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // addAircraftButton
            // 
            addAircraftButton.Location = new Point(23, 113);
            addAircraftButton.Name = "addAircraftButton";
            addAircraftButton.Size = new Size(75, 23);
            addAircraftButton.TabIndex = 13;
            addAircraftButton.Text = "Add Aircraft";
            addAircraftButton.UseVisualStyleBackColor = true;
        }

        public Control Add()
        {
            return marginPanel;
        }

        public Control Edit(string n)
        {
            DataTable oldCustomerInfo = Util.getAllCustomerInfo(n);
            DataTable oldAircraftInfo = Util.getAllAircraftInfoByCustomer(n);
            deleteButton.Click += new EventHandler(delegate
            {
                // Delete customer from aircraft owners table
                using (SqlCommand com = new SqlCommand("DELETE FROM Aircraft_Owners WHERE Customer_Name = @fullname", Form1.connect))
                {
                    com.Parameters.AddWithValue("@fullname", n);
                    com.ExecuteNonQuery();
                }

                using (SqlCommand com = new SqlCommand("DELETE FROM Customer WHERE Full_Name= @name", Form1.connect))
                {
                    com.Parameters.AddWithValue("@name", n);
                    com.ExecuteNonQuery();
                }

                marginPanel.Parent.Controls.Remove(marginPanel);
            });
            addButton.Click -= addClick;
            addButton.Text = "Update";
            editClick = new EventHandler(delegate
            {
                backgroundWorker1.Dispose();
                backgroundWorker1 = new BackgroundWorker();
                backgroundWorker1.DoWork += new DoWorkEventHandler(delegate(object sender, DoWorkEventArgs e)
                    {
                        #region Updates to Customer Table
                        bool firstbool = !firstNameTextBox.Text.Equals(oldCustomerInfo.Rows[0]["First_Name"]);
                        bool lastbool = !lastNameTextBox.Text.Equals(oldCustomerInfo.Rows[0]["Last_Name"]);
                        if (firstbool)
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET First_Name = @an WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@an", firstNameTextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (lastbool)
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Last_Name = @an WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@an", lastNameTextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (lastbool || firstbool)
                        {
                            string fn = lastNameTextBox.Text + ", " + firstNameTextBox.Text;
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Full_Name = @an WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@an", fn);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                            using (SqlCommand com = new SqlCommand("UPDATE Hangars SET Customer_Name = @an WHERE Customer_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@an", fn);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                            using (SqlCommand com = new SqlCommand("UPDATE Invoice SET Customer_Name = @an WHERE Customer_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@an", fn);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (!line1TextBox.Text.Equals(oldCustomerInfo.Rows[0]["Line1"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Line1 = @line1 WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@line1", line1TextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (!line2TextBox.Text.Equals(oldCustomerInfo.Rows[0]["Line2"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Line2 = @line2 WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@line2", line2TextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (!cityTextBox.Text.Equals(oldCustomerInfo.Rows[0]["City"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET City = @city WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@city", cityTextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        stateComboBox.Invoke((MethodInvoker)delegate
                        {
                            string xx = "";
                            if (stateComboBox.SelectedItem != null) { xx = stateComboBox.SelectedItem.ToString(); }
                            if (!xx.Equals(oldCustomerInfo.Rows[0]["State"]))
                            {
                                using (SqlCommand com = new SqlCommand("UPDATE Customer SET State = @state WHERE Full_Name = @fullname", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@state", xx);
                                    com.Parameters.AddWithValue("@fullname", n);
                                    com.ExecuteNonQuery();
                                }
                            }
                        });

                        if (!zipTextBox.Text.Equals(oldCustomerInfo.Rows[0]["Zip"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Zip = @zip WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@zip", zipTextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        if (!phone1TextBox.Text.Equals(oldCustomerInfo.Rows[0]["Phone1"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Phone1 = @phone1 WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@phone1", phone1TextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        phone1ComboBox.Invoke((MethodInvoker)delegate
                        {
                            string xx = "";
                            if (phone1ComboBox.SelectedItem != null) { xx = phone1ComboBox.SelectedItem.ToString(); }
                            if (!xx.Equals(oldCustomerInfo.Rows[0]["Phone1Type"]))
                            {
                                using (SqlCommand com = new SqlCommand("UPDATE Customer SET Phone1Type = @phone1 WHERE Full_Name = @fullname", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@phone1", xx);
                                    com.Parameters.AddWithValue("@fullname", n);
                                    com.ExecuteNonQuery();
                                }
                            }
                        });

                        if (!phone2TextBox.Text.Equals(oldCustomerInfo.Rows[0]["Phone2"]))
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Customer SET Phone2 = @phone2 WHERE Full_Name = @fullname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@phone2", phone2TextBox.Text);
                                com.Parameters.AddWithValue("@fullname", n);
                                com.ExecuteNonQuery();
                            }
                        }

                        stateComboBox.Invoke((MethodInvoker)delegate
                        {
                            string xx = "";
                            if (stateComboBox.SelectedItem != null) { xx = stateComboBox.SelectedItem.ToString(); }
                            if (!xx.Equals(oldCustomerInfo.Rows[0]["Phone2Type"]))
                            {
                                using (SqlCommand com = new SqlCommand("UPDATE Customer SET Phone2Type = @phone2 WHERE Full_Name = @fullname", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@phone2", xx);
                                    com.Parameters.AddWithValue("@fullname", n);
                                    com.ExecuteNonQuery();
                                }
                            }
                        });
                        #endregion

                        #region Updates to Aircraft Related Tables

                        List<AircraftRow> newaircrafts = aircrafts.Distinct<AircraftRow>().ToList<AircraftRow>();

                        /*
                         * If an aircraft is removed from the Form, this segment will remove it from the database
                         */
                        foreach (DataRow x in oldAircraftInfo.Rows)
                        {
                            bool isthere = false;
                            foreach (AircraftRow r in newaircrafts)
                            {
                                if (String.CompareOrdinal(x["Tail_Number"].ToString(), r.aircraftNumberTextBox.Text) == 0)
                                {
                                    isthere = true;
                                    newaircrafts.Remove(r);
                                    break;
                                }
                            }
                            if (!isthere)
                            {
                                using (SqlCommand com = new SqlCommand("DELETE FROM Aircraft_Owners WHERE Customer_Name = @fullname AND Tail_Number = @tailn", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@fullname", n);
                                    com.Parameters.AddWithValue("@tailn", x["Tail_Number"].ToString());
                                    com.ExecuteNonQuery();
                                }
                            }
                        }



                        foreach (AircraftRow r in newaircrafts)
                        {
                            using (SqlCommand com = new SqlCommand("INSERT INTO Aircraft_Owners (Customer_Name, Tail_Number) Values(@fullname, @tailn)", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@fullname", n);
                                com.Parameters.AddWithValue("@tailn", r.aircraftNumberTextBox.Text);
                                com.ExecuteNonQuery();
                            }
                        }

                        foreach (AircraftRow r in newaircrafts)
                        {
                            if (r.aircraftTypeTextBox.Enabled == true)
                            {
                                using (SqlCommand com = new SqlCommand("INSERT INTO Aircraft (Tail_Number, Type, Heaters) Values(@tailn, @type, @heaters)", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@tailn", r.aircraftNumberTextBox.Text);
                                    com.Parameters.AddWithValue("@type", r.aircraftTypeTextBox.Text);
                                    com.Parameters.AddWithValue("@heaters", 0);
                                    com.ExecuteNonQuery();
                                }
                            }
                        }
                        #endregion
                    });
                backgroundWorker1.RunWorkerAsync();
            });
            addButton.Click += editClick;

            buttonFlowLayoutPanel.Controls.Add(deleteButton);

            firstNameTextBox.Text = oldCustomerInfo.Rows[0]["First_Name"].ToString();
            lastNameTextBox.Text = oldCustomerInfo.Rows[0]["Last_Name"].ToString();
            line1TextBox.Text = oldCustomerInfo.Rows[0]["Line1"].ToString();
            line2TextBox.Text = oldCustomerInfo.Rows[0]["Line2"].ToString();
            cityTextBox.Text = oldCustomerInfo.Rows[0]["City"].ToString();
            stateComboBox.SelectedIndex = stateComboBox.FindString(oldCustomerInfo.Rows[0]["State"].ToString());
            zipTextBox.Text = oldCustomerInfo.Rows[0]["Zip"].ToString();
            phone1TextBox.Text = oldCustomerInfo.Rows[0]["Phone1"].ToString();
            phone1ComboBox.SelectedIndex = phone1ComboBox.FindString(oldCustomerInfo.Rows[0]["Phone1Type"].ToString());
            phone2TextBox.Text = oldCustomerInfo.Rows[0]["Phone2"].ToString();
            phone2ComboBox.SelectedIndex = phone2ComboBox.FindString(oldCustomerInfo.Rows[0]["Phone2Type"].ToString());

            foreach (DataRow x in oldAircraftInfo.Rows)
            {
                AircraftRow r = new AircraftRow(this);
                aircrafts.Add(r);
                r.aircraftNumberTextBox.Text = x["Tail_Number"].ToString();
                r.aircraftTypeTextBox.Text = x["Type"].ToString();
                tailNumberFlowLayoutPanel.Controls.Add(r.aircraftNumberTextBox);
                aircraftTypeFlowLayoutPanel.Controls.Add(r.aircraftTypeTextBox);
                deleteFlowLayoutPanel.Controls.Add(r.aircraftDeleteButton);
            }

            return marginPanel;
        }

    }

    class AddHangarBuilding
    {
        TableLayoutPanel marginPanel;
        FlowLayoutPanel flowLayoutPanel1;
        Label buildingNameLabel;
        TextBox buildingNameTextBox;
        FlowLayoutPanel flowLayoutPanel2;
        Label monthlyCostLabel;
        TextBox monthlyCostTextBox;
        Button addButton;

        public AddHangarBuilding()
        {

            marginPanel = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            buildingNameLabel = new Label();
            monthlyCostLabel = new Label();
            buildingNameTextBox = new TextBox();
            monthlyCostTextBox = new TextBox();
            addButton = new Button();
            addButton.Click += new System.EventHandler(delegate
                {
                    if (buildingNameTextBox.Text != string.Empty && monthlyCostTextBox.Text != string.Empty)
                    {
                        using (SqlCommand com = new SqlCommand("INSERT INTO HangarPrice (Building, Price) Values(@building, @price)", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@building", buildingNameTextBox.Text);
                            com.Parameters.AddWithValue("@price", monthlyCostTextBox.Text);
                            com.ExecuteNonQuery();
                            MessageBox.Show("Price for " + buildingNameTextBox.Text + " was set to $" + monthlyCostTextBox.Text);
                        }
                    }
                });

            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(flowLayoutPanel1, 1, 1);
            marginPanel.Controls.Add(flowLayoutPanel2, 1, 2);
            marginPanel.Controls.Add(addButton, 1, 3);
            marginPanel.Dock = DockStyle.Fill;
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 5;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.Size = new Size(410, 305);
            marginPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buildingNameLabel);
            flowLayoutPanel1.Controls.Add(buildingNameTextBox);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(30, 30);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(380, 30);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(monthlyCostLabel);
            flowLayoutPanel2.Controls.Add(monthlyCostTextBox);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(30, 60);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(380, 30);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // buildingNameLabel
            // 
            buildingNameLabel.Location = new Point(3, 0);
            buildingNameLabel.Name = "buildingNameLabel";
            buildingNameLabel.Size = new Size(80, 23);
            buildingNameLabel.TabIndex = 0;
            buildingNameLabel.Text = "Building Name";
            buildingNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // monthlyCostLabel
            // 
            monthlyCostLabel.Location = new Point(3, 0);
            monthlyCostLabel.Name = "monthlyCostLabel";
            monthlyCostLabel.Size = new Size(80, 23);
            monthlyCostLabel.TabIndex = 1;
            monthlyCostLabel.Text = "Monthly Cost";
            monthlyCostLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buildingNameTextBox
            // 
            buildingNameTextBox.Location = new Point(89, 3);
            buildingNameTextBox.Name = "buildingNameTextBox";
            buildingNameTextBox.Size = new Size(100, 20);
            buildingNameTextBox.TabIndex = 1;
            // 
            // monthlyCostTextBox
            // 
            monthlyCostTextBox.Location = new Point(89, 3);
            monthlyCostTextBox.Name = "monthlyCostTextBox";
            monthlyCostTextBox.Size = new Size(100, 20);
            monthlyCostTextBox.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.Location = new Point(33, 93);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 2;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
        }

        public Control Add()
        {
            return marginPanel;
        }
    }

    class AddHangars
    {
        TableLayoutPanel marginPanel;
        FlowLayoutPanel flowLayoutPanel1;
        Label hangarBuildingLabel;
        ComboBox hangarBuildingComboBox;
        FlowLayoutPanel flowLayoutPanel2;
        Label hangarNumberLabel1;
        TextBox hangarNumberMinTextBox;
        Label hangarNumberLabel2;
        TextBox hangarNumberMaxTextBox;
        Button addButton;

        public AddHangars()
        {
            marginPanel = new TableLayoutPanel();
            hangarBuildingLabel = new Label();
            hangarNumberLabel1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            hangarNumberMinTextBox = new TextBox();
            hangarNumberLabel2 = new Label();
            hangarNumberMaxTextBox = new TextBox();
            addButton = new Button();
            addButton.Click += new System.EventHandler(delegate
                {
                    if (hangarNumberMaxTextBox.Text != string.Empty && hangarNumberMinTextBox.Text != string.Empty)
                    {
                        for (int i = Convert.ToInt32(hangarNumberMinTextBox.Text); i <= Convert.ToInt32(hangarNumberMaxTextBox.Text); i++)
                        {
                            using (SqlCommand com = new SqlCommand("INSERT INTO Hangars (Hangar, Customer_Name) Values(@hangars, @cn)", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@hangars", hangarBuildingComboBox.Text + (i < 10 ? "-0" : "-") + i);
                                com.Parameters.AddWithValue("@cn", "");
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                });
            hangarBuildingComboBox = new ComboBox();

            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(flowLayoutPanel1, 1, 1);
            marginPanel.Controls.Add(flowLayoutPanel2, 1, 2);
            marginPanel.Controls.Add(addButton, 1, 3);
            marginPanel.Dock = DockStyle.Fill;
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 5;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.Size = new Size(410, 305);
            marginPanel.TabIndex = 0;
            // 
            // hangarBuildingLabel
            // 
            hangarBuildingLabel.Location = new Point(3, 0);
            hangarBuildingLabel.Name = "hangarBuildingLabel";
            hangarBuildingLabel.Size = new Size(80, 23);
            hangarBuildingLabel.TabIndex = 0;
            hangarBuildingLabel.Text = "Add to Hangar";
            hangarBuildingLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hangarNumberLabel1
            // 
            hangarNumberLabel1.Location = new Point(3, 0);
            hangarNumberLabel1.Name = "hangarNumberLabel1";
            hangarNumberLabel1.Size = new Size(105, 23);
            hangarNumberLabel1.TabIndex = 1;
            hangarNumberLabel1.Text = "Add Hangar Number";
            hangarNumberLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(hangarBuildingLabel);
            flowLayoutPanel1.Controls.Add(hangarBuildingComboBox);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(30, 30);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(380, 30);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(hangarNumberLabel1);
            flowLayoutPanel2.Controls.Add(hangarNumberMinTextBox);
            flowLayoutPanel2.Controls.Add(hangarNumberLabel2);
            flowLayoutPanel2.Controls.Add(hangarNumberMaxTextBox);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(30, 60);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(380, 30);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // hangarNumberMinTextBox
            // 
            hangarNumberMinTextBox.Location = new Point(114, 3);
            hangarNumberMinTextBox.Name = "hangarNumberMinTextBox";
            hangarNumberMinTextBox.Size = new Size(23, 20);
            hangarNumberMinTextBox.TabIndex = 2;
            // 
            // hangarNumberLabel2
            // 
            hangarNumberLabel2.Location = new Point(143, 0);
            hangarNumberLabel2.Name = "hangarNumberLabel2";
            hangarNumberLabel2.Size = new Size(45, 23);
            hangarNumberLabel2.TabIndex = 3;
            hangarNumberLabel2.Text = "through";
            hangarNumberLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hangarNumberMaxTextBox
            // 
            hangarNumberMaxTextBox.Location = new Point(194, 3);
            hangarNumberMaxTextBox.Name = "hangarNumberMaxTextBox";
            hangarNumberMaxTextBox.Size = new Size(23, 20);
            hangarNumberMaxTextBox.TabIndex = 4;
            // 
            // addButton
            // 
            addButton.Location = new Point(33, 93);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 4;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // hangarBuildingComboBox
            // 
            hangarBuildingComboBox.FormattingEnabled = true;
            hangarBuildingComboBox.Location = new Point(89, 3);
            hangarBuildingComboBox.Name = "hangarBuildingComboBox";
            hangarBuildingComboBox.Size = new Size(121, 21);
            hangarBuildingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            hangarBuildingComboBox.TabIndex = 1;
            hangarBuildingComboBox.Items.AddRange(Util.getHangarBuildings());
        }

        public Control Add()
        {
            return marginPanel;
        }
    }

    class EditHangars
    {
        TableLayoutPanel contentPanel;
        TableLayoutPanel marginPanel;
        FlowLayoutPanel sortLayoutPanel;
        Label sortByLabel;
        Button hangarButton;
        Button nameButton;
        Button updateButton;
        Panel panel1;
        public HangarSlots slots;
        public List<EditHangarRow> rows;

        public EditHangars()
        {
            new EditHangarRow(this);
            slots = new HangarSlots(Util.getHangaredCustomers(), Util.getHangarNames());
            rows = new List<EditHangarRow>();

            marginPanel = new TableLayoutPanel();
            sortLayoutPanel = new FlowLayoutPanel();
            sortByLabel = new Label();
            hangarButton = new Button();
            hangarButton.Click += new System.EventHandler(delegate
                {
                    slots.sort(false);
                    UpdateUI();
                });

            nameButton = new Button();
            nameButton.Click += new System.EventHandler(delegate
                {
                    slots.sort(true);
                    UpdateUI();
                });

            contentPanel = new TableLayoutPanel();
            panel1 = new Panel();
            updateButton = new Button();
            updateButton.Click += new System.EventHandler(delegate
                {
                    slots.sortBy(false);
                    for (int i = 0; i < slots.Length; i++)
                    {
                        string x1 = slots.cNames[i];
                        string y1 = slots.getcNamesSaved()[i];
                        if (String.CompareOrdinal(slots.cNames[i], slots.getcNamesSaved()[i]) != 0)
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Hangars SET Customer_Name = @cname WHERE Hangar = @hname", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@cname", slots.cNames[i]);
                                com.Parameters.AddWithValue("@hname", slots.hNames[i]);
                                com.ExecuteNonQuery();
                            }
                        }

                    }
                    marginPanel.Parent.Controls.Remove(marginPanel);
                });

            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 3;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            marginPanel.Controls.Add(sortLayoutPanel, 1, 1);
            marginPanel.Controls.Add(panel1, 1, 2);
            marginPanel.Dock = DockStyle.Fill;
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 3;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.Size = new Size(410, 305);
            marginPanel.TabIndex = 0;
            // 
            // sortLayoutPanel
            // 
            sortLayoutPanel.Controls.Add(sortByLabel);
            sortLayoutPanel.Controls.Add(hangarButton);
            sortLayoutPanel.Controls.Add(nameButton);
            sortLayoutPanel.Dock = DockStyle.Fill;
            sortLayoutPanel.Location = new Point(30, 30);
            sortLayoutPanel.Margin = new Padding(0);
            sortLayoutPanel.Name = "sortLayoutPanel";
            sortLayoutPanel.Size = new Size(350, 30);
            sortLayoutPanel.TabIndex = 0;
            // 
            // sortByLabel
            // 
            sortByLabel.AutoSize = true;
            sortByLabel.Location = new Point(3, 0);
            sortByLabel.Name = "sortByLabel";
            sortByLabel.Size = new Size(41, 13);
            sortByLabel.TabIndex = 0;
            sortByLabel.Text = "Sort By";
            // 
            // hangarButton
            // 
            hangarButton.FlatAppearance.BorderColor = SystemColors.Control;
            hangarButton.FlatStyle = FlatStyle.Flat;
            hangarButton.Location = new Point(50, 3);
            hangarButton.Name = "hangarButton";
            hangarButton.Size = new Size(61, 27);
            hangarButton.TabIndex = 1;
            hangarButton.Text = "Hangar";
            hangarButton.UseVisualStyleBackColor = true;
            // 
            // nameButton
            // 
            nameButton.FlatAppearance.BorderColor = SystemColors.Control;
            nameButton.FlatStyle = FlatStyle.Flat;
            nameButton.Location = new Point(117, 3);
            nameButton.Name = "nameButton";
            nameButton.Size = new Size(61, 27);
            nameButton.TabIndex = 2;
            nameButton.Text = "Name";
            nameButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            updateButton.Location = new Point(33, 93);
            updateButton.Name = "addButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 4;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(contentPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(410, 305);
            panel1.TabIndex = 0;


            // 
            // contentPanel
            // 
            contentPanel.AutoSize = true;
            contentPanel.ColumnCount = 2;
            contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            int j = 0;
            while (j < slots.Length)
            {
                EditHangarRow r = new EditHangarRow(j, slots.cNames);
                rows.Add(r);
                contentPanel.Controls.Add(r.customerComboBox, 1, j);
                contentPanel.Controls.Add(r.hangarSlotLabel, 0, j);
                j++;
            }
            contentPanel.Controls.Add(updateButton, 0, slots.Length);


            contentPanel.Dock = DockStyle.Top;
            contentPanel.Location = new Point(33, 63);
            contentPanel.Name = "tableLayoutPanel2";
            contentPanel.RowCount = Util.getHangarNames().Length + 1;

            int jj = 0;
            while (jj <= slots.Length)
            {
                contentPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
                jj++;
            }

            contentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentPanel.Size = new Size(344, 250);
            contentPanel.TabIndex = 1;
        }

        public Control Add()
        {
            return marginPanel;
        }

        public void UpdateUI()
        {
            int j = 0;
            while (j < slots.Length)
            {
                rows[j].customerComboBox.SelectedIndex = rows[j].customerComboBox.FindStringExact(slots.cNames[j].ToString());
                rows[j].hangarSlotLabel.Text = slots.hNames[j];
                j++;
            }
        }

        public void updateArray(string s, int i)
        {
            slots.cNames[i] = s;
        }
    }

    class Search
    {
        TableLayoutPanel marginPanel;
        TextBox searchTextBox;
        Panel contentPanel;
        List<SelectRow> buttons;
        TableLayoutPanel contentTable;
        BackgroundWorker backgroundWorker1;

        public Search()
        {
            marginPanel = new TableLayoutPanel();
            searchTextBox = new TextBox();
            contentPanel = new Panel();
            buttons = new List<SelectRow>();
            contentTable = new TableLayoutPanel();
            backgroundWorker1 = new BackgroundWorker();

            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(searchTextBox, 1, 1);
            marginPanel.Controls.Add(contentPanel, 1, 2);
            marginPanel.Dock = DockStyle.Fill;
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 3;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.Size = new Size(410, 305);
            marginPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(33, 33);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(150, 20);
            searchTextBox.TabIndex = 0;
            searchTextBox.WordWrap = false;
            #region searchTextBox.KeyDown +=
            searchTextBox.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        e.SuppressKeyPress = true;
                    }
                });
            #endregion
            #region searchTextBox.KeyUp +=
            searchTextBox.KeyUp += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Tab)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        backgroundWorker1.Dispose();
                        backgroundWorker1 = new BackgroundWorker();
                        backgroundWorker1.DoWork += new DoWorkEventHandler(delegate(object sender2, DoWorkEventArgs e2)
                            {
                                if (String.CompareOrdinal(searchTextBox.Text, "") != 0)
                                {
                                    foreach (SelectRow c in buttons)
                                    {
                                        if (Util.searchButtonVisible(searchTextBox.Text, c.L))
                                        {
                                            c.button.Invoke((MethodInvoker)delegate
                                            {
                                                c.button.Visible = true;
                                            });
                                        }
                                        else
                                        {
                                            c.button.Invoke((MethodInvoker)delegate
                                            {
                                                c.button.Visible = false;
                                            });
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (SelectRow c in buttons)
                                    {
                                        c.button.Invoke((MethodInvoker)delegate
                                        {
                                            c.button.Visible = true;
                                        });
                                    }
                                }
                            });
                        backgroundWorker1.RunWorkerAsync();
                        e.Handled = true;
                    }
                });
            #endregion

            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.Controls.Add(contentTable);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(33, 63);
            contentPanel.Name = "contentPanel";
            contentPanel.AutoSize = true;
            contentPanel.Size = new Size(374, 239);
            contentPanel.TabIndex = 2;

            // 
            // contentTable
            // 

            contentTable.ColumnCount = 1;
            contentTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentTable.AutoSize = true;
            contentTable.Location = new Point(0, 0);
            contentTable.Name = "tableLayoutPanel1";
        }

        public Control Customer()
        {
            string[] customers = Util.getCustomerNames();
            int rowc = customers.Length;

            for (int i = 0; i < rowc; i++)
            {
                #region Getting List to search against & fullname
                List<string> l = new List<string>();
                string fullname = customers[i]; //Morton, Steve
                string[] splited = fullname.Split(new char[] { ',', ' ' });
                l.Add(fullname);
                l.Add(splited[0]); //Morton
                l.Add(splited[2]); //Steve
                l.Add(splited[2] + " " + splited[0]); //Steve Morton
                #endregion

                SelectRow c = new SelectRow(l, fullname, fullname, marginPanel, FormDesigner.designEditCustomer);
                buttons.Add(c);
                contentTable.Controls.Add(c.button, 0, i);
            }
            contentTable.RowCount = rowc;
            for (int i = 0; i < rowc; i++)
            {
                contentTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            contentTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            return marginPanel;
        }

        public Control Invoice()
        {
            DataTable invoices = Util.getInvoices(""); //Todo: date parameter
            string[] invoiceIDs = Util.datatableTOarray(invoices, "InvoiceID");
            int rowc = invoiceIDs.Length;

            for (int i = 0; i < rowc; i++)
            {
                string invoiceid = invoices.Rows[i]["InvoiceID"].ToString();
                string customername = invoices.Rows[i]["Customer_Name"].ToString();
                string date = invoices.Rows[i]["Date"].ToString();
                List<string> l = new List<string>();
                l.Add(invoiceid);
                l.Add(customername);
                l.Add(date);

                string buttontext = invoiceid + ", " + date + " " + customername;

                SelectRow c = new SelectRow(l, buttontext, invoiceid, marginPanel, FormDesigner.designEditInvoice);
                buttons.Add(c);
                contentTable.Controls.Add(c.button, 0, i);
            }

            contentTable.RowCount = rowc;
            for (int i = 0; i < rowc; i++)
            {
                contentTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            contentTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            return marginPanel;
        }


    }

    class CreateInvoice
    {
        #region Globals
        TableLayoutPanel marginPanel;
        FlowLayoutPanel customerflowLayoutPanel;
        Label customerLabel;
        ComboBox customerComboBox;
        Label chargesLabel;
        Label paymentsLabel;
        Button paymentAddButton;
        FlowLayoutPanel chargesMasterPanel;
        FlowLayoutPanel paymentsMasterPanel;
        FlowLayoutPanel paymentsHeaderPanel;
        Label amountLabel;
        Label checkNumberLabel;
        CheckBox dateCheckBox;
        DateTimePicker dateTimePicker1;
        FlowLayoutPanel chargesHeaderPanel;
        Label itemLabel;
        Label priceLabel;
        Label notesLabel;
        Label paymentsNotesLabel;
        FlowLayoutPanel flowLayoutPanel2;
        Label chargesBlankLabel;
        Button chargesAddButton;
        FlowLayoutPanel flowLayoutPanel1;
        Label paymentsBlankLabel;
        Button createInvoiceButton;
        public List<ChargesRow> charges;
        public List<PaymentsRow> payments;
        Label accountBalanceLabel;
        #endregion

        public CreateInvoice()
        {
            new ChargesRow(this);
            new PaymentsRow(this);
            marginPanel = new TableLayoutPanel();
            customerflowLayoutPanel = new FlowLayoutPanel();
            customerLabel = new Label();
            customerComboBox = new ComboBox();
            customerComboBox.Validating += new CancelEventHandler(delegate
                {
                    if (!customerComboBox.Items.Contains(customerComboBox.SelectedText))
                    {
                        customerComboBox.Text = "";
                        accountBalanceLabel.Text = "";
                    }
                    else
                    {
                        setBalance(customerComboBox.SelectedText);
                    }
                });
            chargesLabel = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            chargesBlankLabel = new Label();
            chargesAddButton = new Button();
            chargesAddButton.Click += new EventHandler(delegate
                {
                    ChargesRow r = new ChargesRow();
                    charges.Add(r);
                    chargesMasterPanel.Controls.Add(r.chargesExamplePanel);
                });
            paymentsLabel = new Label();
            dateCheckBox = new CheckBox();
            dateCheckBox.Checked = true;
            dateCheckBox.CheckedChanged += new EventHandler(delegate
                {
                    if (dateCheckBox.Checked == true)
                    {
                        dateTimePicker1.Visible = false;
                    }
                    else
                    {
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker1.Visible = true;
                    }
                });
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.Value = DateTime.Now;
            chargesMasterPanel = new FlowLayoutPanel();
            chargesHeaderPanel = new FlowLayoutPanel();
            itemLabel = new Label();
            priceLabel = new Label();
            notesLabel = new Label();
            paymentsMasterPanel = new FlowLayoutPanel();
            paymentsHeaderPanel = new FlowLayoutPanel();
            amountLabel = new Label();
            checkNumberLabel = new Label();
            paymentsNotesLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            paymentsBlankLabel = new Label();
            paymentAddButton = new Button();
            paymentAddButton.Click += new EventHandler(delegate
                {
                    PaymentsRow r = new PaymentsRow();
                    payments.Add(r);
                    paymentsMasterPanel.Controls.Add(r.paymentsExamplePanel);
                });
            createInvoiceButton = new Button();
            charges = new List<ChargesRow>();
            payments = new List<PaymentsRow>();
            accountBalanceLabel = new Label();


            // 
            // marginPanel
            // 
            marginPanel.ColumnCount = 3;
            marginPanel.AutoSize = true;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 196F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(customerflowLayoutPanel, 1, 1);
            marginPanel.Controls.Add(chargesLabel, 1, 3);
            marginPanel.Controls.Add(accountBalanceLabel, 1, 2);
            marginPanel.Controls.Add(flowLayoutPanel2, 1, 5);
            marginPanel.Controls.Add(paymentsLabel, 1, 7);
            marginPanel.Controls.Add(dateCheckBox, 2, 1);
            marginPanel.Controls.Add(dateTimePicker1, 2, 2);
            marginPanel.Controls.Add(chargesMasterPanel, 1, 4);
            marginPanel.Controls.Add(paymentsMasterPanel, 1, 8);
            marginPanel.Controls.Add(flowLayoutPanel1, 1, 9);
            marginPanel.Controls.Add(createInvoiceButton, 1, 10);
            marginPanel.Location = new Point(21, 12);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 11;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            marginPanel.Size = new Size(469, 329);
            marginPanel.TabIndex = 2;
            // 
            // customerflowLayoutPanel
            // 
            customerflowLayoutPanel.Controls.Add(customerLabel);
            customerflowLayoutPanel.Controls.Add(customerComboBox);
            customerflowLayoutPanel.Dock = DockStyle.Fill;
            customerflowLayoutPanel.Location = new Point(20, 20);
            customerflowLayoutPanel.Margin = new Padding(0);
            customerflowLayoutPanel.Name = "customerflowLayoutPanel";
            customerflowLayoutPanel.Size = new Size(196, 30);
            customerflowLayoutPanel.TabIndex = 0;
            // 
            // customerLabel
            // 
            customerLabel.Location = new Point(3, 0);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(54, 23);
            customerLabel.TabIndex = 0;
            customerLabel.Text = "Customer";
            customerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // customerComboBox
            // 
            customerComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            customerComboBox.FormattingEnabled = true;
            customerComboBox.Items.AddRange(Util.getCustomerNames());
            customerComboBox.Location = new Point(63, 3);
            customerComboBox.Name = "customerComboBox";
            customerComboBox.Size = new Size(121, 21);
            customerComboBox.TabIndex = 1;
            // 
            // chargesLabel
            // 
            chargesLabel.AutoSize = true;
            chargesLabel.Location = new Point(23, 83);
            chargesLabel.Margin = new Padding(3);
            chargesLabel.Name = "chargesLabel";
            chargesLabel.Size = new Size(46, 13);
            chargesLabel.TabIndex = 1;
            chargesLabel.Text = "Charges";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(chargesBlankLabel);
            flowLayoutPanel2.Controls.Add(chargesAddButton);
            flowLayoutPanel2.Location = new Point(20, 141);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(196, 30);
            flowLayoutPanel2.TabIndex = 9;
            // 
            // chargesBlankLabel
            // 
            chargesBlankLabel.Location = new Point(3, 0);
            chargesBlankLabel.Name = "chargesBlankLabel";
            chargesBlankLabel.Size = new Size(80, 23);
            chargesBlankLabel.TabIndex = 0;
            // 
            // chargesAddButton
            // 
            chargesAddButton.AutoSize = true;
            chargesAddButton.Location = new Point(89, 3);
            chargesAddButton.Name = "chargesAddButton";
            chargesAddButton.Size = new Size(80, 23);
            chargesAddButton.TabIndex = 4;
            chargesAddButton.Text = "Add Charges";
            chargesAddButton.UseVisualStyleBackColor = true;
            // 
            // paymentsLabel
            // 
            paymentsLabel.AutoSize = true;
            paymentsLabel.Location = new Point(23, 189);
            paymentsLabel.Margin = new Padding(3);
            paymentsLabel.Name = "paymentsLabel";
            paymentsLabel.Size = new Size(53, 13);
            paymentsLabel.TabIndex = 3;
            paymentsLabel.Text = "Payments";
            // 
            // dateCheckBox
            // 
            dateCheckBox.AutoSize = true;
            dateCheckBox.Location = new Point(219, 23);
            dateCheckBox.Name = "dateCheckBox";
            dateCheckBox.Size = new Size(89, 17);
            dateCheckBox.TabIndex = 6;
            dateCheckBox.Text = "Today\'s Date";
            dateCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(219, 53);
            dateTimePicker1.Name = "dateTimePicker1";
            marginPanel.SetRowSpan(dateTimePicker1, 2);
            dateTimePicker1.Size = new Size(120, 20);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "M/dd/yyyy";
            // 
            // chargesMasterPanel
            // 
            chargesMasterPanel.AutoSize = true;
            marginPanel.SetColumnSpan(chargesMasterPanel, 2);
            chargesMasterPanel.Controls.Add(chargesHeaderPanel);
            chargesMasterPanel.FlowDirection = FlowDirection.TopDown;
            chargesMasterPanel.Location = new Point(20, 99);
            chargesMasterPanel.Margin = new Padding(0);
            chargesMasterPanel.Name = "chargesMasterPanel";
            chargesMasterPanel.Size = new Size(441, 42);
            chargesMasterPanel.TabIndex = 5;
            // 
            // chargesHeaderPanel
            // 
            chargesHeaderPanel.AutoSize = true;
            chargesHeaderPanel.Controls.Add(itemLabel);
            chargesHeaderPanel.Controls.Add(priceLabel);
            chargesHeaderPanel.Controls.Add(notesLabel);
            chargesHeaderPanel.Location = new Point(0, 0);
            chargesHeaderPanel.Margin = new Padding(0);
            chargesHeaderPanel.Name = "chargesHeaderPanel";
            chargesHeaderPanel.Size = new Size(418, 16);
            chargesHeaderPanel.TabIndex = 0;
            chargesHeaderPanel.WrapContents = false;
            // 
            // itemLabel
            // 
            itemLabel.Location = new Point(3, 0);
            itemLabel.Name = "itemLabel";
            itemLabel.Size = new Size(100, 16);
            itemLabel.TabIndex = 0;
            itemLabel.Text = "Item";
            itemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // priceLabel
            // 
            priceLabel.Location = new Point(109, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(100, 16);
            priceLabel.TabIndex = 1;
            priceLabel.Text = "Price";
            priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // notesLabel
            // 
            notesLabel.Location = new Point(215, 0);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new Size(200, 16);
            notesLabel.TabIndex = 2;
            notesLabel.Text = "Notes";
            notesLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // paymentsMasterPanel
            // 
            paymentsMasterPanel.AutoSize = true;
            marginPanel.SetColumnSpan(paymentsMasterPanel, 2);
            paymentsMasterPanel.Controls.Add(paymentsHeaderPanel);
            paymentsMasterPanel.FlowDirection = FlowDirection.TopDown;
            paymentsMasterPanel.Location = new Point(20, 205);
            paymentsMasterPanel.Margin = new Padding(0);
            paymentsMasterPanel.Name = "paymentsMasterPanel";
            paymentsMasterPanel.Size = new Size(441, 42);
            paymentsMasterPanel.TabIndex = 6;
            paymentsMasterPanel.WrapContents = false;
            // 
            // paymentsHeaderPanel
            // 
            paymentsHeaderPanel.AutoSize = true;
            paymentsHeaderPanel.Controls.Add(amountLabel);
            paymentsHeaderPanel.Controls.Add(checkNumberLabel);
            paymentsHeaderPanel.Controls.Add(paymentsNotesLabel);
            paymentsHeaderPanel.Location = new Point(0, 0);
            paymentsHeaderPanel.Margin = new Padding(0);
            paymentsHeaderPanel.Name = "paymentsHeaderPanel";
            paymentsHeaderPanel.Size = new Size(418, 16);
            paymentsHeaderPanel.TabIndex = 0;
            paymentsHeaderPanel.WrapContents = false;
            // 
            // amountLabel
            // 
            amountLabel.Location = new Point(3, 0);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(100, 16);
            amountLabel.TabIndex = 1;
            amountLabel.Text = "Amount";
            amountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkNumberLabel
            // 
            checkNumberLabel.Location = new Point(109, 0);
            checkNumberLabel.Name = "checkNumberLabel";
            checkNumberLabel.Size = new Size(100, 16);
            checkNumberLabel.TabIndex = 2;
            checkNumberLabel.Text = "Check Number";
            checkNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // paymentsNotesLabel
            // 
            paymentsNotesLabel.Location = new Point(215, 0);
            paymentsNotesLabel.Name = "paymentsNotesLabel";
            paymentsNotesLabel.Size = new Size(200, 16);
            paymentsNotesLabel.TabIndex = 3;
            paymentsNotesLabel.Text = "Notes";
            paymentsNotesLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(paymentsBlankLabel);
            flowLayoutPanel1.Controls.Add(paymentAddButton);
            flowLayoutPanel1.Location = new Point(20, 247);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(196, 30);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // paymentsBlankLabel
            // 
            paymentsBlankLabel.Location = new Point(3, 0);
            paymentsBlankLabel.Name = "paymentsBlankLabel";
            paymentsBlankLabel.Size = new Size(80, 23);
            paymentsBlankLabel.TabIndex = 0;
            // 
            // paymentAddButton
            // 
            paymentAddButton.AutoSize = true;
            paymentAddButton.Location = new Point(89, 3);
            paymentAddButton.Name = "paymentAddButton";
            paymentAddButton.Size = new Size(80, 23);
            paymentAddButton.TabIndex = 4;
            paymentAddButton.Text = "Add Payment";
            paymentAddButton.UseVisualStyleBackColor = true;
            // 
            // createInvoiceButton
            // 
            createInvoiceButton.AutoSize = true;
            createInvoiceButton.Location = new Point(23, 280);
            createInvoiceButton.Name = "createInvoiceButton";
            createInvoiceButton.Size = new Size(86, 23);
            createInvoiceButton.TabIndex = 10;
            createInvoiceButton.Text = "Create Invoice";
            createInvoiceButton.UseVisualStyleBackColor = true;
            // 
            // accountBalanceLabel
            // 
            accountBalanceLabel.AutoSize = true;
            accountBalanceLabel.Location = new Point(23, 83);
            accountBalanceLabel.Margin = new Padding(3);
            accountBalanceLabel.Name = "accountBalanceLabel";
            accountBalanceLabel.Size = new Size(46, 13);
            accountBalanceLabel.TabIndex = 1;
        }

        public void setBalance(string s)
        {
            decimal d = Util.getCustomerBalance(s);
            accountBalanceLabel.Text = "Balance: " + d.ToString("0.00", CultureInfo.InvariantCulture);
            if (d >= 0)
            {
                accountBalanceLabel.ForeColor = Color.Green;
            }
            else
            {
                accountBalanceLabel.ForeColor = Color.Red;
            }
        }

        public Control Add()
        {
            dateTimePicker1.Visible = false;

            createInvoiceButton.Click += new EventHandler(delegate
            {
                string invoiceID = Util.getNextInvoiceID();

                string fullname = customerComboBox.Text;
                decimal amount_due = 0m;

                foreach (ChargesRow r in charges)
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO Item (Amount, InvoiceID, Notes, Item) Values(@amount, @invoiceid, @notes, @item)", Form1.connect))
                    {
                        com.Parameters.AddWithValue("@invoiceid", invoiceID);
                        com.Parameters.AddWithValue("@amount", r.chargesEpriceTextBox.Text);
                        com.Parameters.AddWithValue("@notes", r.chargesEnotesTextBox.Text);
                        com.Parameters.AddWithValue("@item", r.chargesEitemTextBox.Text);
                        com.ExecuteNonQuery();
                    }
                    amount_due -= Convert.ToDecimal(r.chargesEpriceTextBox.Text);
                }

                foreach (PaymentsRow r in payments)
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO Payment (InvoiceID, Amount, Check_Number, Notes) Values(@invoiceid, @amount, @checknumber, @notes)", Form1.connect))
                    {
                        com.Parameters.AddWithValue("@invoiceid", invoiceID);
                        com.Parameters.AddWithValue("@amount", r.paymentEamountTextBox.Text);
                        com.Parameters.AddWithValue("@notes", r.paymentsENotesTextBox.Text);
                        com.Parameters.AddWithValue("@checknumber", r.paymentECheckNumberTextBox.Text);
                        com.ExecuteNonQuery();
                    }
                    amount_due += Convert.ToDecimal(r.paymentEamountTextBox.Text);
                }

                using (SqlCommand com = new SqlCommand("INSERT INTO Invoice (InvoiceID, Customer_Name, Date, Amount_Due, Date_Created) Values(@invoiceid, @customern, @date, @amountd, @datecreated)", Form1.connect))
                {
                    com.Parameters.AddWithValue("@invoiceid", invoiceID);
                    com.Parameters.AddWithValue("@customern", fullname);
                    com.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    com.Parameters.AddWithValue("@amountd", amount_due);
                    com.Parameters.AddWithValue("@datecreated", DateTime.Now);
                    com.ExecuteNonQuery();
                }

                Util.updateCustomerBalance(fullname, amount_due);

                marginPanel.Parent.Controls.Remove(marginPanel);
            });

            return marginPanel;
        }

        public Control Edit(string invoiceID)
        {
            DataTable invoiceTable = Util.getInvoice(invoiceID);
            dateTimePicker1.Value = DateTime.Parse(invoiceTable.Rows[0]["Date"].ToString());
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(invoiceTable.Rows[0]["Customer_Name"].ToString());
            setBalance(invoiceTable.Rows[0]["Customer_Name"].ToString());

            DataTable itemsTable = Util.getItems(invoiceID);
            foreach (DataRow r in itemsTable.Rows)
            {
                ChargesRow c = new ChargesRow();
                c.chargesEitemTextBox.Text = r["Item"].ToString();
                decimal price = Convert.ToDecimal(r["Amount"].ToString());
                c.chargesEpriceTextBox.Text = price.ToString("0.00", CultureInfo.InvariantCulture);
                c.chargesEnotesTextBox.Text = r["Notes"].ToString();
                charges.Add(c);
                chargesMasterPanel.Controls.Add(c.chargesExamplePanel);
            }


            DataTable paymentsTable = Util.getPayments(invoiceID);
            foreach (DataRow r in paymentsTable.Rows)
            {
                PaymentsRow p = new PaymentsRow();
                decimal price = Convert.ToDecimal(r["Amount"].ToString());
                p.paymentEamountTextBox.Text = price.ToString("0.00", CultureInfo.InvariantCulture);
                p.paymentECheckNumberTextBox.Text = r["Check_Number"].ToString();
                p.paymentsENotesTextBox.Text = r["Notes"].ToString();
                payments.Add(p);
                paymentsMasterPanel.Controls.Add(p.paymentsExamplePanel);
            }


            dateCheckBox.Visible = false;
            createInvoiceButton.Text = "Update Invoice";
            createInvoiceButton.Click += new EventHandler(delegate
            {
                int oCount = 0;
                int nCount = 0;
                #region update items section
                while (oCount < itemsTable.Rows.Count)
                {
                    DataRow oldRow = itemsTable.Rows[oCount];
                    ChargesRow newRow = charges[nCount];
                    if (string.CompareOrdinal(oldRow["Item"].ToString(), newRow.chargesEitemTextBox.Text) == 0)
                    {
                        if (string.CompareOrdinal(oldRow["Amount"].ToString(), newRow.chargesEpriceTextBox.Text) != 0)
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Item SET Amount = @amount WHERE ItemID = @id", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@id", oldRow["ItemID"].ToString());
                                com.Parameters.AddWithValue("@amount", newRow.chargesEpriceTextBox.Text);
                                com.ExecuteNonQuery();
                            }
                        }
                        if (string.CompareOrdinal(oldRow["Notes"].ToString(), newRow.chargesEnotesTextBox.Text) != 0)
                        {
                            using (SqlCommand com = new SqlCommand("UPDATE Item SET Notes = @notes WHERE ItemID = @id", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@id", oldRow["ItemID"].ToString());
                                com.Parameters.AddWithValue("@notes", newRow.chargesEnotesTextBox.Text);
                                com.ExecuteNonQuery();
                            }
                        }
                        oCount++;
                        nCount++;
                    }
                    else
                    {
                        using (SqlCommand com = new SqlCommand("DELETE FROM Item WHERE ItemID = @id", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@id", oldRow["ItemID"].ToString());
                            com.ExecuteNonQuery();
                        }
                        oCount++;
                    }
                }

                while (nCount < charges.Count)
                {
                    using (SqlCommand com = new SqlCommand("INSERT INTO Item (Amount, InvoiceID, Notes, Item) Values(@amount, @invoiceid, @notes, @item)", Form1.connect))
                    {
                        com.Parameters.AddWithValue("@invoiceid", invoiceID);
                        com.Parameters.AddWithValue("@amount", charges[nCount].chargesEpriceTextBox.Text);
                        com.Parameters.AddWithValue("@notes", charges[nCount].chargesEnotesTextBox.Text);
                        com.Parameters.AddWithValue("@item", charges[nCount].chargesEitemTextBox.Text);
                        com.ExecuteNonQuery();
                    }
                    nCount++;
                }
                #endregion

                oCount = 0;
                nCount = 0;
                #region update payment section
                while (oCount < Math.Min(paymentsTable.Rows.Count, payments.Count))
                {
                    DataRow oldRow = paymentsTable.Rows[oCount];
                    PaymentsRow newRow = payments[nCount];
                    if (string.CompareOrdinal(oldRow["Check_Number"].ToString(), newRow.paymentECheckNumberTextBox.Text) == 0)
                    {
                        using (SqlCommand com = new SqlCommand("UPDATE Payment SET Check_Number = @checkn WHERE PaymentID = @id", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@id", oldRow["PaymentID"].ToString());
                            com.Parameters.AddWithValue("@checkn", newRow.paymentEamountTextBox.Text);
                            com.ExecuteNonQuery();
                        }
                    }
                    if (string.CompareOrdinal(oldRow["Amount"].ToString(), newRow.paymentEamountTextBox.Text) != 0)
                    {
                        using (SqlCommand com = new SqlCommand("UPDATE Payment SET Amount = @amount WHERE PaymentID = @id", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@id", oldRow["PaymentID"].ToString());
                            com.Parameters.AddWithValue("@amount", newRow.paymentEamountTextBox.Text);
                            com.ExecuteNonQuery();
                        }
                    }
                    if (string.CompareOrdinal(oldRow["Notes"].ToString(), newRow.paymentsENotesTextBox.Text) != 0)
                    {
                        using (SqlCommand com = new SqlCommand("UPDATE Payment SET Notes = @notes WHERE PaymentID = @id", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@id", oldRow["PaymentID"].ToString());
                            com.Parameters.AddWithValue("@notes", newRow.paymentsENotesTextBox.Text);
                            com.ExecuteNonQuery();
                        }
                    }

                    oCount++;
                    nCount++;
                }

                if (paymentsTable.Rows.Count < payments.Count)
                {
                    while (nCount < payments.Count)
                    {
                        using (SqlCommand com = new SqlCommand("INSERT INTO Payment (InvoiceID, Amount, Check_Number, Notes) Values(@invoiceid, @amount, @checkn, @notes)", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@invoiceid", invoiceID);
                            com.Parameters.AddWithValue("@amount", payments[nCount].paymentEamountTextBox.Text);
                            com.Parameters.AddWithValue("@notes", payments[nCount].paymentsENotesTextBox.Text);
                            com.Parameters.AddWithValue("@checkn", payments[nCount].paymentECheckNumberTextBox.Text);
                            com.ExecuteNonQuery();
                        }
                        nCount++;
                    }
                }

                if (paymentsTable.Rows.Count > payments.Count)
                {
                    while(nCount < paymentsTable.Rows.Count)
                    {
                        using (SqlCommand com = new SqlCommand("DELETE FROM Payment WHERE PaymentID = @id", Form1.connect))
                        {
                            com.Parameters.AddWithValue("@id", paymentsTable.Rows[oCount]["PaymentID"].ToString());
                            com.ExecuteNonQuery();
                        }
                        oCount++;
                    }
                }
                #endregion

            });

            return marginPanel;
        }

    }

    class EditAircraft
    {
        TableLayoutPanel marginPanel;
        FlowLayoutPanel dataFlowLayoutPanel;
        TextBox aircraftTypeTextBox;
        TextBox heatersTextBox;
        FlowLayoutPanel headerFlowLayoutPanel;
        Label aircraftTypeLabel;
        Label heatersLabel;
        FlowLayoutPanel aircraftFlowLayoutPanel;
        Label aircraftLabel;
        ComboBox aircraftComboBox;
        Button updateButton;
        DataTable oldAircraftInfo;

        public EditAircraft()
        {
            marginPanel = new TableLayoutPanel();
            aircraftFlowLayoutPanel = new FlowLayoutPanel();
            headerFlowLayoutPanel = new FlowLayoutPanel();
            dataFlowLayoutPanel = new FlowLayoutPanel();
            updateButton = new Button();
            updateButton.Click += new EventHandler(delegate
                {
                    string tailnum = aircraftComboBox.Text;
                    BackgroundWorker backgroundWorker1;
                    backgroundWorker1 = new BackgroundWorker();
                    backgroundWorker1.DoWork += new DoWorkEventHandler(delegate(object sender, DoWorkEventArgs e)
                        {
                            if (string.CompareOrdinal(heatersTextBox.Text, oldAircraftInfo.Rows[0]["Heaters"].ToString()) != 0)
                            {
                                using (SqlCommand com = new SqlCommand("UPDATE Aircraft SET Heaters = @heat WHERE Tail_Number = @tailn", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@heat", heatersTextBox.Text);
                                    com.Parameters.AddWithValue("@tailn", tailnum);
                                    com.ExecuteNonQuery();
                                }
                            }

                            if (string.CompareOrdinal(aircraftTypeTextBox.Text, oldAircraftInfo.Rows[0]["Type"].ToString()) != 0)
                            {
                                using (SqlCommand com = new SqlCommand("UPDATE Aircraft SET Type = @type WHERE Tail_Number = @tailn", Form1.connect))
                                {
                                    com.Parameters.AddWithValue("@type", aircraftTypeTextBox.Text);
                                    com.Parameters.AddWithValue("@tailn", tailnum);
                                    com.ExecuteNonQuery();
                                }
                            }
                        });
                    backgroundWorker1.RunWorkerAsync();
                });
            aircraftLabel = new Label();
            aircraftTypeLabel = new Label();
            heatersLabel = new Label();
            aircraftTypeTextBox = new TextBox();
            heatersTextBox = new TextBox();
            aircraftComboBox = new ComboBox();
            aircraftComboBox.Validating += new CancelEventHandler(delegate
                {
                    oldAircraftInfo = Util.getAllAircraftInfoByTailNumber(aircraftComboBox.Text);
                    heatersTextBox.Text = oldAircraftInfo.Rows[0]["Heaters"].ToString();
                    aircraftTypeTextBox.Text = oldAircraftInfo.Rows[0]["Type"].ToString();
                });
            oldAircraftInfo = new DataTable();

            // 
            // tableLayoutPanel1
            // 
            marginPanel.AutoSize = true;
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(dataFlowLayoutPanel, 1, 4);
            marginPanel.Controls.Add(headerFlowLayoutPanel, 1, 3);
            marginPanel.Controls.Add(aircraftFlowLayoutPanel, 1, 1);
            marginPanel.Controls.Add(updateButton, 1, 6);
            marginPanel.Location = new Point(0, 0);
            marginPanel.Name = "tableLayoutPanel1";
            marginPanel.RowCount = 7;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            marginPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            aircraftFlowLayoutPanel.Controls.Add(aircraftLabel);
            aircraftFlowLayoutPanel.Controls.Add(aircraftComboBox);
            aircraftFlowLayoutPanel.Dock = DockStyle.Fill;
            aircraftFlowLayoutPanel.Location = new Point(20, 20);
            aircraftFlowLayoutPanel.Margin = new Padding(0);
            aircraftFlowLayoutPanel.Name = "aircraftFlowLayoutPanel";
            aircraftFlowLayoutPanel.Size = new Size(293, 30);
            aircraftFlowLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            headerFlowLayoutPanel.Controls.Add(aircraftTypeLabel);
            headerFlowLayoutPanel.Controls.Add(heatersLabel);
            headerFlowLayoutPanel.Dock = DockStyle.Fill;
            headerFlowLayoutPanel.Location = new Point(20, 65);
            headerFlowLayoutPanel.Margin = new Padding(0);
            headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            headerFlowLayoutPanel.Size = new Size(293, 30);
            headerFlowLayoutPanel.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            dataFlowLayoutPanel.Controls.Add(aircraftTypeTextBox);
            dataFlowLayoutPanel.Controls.Add(heatersTextBox);
            dataFlowLayoutPanel.Dock = DockStyle.Fill;
            dataFlowLayoutPanel.Location = new Point(20, 95);
            dataFlowLayoutPanel.Margin = new Padding(0);
            dataFlowLayoutPanel.Name = "dataFlowLayoutPanel";
            dataFlowLayoutPanel.Size = new Size(293, 30);
            dataFlowLayoutPanel.TabIndex = 1;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(23, 143);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 2;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            // 
            // aircraftLabel
            // 
            aircraftLabel.Location = new Point(3, 0);
            aircraftLabel.Name = "aircraftLabel";
            aircraftLabel.Size = new Size(44, 23);
            aircraftLabel.TabIndex = 0;
            aircraftLabel.Text = "Aircraft";
            aircraftLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aircraftTypeLabel
            // 
            aircraftTypeLabel.Location = new Point(3, 0);
            aircraftTypeLabel.Name = "aircraftTypeLabel";
            aircraftTypeLabel.Size = new Size(100, 23);
            aircraftTypeLabel.TabIndex = 1;
            aircraftTypeLabel.Text = "Aircraft Type";
            aircraftTypeLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // heatersLabel
            // 
            heatersLabel.Location = new Point(109, 0);
            heatersLabel.Name = "heatersLabel";
            heatersLabel.Size = new Size(100, 23);
            heatersLabel.TabIndex = 2;
            heatersLabel.Text = "Heaters";
            heatersLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // aircraftTypeTextBox
            // 
            aircraftTypeTextBox.Location = new Point(3, 3);
            aircraftTypeTextBox.Name = "aircraftTypeTextBox";
            aircraftTypeTextBox.Size = new Size(100, 20);
            aircraftTypeTextBox.TabIndex = 0;
            // 
            // heatersTextBox
            // 
            heatersTextBox.Location = new Point(109, 3);
            heatersTextBox.Name = "heatersTextBox";
            heatersTextBox.Size = new Size(100, 20);
            heatersTextBox.TabIndex = 1;
            // 
            // aircraftComboBox
            // 
            aircraftComboBox.FormattingEnabled = true;
            aircraftComboBox.Location = new Point(53, 3);
            aircraftComboBox.Name = "aircraftComboBox";
            aircraftComboBox.Size = new Size(121, 21);
            aircraftComboBox.TabIndex = 1;
            aircraftComboBox.Items.AddRange(Util.getAircraftNumbers());
            aircraftComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            aircraftComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public Control Add()
        {
            return marginPanel;
        }
    }

    class CreateMonthlyBill
    {
        TableLayoutPanel marginPanel;
        Label titleLabel;
        ComboBox monthComboBox;
        ComboBox yearComboBox;
        Button createButton;

        public CreateMonthlyBill()
        {
            marginPanel = new TableLayoutPanel();
            titleLabel = new Label();
            monthComboBox = new ComboBox();
            yearComboBox = new ComboBox();
            createButton = new Button();
            createButton.Click += new EventHandler(delegate
                {
                    int counter = 0;
                    DataTable hangarSlots = Util.getAllHangarSlots();
                    foreach (DataRow row in hangarSlots.Rows)
                    {
                        string fullname = row["Customer_Name"].ToString();
                        if (String.CompareOrdinal(fullname, "") != 0)
                        {
                            counter++;
                            decimal amount = Util.getHangarPrice((row["Hangar"].ToString().Split(new char[] { '-' }))[0]);
                            decimal amount_due = 0m - amount;
                            string invoiceID = Util.getNextInvoiceID();

                            using (SqlCommand com = new SqlCommand("INSERT INTO Invoice (InvoiceID, Customer_Name, Date, Amount_Due, Date_Created) Values(@invoiceid, @customern, @date, @amountd, @datecreated)", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@invoiceid", invoiceID);
                                com.Parameters.AddWithValue("@customern", fullname);
                                com.Parameters.AddWithValue("@date", DateTime.Now);
                                com.Parameters.AddWithValue("@amountd", amount_due);
                                com.Parameters.AddWithValue("@datecreated", DateTime.Now);
                                com.ExecuteNonQuery();
                            }

                            using (SqlCommand com = new SqlCommand("INSERT INTO Item (Amount, InvoiceID, Notes, Item) Values(@amount, @invoiceid, @notes, @item)", Form1.connect))
                            {
                                com.Parameters.AddWithValue("@invoiceid", invoiceID);
                                com.Parameters.AddWithValue("@amount", amount);
                                com.Parameters.AddWithValue("@notes", Util.getTailNumberFromName(fullname) + " in " + row["Hangar"].ToString());
                                com.Parameters.AddWithValue("@item", Util.removeFirstTwoDigits(Convert.ToInt32(yearComboBox.SelectedItem.ToString())) + "-" + Util.shortenMonth(monthComboBox.SelectedItem.ToString()));

                                com.ExecuteNonQuery();
                            }

                            Util.updateCustomerBalance(fullname, (amount_due));
                        }
                    }
                    MessageBox.Show(counter + " Invoices created");
                });

            // 
            // marginPanel
            // 
            marginPanel.AutoSize = true;
            marginPanel.ColumnCount = 2;
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            marginPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            marginPanel.Controls.Add(titleLabel, 1, 1);
            marginPanel.Controls.Add(monthComboBox, 1, 2);
            marginPanel.Controls.Add(yearComboBox, 1, 3);
            marginPanel.Controls.Add(createButton, 1, 5);
            marginPanel.Location = new System.Drawing.Point(0, 0);
            marginPanel.Name = "marginPanel";
            marginPanel.RowCount = 6;
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            marginPanel.RowStyles.Add(new RowStyle());
            marginPanel.Size = new System.Drawing.Size(266, 216);
            marginPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(23, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(157, 13);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Generate Bill for All Hangars for:";
            // 
            // monthComboBox
            // 
            monthComboBox.FormattingEnabled = true;
            monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthComboBox.Location = new System.Drawing.Point(23, 36);
            monthComboBox.Name = "monthComboBox";
            monthComboBox.Size = new System.Drawing.Size(121, 21);
            monthComboBox.TabIndex = 0;
            monthComboBox.Items.AddRange(Util.Months);
            monthComboBox.SelectedIndex = monthComboBox.FindStringExact(Util.intToMonth(DateTime.Now.Month));
            // 
            // yearComboBox
            // 
            yearComboBox.FormattingEnabled = true;
            yearComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearComboBox.Location = new System.Drawing.Point(23, 63);
            yearComboBox.Name = "yearComboBox";
            yearComboBox.Size = new System.Drawing.Size(121, 21);
            yearComboBox.TabIndex = 2;
            yearComboBox.Items.AddRange(Util.Years);
            yearComboBox.SelectedIndex = yearComboBox.FindStringExact(DateTime.Now.Year.ToString());
            // 
            // createButton
            // 
            createButton.Location = new System.Drawing.Point(23, 110);
            createButton.Name = "createButton";
            createButton.Size = new System.Drawing.Size(75, 23);
            createButton.TabIndex = 3;
            createButton.Text = "Create Bills";
            createButton.UseVisualStyleBackColor = true;
        }

        public Control Add()
        {
            return marginPanel;
        }
    }
}
