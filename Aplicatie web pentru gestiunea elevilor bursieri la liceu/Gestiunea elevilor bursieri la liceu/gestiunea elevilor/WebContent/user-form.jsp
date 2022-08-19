

<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<html>
<head>
<title>Gestiunea elevilor bursieri la liceu</title>
<link rel="stylesheet"
	href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
	integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
	crossorigin="anonymous">
</head>
<body>

	<header>
		<nav class="navbar navbar-expand-md navbar-dark"
			style="background-color: blue">
			<div>
				<a href="https://www.xadmin.net" class="navbar-brand"> Gestiunea elevilor bursieri la liceu </a>
			</div>

			<ul class="navbar-nav">
				<li><a href="<%=request.getContextPath()%>/list"
					class="nav-link">Users</a></li>
			</ul>
		</nav>
	</header>
	<br>
	<div class="container col-md-5">
		<div class="card">
			<div class="card-body">
				<c:if test="${user != null}">
					<form action="update" method="post">
				</c:if>
				<c:if test="${user == null}">
					<form action="insert" method="post">
				</c:if>

				<caption>
					<h2>
						<c:if test="${user != null}">
            			Editeaza elev
            		</c:if>
						<c:if test="${user == null}">
            			Adauga elev
            		</c:if>
					</h2>
				</caption>

				<c:if test="${user != null}">
					<input type="hidden" name="id" value="<c:out value='${user.id}' />" />
				</c:if>

				<fieldset class="form-group">
					<label>Nume</label> <input type="text"
						value="<c:out value='${user.firstname}' />" class="form-control"
						name="firstname" required="required">
				</fieldset>

				<fieldset class="form-group">
					<label>Prenume</label> <input type="text"
						value="<c:out value='${user.lastname}' />" class="form-control"
						name="lastname">
				</fieldset>

				<fieldset class="form-group">
					<label>Tip Bursa</label> <input type="text"
						value="<c:out value='${user.bursa}' />" class="form-control"
						name="bursa">
				</fieldset>
				
				<fieldset class="form-group">
					<label>Liceu</label> <input type="text"
						value="<c:out value='${user.liceu}' />" class="form-control"
						name="liceu">
				</fieldset>

				<button type="submit" class="btn btn-success">Actualizare</button>
				</form>
			</div>
		</div>
	</div>
</body>
</html>