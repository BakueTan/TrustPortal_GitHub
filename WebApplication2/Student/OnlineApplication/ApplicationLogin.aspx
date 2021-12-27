<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="ApplicationLogin.aspx.vb" Inherits="TrustAcademyPortal.ApplicationLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="divMain">


  <div class ="Inputdiv">
      <div style="display:inline-flex;width:100%" >
           <asp:TextBox ID="TextBox1" runat="server" CssClass="inputtextLogin" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="E-mail Required"></asp:RequiredFieldValidator>
      </div>
        
  </div>
             
        <div class="Inputdiv">
             <div width:100%>
                   
          <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/RecoverPasswordOnlineApplication.aspx"  ForeColor="Red" style="float:right;font-size:xx-small;">Forgot Password?</asp:HyperLink>
      </div> 

 <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="inputtextLogin" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
          
        </div>
            
               
      <div class="Inputdiv">
               <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass ="LoginButton1"/>
      </div>

     
      
        <div class="Inputdiv">
            
       <div>
Don&#39;t have an Account? <asp:HyperLink ID ="lbCreateAccount" Text ="Create Account" runat ="server" NavigateUrl="~/Student/OnlineApplication/ApplcationSignUp.aspx"></asp:HyperLink>
       </div> 

        </div>
           
    
    <div class="Inputdiv">
  <asp:Label ID="errorstatus" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>

    </div>
      
       
            <div style="font-style:italic;color:red;font-size:large;text-decoration:underline;"><h3>IMPORTANT INFORMATION</h3></div>
         <ul>
            <li>
                <div style="font-style:normal;color:red;font-size:large">Students should receive emails from "admissions@trustacademy.ac.zw" after each stage of the application process.</div>
            </li>
             <li>
                    <div  style="font-style:normal;color:red;font-size:large ">These emails will contain instructions on the proceeding stages of the application.</div>
             </li>
             <li>
                  <div  style="font-style:normal;color:red;font-size:large">Delays from student to act upon these instructions might result in delays in the application process as a whole.</div>
             </li>
             <li>
                 <div style="font-style:normal;color:red;font-size:large">Please make sure upon receiving the first email after creating your account ,if it goes into junk mail,configure your mail box NOT to recognise emails from &quot;admissions@trustacademy.ac.zw&quot; as JUNK.</div>
             </li>
        </ul>
         
     
       
            
         
     
        </div>
  
</asp:Content>
