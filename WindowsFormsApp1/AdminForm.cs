using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox with table names
            tableSelectorComboBox.Items.AddRange(new object[] {
                "Пользователи",
                "Номера",
                "Картинки",
                "Гости",
                "Отзывы",
                "Услуги",
                "Гостевые услуги"
            });
            tableSelectorComboBox.SelectedIndex = 0; // Default to first table

            // Load data into tables
            this.uSERSTableAdapter.Fill(this.hotel_Urban_StayDataSet.USERS);
            this.rOOMSTableAdapter.Fill(this.hotel_Urban_StayDataSet.ROOMS);
            this.iMAGESTableAdapter.Fill(this.hotel_Urban_StayDataSet.IMAGES);
            this.gUESTSTableAdapter.Fill(this.hotel_Urban_StayDataSet.GUESTS);
            this.rEVIEWSTableAdapter.Fill(this.hotel_Urban_StayDataSet.REVIEWS);
            this.sERVICESTableAdapter.Fill(this.hotel_Urban_StayDataSet.SERVICES);
            this.gUESTSERVICESTableAdapter.Fill(this.hotel_Urban_StayDataSet.GUESTSERVICES);

            // Show only the first DataGridView initially
            UpdateDataGridViewVisibility();
        }

        private void tableSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewVisibility();
        }

        private void UpdateDataGridViewVisibility()
        {
            // Hide all DataGridViews
            uSERSDataGridView.Visible = false;
            rOOMSDataGridView.Visible = false;
            iMAGESDataGridView.Visible = false;
            gUESTSDataGridView.Visible = false;
            rEVIEWSDataGridView.Visible = false;
            sERVICESDataGridView.Visible = false;
            gUESTSERVICESDataGridView.Visible = false;

            // Show the selected DataGridView
            switch (tableSelectorComboBox.SelectedIndex)
            {
                case 0:
                    uSERSDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = uSERSBindingSource;
                    break;
                case 1:
                    rOOMSDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = rOOMSBindingSource;
                    break;
                case 2:
                    iMAGESDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = iMAGESBindingSource;
                    break;
                case 3:
                    gUESTSDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = gUESTSBindingSource;
                    break;
                case 4:
                    rEVIEWSDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = rEVIEWSBindingSource;
                    break;
                case 5:
                    sERVICESDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = sERVICESBindingSource;
                    break;
                case 6:
                    gUESTSERVICESDataGridView.Visible = true;
                    uSERSBindingNavigator.BindingSource = gUESTSERVICESBindingSource;
                    break;
            }
        }




        private void uSERSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.uSERSBindingSource.EndEdit();
            this.rOOMSBindingSource.EndEdit();
            this.iMAGESBindingSource.EndEdit();
            this.gUESTSBindingSource.EndEdit();
            this.rEVIEWSBindingSource.EndEdit();
            this.sERVICESBindingSource.EndEdit();
            this.gUESTSERVICESBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotel_Urban_StayDataSet);
        }

        private void gUESTSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gUESTSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotel_Urban_StayDataSet);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}