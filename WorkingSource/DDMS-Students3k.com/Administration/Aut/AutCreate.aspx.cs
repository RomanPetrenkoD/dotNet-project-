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

using edmsNET.DataAccess;
using edmsNET.Common;

namespace edmsNET.Administration.AUT
{
	/// <summary>
	/// Summary description for AutCreate.
	/// </summary>
	public partial class AutCreate : edmsNET.Common.AuthorizedPage
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (IsPostBack)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        MyContent content = new MyContent(appEnv.GetConnection());
                        Account account = new Account(appEnv.GetConnection());
                        content.Insert(tbHeadline.Text, tbSource.Text, account.GetAccountID(User.Identity.Name), 
                            tbTeaser.Text, tbBody.Text, tbTagline.Text);
                    }
                    catch (Exception err)
                    {
                        Page_Error("The following error occured: " + err.Message);
                    }

                    Response.Redirect("AutList.aspx");
                }
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
