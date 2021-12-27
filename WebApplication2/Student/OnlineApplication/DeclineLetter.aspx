<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="DeclineLetter.aspx.vb" Inherits="TrustAcademyPortal.DeclineLetter" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div>
    </div>
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt"  WaitMessageFont-Names="Verdana" width="41%"
        WaitMessageFont-Size="14pt" ShowRefreshButton="False" ShowWaitControlCancelLink="False" Height="419px" SizeToReportContent="True">
        
        <LocalReport ReportPath="Reports\RptDeclineLetter.rdlc">
            <DataSources>
                
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="OfferLetter">
                </rsweb:ReportDataSource>
                
            </DataSources>
            
        </LocalReport>
        
    </rsweb:ReportViewer>
    </div><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetData" 
        TypeName="TrustAcademyPortal.dsStudAppTableAdapters.StudentApplicationTableAdapter" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_AppReference" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="AppReference" SessionField="Reference" 
                Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="DateSubmitted" Type="DateTime" />
            <asp:Parameter Name="Program" Type="String" />
            <asp:Parameter Name="Intake" Type="String" />
            <asp:Parameter Name="_Class" Type="Int32" />
            <asp:Parameter Name="Session" Type="String" />
            <asp:Parameter Name="AppStatus" Type="String" />
            <asp:Parameter Name="comment" Type="String" />
            <asp:Parameter Name="gender" Type="String" />
            <asp:Parameter Name="dob" Type="DateTime" />
            <asp:Parameter Name="Address1" Type="String" />
            <asp:Parameter Name="Address2" Type="String" />
            <asp:Parameter Name="Address3" Type="String" />
            <asp:Parameter Name="Contact" Type="String" />
            <asp:Parameter Name="School" Type="String" />
            <asp:Parameter Name="Occupation" Type="String" />
            <asp:Parameter Name="WorkPhone" Type="String" />
            <asp:Parameter Name="workAddress" Type="String" />
            <asp:Parameter Name="updatedby" Type="String" />
            <asp:Parameter Name="dateupdated" Type="DateTime" />
            <asp:Parameter Name="Original_AppReference" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <div style ="display:flex;flex-direction:row;flex-wrap:wrap;">
        <div class="appformdiv">
                </div>
                <div class="appformdiv">
                </div>
       
    </div>
      <div class="appformdiv">
                </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    </asp:Content>

