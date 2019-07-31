using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using edmsNET.Common;
using edmsNET.DataAccess;

namespace edmsNET.Administration.AdmAcnt
{
	/// <summary>
	/// Summary description for admAcntRemove.
	/// </summary>
	public partial class admAcntRemove : edmsNET.Common.AuthorizedPage
	{
    
        private Account account;
        private AccountProperty property;
        private int aid = 0;
        private DataRow dr;
        
        protected void Page_Load(object sender, System.EventArgs e)
		{
            aid = Convert.ToInt32(Request.QueryString["AccountID"]);

            if (aid == 0)
            {
                Page_Error("AccountID Missing");
            }

            account  = new Account(appEnv.GetConnection());
            property = new AccountProperty(appEnv.GetConnection());

            dr = account.GetAccountForID(aid);

            lbUserID.Text = dr["UserName"].ToString();
            lbUserName.Text = property.GetValue(Convert.ToInt32(dr["AccountID"]), "UserName");
            lbEmail.Text = dr["Email"].ToString();
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

        }
		#endregion

        protected void bnRemove_Click(object sender, System.EventArgs e)
        {
            int id = Convert.ToInt32(dr["AccountID"]);

            AccountRoles roles = new AccountRoles(appEnv.GetConnection());
            roles.Remove(id);
            property.Remove(id);
            account.Remove(id);
            
            Response.Redirect("AdmAcntList.aspx");
        }
	}
}
