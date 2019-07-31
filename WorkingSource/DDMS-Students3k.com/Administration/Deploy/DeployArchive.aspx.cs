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
	public partial class DeployArchive : edmsNET.Common.AuthorizedPage
	{

        private MyContent content;
        private int cid = 0;
        private int ver = 0;
        private DataRow dr;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ID"]);
            ver = Convert.ToInt32(Request.QueryString["Ver"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }

            if (ver == 0)
            {
                Page_Error("Version Missing");
            }

            content = new MyContent(appEnv.GetConnection());

            dr = content.GetContentForIDVer(cid, ver);
            lbWhichHeadline.Text = dr["Headline"].ToString();
            lbWhichBody.Text = dr["Body"].ToString();
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

        protected void bnArchive_Click(object sender, System.EventArgs e)
        {
//          content.SetStatus(cid, ver, StatusCodes.Archived);
            content.SetStatus(cid, ver, StatusCodes.Approved);

            new Distribution(appEnv.GetConnection()).Remove(cid, ver);
            Response.Redirect("DeployList.aspx");
        }
	}
}
