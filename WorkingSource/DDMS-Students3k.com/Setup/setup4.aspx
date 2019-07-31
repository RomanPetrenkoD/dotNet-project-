<%@ Page language="c#" Inherits="edmsNET.Setup.setup4" CodeFile="setup4.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>setup4</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form method="post" runat="server">
            <p><IMG src="Images/setup.jpg"></p>
            <hr width="100%" size="1">
            <p><b>Setup Complete!</b>
                
                    edms.NET setup is now complete. Click the button below to jump to the 
                    Administation Site where you'll be able to create and administer your web site.
               
                
                    <asp:Button id="btnLogin" runat="server" Text="Login to edms.NET Administation" onclick="btnLogin_Click"></asp:Button></p>
                <br/>
                <hr size="0"/>
                
                    <asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="http://www.contentmgr.com" Font-Size="XX-Small">www.contentmgr.com</asp:hyperlink>
                
        </form>
    </body>
</HTML>
