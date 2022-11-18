using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace MiracleTallyExportApp
{
    public partial class frm_NCDescription : Form
    {
        string ssqlconnectionstring = "server=10.10.0.27;user id = sa; password = wings$2012; database = ErpData; connection reset = false; MultipleActiveResultSets=True";
        SqlConnection sqlconn = new SqlConnection();
        String sUpdateID = "";
        String sZone = "%";

        public frm_NCDescription()
        {
            InitializeComponent();
            
        }

        private void NCDescription_Load(object sender, EventArgs e)
        {
            SqlCommand sqlcmdNCDesc;
            string StrNCDesc;
            DataTable dtNCDesc;
            SqlDataAdapter daNCDesc;

            sqlconn.ConnectionString = ssqlconnectionstring;
            sqlconn.Open();
            StrNCDesc = "Select * from CM_MST_Department where iActive = 1";
            sqlcmdNCDesc = new SqlCommand(StrNCDesc, sqlconn);
            dtNCDesc=new DataTable();
            daNCDesc= new SqlDataAdapter(sqlcmdNCDesc);
            daNCDesc.Fill(dtNCDesc);
            
            CmbDept.DataSource=dtNCDesc;
            CmbDept.DisplayMember = "sDepartmentName";
            CmbDept.ValueMember = "iDepartmentId";
            
            FillHistory(CmbDept.Text);

            StrNCDesc = "select 'North' Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('N')" +     " union select 'East' as Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('E')" +
                " union select 'West' Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('W')" +
                " union select 'South'  Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('S')" +
                " union select 'All'  Zone from cm_Mst_Party";
            sqlcmdNCDesc = new SqlCommand(StrNCDesc, sqlconn);
            dtNCDesc = new DataTable();
            daNCDesc = new SqlDataAdapter(sqlcmdNCDesc);
            daNCDesc.Fill(dtNCDesc);
            cmbZone.DataSource = dtNCDesc;
            cmbZone.DisplayMember = "Zone";
            cmbZone.ValueMember = "Zone";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            sqlconn.Close();            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            if (CmbDept.Text == "")
            {
                MessageBox.Show("Department Can't be blank");
                return;
            }

            if (TxtNCDescription.Text == "")
            {
                MessageBox.Show("Description Can't be blank");
                return;
            }

            if (Flag == 0)
            {
                if (sUpdateID == "")
                {
                    SqlCommand SqlHdrInsert = new SqlCommand("Insert Into WF_MST_NCDescription (iNCDescID,sNCDesc,iDepartmentID) Values(" + getNCMaxID() + ",'" + TxtNCDescription.Text.Trim()  + "'," + getDepID() + ")", sqlconn);
                    SqlHdrInsert.ExecuteNonQuery();
                }

                if (sUpdateID != "")
                {
                    SqlCommand SqlHdrUpdate = new SqlCommand("Update WF_MST_NCDescription set sNCDesc = '" + TxtNCDescription.Text.Trim() + "' where " +
                        " iDepartmentID = " + getDepID() + " and iNCDescID = " + sUpdateID, sqlconn);
                    SqlHdrUpdate.ExecuteNonQuery();
                    
                }

                InitializeForm();
                //MessageBox.Show("Record Successfully Saved");
                FillHistory(CmbDept.Text);
                TxtNCDescription.Focus();
                sUpdateID = "";
            }
        }
        
        private Int32 getDepID()
        {
            SqlCommand SqlHdrInsert = new SqlCommand("select iDepartmentID as DepId from CM_MST_Department where sDepartmentName ='" + CmbDept.Text + "'" , sqlconn);
            Int32 Depid = Convert.ToInt32(SqlHdrInsert.ExecuteScalar());
            return Depid;
        }
        private Int32 getNCMaxID()
        {
            SqlCommand SqlHdrInsert = new SqlCommand("select isnull(max(iNCDescID),0) + 1 as maxId from WF_MST_NCDescription", sqlconn);
            Int32 Maxid = Convert.ToInt32(SqlHdrInsert.ExecuteScalar());
            return Maxid;
        }

        private void InitializeForm()
        {
            CmbDept.Text = "";
            TxtNCDescription.Text = "";
            DGVNCDescription.Columns.Remove("ID");
            DGVNCDescription.Columns.Remove("NCDescription");
            DGVNCDescription.DataSource = null;
        }
        private void CmbDept_ValueChanged(object sender, EventArgs e)
        {
            FillHistory(CmbDept.Text);
            TxtNCDescription.Text = "";
        }
        public void FillHistory(String NCDept)
        {

            SqlCommand sqlCmdHistory = new SqlCommand("Select iNCDescID id, sNCDesc NCDescription From WF_MST_NCDescription n, CM_MST_Department d Where sDepartmentName = '" + CmbDept.Text + "' and n.iDepartmentID = d.iDepartmentID order by iNCDescID ", sqlconn);
            System.Data.DataTable dtHistory = new System.Data.DataTable();
            SqlDataAdapter daHistory = new SqlDataAdapter(sqlCmdHistory);
            daHistory.Fill(dtHistory);
            
            DGVNCDescription.DataSource=dtHistory;
            DGVNCDescription.AutoGenerateColumns = true;
            DGVNCDescription.Columns["ID"].Width  = 25;
            DGVNCDescription.Columns["NCDescription"].Width = DGVNCDescription.Width - DGVNCDescription.Columns["ID"].Width - 50;

            for (int i = 0; i < DGVNCDescription.Columns.Count; i++)
            {
                DGVNCDescription.Columns[i].ReadOnly = true;
            }

            fillChart();
        }
       
        private void fillChart()
        {
            foreach (var series in chart1.Series) 
            {
                series.Points.Clear();
            }

            //SqlCommand sqlCmdHistory = new SqlCommand("Select sDepartmentName, count(n.iDepartmentId) as cnt From WF_MST_NCDescription n, CM_MST_Department d Where n.iDepartmentID = d.iDepartmentID group by sDepartmentname ", sqlconn);
            SqlCommand sqlCmdHistory = new SqlCommand("select top 20 p.sPartyName,round(isnull(sum(iInvoiceAmount),0)/100000,2) as amt from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId and sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> '' group by p.sPartyName order by sum(iInvoiceAmount) desc  ", sqlconn);

            DataTable dtHistory = new DataTable();
            SqlDataAdapter daHistory = new SqlDataAdapter(sqlCmdHistory);
            daHistory.Fill(dtHistory);
            chart1.DataSource = dtHistory;
            chart1.Series["NCCount"].XValueMember = "sPartyName";
            chart1.Series["NCCount"].YValueMembers = "amt";
            chart1.Series["NCCount"].IsValueShownAsLabel = true;


            chart1.Legends["Legend1"].Docking = Docking.Top;
            chart1.Legends["Legend1"].Title = "Customer wise sales (Domestic)";
            chart1.Legends["Legend1"].Alignment = StringAlignment.Center;
            
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Customer Name";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor  = Color.Blue;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 60;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; //Set the X axis coordinate interval to 1
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalOffset = 1; //Set the X axis coordinate offset to 1
            //chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = true;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Amount (in Lacs.)";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Blue;
        }
        private void DGVMaintenanceHistory_DoubleClick(object sender, EventArgs e)
        {
            TxtNCDescription.Text = DGVNCDescription["NCDescription", DGVNCDescription.CurrentRow.Index].Value.ToString();
            sUpdateID = DGVNCDescription["ID", DGVNCDescription.CurrentRow.Index].Value.ToString();
        }
        
        private void CmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillHistory(CmbDept.Text);
        }

        private void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbZone.Text.ToUpper() == "NORTH"){ sZone = "N";}
            else if (cmbZone.Text.ToUpper() == "SOUTH") { sZone = "S"; }
            else if (cmbZone.Text.ToUpper() == "EAST") { sZone = "E"; }
            else if (cmbZone.Text.ToUpper() == "WEST") { sZone = "W"; }
            else if (cmbZone.Text.ToUpper() == "ALL") { sZone = "%"; }
            fillChart();

        }

    }
}
