<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@page import="java.sql.*" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
<table class="table table-bordered">
				<thead>
							
					<tr>
						<th>ID</th>
						<th>Nume</th>
						<th>Prenume</th>
						<th>Tip Bursa</th>
						<th>Liceu</th>
					</tr>
					<tr>
				<%		
                      response.setContentType("application/vnd.ms-excel");
                      response.setHeader("Content-Disposition", "inline; filename="+ "excel.xls"); 
            	%>
            			<tr>
							<td><%="5" %></td>
							<td><%="Osanu"%></td>
							<td><%="Ioan" %></td>
							<td><%="Performanta" %></td>
							<td><%="Liceul Economic \"Virgil Madgearu\" Galati"%></td>
						</tr>
					
						<tr>
							<td><%="20" %></td>
							<td><%="Osanu" %></td>
							<td><%="Ionel" %></td>
							<td><%="Performanta" %></td>
							<td><%="Liceul Economic \"Virgil Madgearu\" Galati daaa"%></td>
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
						</tr>
					</c:forEach>
					
					
		
				</tbody>
			
			</table>
</body>
</html>