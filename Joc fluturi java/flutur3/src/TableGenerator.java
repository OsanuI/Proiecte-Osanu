import javax.swing.*;
import java.awt.*;
import java.util.Random;
import java.util.concurrent.RecursiveTask;

/**
 * Clasa Singletone ce initializeaza intern tabela de flururi (Command)
 */
public class TableGenerator implements Command {
	// sunt 10 tipuri de fluturi
	private int[] types = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
	private static TableGenerator INSTANCE = null;

	@Override
	public void execute() {
		// Clasa MyButton trebuie sa stie cum arata fluturii
		MyButton.butterflies = new Butterfly[10][10];
		// Clasa algorithm trebuie sa stie cum arata matricea de fluturi (aceasta are zerourile incluse)
		Algorithm.butterflyMatrix = new int[12][12];

		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				// iau tipul random ca dupa ele le compar
				int type = getRandomType();
				// in functie de tipul ales, setez imaginea corespunzatoare
				Icon icon = scaleImage(new ImageIcon(getRandomPath(type)));
				// adaug in matricea de fluturi fluturele nou creat
				//Builder desing pattern
				MyButton.butterflies[i][j] =
						new ButterflyBuilder()
						.withIcon(icon)
						.withRow(i)
						.withCol(j)
						.withType(type)
						.build();
				// +1 deoarece incepe de la [1,1] (pe margini vom avea zerouri si -1)
				Algorithm.butterflyMatrix[i + 1][j + 1] = type;
			}
		}
	}

	// ia un numar random intre 1 si 10  (un tip de fluture)
	private int getRandomType() {
		return types[new Random().nextInt(10)];
	}

	// in functie de tipul ales, selectez imaginea corespunzatoare
	private String getRandomPath(int type) {
		return switch (type) {
			case 1 -> "black&blue.jfif";
			case 2 -> "black&green.jfif";
			case 3 -> "black&white.jfif";
			case 4 -> "black.png";
			case 5 -> "blakc&yellow.jfif";
			case 6 -> "blue.jfif";
			case 7 -> "yellow.jfif";
			case 8 -> "purple.jfif";
			case 9 -> "rainbow.jfif";
			case 10 -> "tiger.jfif";
			default -> null;
		};
	}

	//Singletone
	public static TableGenerator getInstance() {
		INSTANCE = INSTANCE == null ? new TableGenerator() : INSTANCE;
		return  INSTANCE;
	}

	// functie ce redimensioneaza o imagine
	private ImageIcon scaleImage(ImageIcon imageIcon) {
		Image image = imageIcon.getImage(); // transform it
		Image newimg = image.getScaledInstance(30, 30, java.awt.Image.SCALE_SMOOTH); // scale it the smooth way
		return new ImageIcon(newimg);  // transform it back
	}
}
