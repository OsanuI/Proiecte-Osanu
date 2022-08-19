package com.servletes;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class Login extends HttpServlet{
	String email,password;
	public void doPost(HttpServletRequest req,HttpServletResponse res) throws IOException {
		res.setContentType("text/html");
		PrintWriter out = res.getWriter();
		
		email = req.getParameter("uemail");
		password = req.getParameter("upass");
		
		//out.println(""+email);
		//out.println(""+password);
		
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");//Register the Driver 
			Connection con = DriverManager.getConnection("jdbc:mysql://localhost:3306/proiectisi","root","");
			
			Statement stmt = con.createStatement();
			
			String sql = "select * from utilizator where u_email='"+email+"' and u_pass1='"+password+"'";
			
			ResultSet rs = stmt.executeQuery(sql);
			
			if(rs.next()) {
				res.sendRedirect("list");
				//out.println("Login Succefully !!!");
			}
			else {
				res.sendRedirect("Error.jsp");
			}
			
				
		}catch(Exception e) {
			out.println(""+e);
		}
		
		
		
	}

}
