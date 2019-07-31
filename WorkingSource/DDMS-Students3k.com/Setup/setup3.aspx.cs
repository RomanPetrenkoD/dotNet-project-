using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using edmsNET.Common;
using edmsNET.DataAccess;

namespace edmsNET.Setup
{
	public partial class setup3 : System.Web.UI.Page
	{
    
        Account         account;
        AccountProperty property;
        AccountRoles    role;


        private void ProcessAdministratorName() 
        {
            if (txtAdministratorName.Text.Length > 0)
            {
                try
                {
                    property.Insert(1, "UserName", txtAdministratorName.Text);
                }
                catch (SqlException sqlerr)
                {
                    if (sqlerr.Message.IndexOf("duplicate key") >= 0)
                    {
                        property.Update(1, "UserName", txtAdministratorName.Text);
                    }
                    else
                        throw sqlerr;
                }
            }
        }

        private void ProcessAccountRoles() 
        {
            try
            {
                role.Insert(1, "Administrator");
            }
            catch (SqlException)
            {
                // Duplicate key means jobs done already... move on.
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
		{
            if (IsPostBack)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        if (!account.Exist(1))
                        {
                            account.Insert(txtUserName.Text, txtPassword.Text, txtEmail.Text);
                        }
                        else
                        {
                            account.Update(1, txtUserName.Text, txtPassword.Text, txtEmail.Text);
                        }
                        ProcessAdministratorName();
                        ProcessAccountRoles();

                        Response.Redirect("setup4.aspx");
                    }
                    catch (Exception err)
                    {
                        lblError.Text = "Sorry, the following error occured: " + err.Message;
                    }
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
        
            SqlConnection connection = new AppEnv(Context).GetConnection();
            account  = new Account(connection);
            property = new AccountProperty(connection);
            role     = new AccountRoles(connection);
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
