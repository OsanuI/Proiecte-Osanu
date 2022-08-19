import java.util.Iterator;
import java.util.NoSuchElementException;

/**
 * Iterator design pattern
 */

public class ArrayMatrixIterator<T> implements Iterator<T> {

	private T[][] dataset;
	private int rowIndex;
	private int columnIndex;

	public ArrayMatrixIterator(T[][] dataset) {
		this.dataset = dataset;
	}

	@Override
	public boolean hasNext() {
		if (rowIndex >= dataset.length)
			return false;
		if (columnIndex >= dataset[rowIndex].length &&
				(rowIndex >= dataset.length || rowIndex == dataset.length - 1))
			return false;
		return true;
	}

	@Override
	public T next() {
		if (!hasNext())
			throw new NoSuchElementException();
		if (columnIndex >= dataset[rowIndex].length) {
			rowIndex++;
			columnIndex = 0;
		}
		return dataset[rowIndex][columnIndex++];
	}
}