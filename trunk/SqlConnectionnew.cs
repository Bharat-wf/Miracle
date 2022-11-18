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


namespace WNFProduction 
{
    public class SqlConnectionnew
    {
        public string SqlConnection11;
        public void conn()
        {
            string ssqlconnectionstring = "server=10.10.0.27;user id = sa; password = wings$2012; database = ErpData; connection reset = false; MultipleActiveResultSets=True";
            SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
           
        }
        public void add()
        { 
        
        }

    }
}
