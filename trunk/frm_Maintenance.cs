using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WNFProduction
{
    public partial class frm_Maintenance : Form
    {
        string ssqlconnectionstring = "server=10.10.0.27;user id = sa; password = wings$2012; database = ErpData; connection reset = false; MultipleActiveResultSets=True";
        SqlConnection sqlconn = new SqlConnection();
        
        public frm_Maintenance()
        {
            InitializeComponent();
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            sqlconn.ConnectionString = ssqlconnectionstring;
            sqlconn.Open();
            string StrShift = "Select * from PR_MST_Shift";
            SqlCommand sqlcmdShift = new SqlCommand(StrShift, sqlconn);
            System.Data.DataTable dtShift=new System.Data.DataTable();
            SqlDataAdapter daShift= new SqlDataAdapter(sqlcmdShift);
            daShift.Fill(dtShift);
            CmbShift.DataSource=dtShift;
            CmbShift.DisplayMember = "sShiftDesc";
            CmbShift.ValueMember = "iShiftId";
            //InitialiseEmpDetail();
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();

            SqlCommand sqlcmdEmp = new SqlCommand("Select sEmployeeName +'-' + sEmployeeCode Employee From CM_MST_Employee Where sDepartmentName = 'maintenance'  And dDOL is Null", sqlconn);
            System.Data.DataTable dtEmp = new System.Data.DataTable();
            SqlDataAdapter daEmp = new SqlDataAdapter(sqlcmdEmp);
            daEmp.Fill(dtEmp);
            dataGridViewComboBoxColumn.HeaderText = "Employee";
            dataGridViewComboBoxColumn.Name = "Employee";
            dataGridViewComboBoxColumn.DataSource = dtEmp;
            dataGridViewComboBoxColumn.DisplayMember = "Employee";
            dataGridViewComboBoxColumn.ValueMember = "Employee";
            dataGridViewComboBoxColumn.Width = 180;

            dataGridViewCheckBoxColumn.HeaderText = "Delete";
            dataGridViewCheckBoxColumn.Name = "Delete";
            dataGridViewCheckBoxColumn.Width = 50;

            DGVEmpDetail.Columns.Add(dataGridViewComboBoxColumn);
            DGVEmpDetail.Columns.Add("Hrs", "Hrs");
            DGVEmpDetail.Columns.Add(dataGridViewCheckBoxColumn);
            DGVEmpDetail.Columns["Hrs"].Width = 50;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            sqlconn.Close();            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            if (CmbShift.Text == "")
            {
                MessageBox.Show("Shift Can't be blank");
                return;
            }
            if (DGVEmpDetail.Rows.Count == 1)
            {
                MessageBox.Show("Employee Detail can't be blank");
                Flag = 1;
                return;
            }
            foreach (DataGridViewRow dr in DGVEmpDetail.Rows)
            {
                if (dr.Cells["Employee"].Value != null && Convert.ToBoolean(dr.Cells["Delete"].Value) == false)
                {
                    if (dr.Cells["Hrs"].Value != null && dr.Cells["Hrs"].Value.ToString() != "")
                    {
                        if (Convert.ToInt16(dr.Cells["Hrs"].Value) == 0)
                        {
                            MessageBox.Show("Hrs Can't be 0");
                            Flag = 1;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hrs Can't be 0");
                        Flag = 1;
                        break;
                    }
                }
            }
            if (Flag == 0)
            {
                SqlCommand SqlHdrDelete = new SqlCommand("Delete From WF_MST_MAINTENANCE Where MdDate='" + DtpDate.Value.Date + "' And sShift='" + CmbShift.Text + "'", sqlconn);
                SqlHdrDelete.ExecuteNonQuery();

                SqlCommand SqlHdrInsert = new SqlCommand("Insert Into WF_MST_MAINTENANCE (MdDate,sShift,sShiftIC,sTypeofmaintance,sMachineType) Values('" + DtpDate.Value.Date + "','" + CmbShift.Text + "','" + TxtShiftIncharge.Text + "','" + CmbMaintType.Text + "','" + CmbMcType.Text + "')", sqlconn);
                SqlHdrInsert.ExecuteNonQuery();

                SqlCommand SqlDtlDelete = new SqlCommand("Delete From WF_DET_MaintanceEmpHrs Where MdDate='" + DtpDate.Value.Date + "' And sShift='" + CmbShift.Text + "'", sqlconn);
                SqlDtlDelete.ExecuteNonQuery();

                foreach (DataGridViewRow dr in DGVEmpDetail.Rows)
                {
                    string EmpName = "", EmpCode = "";
                    if (dr.Cells["Hrs"].Value != null && Convert.ToBoolean(dr.Cells["Delete"].Value) == false)
                    {
                        EmpName = dr.Cells["Employee"].Value.ToString().Substring(0, dr.Cells["Employee"].Value.ToString().IndexOf("-") );
                        EmpCode = dr.Cells["Employee"].Value.ToString().Substring(dr.Cells["Employee"].Value.ToString().IndexOf("-") + 1);

                        SqlCommand SqlDtlInsert = new SqlCommand("Insert Into WF_DET_MaintanceEmpHrs (MdDate,sShift,sShiftIC,sTypeofmaintance,sMachineType,sEmpName,sEmpCode,sEmpHrs) Values('" + DtpDate.Value.Date + "','" + CmbShift.Text + "','" + TxtShiftIncharge.Text + "','" + CmbMaintType.Text + "','" + CmbMcType.Text + "','" + EmpName + "','" + EmpCode + "','" + dr.Cells["Hrs"].Value.ToString() + "')", sqlconn);
                        SqlDtlInsert.ExecuteNonQuery();
                    }
                }
                InitializeForm();
                MessageBox.Show("Record Successfully Saved");
                FillHistory(DtpDate.Value.Date, CmbShift.Text);
            }
        }
        private void InitializeForm()
        {
            CmbShift.Text = "";
            CmbMaintType.Text = "";
            CmbMcType.Text = "";
            TxtShiftIncharge.Text = "";
            DGVEmpDetail.Columns.Remove("Hrs");
            DGVEmpDetail.Columns.Remove("Employee");
            DGVEmpDetail.Columns.Remove("Delete");
            DGVEmpDetail.DataSource = null;
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();

            SqlCommand sqlcmdEmp = new SqlCommand("Select sEmployeeName +'-' + sEmployeeCode Employee From CM_MST_Employee Where sDepartmentName = 'maintenance' And dDOL is Null", sqlconn);
            System.Data.DataTable dtEmp = new System.Data.DataTable();
            SqlDataAdapter daEmp = new SqlDataAdapter(sqlcmdEmp);
            daEmp.Fill(dtEmp);
            dataGridViewComboBoxColumn.HeaderText = "Employee";
            dataGridViewComboBoxColumn.Name = "Employee";
            dataGridViewComboBoxColumn.DataSource = dtEmp;
            dataGridViewComboBoxColumn.DisplayMember = "Employee";
            dataGridViewComboBoxColumn.ValueMember = "Employee";
            dataGridViewComboBoxColumn.Width = 180;

            dataGridViewCheckBoxColumn.HeaderText = "Delete";
            dataGridViewCheckBoxColumn.Name = "Delete";
            dataGridViewCheckBoxColumn.Width = 50;

            DGVEmpDetail.Columns.Add(dataGridViewComboBoxColumn);
            DGVEmpDetail.Columns.Add("Hrs", "Hrs");
            DGVEmpDetail.Columns.Add(dataGridViewCheckBoxColumn);
            DGVEmpDetail.Columns["Hrs"].Width = 50;

        }
        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            FillHistory(DtpDate.Value.Date, CmbShift.Text);
            SqlCommand sqlCmsShiftIC = new SqlCommand("SELECT sShiftICName FROM WF_MST_ALLOCATION Where sShiftDesc='" + CmbShift.Text + "' And sDate='" + DtpDate.Value.Date + "'", sqlconn);
            string str = (string)sqlCmsShiftIC.ExecuteScalar();

            if (str != null)
            {
                TxtShiftIncharge.Text = sqlCmsShiftIC.ExecuteScalar().ToString();
            }
            else
            {
                TxtShiftIncharge.Text = "";

            }
        }
        public void FillHistory(DateTime ShiftDate, String Shift)
        {
            
            SqlCommand sqlCmdHistory = new SqlCommand("SELECT Distinct MdDate [Date],sShift Shift,sShiftiC [Shift Inc.],sTypeofMaintance [Type of Maintenance],sMachineType [Machine Type]  FROM WF_MST_MAINTENANCE Where sShift='" + Shift + "' And MdDate='" + ShiftDate + "'"  , sqlconn);
            System.Data.DataTable dtHistory = new System.Data.DataTable();
            SqlDataAdapter daHistory = new SqlDataAdapter(sqlCmdHistory);
            daHistory.Fill(dtHistory);
            DGVMaintenanceHistory.DataSource=dtHistory;
            DGVMaintenanceHistory.AutoGenerateColumns = true;
            DGVMaintenanceHistory.Columns["Date"].Width = 70;
            DGVMaintenanceHistory.Columns["Shift"].Width = 30;
            DGVMaintenanceHistory.Columns["Shift Inc."].Width = 150;
            DGVMaintenanceHistory.Columns["Type of Maintenance"].Width = 132;
            DGVMaintenanceHistory.Columns["Machine Type"].Width = 100;
        }

        private void CmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillHistory(DtpDate.Value.Date, CmbShift.Text);
            if (CmbShift.Text != "System.Data.DataRowView")
            {
               SqlCommand sqlCmsShiftIC = new SqlCommand("SELECT sShiftICName FROM WF_MST_ALLOCATION Where sShiftDesc='" + CmbShift.Text + "' And sDate='" + DtpDate.Value.Date  + "'", sqlconn);
               string str=(string)sqlCmsShiftIC.ExecuteScalar();

                if (str !=null)
                {
                    TxtShiftIncharge.Text = sqlCmsShiftIC.ExecuteScalar().ToString();
                }
                else
                {
                    TxtShiftIncharge.Text = "";

                }
            }            
        }
               
        private void DGVMaintenanceHistory_DoubleClick(object sender, EventArgs e)
        {
            CmbMaintType.Text = DGVMaintenanceHistory["Type of Maintenance", DGVMaintenanceHistory.CurrentRow.Index].Value.ToString();
            CmbMcType.Text = DGVMaintenanceHistory["Machine Type", DGVMaintenanceHistory.CurrentRow.Index].Value.ToString();
            TxtShiftIncharge.Text = DGVMaintenanceHistory["Shift Inc.", DGVMaintenanceHistory.CurrentRow.Index].Value.ToString();
            CmbShift.Text = DGVMaintenanceHistory["Shift", DGVMaintenanceHistory.CurrentRow.Index].Value.ToString();
            FillGrid(DtpDate.Value.Date, CmbShift.Text);         
        }
        private void FillGrid(DateTime ShiftDate,string Shift)
        {
            DGVEmpDetail.Columns.Remove("Hrs");
            DGVEmpDetail.Columns.Remove("Employee");
            DGVEmpDetail.Columns.Remove("Delete");
            SqlCommand sqlCmdEmp = new SqlCommand("SELECT sEmpName +'-' + sEmpCode Employee,sEmphrs Hrs  FROM WF_DET_MaintanceEmpHrs Where sShift='" + Shift + "' And MdDate='" + ShiftDate + "'", sqlconn);
            System.Data.DataTable dtEmp = new System.Data.DataTable();
            SqlDataAdapter daEmp = new SqlDataAdapter(sqlCmdEmp);
            daEmp.Fill(dtEmp);

            SqlCommand sqlcmdEmpNew = new SqlCommand("Select sEmployeeName +'-' + sEmployeeCode Employee From CM_MST_Employee Where sDepartmentName = 'maintenance' And dDOL is Null", sqlconn);
            System.Data.DataTable dtEmpNew = new System.Data.DataTable();
            SqlDataAdapter daEmpNew= new SqlDataAdapter(sqlcmdEmpNew);
            daEmpNew.Fill(dtEmpNew);
           
            DGVEmpDetail.DataSource = dtEmp;

            DGVEmpDetail.Columns.Remove("Employee");
            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            DataGridViewCheckBoxColumn CheckCol = new DataGridViewCheckBoxColumn();

            cmbCol.HeaderText = "Employee";
            cmbCol.Name = "Employee";

            CheckCol.HeaderText = "Delete";
            CheckCol.Name = "Delete";

            cmbCol.Items.Add(true);
            cmbCol.ValueMember = "Employee";
            cmbCol.DisplayMember = "Employee";
            cmbCol.DataPropertyName = "Employee";
            cmbCol.DataSource = dtEmpNew;
            DGVEmpDetail.Columns.Add(cmbCol);
            DGVEmpDetail.Columns.Add(CheckCol);
            DGVEmpDetail.Columns["Employee"].DisplayIndex = 0;
            cmbCol.Width = 180;
            CheckCol.Width = 50;
            DGVEmpDetail.Columns["Hrs"].Width = 50;
        }

        private void DGVEmpDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
