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

namespace edmsNET.CDA.Protected
{
	public partial class StoryPg : edmsNET.Common.AuthorizedPage
	{
        
        protected void Page_Load(object sender, System.EventArgs e)
		{
            int curId  = Convert.ToInt32(Request.QueryString["ID"]);
            int curVer = Convert.ToInt32(Request.QueryString["Ver"]);

            if (!Request.IsAuthenticated)
                ucLogin.Visible = true;
            else
                ucLogout.Visible = true;

            MyContent content = new MyContent(appEnv.GetConnection());
            AccountProperty property = new AccountProperty(appEnv.GetConnection());

            DataRow dr = content.GetContentForIDVer(curId, curVer);
            
            if (dr != null)
            {
                lbHeadline.Text = dr["Headline"].ToString();
                lbSource.Text = dr["Source"].ToString();
                lbByline.Text = property.GetValue(Convert.ToInt32(dr["Byline"]), "UserName").Trim();
                lbDate.Text = dr["ModifiedDate"].ToString();
                lbTeaser.Text = dr["Teaser"].ToString();
                lbBody.Text = dr["Body"].ToString();
                lbTagline.Text = dr["Tagline"].ToString();
            }
            else
            {
                lbHeadline.Text = "No Stories";
                lbBy.Visible = false;
                lbDashes.Visible = false;
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
