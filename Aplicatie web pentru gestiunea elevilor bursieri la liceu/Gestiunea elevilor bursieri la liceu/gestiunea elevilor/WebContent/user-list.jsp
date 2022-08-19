<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@page import="java.sql.*" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<html>
<head>
<title>Gestiunea elevilor bursieri la liceu</title>
<link rel="stylesheet"
	href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
	integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
	crossorigin="anonymous">
</head>
	<header>
		<nav class="navbar navbar-expand-md navbar-dark"
			style="background-color: blue">
			<div>
				<a href="https://www.xadmin.net" class="navbar-brand"> Gestiunea elevilor bursieri la liceu </a>
			</div>

			<ul class="navbar-nav">
				<li><a href="<%=request.getContextPath()%>/list"
					class="nav-link">Elevi bursieri</a></li>
			</ul>
		</nav>
	</header>
	<br>

	<div class="row">
		<!-- <div class="alert alert-success" *ngIf='message'>{{message}}</div> -->

		<div class="container">
			<h3 class="text-center">Lista elevilor</h3>
			<hr>
			<div class="container text">

				<a href="<%=request.getContextPath()%>/new" class="btn btn-success text-left">Adauga elev</a>
				<a href="<%=request.getContextPath()%>/export" class="btn btn-success text-left">Export excel</a>
				<a href="<%=request.getContextPath()%>/download" class="btn btn-success text-left">Export text</a>
				
				<p>
				
				
				</p>
			</div>
			<br>	
			<a href = "exportExcel.jsp">Export Excel</a>
			<br>
			
			<br>	
			<a href = "chart.jsp">Vizualizare grafic</a>
			<br>
			<table class="table table-bordered">
				<thead>
					<tr>
						<th>ID</th>
						<th>Nume</th>
						<th>Prenume</th>
						<th>Tip Bursa</th>
						<th>Liceu</th>
					</tr>
				</thead>
				<tbody>
			
					<c:forEach var="user" items="${listUser}">

						<tr>
							<td><c:out value="${user.id}" /></td>
							<td><c:out value="${user.firstname}" /></td>
							<td><c:out value="${user.lastname}" /></td>
							<td><c:out value="${user.bursa}" /></td>
							<td><c:out value="${user.liceu}" /></td>
							<td><a href="edit?id=<c:out value='${user.id}' />">Editare</a>
								&nbsp;&nbsp;&nbsp;&nbsp; <a
								href="delete?id=<c:out value='${user.id}' />">Sterge</a></td>
						</tr>
					</c:forEach>
					
			 
				</tbody>
				
			</table>
		</div>
		
		
		<body>
        <div class="container">
            <div class="table table-bordered">
             <%
                Connection con;
                PreparedStatement pst;
                ResultSet rs;
                Class.forName("com.mysql.jdbc.Driver");
                con = DriverManager.getConnection("jdbc:mysql://localhost/proiectisi","root","");
                
                String firstname = request.getParameter("firstname");
           
                
               
                 if (firstname == null  || firstname.isEmpty()) 
                {
                  pst = con.prepareStatement("select * from users");
                  rs = pst.executeQuery();
       
                }
               else {
                pst = con.prepareStatement("select * from users where firstname=?;");
           
                pst.setString(1, firstname);
           

            
                rs = pst.executeQuery();
                
                 while(rs.next())
                 {   
                     out.print("<Table cellpadding=10 cellspacing=5 border=2 bgcolor=white>");
                     out.print("<TR>");
                     out.print("<TD>" + rs.getString("id") + "<TD>");
                     out.print("<TD>" + rs.getString("firstname") + "<TD>");
                     out.print("<TD>" + rs.getString("lastname") + "<TD>");
                     out.print("<TD>" + rs.getString("bursa") + "<TD>");
                     out.print("<TD>" + rs.getString("liceu") + "<TD>");
                     out.print("</TR>");
                      out.print("</Table>");
                 }
                }
              %>                   
  <body>
        <div class="container">
             <div class="form-group col-6 p-0">
                 <form id="form" method="post" action="user-list" class="form-horizontal">
                      <div class="form-group col-md-6"> 
                  		<input type="text" name="firstname" class="form-control" id="firstname" placeholder="Cauta un nume.." required>
                      </div>
                      
                      <div class="form-group col-md-6" align="center"> 
                        <Button class="btn btn-success" style="width: 80px;">Cauta</Button>
                      </div>
                 </form>
             </div>
         </div>   
 </body>
   			</div>
	
</body>


<body>
		
		
</html>