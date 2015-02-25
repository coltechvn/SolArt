<%@ Import Namespace="System.IO.Path" %>
<%@ Import Namespace="System.IO" %>
<%@ Register TagPrefix="cc1" Namespace="ChrisDengler.WebUI.Components" Assembly="WebMsgBox" %>
<%@ Page Trace="False" Inherits="AWS.FilePicker.FileManager" CodeBehind="FilePicker.aspx.vb" Language="vb" AutoEventWireup="false" %>

<HTML>
  <HEAD>
		<TITLE> <%=rm.GetString("LOC_LABEL_SELECTAFILE")%>
		</TITLE>
		<META http-equiv="Content-Type" content="text/html">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="menu.js"></script>
</HEAD>
	<body>
		<form id="formExplorer" encType="multipart/form-data" runat="server">
			<table class="background" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<tr>
					<td width="100%" align="center" colspan="15">
						<table cellpadding="0" cellspacing="7" border="0">
							<tr>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnRoot" onclick="NavigateHome" runat="server" imageurl="Images/Root.gif" height="24"
										width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnNavigateUp" onclick="NavigateUp" runat="server" imageurl="Images/Up.gif"
										height="24" width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnCopy" onclick="Copy" runat="server" imageurl="Images/Copy.gif"
										height="24" width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnCut" onclick="Cut" runat="server" imageurl="Images/Cut.gif" height="24" width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnPaste" onclick="Paste" runat="server" imageurl="Images/Paste.gif" height="24"
										width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnNewFolder" onclick="NewFolder" runat="server" imageurl="Images/NewFolder.gif"
										height="24" width="24"></asp:imagebutton></td>
								<td class=buttonOff onmouseover="changeBg(this,'buttonOn')" 
								onclick="javascript: return confirm('<%=deleteConfirmation %>');" 
								onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnDelete" onclick="Delete" runat="server" imageurl="Images/Delete.gif" height="24"
										width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnRefresh" onclick="Refresh" runat="server" imageurl="Images/Refresh.gif" height="24"
										width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnReserverCheck" onclick="ReverseCheck" runat="server" imageurl="Images/ReverseCheck.gif"
										height="24" width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnToggleThumbnails" onclick="ToggleThumbnails" runat="server" imageurl="Images/ThumbNail.gif"
										height="24" width="24"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnUpload" onclick="ShowUpload" runat="server" imageurl="Images/Upload.gif"
										height="24" width="24"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="15"><cc1:webmsgbox id="wmbMessage" runat="server" Enabled="False" MsgBoxIcon="vbExclamation"></cc1:webmsgbox>
						<div id="ProgressBarPanel" style="DISPLAY: none">
							<table align="center">
								<tr>
									<td><span class="languageSelector"><b><%=rm.GetString("LOC_LABEL_PLEASEWAIT")%>
											</b>
										</span><IMG id="ProgressBar" height="13" src="Images/Progress.gif" width="240" border="0">
									</td>
								</tr>
							</table>
						</div>
						<asp:panel id="PanelUpload" runat="server" visible="false" CssClass="Panel">
      <TABLE align=center>
        <TR align=center>
          <TD height=30><INPUT class=textBox id=inputFileName type=file 
            name=inputFileName runat="server"> </TD>
          <TD height=30><A 
            href="javascript:ShowProgressBar('uploadfileLink')"><IMG height=24 
            alt='<%=rm.GetString("LOC_LABEL_UPLOADUPLOADFILE")%>' 
            src="Images/Save.gif" width=24 border=0> </A>
<asp:LinkButton id=uploadfileLink onclick=uploadFile runat="server" EnableViewState="False" Visible="true"></asp:LinkButton></TD></TR>
        <TR align=center>
          <TD colSpan=2>
            <FIELDSET class=fieldset><LEGEND><B><%=rm.GetString("LOC_LABEL_UPLOAD_IFZIPUPLOADED")%></B></LEGEND>
<asp:RadioButtonList id=rblUploadOptions runat="server" cssclass="radiolist" RepeatColumns="3">
												<asp:ListItem />
												<asp:ListItem />
												<asp:ListItem selected="true" />
											</asp:RadioButtonList></FIELDSET> 
      </TD></TR></TABLE>
						</asp:panel></td>
				</tr>
				<asp:placeholder id="phLanguageSelector" Runat="server">
  <TR>
    <TD class=languageSelector align=right colSpan=15 height=17><A class=link 
      onclick="document.cookie ='UserLanguage=en';document.location.href=document.location.href;return true;" 
      href="#">English</A>&nbsp;–&nbsp;<A class=link 
      onclick="document.cookie ='UserLanguage=es';document.location.href=document.location.href;return true;" 
      href="#">Spanish</A>&nbsp;–&nbsp;<A class=link 
      onclick="document.cookie ='UserLanguage=ru';document.location.href=document.location.href;return true;" 
      href="#">Russian</A></TD></TR>
				</asp:placeholder>
				<tr>
					<td colSpan="15"><asp:textbox id="txtCurrentPath" runat="server" CssClass="pathTextBox" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="15"><span class="info"><asp:label id=Info runat="server" cssClass="text" Text='<b><%=rm.GetString("LOC_LABEL_INFO")%> </b>'></asp:label>
						</span></td>
				</tr>
				<tr align="right">
					<td colSpan="14"></td>
					<td align="right"><A href="#Bottom"><IMG height=5 alt='<%=rm.GetString("LOC_LABEL_BOTTOM")%>' src="Images/Bottom.gif" width=9 border=0 align=bottom></A></td>
				</tr>
				<tr>
					<td colSpan="15"><asp:datagrid id="dgExplorer" Runat="server" cssClass="fileFolderGrid" AutoGenerateColumns="False"
							BorderColor="#0053A5" AllowSorting="True" DataKeyField="Id" OnSortCommand="Sort" OnEditCommand="Edit"
							OnCancelCommand="Cancel" OnUpdateCommand="Update" OnItemCreated="Created" GridLines="Horizontal" Width="100%"
							CellPadding="2">
							<ItemStyle BackColor="#FFFFFF"></ItemStyle>
							<AlternatingItemStyle BackColor="#CFDFE5"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
									<HeaderStyle CssClass="fileFolderGridHeader" Width="5%"></HeaderStyle>
									<ItemTemplate>
										<a name='<%# Container.DataItem("Id") %>'>
											<asp:CheckBox Id="chkSelected" Checked='<%# Container.DataItem("Chk") %>' runat='Server'/>
										</a>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:CheckBox Id="chkSelected" Checked='<%# Container.DataItem("Chk") %>' runat='server'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Name">
									<HeaderStyle Width="35%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<nobr>
											<asp:ImageButton runat="server" ImageAlign="Middle" ImageUrl = '<%# GetFileDirPicture(Container.DataItem("Type"), Container.DataItem("Name"))%>' OnCommand='NavigateDown' ID="Icon" AlternateText='<%# Container.DataItem("Name") %>' CommandName='<%# Container.DataItem("Type") %>'>
											</asp:ImageButton>
											<asp:LinkButton Id="Name" CssClass="link" Text='<%# Container.DataItem("Name") %>' CommandName='<%# Container.DataItem("Type") %>' OnCommand='NavigateDown' runat='server'/>
										</nobr>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Id="Name" CssClass='newNameTextBox' Text='<%# Container.DataItem("Name") %>' runat='server'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Length">
									<HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:Label Id="Length" Text='<%# Container.DataItem("Length") %>' runat='server' CssClass='<%# DirectoryAlign(Container.DataItem("Type")) %>'/>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:Label Id="Length" Text='<%# Container.DataItem("Length") %>' runat='server' CssClass='<%# DirectoryAlign(Container.DataItem("Type")) %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Updated">
									<HeaderStyle Width="20%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:Label Runat="server" Text='&nbsp;<%# Container.DataItem("Updated") %>&nbsp;' ID="Updated"/>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:Label Runat="server" Text='&nbsp;<%# Container.DataItem("Updated") %>&nbsp;' ID="Label2"/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:ImageButton CommandName="Edit" runat="server" imageurl="Images/Rename.gif" width="24" height="16" 
 id="btnRename" EnableViewState="False" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:ImageButton CommandName="Update" runat="server" imageurl="Images/Ok.gif" id="btnRenameOk" EnableViewState="False" />
										<asp:ImageButton CommandName="Cancel" runat="server" imageurl="Images/Cancel.gif" id="btnRenameCancel" 
 EnableViewState="False" />
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr align="right">
					<td colSpan="14"></td>
					<td align="right"><A href="#Top"><IMG height=5 alt='<%=rm.GetString("LOC_LABEL_TOP")%>' src="Images/Top.gif" width=9 border=0 ></A></td>
				</tr>
			</table>
			<a name="#Bottom"></a>
		</form>
	</body>
</HTML>
