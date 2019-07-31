using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using edmsNET.Common;
using edmsNET.DataAccess;

namespace edmsNET.CDA
{
	public partial  class HeadlineTeaser : System.Web.UI.UserControl
	{

        private int m_contentid = 0;
        private int m_version = 0;

        public int ContentID
        {
            get
            {
                return m_contentid;
            }
            set
            {
                m_contentid = value;
            }
        }

        public int Version
        {
            get
            {
                return m_version;
            }
            set
            {
                m_version = value;
            }
        }

        private string buildDirectory (DataRow dr)
        {
            if (Convert.ToInt32(dr["Protected"]) == 0)
                return "";

            return "Protected/";
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                AppEnv appEnv = new AppEnv(Context);
                MyContent content = new MyContent(appEnv.GetConnection());
                AccountProperty property = new AccountProperty(appEnv.GetConnection());

                DataRow dr = content.GetContentForIDVer(m_contentid, m_version);

                if (dr != null)
                {
                    lbHeadline.Text = dr["Headline"].ToString();
                    lbSource.Text = dr["Source"].ToString();
                    lbByline.Text = property.GetValue(Convert.ToInt32(dr["Byline"]), "UserName").Trim();
                    lbTeaser.Text = dr["Teaser"].ToString();
                    hlReadMore.NavigateUrl = buildDirectory(dr) +
                        "StoryPg.aspx?ID=" + m_contentid + "&Ver=" + m_version;
                }
                else
                {
                    lbHeadline.Text = "No Stories";
                    hlReadMore.Visible = false;
                    lbBy.Visible = false;
                    imgPlus.Visible = false;
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

        }
		#endregion
	}
}
