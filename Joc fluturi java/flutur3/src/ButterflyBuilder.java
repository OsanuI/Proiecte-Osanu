import javax.swing.*;

/**
 * Clasa builder - principiu modifica campul butterfly, returneaza this si la sfarsit
 * returneaza campul butterfly modificat (build)
 */
public class ButterflyBuilder {
	private Butterfly butterfly = new Butterfly();

	public ButterflyBuilder withIcon (Icon icon) {
		butterfly.setIcon(icon);
		return this;
	}
	public ButterflyBuilder withRow (int row) {
		butterfly.setRow(row);
		return this;
	}
	public ButterflyBuilder withCol (int col) {
		butterfly.setCol(col);
		return this;
	}
	public ButterflyBuilder withType (int type) {
		butterfly.setType(type);
		return this;
	}
	public Butterfly build() {
		return butterfly;
	}
}
