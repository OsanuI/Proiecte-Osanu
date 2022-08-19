import javax.swing.*;
import java.awt.*;

/** Clasa Mediator/Broker ce face legatura intre GUI si restul claselor
 * Reprezinta tabelul de fluturi.
 * metoda importanta: checkButton
 */
public class MyPanel extends JPanel {

	private MyButton selectedButton;
	private ArrayMatrixIterator<Butterfly> butterflyArrayMatrixIterator;
	private Algorithm findPath = new Algorithm();
	private Butterfly nextButterfly;

	public MyPanel() throws HeadlessException {
		setLayout(new GridLayout(10, 10));
		butterflyArrayMatrixIterator = new ArrayMatrixIterator<>(MyButton.butterflies);

		for (int i = 1; i < 101; i++) {
			// creez butonul meu special care contine obiect de tip fluture
			if (butterflyArrayMatrixIterator.hasNext()) {
				nextButterfly = butterflyArrayMatrixIterator.next();
			}
			MyButton button = new MyButton("button" + i, nextButterfly.getImageIcon(), nextButterfly);
			button.addActionListener(e -> checkButton(button));
			add(button);
		}
		setSize(500, 500);
		setVisible(true);
	}

	private void checkButton(MyButton button) {
		button.setEnabled(false);
		// daca am un fluturas selectat deja inseamna ca-i caut perechea
		if (selectedButton != null) {
			// daca i-am gasit perechea eliberez butoanele
			if (selectedButton.getButterfly().getType() == button.getButterfly().getType()) {
				// setez destinatia si sursa intre care voi cauta drum
				findPath.choosePoints(selectedButton, button);
				// looking for a path between source and dest (bfs)
				findPath.execute();
				if (findPath.pathExists()) {
					selectedButton.freeButterfly();
					button.freeButterfly();
					selectedButton = null;
				} else {
					// path not existing
					GUI.setLabelText("Path not found");
					selectedButton.setEnabled(true);
					button.setEnabled(true);
					selectedButton = null;
				}
				// wrong answer
			} else {
				GUI.setLabelText("Not matching butterflies");
				selectedButton.setEnabled(true);
				button.setEnabled(true);
				selectedButton = null;
			}
		} else {
			selectedButton = button;
		}
	}

}
