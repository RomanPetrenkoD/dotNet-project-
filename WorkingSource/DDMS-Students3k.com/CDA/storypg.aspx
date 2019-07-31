<%@ Register TagPrefix="edmsnet" TagName="HeadlineTeaser" Src="HeadlineTeaser.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Login" Src="Login.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Logout" Src="Logout.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="NavBar" Src="NavBar.ascx" %>
<%@ Register TagPrefix="edmsnet" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Inherits="edmsNET.CDA.StoryPg" CodeFile="StoryPg.aspx.cs" CodeFileBaseClass="edmsNET.Common.AuthorizedPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>edms.NET -- Story Page</title>
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
                        <edmsnet:header id="Header" style="LEFT: 1px; TOP: 2px" runat="server" Level="story"></edmsnet:header>
                    </TD>
                </TR>
                <TR>
                    <TD vAlign="top" width="20%" bgColor="#8cd3ef">
                        <P>
                            <BR>
                            <edmsnet:navbar id="MainNavBar" runat="server"></edmsnet:navbar>
                        </P>
                        <P>&nbsp;</P>
                        <P>
                            <edmsnet:Login id="ucLogin" runat="server" Visible="False"></edmsnet:Login>
                            <edmsnet:Logout id="ucLogout" runat="server" Visible="False"></edmsnet:Logout>
                        </P>
                        <P>&nbsp;</P>
                    </TD>
                    </FONT>
                    <TD width="80%" valign="top">
                        <FONT color="darkslategray">
                            <P>
                                <asp:label id="lbHeadline" runat="server" Font-Size="Large"></asp:label>
                            </P>
                            <P>
                                <STRONG>
                                    <asp:Label id="lbSource" runat="server"></asp:Label>
                                </STRONG>
                            </P>
                            <P>
                        </FONT>
                        <asp:label id="lbBy" runat="server" Font-Size="Smaller">by</asp:label>
                        &nbsp;<asp:label id="lbByline" runat="server" Font-Size="Smaller"></asp:label>&nbsp;<asp:label id="lbDashes" runat="server" Font-Size="Smaller">--</asp:label>&nbsp;<asp:label id="lbDate" runat="server" Font-Size="Smaller"></asp:label>
                        </P>
                        <P>
                            <asp:label id="lbTeaser" runat="server"></asp:label>
                        </P>
                        <P>
                            <asp:label id="lbBody" runat="server"></asp:label>
                        </P>
                        <EM><FONT size="2">
                                <P>
                                    <asp:label id="lbTagline" runat="server"></asp:label>
                                </P>
                            </FONT></EM>
                    </TD>
                </TR>
                <TR>
                    <TD colSpan="2">
                        <edmsnet:footer id="Footer" runat="server"></edmsnet:footer>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
