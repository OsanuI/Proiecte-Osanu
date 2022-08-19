import org.junit.Test;

import java.util.Random;

import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.*;

public class AlgorithmTest {
	@Test
	public void rightTest() {
		// initializarea elementelor
		Algorithm algorithm = new Algorithm();
		int len = 4;
		// creem o matrice noua random asemanatoare cu cea din program, dar mai mica
		int[][] mat = new int[len][len];
		for (int i = 0; i < len ; i++) {
			for (int j = 0; j < len; j++) {
				mat[i][j] = new Random().nextInt(4);
			}
		}
			
		// creez un drum clar intre pozitiile 1,1 si 2,2 (1,2)
		mat[1][2] = 0;
		algorithm.setButterflyMatrix(mat);
		algorithm.setDest(new Pair(2,2,  null));
		algorithm.setSrc(new Pair(1, 1, null));
		mat[1][1] = 6;
		mat[2][2] = 7;

		// rulez algoritmul
		algorithm.execute();

		// afiez sa vad ce mi-a dat
		for (int i = 0; i < len ; i++) {
			for (int j = 0; j < len; j++) {
				System.out.print(mat[i][j]  + " ");
			}
			System.out.println();
		}
		// al trebui sa existe drum
		assertTrue(algorithm.pathExists());
	}
}