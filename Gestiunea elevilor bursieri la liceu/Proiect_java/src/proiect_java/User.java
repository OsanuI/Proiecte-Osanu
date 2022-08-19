package proiect_java;


public class User {
    
    private int id;
    private String nume;
    private String prenume;
    private String tipBursa;
    private String liceu;
    
    public User (int ID, String Nume, String Prenume, String TipBursa, String Liceu)
    {
        this.id = ID;
        this.nume = Nume;
        this.prenume = Prenume;
        this.tipBursa = TipBursa;
        this.liceu = Liceu;
    }
    
    public int getID()
    {
        return id;
    }
    
    public String getNume()
    {
        return nume; 
    }
    
    public String getPrenume()
    {
        return prenume;
    }
    
    public String getTipBursa()
    {
        return tipBursa;
    }
    
    public String getLiceu()
    {
        return liceu;
    }
      
}
