<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ClientWeb.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get User" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add User" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get All Users" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Panel ID="Panel3" runat="server">
            <asp:GridView ID="GridView2" runat="server" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CellPadding="10" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </asp:Panel>
        
        <asp:Panel ID="Panel1" runat="server">
            <div>
            <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td>
                    <b>ID</b>
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Gender</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Date Of Birth</b>
                </td>
                <td>
                    <asp:TextBox ID="txtDateOfBirth" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>User Type</b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" 
                        OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Text="Select User Type" Value="-1">
                        </asp:ListItem>
                        <asp:ListItem Text="Student" Value="1">
                        </asp:ListItem>
                        <asp:ListItem Text="Teacher" Value="2">
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trStd" runat="server" visible="false">
                <td>
                    <b>Standard</b>
                </td>
                <td>
                    <asp:TextBox ID="txtStd" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr id="trSub" runat="server" visible="false">
                <td>
                    <b>Subject</b>
                </td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnSave" runat="server" 
                    Text="Save User" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" 
                        ForeColor="Green" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
        </table>
        </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td class="auto-style2">
                    <b>Enter ID</b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b>Name</b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b>Gender</b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Date Of Birth</b>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>User Type</b>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false" >
                <td>
                    <b>Standard</b>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="tr2" runat="server" visible="false">
                <td>
                    <b>Subject</b>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete User" Width="81px" />
                    &nbsp; </td>
                <td class="auto-style1">
                    &nbsp;<asp:Button ID="GetUser" runat="server" 
                    Text="Get User" OnClick="btnGetUser_Click" Width="88px" style="height: 26px" />
                    &nbsp;
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Update" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" 
                        ForeColor="Green" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
        </table>
            <br />
            <br />
            <br />
        </asp:Panel>
</asp:Content>
