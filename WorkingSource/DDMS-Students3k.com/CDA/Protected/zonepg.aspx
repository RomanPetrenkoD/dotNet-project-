<%@ Reference Control="~/cda/headlineteaser.ascx" %>
<%@ Reference Page="~/cda/zonepg.aspx" %>
<%@ Register TagPrefix="edmsnet" TagName="Login" Src="../Login.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Logout" Src="../Logout.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Header" Src="../Header.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="NavBar" Src="../NavBar.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="HeadlineTeaser" Src="../HeadlineTeaser.ascx" %>
<%@ Page language="c#" Inherits="edmsNET.CDA.Protected.ZonePg" CodeFile="ZonePg.aspx.cs" CodeFileBaseClass="edmsNET.Common.AuthorizedPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>edms.NET -- Zone Page</title>
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
                        <edmsnet:Header id="Header" runat="server" Level="zone"></edmsnet:Header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <BR>
                            <edmsnet:NavBar id="MainNavBar" runat="server"></edmsnet:NavBar>
                        </P>
                        <P>&nbsp;</P>
                        <P>
                            <edmsnet:Login id="ucLogin" runat="server" Visible="False"></edmsnet:Login>
                            <edmsnet:Logout id="ucLogout" runat="server" Visible="False"></edmsnet:Logout>
                        </P>
                        <P>&nbsp;</P>
                    </TD>
                    <TD width="80%" vAlign="top">
                        <H1>
                            <asp:Label id="lbZone" runat="server" ForeColor="DarkSlateGray"></asp:Label>
                        </H1>
                        <edmsnet:HeadlineTeaser id="htLead" runat="server"></edmsnet:HeadlineTeaser>
                        <P>
                            <asp:Table id="tblDomHeadlines" runat="server" CellPadding="8" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell Width="50%" ID="tcLeft"></asp:TableCell>
                                    <asp:TableCell Width="50%" ID="tcRight"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </P>
                    </TD>
                </TR>
                <TR>
                    <TD colSpan="2">
                        <edmsnet:Footer id="Footer1" runat="server"></edmsnet:Footer>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
