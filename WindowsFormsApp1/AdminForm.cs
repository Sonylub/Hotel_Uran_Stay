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

        private void uSERSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.uSERSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotel_Urban_StayDataSet);

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.GUESTSERVICES". При необходимости она может быть перемещена или удалена.
            this.gUESTSERVICESTableAdapter.Fill(this.hotel_Urban_StayDataSet.GUESTSERVICES);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.SERVICES". При необходимости она может быть перемещена или удалена.
            this.sERVICESTableAdapter.Fill(this.hotel_Urban_StayDataSet.SERVICES);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.REVIEWS". При необходимости она может быть перемещена или удалена.
            this.rEVIEWSTableAdapter.Fill(this.hotel_Urban_StayDataSet.REVIEWS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.GUESTS". При необходимости она может быть перемещена или удалена.
            this.gUESTSTableAdapter.Fill(this.hotel_Urban_StayDataSet.GUESTS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.IMAGES". При необходимости она может быть перемещена или удалена.
            this.iMAGESTableAdapter.Fill(this.hotel_Urban_StayDataSet.IMAGES);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.ROOMS". При необходимости она может быть перемещена или удалена.
            this.rOOMSTableAdapter.Fill(this.hotel_Urban_StayDataSet.ROOMS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Urban_StayDataSet.USERS". При необходимости она может быть перемещена или удалена.
            this.uSERSTableAdapter.Fill(this.hotel_Urban_StayDataSet.USERS);

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void gUESTSERVICESDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
