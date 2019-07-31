<%@ Page language="c#" Inherits="edmsNET.CDA.HomePg" CodeFile="HomePg.aspx.cs" CodeFileBaseClass="edmsNET.Common.AuthorizedPage" %>
<%@ Register TagPrefix="edmsnet" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="NavBar" Src="NavBar.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Login" Src="Login.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Logout" Src="Logout.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>edms.NET -- Home Page</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    </HEAD>
    <body>
        <form method="post" runat="server">
            <TABLE cellSpacing="8" cellPadding="1" width="100%" border="0">
                <TR>
                    <TD colSpan="2">
                        <edmsnet:Header id="Header" Level="home" runat="server"></edmsnet:Header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <br>
                            <edmsnet:NavBar id="MainNavBar" runat="server"></edmsnet:NavBar>
                        </P>
                        <P>&nbsp;</P>
                        <P>
                        </P>
                        <P>
                            <edmsnet:Login id="ucLogin" runat="server" Visible="False"></edmsnet:Login>
                            <edmsnet:Logout id="ucLogout" runat="server" Visible="False"></edmsnet:Logout></P>
                        <P>&nbsp;</P>
                    </TD>
                    <TD width="80%" vAlign="top">
                        <H1>
                            <FONT color="darkslategray">Welcome to edms.NET!</FONT>
                        </H1>
                        <P>
                            (Add home page stuff here)
                        </P>
                    </TD>
                </TR>
                <TR>
                    <TD colSpan="2">
                        <edmsnet:Footer id="Footer" runat="server"></edmsnet:Footer>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
