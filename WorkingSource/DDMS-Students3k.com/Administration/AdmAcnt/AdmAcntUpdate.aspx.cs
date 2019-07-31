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

namespace edmsNET.Administration.AdmAcnt
{
	public partial class AdmAcntUpdate : edmsNET.Common.AuthorizedPage
	{
    
        private Account account;
        private AccountProperty property;
        private AccountRoles roles;
        private int aid = 0;
        private DataRow dr;
        
        protected void Page_Load(object sender, System.EventArgs e)
		{
            aid = Convert.ToInt32(Request.QueryString["AccountID"]);

            if (aid == 0)
            {
                Page_Error("AccountID Missing");
            }

            if (aid == 1)
            {
                bnRemove.Visible = false;
            }

            account  = new Account(appEnv.GetConnection());
            property = new AccountProperty(appEnv.GetConnection());
            roles = new AccountRoles(appEnv.GetConnection());

            dr = account.GetAccountForID(aid);

            if (!IsPostBack)
            {
                tbUserID.Text = dr["UserName"].ToString().Trim();
                tbUserName.Text = property.GetValue(aid, "UserName").Trim();
                tbEmail.Text = dr["Email"].ToString().Trim();

                DataTable roledt = roles.GetRolesForID(aid);

                string Cmd = "Select * FROM Roles";
                SqlDataAdapter DAdpt = new SqlDataAdapter(Cmd, appEnv.GetConnection());

                DataSet ds = new DataSet();
                DAdpt.Fill(ds, "Roles");
                
                DataTable allRolesdt = ds.Tables["Roles"];

                foreach (DataRow drr in allRolesdt.Rows)
                {
                    ListItem li = new ListItem(drr["Role"].ToString());

                    foreach (DataRow adr in roledt.Rows)
                    {
                        if (drr["Role"].ToString().Equals(adr["Role"].ToString()))
                            li.Selected = true;
                    }
                    lbRoles.Items.Add(li);
                }
                if (aid == 1)
                {
                    bnRemove.Visible = false;
                    lbRoles.Enabled = false;
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


        private void ProcessUserName() 
        {
            if (tbUserName.Text.Length > 0)
            {
                try
                {
                    property.Insert(aid, "UserName", tbUserName.Text);
                }
                catch (SqlException sqlerr)
                {
                    if (sqlerr.Message.IndexOf("duplicate key") >= 0)
                    {
                        property.Update(aid, "UserName", tbUserName.Text);
                    }
                    else
                        throw sqlerr;
                }
            }
            else
                property.RemoveProperty(aid, "UserName");
        }

        private void ProcessAccountRoles() 
        {
            roles.Remove(aid);

            for (int i = 0; i < lbRoles.Items.Count; i++)
            {
                if (lbRoles.Items[i].Selected)
                {
                    roles.Insert(aid, lbRoles.Items[i].Text);
                }
            }
        }

        protected void bnUpdate_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (tbPassword.Text.Length == 0)
                        account.Update(aid, tbUserID.Text, dr["Password"].ToString(), tbEmail.Text);
                    else
                        account.Update(aid, tbUserID.Text, tbPassword.Text, tbEmail.Text);

                    ProcessUserName();
                    ProcessAccountRoles();
                }
                catch (Exception err)
                {
                    if (err.Message.IndexOf("UNIQUE KEY") >= 0)
                    {
                        lblError.Text = "UserID already exists";
                        return;
                    }
                    else
                        Page_Error("The following error occured: " + err.Message);
                }

                Response.Redirect("AdmAcntList.aspx");
            }
        }

        protected void bnRemove_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("AdmAcntRemove.aspx?AccountID=" + aid);
        }
	}
}
