

<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="Login.aspx.vb" Inherits="TrustAcademyPortal._Default" 
    title="StudentPortal" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    
   


    
    <div class="divMain">
       
      <div  style=" WIDTH :100%;align-items:center">
                       <h3 >LOGIN</h3>
                   </div>
      
                            <div class="InputdivLogin">
                               
                          <div style="display:flex;flex-direction:column">
                              <asp:Label ID ="lbusertype" runat ="server" Text ="Select UserType" float ="left" Font-Size="XX-Small"></asp:Label>
                                               <asp:DropDownList ID="UserType" name = "UserType" runat="server" cssclass="ddlinputLogin"
                                                         >
                                                        
                                                         
                                                   
                    <asp:ListItem>Student</asp:ListItem>
                                       <asp:ListItem>Staff</asp:ListItem>
                  
                                                    </asp:DropDownList>
                            
                                       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="UserType" ErrorMessage="User Type is required." 
                                                        ToolTip="User Type is Required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>--%>
                          </div>
                            </div>
                             
                           
                            <div class="InputdivLogin">
                                                        
                                                    <asp:TextBox ID="UserName" runat="server" CssClass ="inputtextLogin" placeholder="RegNumber"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                        ControlToValidate="UserName" ErrorMessage="User ID is required." 
                                                        ToolTip="User Name is required." ></asp:RequiredFieldValidator>
                        
                            </div>

                            <div class="InputdivLogin">
                                <div style="width:100%">
                                  <asp:HyperLink ID="HyperLink3" runat="server" 
                                                        NavigateUrl="~/Admin/RecoverPasswordPortal.aspx" ForeColor="Red" style="float:right;font-size:xx-small;">Forgot Password?</asp:HyperLink>
                                                  </div>
                              
                                                   
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputtextLogin" placeholder="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                                        ToolTip="Password is required." ></asp:RequiredFieldValidator>
                            
                            </div>
                   
                              <div>

                              </div>           
                                     
                            <div class="InputdivLogin">
                                <asp:Button ID="btnlogin" runat="server"  CommandName="Login"  Text="Log In"  CssClass="LoginButton1" />
                                                
                            </div>
                            <div class="InputdivLogin">
                                  <asp:HyperLink ID="CreateUserLink" runat="server" 
                                                        NavigateUrl="~/Admin/CreateUserPortal_Custom.aspx" ForeColor="Red">CreateUser</asp:HyperLink>
                            </div>
                           
                            <div class="InputdivLogin">
                                  <asp:HyperLink ID="HyperLink1" runat="server" 
                                                        NavigateUrl="~/Student/OnlineApplication/ApplcationSignUp.aspx" ForeColor="Red">Online Application</asp:HyperLink>
                            </div>

           <div class="InputdivLogin">
                                                          <asp:Literal ID="FailureText" runat="server" EnableViewState="False" > </asp:Literal>
                                        </div>  
                                   
                                           
                                        
                                                                                                                        
                                     
                         
                        

    </div>
                      
                    
          
    
   

</asp:Content>
