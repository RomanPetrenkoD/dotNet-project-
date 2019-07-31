<%@ Reference Control="~/cda/protected/zonecard.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Footer" Src="../Footer.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Logout" Src="../Logout.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Login" Src="../Login.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="NavBar" Src="../NavBar.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Header" Src="../Header.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="ZoneCard" Src="ZoneCard.ascx" %>
<%@ Page language="c#" Inherits="edmsNET.CDA.Protected.myHomePg" CodeFile="myHomePg.aspx.cs" CodeFileBaseClass="edmsNET.Common.AuthorizedPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>myHomePg</title>
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
                        <edmsnet:Header id="Header" runat="server" Level="myHome"></edmsnet:Header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <BR>
                            <edmsnet:NavBar id="MainNavBar" runat="server"></edmsnet:NavBar>
                        </P>
                        <edmsnet:Logout id="ucLogout" runat="server"></edmsnet:Logout>
                        <P>
                        </P>
                    </TD>
                    <TD vAlign="top" width="80%">
                        <TABLE cellSpacing="2" cellPadding="5" width="100%" border="0">
                            <TR>
                                <TD width="50%">
                                    <TABLE cellSpacing="5" cellPadding="3" width="100%" border="0">
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard1" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard2" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard3" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                    </TABLE>
                                </TD>
                                <TD width="50%">
                                    <TABLE cellSpacing="5" cellPadding="3" width="100%" border="0">
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard4" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard5" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                        <TR>
                                            <TD>
                                                <edmsnet:ZoneCard id="ZoneCard6" runat="server"></edmsnet:ZoneCard>
                                            </TD>
                                        </TR>
                                    </TABLE>
                                </TD>
                            </TR>
                        </TABLE>
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
