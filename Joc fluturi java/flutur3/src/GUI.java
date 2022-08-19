import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;

/**
 * Clasa ce reprezinta ansamnblu de componente grafice
 * De aceasta e legata clasa MyPannel care mediaza (MEDIATOR/BROKER DP) interactiunea
 * dintre aceasta si restul claselor
 * De asemenea aceasta se apeleaza in clasa Composite Main unde se apeleaza doua clase Command
 * (Main -> TableGenerator -> TableGenerator -> MyButton ...
 * 											 -> Algorithm ...
 * 		 -> GUI   			-> MyPannel -> multiple clase
 *  )
 */
public class GUI implements Command{
	private static JButton jb;
	private static MyPanel myPanel;
	private static JLabel jl;
	private static JLabel pathLabel;
	private static JFrame frame;
	private static JPanel panel;

	@Override
	public void execute() {

		JFrame.setDefaultLookAndFeelDecorated(true);
		frame = new JFrame("Butterfly Kyodai");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		// definim panelul unde vom pune elementele
		panel = new JPanel();
		BoxLayout boxlayout = new BoxLayout(panel, BoxLayout.Y_AXIS);
		panel.setLayout(boxlayout);
		panel.setBorder(new EmptyBorder(new Insets(20, 20, 20, 20)));

		// definim componentele
		jb = new JButton(scaleImage(new ImageIcon("refreshGame.png")));
		jb.addActionListener(e -> restartGame());
		myPanel = new MyPanel();
		jl = new JLabel("Good luck");
		jl.setFont(new Font("Serif", Font.BOLD, 20));
		jl.setHorizontalAlignment(JLabel.CENTER);
		pathLabel = new JLabel();
		pathLabel.setHorizontalAlignment(JLabel.CENTER);

		// adaug elementele si spatiu de 20px intre ele
		panel.add(jb);
		panel.add(Box.createRigidArea(new Dimension(0, 20)));
		panel.add(jl);
		panel.add(Box.createRigidArea(new Dimension(0, 20)));
		panel.add(myPanel);
		panel.add(Box.createRigidArea(new Dimension(0, 20)));
		panel.add(pathLabel);

		frame.add(panel);
		frame.pack();
	
		frame.setVisible(true);
		

	}

	// reapelam functia de execute si inchidem fereastra veche
	private void restartGame() {
		JFrame oldFrame = frame;
		TableGenerator.getInstance().execute();
		execute();
		oldFrame.dispose();
	}

	// functie fololsita pentru redimensionarea imaginilor
	private static ImageIcon scaleImage(ImageIcon imageIcon) {
		Image image = imageIcon.getImage();
		Image newimg = image.getScaledInstance(60, 60,  java.awt.Image.SCALE_SMOOTH); // scale it the smooth way
		return new ImageIcon(newimg);
	}

	// setter pentru textul de label
	public static void setLabelText(String text) {
		jl.setText(text);
	}

	// afisarea drumului
	public static void setPathLabel(String text) {
		pathLabel.setText(text);
	}

}
