<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ClientWeb.pages.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="AllStudents" runat="server" Text="Get All Students" OnClick="AllStudents_Click" Width="128px" />
&nbsp;&nbsp;&nbsp;<asp:Button ID="AddStudent" runat="server" OnClick="AddStudent_Click" Text="Add Student" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Update Student" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="301px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
&nbsp;&nbsp;<br />
        <br />
        <asp:Panel ID="Panel4" runat="server">
            <table style="font-family: Arial; border: 1px solid black;">
                <tr>
                    <td class="auto-style2"><b>Enter ID</b> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Name</b> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Gender</b> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Date Of Birth</b> </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server">
                    </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Standard</b> </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server">
                    </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="GetUser" runat="server" OnClick="GetUser_Click" Text="Get Student" />
                    </td>
                    <td class="auto-style1">&nbsp;&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Update" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="DeleteStudent" runat="server" OnClick="DeleteStudent_Click" Text="Delete Student" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <table style="font-family: Arial; border: 1px solid black;">
                <tr>
                    <td class="auto-style2"><b>Enter ID</b> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Id" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height: 22px"><b>Name</b> </td>
                    <td class="auto-style2" style="height: 22px">
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Gender</b> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Gender" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Date Of Birth</b> </td>
                    <td>
                        <asp:TextBox ID="DOB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Standard</b> </td>
                    <td>
                        <asp:TextBox ID="Std" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Save" runat="server" OnClick="Button4_Click" Text="Save Student" Width="81px" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
