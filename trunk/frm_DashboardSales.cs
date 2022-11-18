using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WNFMaintenance
{
    public partial class frm_DashboardSales : Form
    {
        string ssqlconnectionstring = "server=10.10.0.27;user id = sa; password = wings$2012; database = ErpData; connection reset = false; MultipleActiveResultSets=True";
        SqlConnection sqlconn = new SqlConnection();
        String sZone = "%";
        String sCustomer = "%";
        SqlCommand sqlcmdDesc;
        string StrDesc;
        DataTable dtDesc;
        SqlDataAdapter daDesc;

        public frm_DashboardSales()
        {
            InitializeComponent();
            sqlconn.ConnectionString = ssqlconnectionstring;
            sqlconn.Open();

        }

        private void frm_DashboardSales_Load(object sender, EventArgs e)
        {
            StrDesc = " select 'All'  Zone from cm_Mst_Party union select 'North' Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('N')" + " union select 'East' as Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('E')" +
                " union select 'West' Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('W')" +
                " union select 'South'  Zone from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) in ('S')";
            sqlcmdDesc = new SqlCommand(StrDesc, sqlconn);
            dtDesc = new DataTable();
            daDesc = new SqlDataAdapter(sqlcmdDesc);
            daDesc.Fill(dtDesc);
            cmbZone.DataSource = dtDesc;
            cmbZone.DisplayMember = "Zone";
            cmbZone.ValueMember = "Zone";

            StrDesc = " select CASE WHEN (MONTH(CAST( GETDATE() AS Date))) <= 3 THEN convert(varchar(4), YEAR(CAST( GETDATE() AS Date))-1) + '-' + convert(varchar(4), YEAR(CAST( GETDATE() AS Date))) ELSE convert(varchar(4),YEAR(CAST( GETDATE() AS Date)))+ '-' + convert(varchar(4),(YEAR(CAST( GETDATE() AS Date)))+1)  End dYear " +
                "union select CASE WHEN (MONTH(CAST( GETDATE() AS Date))) <= 3 THEN convert(varchar(4), YEAR(CAST( GETDATE() AS Date))-2) + '-' + convert(varchar(4), YEAR(CAST( GETDATE() AS Date))-1) ELSE convert(varchar(4),YEAR(CAST( GETDATE() AS Date))-1)+ '-' + convert(varchar(4),(YEAR(CAST( GETDATE() AS Date))))  End dYear  " +
                "union select CASE WHEN (MONTH(CAST( GETDATE() AS Date))) <= 3 THEN convert(varchar(4), YEAR(CAST( GETDATE() AS Date))-3) + '-' + convert(varchar(4), YEAR(CAST( GETDATE() AS Date))-2)  ELSE convert(varchar(4),YEAR(CAST( GETDATE() AS Date))-2)+ '-' + convert(varchar(4),(YEAR(CAST( GETDATE() AS Date))-1))  End dYear order by 1 desc" ;
            sqlcmdDesc = new SqlCommand(StrDesc, sqlconn);
            dtDesc = new DataTable();
            daDesc = new SqlDataAdapter(sqlcmdDesc);
            daDesc.Fill(dtDesc);
            cmbFY.DataSource = dtDesc;
            cmbFY.DisplayMember = "dYear";
            cmbFY.ValueMember = "dYear";
            fillChart();

        }

        private void fillCustomer(String sZone)
        {

            StrDesc = " select ' All' as sPartyName from cm_Mst_Party union select distinct sPartyName from cm_Mst_Party where sPartyType = 'Customer' and SUBSTRING(sZoneName,2,1) like ('" + sZone + "')";
            sqlcmdDesc = new SqlCommand(StrDesc, sqlconn);
            dtDesc = new DataTable();
            daDesc = new SqlDataAdapter(sqlcmdDesc);
            daDesc.Fill(dtDesc);
            cmbCustomer.DataSource = dtDesc;
            cmbCustomer.DisplayMember = "sPartyName";
            cmbCustomer.ValueMember = "sPartyName";
        }

        private void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListControl)sender).ValueMember != "") 
            {
                if (cmbZone.Text.ToString().ToUpper() == "All".ToUpper()) { sZone = "%"; }
                else if (cmbZone.Text.ToString().ToUpper() == "North".ToUpper()) { sZone = "N"; }
                else if (cmbZone.Text.ToString().ToUpper() == "South".ToUpper()) { sZone = "S"; }
                else if (cmbZone.Text.ToString().ToUpper() == "East".ToUpper()) { sZone = "E"; }
                else if (cmbZone.Text.ToString().ToUpper() == "West".ToUpper()) { sZone = "W"; }
            }
            fillCustomer(sZone);
            fillChart();

        }

        private void fillChart()
        {
            String str="";
            String legendTitle="";
            String xAisTitle = "";
            String YAisTitle = "";
            Boolean bAutoFit = false;


            if (rBtn20Cust.Checked)
            {
                if (cmbFY.ValueMember != "")
                {
                    str = "select top 20 p.sPartyName  as colX,round(isnull(sum(iInvoiceAmount),0)/100000,2) as colY from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and p.sPartyName like ('" + sCustomer + "') and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> '' and dInvoiceDate between '04/01/" + cmbFY.Text.Substring(0,4) + "' and '03/31/" + cmbFY.Text.Substring(5,4) + "' group by p.sPartyName order by sum(iInvoiceAmount) desc ";
                
                    legendTitle = "Customer wise sales (Domestic)";
                    xAisTitle = "Customer Name";
                    YAisTitle = "Amount (in Lacs.)";
                    bAutoFit = true;
                }
            }
            else if (rBtnPeriod.Checked && rBtnYear.Checked)
            {
                str = "select CASE WHEN(MONTH(dInvoiceDate)) <= 3 THEN convert(varchar(4), YEAR(dInvoiceDate) - 1) +'-' + convert(varchar(4), YEAR(dInvoiceDate))  ELSE convert(varchar(4),YEAR(dInvoiceDate))+'-' + convert(varchar(4), (YEAR(dInvoiceDate)) + 1)  End colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate >= '04/01/2017'  group by CASE WHEN(MONTH(dInvoiceDate)) <= 3 THEN convert(varchar(4), YEAR(dInvoiceDate) - 1) +'-' + convert(varchar(4), YEAR(dInvoiceDate))  ELSE convert(varchar(4),YEAR(dInvoiceDate))+'-' + convert(varchar(4), (YEAR(dInvoiceDate)) + 1)  End  ORDER BY colX";
                
                legendTitle = "Year wise sales (Domestic)";
                xAisTitle = "Financial Year";
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;    
            }
            else if (rBtnPeriod.Checked && rBtnMonth.Checked)
            {
                str = "select DATENAME(MONTH,dInvoiceDate) colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate between '04/01/" + cmbFY.Text.Substring(0,4) + "' and '03/31/" + cmbFY.Text.Substring(5,4) + "' group by  YEAR(dInvoiceDate),MONTH(dInvoiceDate) ,DATENAME(MONTH,dInvoiceDate) ORDER BY YEAR(dInvoiceDate),MONTH(dInvoiceDate)";

                legendTitle = "Month wise sales (Domestic)" ;
                xAisTitle = "Financial Year - " + cmbFY.Text.ToString();
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;
            }
            else if (rBtnPeriod.Checked && rBtnDaily.Checked)
            {
                str = "select DAY(dInvoiceDate) colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate between '04/01/" + cmbFY.Text.Substring(0,4) + "' and '03/31/" + cmbFY.Text.Substring(5,4) + "' and MONTH(dInvoiceDate) =" + DateTime.Now.ToString("MM") + " group by  DAY(dInvoiceDate) ORDER BY DAY(dInvoiceDate)";

                legendTitle = "Day wise sales (Domestic) - " + DateTime.Now.ToString("MMM");
                xAisTitle = "Financial Year - " + cmbFY.Text.ToString() + " Month - " + DateTime.Now.ToString("MMM");
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;
            }
            else if (rBtnCustomer.Checked && rBtnYear.Checked)
            {
                str = "select CASE WHEN(MONTH(dInvoiceDate)) <= 3 THEN convert(varchar(4), YEAR(dInvoiceDate) - 1) +'-' + convert(varchar(4), YEAR(dInvoiceDate))  ELSE convert(varchar(4),YEAR(dInvoiceDate))+'-' + convert(varchar(4), (YEAR(dInvoiceDate)) + 1)  End colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and p.sPartyName like ('" + sCustomer + "') and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate >= '04/01/2017'  group by CASE WHEN(MONTH(dInvoiceDate)) <= 3 THEN convert(varchar(4), YEAR(dInvoiceDate) - 1) +'-' + convert(varchar(4), YEAR(dInvoiceDate))  ELSE convert(varchar(4),YEAR(dInvoiceDate))+'-' + convert(varchar(4), (YEAR(dInvoiceDate)) + 1)  End  ORDER BY colX";

                legendTitle = "Year wise sales (Domestic)" ;
                xAisTitle = "Financial Year for Customer - " + cmbCustomer.Text.ToString();
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;
            }
            else if (rBtnCustomer.Checked && rBtnMonth.Checked)
            {
                str = "select DATENAME(MONTH,dInvoiceDate) colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId  and p.sPartyName like ('" + sCustomer + "') and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate between '04/01/" + cmbFY.Text.Substring(0, 4) + "' and '03/31/" + cmbFY.Text.Substring(5, 4) + "' group by  YEAR(dInvoiceDate),MONTH(dInvoiceDate) ,DATENAME(MONTH,dInvoiceDate) ORDER BY YEAR(dInvoiceDate),MONTH(dInvoiceDate)";

                legendTitle = "Month wise sales (Domestic)";  
                xAisTitle = "Financial Year - " + cmbFY.Text.ToString() + " for Customer - " + cmbCustomer.Text.ToString();;
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;
            }
            else if (rBtnCustomer.Checked && rBtnDaily.Checked)
            {
                str = "select DAY(dInvoiceDate) colX, round(isnull(sum(iInvoiceAmount), 0) / 100000, 2) as colY  from oe_mst_invoice i, cm_mst_party p where i.iPartyId = p.iPartyId   and p.sPartyName like ('" + sCustomer + "') and SUBSTRING(sZoneName,2,1) like ('" + sZone + "') and ISNULL(i.iexport,0)= 0 and p.sPartyName <> ''  and  dInvoiceDate between '04/01/" + cmbFY.Text.Substring(0, 4) + "' and '03/31/" + cmbFY.Text.Substring(5, 4) + "' and MONTH(dInvoiceDate) =" + DateTime.Now.ToString("MM") + " group by  DAY(dInvoiceDate) ORDER BY DAY(dInvoiceDate)";

                legendTitle = "Day wise sales (Domestic) - " + DateTime.Now.ToString("MMM");
                xAisTitle = "Financial Year - " + cmbFY.Text.ToString() + " Month - " + DateTime.Now.ToString("MMM") + " for Customer - " + cmbCustomer.Text.ToString();
                YAisTitle = "Amount (in Lacs.)";
                bAutoFit = true;
            }
            if (cmbFY.ValueMember != "")
            { fillChartPara(str, "colX", "colY", true, Docking.Top, legendTitle, xAisTitle, 60, false, YAisTitle, bAutoFit); }
        }

        private void fillChartPara(String sQuery,String sXValueMamber, String sYValueMamber,Boolean bShowValue,Docking sPosition, String sLegendTitle, String sXAxisTitle, Int32 iXAxisAngle,Boolean bXAxisStaggered,String sYAxisTitle, Boolean bAutoFitX)
        {
            SqlCommand sqlCmdHistory;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            sqlCmdHistory = new SqlCommand(sQuery, sqlconn);

            DataTable dtHistory = new DataTable();
            SqlDataAdapter daHistory = new SqlDataAdapter(sqlCmdHistory);
            daHistory.Fill(dtHistory);
            chart1.DataSource = dtHistory;
            chart1.Series["Sales"].XValueMember = sXValueMamber;
            chart1.Series["Sales"].YValueMembers = sYValueMamber;
            chart1.Series["Sales"].IsValueShownAsLabel = bShowValue;
            chart1.Series["Sales"].IsVisibleInLegend  = true;

            chart1.Legends["Legend1"].Docking = sPosition; 
            chart1.Legends["Legend1"].Title = sLegendTitle;
            chart1.Legends["Legend1"].Alignment = StringAlignment.Center;
            
            chart1.ChartAreas["ChartArea1"].AxisX.Title = sXAxisTitle;
            chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Blue;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = iXAxisAngle;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; //Set the X axis coordinate interval to 1
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalOffset = 1; //Set the X axis coordinate offset to 1
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = bXAxisStaggered;
            chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = bAutoFitX;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = sYAxisTitle;
            chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Blue;
            //chart1.ChartAreas["ChartArea1"].AxisY.IsLabelAutoFit = true;
        }

        private void rBtn20Cust_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void rBtnPeriod_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListControl)sender).ValueMember != "")
            {
                if (cmbCustomer.Text.ToString().ToUpper() == " All".ToUpper()) { sCustomer = "%"; }
                else { sCustomer = cmbCustomer.Text; }
                fillChart();
            }
            
        }

        private void rBtnYear_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void rBtnMonth_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void rBtnDaily_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void cmbFY_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            fillChart();
        }

        private void rBtnCustomer_Click(object sender, EventArgs e)
        {
            fillChart();
        }
    }
}
