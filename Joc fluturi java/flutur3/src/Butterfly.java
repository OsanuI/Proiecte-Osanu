import javax.swing.*;

/**
 * Obiect fluture ce are rand, coloana, tip si imagine
 * Folosit in MyButton
 * Fortam utilizarea unu Builder DP
 */
public class Butterfly {
	private Icon icon;
	private int row;
	private int col;
	private int type;

	public Icon getImageIcon() {
		return icon;
	}

	public int getRow() {
		return row;
	}

	public int getCol() {
		return col;
	}

	public int getType() {
		return type;
	}

	public void setIcon(Icon icon) {
		this.icon = icon;
	}

	public void setRow(int row) {
		this.row = row;
	}

	public void setCol(int col) {
		this.col = col;
	}

	public void setType(int type) {
		this.type = type;
	}
}
