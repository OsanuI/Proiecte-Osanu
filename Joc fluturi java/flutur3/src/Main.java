public class Main {
	/**
	 * Clasa principala, Composite incepe prin a apela TableGenerator si interfata grafica GUI
	 * @param args
	 */
	public static void main(String[] args) {
		TableGenerator.getInstance().execute();
		GUI gui = new GUI();
		gui.execute();
	}
}
