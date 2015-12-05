<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Product</title>
</head>
<body>
    <div>
        <%using(Html.BeginForm("Product","Product",FormMethod.Post)){ %>
        <table>
            <tr>
                <td>Discount scheme</td>
                <td>
                    <label>
                        
                        <%if (Convert.ToBoolean(ViewData["schemetype"]))
                              Response.Write(Html.RadioButton("schemetype", true, new { @checked = "checked" })); 
                            else
                              Response.Write(Html.RadioButton("schemetype", true)); 
                            %>  Single

                    </label> 
                    <label><%if (!Convert.ToBoolean(ViewData["schemetype"]))
                              Response.Write(Html.RadioButton("schemetype", false, new { @checked = "checked" })); 
                            else
                              Response.Write(Html.RadioButton("schemetype", false)); 
                            %>   Multiple</label> 
                </td>
                
                <td></td>
            </tr>

            <tr>
                <td>Number of Iphone6</td>
                <td>
                   <%Response.Write(Html.DropDownList("iphone6data"));%>
                </td>
                <td>* £300</td>
            </tr>

            <tr>
                <td>Number of Iphone5</td>
                <td>
                   <%Response.Write(Html.DropDownList("iphone5data"));%>
                </td>
                <td>* £200</td>
            </tr>

            <tr>
                <td>Number of Ipad</td>
                <td>
                   <%Response.Write(Html.DropDownList("ipaddata"));%>
                </td>
                <td>* £500</td>
            </tr>

            <tr>
                <td>Number of Macbook air</td>
                <td>
                   <%Response.Write(Html.DropDownList("macbookairdata"));%>
                </td>
                <td>* £1000</td>
            </tr>

            <tr>
                <td>Number of Macbook pro </td>
                <td>
                   <%Response.Write(Html.DropDownList("macbookprodata"));%>
                </td>
                <td>* £2000</td>
            </tr>

            <tr>
                <td>
                    Is it your birthday today?
                </td>
                <td>
                    <label> <%if (Convert.ToBoolean(ViewData["isBirthday"]))
                                Response.Write(Html.RadioButton("birthday", true,new { @checked = "checked" })); 
                            else
                              Response.Write(Html.RadioButton("birthday", true)); 
                            %> Yes</label> 
                    <label>

                        <%if (!Convert.ToBoolean(ViewData["isBirthday"]))
                            Response.Write(Html.RadioButton("birthday", false,new { @checked = "checked" })); 
                          else
                              Response.Write(Html.RadioButton("birthday", false)); 
                        %> No

                    </label> 
                </td>
            </tr>

            <tr>
                <td>
                    Are you a senior citizen?
                </td>
                <td>
                    <label>
                        <%if (Convert.ToBoolean(ViewData["isCitizen"]))
                              Response.Write(Html.RadioButton("citizen", true, new { @checked = "checked" })); 
                            else
                              Response.Write(Html.RadioButton("citizen", true)); 
                            %>  
                        Yes</label> 
                    <label><%if (!Convert.ToBoolean(ViewData["isCitizen"]))
                                 Response.Write(Html.RadioButton("citizen", false, new { @checked = "checked" })); 
                            else
                                 Response.Write(Html.RadioButton("citizen", false)); 
                            %> No</label> 
                </td>
            </tr>

            <tr>
                <td>Number of iphone6</td>
                <td>
                    <input type="submit" value="Get price" />
                </td>
            </tr>
        </table>
        <%} %>
    </div>
</body>
</html>
