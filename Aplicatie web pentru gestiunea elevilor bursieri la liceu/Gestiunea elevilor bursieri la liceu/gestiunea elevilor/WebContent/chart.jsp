<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Pie Chart</title>
<script language="Javascript">
function refreshpage(){
document.forms.form1.submit();
}
</script>
<style>
    body{
        background-color:  darkgray;
        
       
    } 
</style>
</head>
<body>
<center> <h1>Pie Chart</h1> </center>
<%response.setIntHeader("Refresh",10);%>
<form id="form1">
    <center><img src="chart" width="600" height="400" border="0"/></center>

</form>
</body>
</html>