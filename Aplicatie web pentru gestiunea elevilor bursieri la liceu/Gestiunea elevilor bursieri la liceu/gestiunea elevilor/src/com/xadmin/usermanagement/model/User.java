package com.xadmin.usermanagement.model;

/**

 * @author Osanu Ioan
 *
 */
public class User {
	protected int id;
	protected String firstname;
	protected String lastname;
	protected String bursa;
	protected String liceu;
	
	public User() {
	}
	
	public User(String firstname, String lastname, String bursa, String liceu) {
		super();
		this.firstname = firstname;
		this.lastname = lastname;
		this.bursa = bursa;
		this.liceu = liceu;
	}

	public User(int id, String firstname, String lastname, String bursa, String liceu) {
		super();
		this.id = id;
		this.firstname = firstname;
		this.lastname = lastname;
		this.bursa = bursa;
		this.liceu = liceu;
	}

	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getFirstname() {
		return firstname;
	}
	public void setFirstname(String firstname) {
		this.firstname = firstname;
	}
	public String getLastname() {
		return lastname;
	}
	public void setLastname(String lastname) {
		this.lastname = lastname;
	}
	public String getBursa() {
		return bursa;
	}
	public void setBursa(String bursa) {
		this.bursa = bursa;
	}
	public String getLiceu() {
		return liceu;
	}
	public void setLiceu(String liceu) {
		this.liceu = liceu;
	}
}