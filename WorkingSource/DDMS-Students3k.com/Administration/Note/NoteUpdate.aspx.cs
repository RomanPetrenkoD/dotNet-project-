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

namespace edmsNET.Administration.Note
{
	/// <summary>
	/// Summary description for NoteUpdate.
	/// </summary>
	public partial class NoteUpdate : edmsNET.Common.AuthorizedPage
	{
    
        private string origin;
        private int nid = 0;
    
        private void BuildOrigPage()
        {
            AccountProperty property = new AccountProperty(appEnv.GetConnection());

            DataRow dr = new ContentNotes(appEnv.GetConnection()).GetNote(nid);

            lbContentID.Text = dr["ContentID"].ToString();
            tbNote.Text   = dr["Note"].ToString();
            lbAuthor.Text = property.GetValue(Convert.ToInt32(dr["Author"]), 
                "UserName").Trim();
            lbModifiedDate.Text  = dr["ModifiedDate"].ToString();
            lbCreationDate.Text  = dr["CreationDate"].ToString();
        }

        protected void Page_Load(object sender, System.EventArgs e)
		{
            nid = Convert.ToInt32(Request.QueryString["NoteID"]);
            origin = Request.QueryString["Origin"];

            if (nid == 0)
            {
                Page_Error("NoteID Missing");
            }

            if (!IsPostBack)
            {
                lbWho.Text = origin;
                BuildOrigPage();
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

        protected void bnUpdate_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ContentNotes note = new ContentNotes(appEnv.GetConnection());
                    note.Update(nid, tbNote.Text);
                }
                catch (Exception err)
                {
                    Page_Error("The following error occured: " + err.Message);
                }

                Response.Redirect("NoteList.aspx?ContentID=" + lbContentID.Text + "&origin=" + origin);
            }
        }

        protected void bnRestore_Click(object sender, System.EventArgs e)
        {
            BuildOrigPage();
        }

        protected void bnRemove_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("NoteRemove.aspx?NoteID=" + nid + "&Origin=" + origin);
        }
	}
}
