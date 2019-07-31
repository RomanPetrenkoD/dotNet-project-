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

namespace edmsNET.Administration.Approve
{
	public partial class AppDiscont : edmsNET.Common.AuthorizedPage
	{

        private MyContent content;
        private int cid = 0;
        private DataTable dt;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            cid = Convert.ToInt32(Request.QueryString["ContentID"]);

            if (cid == 0)
            {
                Page_Error("ContentID Missing");
            }

            content = new MyContent(appEnv.GetConnection());

            dt = content.GetContentForID(cid);
            lbWhichHeadline.Text = dt.Rows[0]["Headline"].ToString();
            lbWhichBody.Text = dt.Rows[0]["Body"].ToString();

            tbEdReason.Text = "ContentID: " + cid + "\nHeadline : " + dt.Rows[0]["Headline"].ToString() + "\n";
            tbAutReason.Text = "ContentID: " + cid + "\nHeadline : " + dt.Rows[0]["Headline"].ToString() + "\n";
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

        protected void bnReturn_Click(object sender, System.EventArgs e)
        {
            int code;
            Account account = new Account(appEnv.GetConnection());

            content.SetApproval(Convert.ToInt32(dt.Rows[0]["ContentID"]),
                Convert.ToInt32(dt.Rows[0]["Version"]),
                account.GetAccountID(User.Identity.Name));
            content.SetStatus(Convert.ToInt32(dt.Rows[0]["ContentID"]),
                Convert.ToInt32(dt.Rows[0]["Version"]),
                (code = StatusCodes.Discontinued));

            EmailAlert ea = new EmailAlert(Context, code, Convert.ToInt32(dt.Rows[0]["Editor"]));
            ea.Body = tbEdReason.Text;
            ea.Send();
			
            ea = new EmailAlert(Context, code, Convert.ToInt32(dt.Rows[0]["ByLine"]));
            ea.Body = tbAutReason.Text;
            ea.Send();
			
            Response.Redirect("AppList.aspx");
        }
	}
}
