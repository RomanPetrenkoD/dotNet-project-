using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using edmsNET.Common;
using edmsNET.DataAccess;

namespace edmsNET.CDA
{
	public partial class Register : edmsNET.Common.AuthorizedPage
	{
    
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
            this.ibnRegister.Click += new System.Web.UI.ImageClickEventHandler(this.ibnRegister_Click);
            this.ibnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.ibnCancel_Click);

        }
		#endregion

        private void ibnRegister_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Account account  = new Account(appEnv.GetConnection());

            if (Page.IsValid)
            {
                try
                {
                    if (account.GetAccountID(tbUserName.Text) > 0)
                        lblError.Text = "UserID already in use";
                }
                catch (Exception)
                {
                    try
                    {
                        account.Insert(tbUserName.Text, tbPassword.Text, tbEmail.Text);
                        int AccountID = account.GetAccountID(tbUserName.Text);

                        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
                    }
                    catch (Exception err)
                    {
                        Page_Error("The following error occurred " + err.Message);
                    }

                    Response.Redirect("../Default.aspx");
                }
            }
        }

        private void ibnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.Controls.Add(new LiteralControl("<script language=javascript>" +
                "history.go(-2);" +
                "</script>"));
        }
	}
}
