<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">

<title>Inregistrare</title>
</head>
<body>
	<div class="container">
    <div class="row justify-content-center">
    	<div class="col-md-8">
    	   <h1>Inregistrare</h1><br>
    		<form class="form-group" action="register" method="post">
    			<label  class="form-label" for="username" >Username</label>
    				<input name="uname" type="text" class="form-control mb-3" >
    			<label class="form-label" for="email">Email </label>
    				<input name="uemail" type="email" class="form-control mb-3" >
    			<label class="form-label" for="password" >Parola</label>
    				<input name="pass1" type="password" class="form-control mb-3" >
    			<label class="form-label" for="password2">Confirma parola</label>
    				<input name="pass2" type="password" class="form-control mb-3">
    			<button class="btn btn-primary mb-4" type="submit">Inregistrare</button>
    		</form>
    	</div>
    </div>
   </div>
	

</body>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" integrity="sha384-q2kxQ16AaE6UbzuKqyBE9/u/KzioAlnx2maXQHiDX9d4/zp8Ok3f+M7DPm+Ib6IU" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js" integrity="sha384-pQQkAEnwaBkjpqZ8RU1fF1AKtTcHJwFl3pblpTlHXybJjHpMYo79HY3hIi4NKxyj" crossorigin="anonymous"></script>

</html>