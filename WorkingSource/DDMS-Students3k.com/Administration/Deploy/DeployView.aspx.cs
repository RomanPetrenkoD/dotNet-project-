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

namespace edmsNET.Administration.Deploy
{
	public partial class DeployView : edmsNET.Common.AuthorizedPage
	{
    
        protected DataRow dr;
        
        protected void Page_Load(object sender, System.EventArgs e)
		{
            int cid = Convert.ToInt32(Request.QueryString["ID"]);
            int ver = Convert.ToInt32(Request.QueryString["Ver"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }
            if (ver == 0)
            {
                Page_Error("Version Missing");
            }
            dr = new MyContent(appEnv.GetConnection()).GetContentForIDVer(cid, ver);

            if (!IsPostBack)
            {
                AccountProperty property = new AccountProperty(appEnv.GetConnection());

                lbContentID.Text = dr["ContentID"].ToString();
                lbVersion.Text   = dr["Version"].ToString();
                lbHeadline.Text  = dr["Headline"].ToString();
                lbSource.Text    = dr["Source"].ToString() + "&nbsp;";
                lbByline.Text    = property.GetValue(Convert.ToInt32(dr["Byline"]), 
                    "UserName").Trim();
                lbTeaser.Text    = dr["Teaser"].ToString() + "&nbsp;";
                lbBody.Text      = dr["Body"].ToString();
                lbTagline.Text   = dr["Tagline"].ToString() + "&nbsp;";
                lbStatus.Text    = dr["Status"].ToString();
                lbUpdateUser.Text  = property.GetValue(Convert.ToInt32(dr["UpdateUserID"]), 
                    "UserName").Trim();
                lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
                lbCreationDate.Text  = dr["CreationDate"].ToString();
            }
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
	}
}
