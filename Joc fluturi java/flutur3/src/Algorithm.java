

import java.util.LinkedList;
import java.util.Queue;

/**
 * Clasa importanta reprezentand un algoritm ce are nevoie de mai multe campuri si prelucrari
 * Exemplul perfect de necesitate a DP Command
 * Dupa o serie de prelucrari pe o matrice, aplic algoritmul de bfs de la susa la destinatie
 * ( acestea fiind setate cu choosePoints in clasa ce apeleaza functia (checkButton din MyButton) )
 *
 */
public class Algorithm implements Command {
	private boolean foundRoute;
	public static int[][] butterflyMatrix;
	private Pair src;
	private Pair dest;
	private int ROW ;
	private int COL ;
	private final int[] rowNum = {-1, 0, 0, 1};
	private final int[] colNum = {0, -1, 1, 0};

	@Override
	public void execute() {
		// butterflyMatrix va fi construit cu ajutorul altei clase (test sau TableGenerator)
		// astfel dimensiunea poate varia
		ROW = butterflyMatrix.length;
		COL = butterflyMatrix[0].length;

		// initializam cu false faptul ca am gasit un drum intre src si dest
		foundRoute = false;

		// bordez matricea cu zerouri pentru a face cautarea mai usoara
		for (int i = 0; i < ROW; i++) {
			butterflyMatrix[i][0] = 0;
			butterflyMatrix[i][COL - 1] = 0;
		}
		for (int j = 0; j < COL; j++) {
			butterflyMatrix[0][j] = 0;
			butterflyMatrix[ROW - 1][j] = 0;
		}
		// si colturile le fac -1 pentru ca cautareasa se faca pe aceeasi latura
		butterflyMatrix[0][0] = butterflyMatrix[ROW - 1][COL - 1] = butterflyMatrix[0][COL - 1] = butterflyMatrix[ROW - 1][0] = -1;

		// jocul s-a redus la gasirea unui drum intre sursa si destinatie in matricea de fluturi
		BFS(butterflyMatrix, src, dest);
	}


	private void BFS(int[][] mat, Pair src, Pair dest) {

		boolean[][] visited = new boolean[ROW][COL];

		// setez sursa ca vizitata
		visited[src.x][src.y] = true;

		// creez o coada pentru parcurgerea bfs
		Queue<Pair> q = new LinkedList<>();

		// adaug sursa in coada
		q.add(src);

		// fac bfs pornind de la sursa
		while (!q.isEmpty()) {
			// iau urmatorul element
			Pair curr = q.remove();
			// ii parcurg vecinii cu ajutorul vectorilor de directie
			for (int i = 0; i < 4; i++) {
				int row = curr.x + rowNum[i];
				int col = curr.y + colNum[i];

				// in caz ca am ajnus la dest
				if (row == dest.x && col == dest.y) {
					// zic ca am gasit ruta
					this.foundRoute = true;
					// sterg fluturii de pe sursa si dest, asadar setez si in matrice la 0 tipurile acestora
					butterflyMatrix[dest.x][dest.y] = 0;
					butterflyMatrix[src.x][src.y] = 0;
					// adaug si ultimul nod on arborele de parinti ca sa l pot afisa
					Pair lastOne = new Pair(row, col, curr);
					// afisez drumul
					StringBuilder path = new StringBuilder().append("Path: ");
					while (lastOne != null) {
						path.append(lastOne);
						lastOne = lastOne.parent;
					}
					try {
						GUI.setPathLabel(path.append("END").toString());
					}
					catch (Exception e) {
						
					}

					return;
				}
				// daca celula urmatoare este libera
				// (este in matrice si valoare e 0)
				// o adaug in coada si actualizez vectorul de vizitate
				if (isValid(row, col) &&
						mat[row][col] == 0 &&
						!visited[row][col]) {
					// mark cell as visited and enqueue it
					visited[row][col] = true;
					q.add(new Pair(row, col, curr));
				}
			}
		}
	}


	private boolean isValid(int row, int col) {
		return (row >= 0) && (row < ROW) &&
				(col >= 0) && (col < COL);
	}

	public void choosePoints(MyButton b1, MyButton b2) {
		src = new Pair(b1.getButterfly().getRow() + 1, b1.getButterfly().getCol() + 1, null);
		dest = new Pair(b2.getButterfly().getRow() + 1, b2.getButterfly().getCol() + 1, null);
	}

	public boolean pathExists() {
		return foundRoute;
	}

	public void setButterflyMatrix(int[][] matrix) {
		butterflyMatrix = matrix;
	}

	public void setSrc(Pair pair) {
		src = pair;
	}

	public void setDest(Pair pair) {
		dest = pair;
	}
}



class Pair {
	int x;
	int y;
	Pair parent;

	public Pair(int i, int j, Pair parent) {
		x = i;
		y = j;
		this.parent = parent;
	}

	@Override
	public String toString() {
		return "{" +
				x +
				"," +
				y +
				"}->" ;
	}
}