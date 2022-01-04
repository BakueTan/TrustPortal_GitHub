<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="OfferLetter.aspx.vb" Inherits="TrustAcademyPortal.OfferLetter" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress runat ="server" ID ="offerprogress" AssociatedUpdatePanelID ="pnloffer">
      <ProgressTemplate>
                 <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Updating Offer...    
                               
        </div>
                   </div>
      </ProgressTemplate>
  </asp:UpdateProgress>
    <div>
       <asp:label id ="lbAcccept" runat ="server" forecolor="Red"></asp:label>
    </div>
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt"  WaitMessageFont-Names="Verdana" width="50%"
        WaitMessageFont-Size="14pt" Height="419px" SizeToReportContent="True" ZoomMode="PageWidth" ZoomPercent="75">
        
        <LocalReport ReportPath="Reports\RptAdmissionLetter2 - Backup.rdlc">
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
    <div style ="display:flex;flex-direction:column;flex-wrap:wrap;">
            <asp:UpdatePanel ID ="pnlOffer" runat ="server" >
            <ContentTemplate>
           <div class="appformdiv">
           <asp:Label ID ="lbacceptanceslip" runat ="server" Text ="Upload signed acceptance slip" float ="left" Font-Size="Small" style="color:green" Visible="False"></asp:Label>
            <div>
    <%--<asp:Fileupload ID="fuOfferSlip" runat="server" Visible="False" />--%>
                <ajaxToolkit:AsyncFileUpload ID="fuOfferSlip2" runat="server" visible="false"/>
            </div>
                 
                </div>
    
                <div class="appformdiv">
                         <asp:Button ID="btnAcceptOffer" runat="server" Text="AcceptOffer" CssClass ="btn" OnClientClick ="return confirm('Accept Offer?');" /> 
                </div>
                <div class="appformdiv">
                     <asp:Button ID="btnDeclineOffer" runat="server" Text="DeclineOffer" cssclass="btnCancel"  OnClientClick ="return confirm('Decline Offer?');"/>
                </div>
       
       
  
      <div class="appformdiv">
                </div>


         
           <div class="appformdiv">
                     <asp:Button ID="btnConfirmPopUp" style="display:none" runat ="server" Text="Cancel" />
                     <ajaxtoolkit:modalpopupextender ID="btnConfirmPopUp_ModalPopupExtender" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="btnConfirmPopUp"
                         PopupControlID="ResultPopup"    BackgroundCssClass="modalBackground">
                     </ajaxtoolkit:modalpopupextender>
                </div>
            <asp:Panel runat="server" ID="ResultPopup" Style=" display:none;width:200px;border:solid" CssClass ="modalPopup"  >
       <asp:Label ID ="lblAppSubmitResult" runat ="server" ></asp:Label>
                <br />
       
            <asp:Button runat="server" ID="hideModalPopupViaServer" Text="Ok"
                OnClick="hideModalPopupViaServer_Click" CausesValidation="False" />
      
    </asp:Panel>
                     </ContentTemplate>
      
        
       </asp:UpdatePanel>
      </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    </asp:Content>

