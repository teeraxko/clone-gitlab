using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Facade.ContractFacade;
using Facade.VehicleFacade;
using Entity.VehicleEntities;
using Facade.TempFacade;

namespace Presentation.TempGUI
{
    public partial class FrmTest01 : Form
    {
        private Test01Facade facade;

        public FrmTest01()
        {
            try
            {
                InitializeComponent();
                facade = new Test01Facade();

                for (int i = 0; i < facade.DataSourceKindOfVehicle.Count; i++)
			    {
                    Column1.Items.Add(facade.DataSourceKindOfVehicle[i].ToString());
			    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //this.Column2.DataSource = facadeVehicle.DataSourceKindOfVehicle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KindOfVehicle obj = facade.ObjKindOfVehicleList[dataGridView1[0, 0].Value.ToString()];
            textBox1.Text = obj.Code + obj.EntityKey;
        }

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                object obj = dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            object obj = dataGridView1[0, 0].Value;
            dataGridView1[0, dataGridView1.CurrentRow.Index].Value = obj;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount++;
        }
    }
}