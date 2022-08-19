import javax.swing.*;

/**
 * Clasa ce extinde JButton pentru a avea un obiect inclus anume obiectul de tip Butterfly
 */
public class MyButton extends JButton {
	private Butterfly butterfly;
	public static Butterfly[][] butterflies;

	public MyButton(String text, Icon icon, Butterfly butterfly) {
		super(null, icon);
		this.butterfly = butterfly;
		this.setIcon(icon);
	}

	public Butterfly getButterfly() {
		return butterfly;
	}

	// seteaza textul la "", sterge fluturele de pe buton (cu tot cu imagine) si face butonul unclickable
	public void freeButterfly() {
		setText("");
		butterfly = null;
		this.setEnabled(false);
		this.setIcon(null);
	}
}
