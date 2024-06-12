import java.awt.*;
import java.awt.image.BufferedImage;

import javax.swing.*;

public class RocketGarden extends JPanel {

	
	private static final int WIDTH = 800;
	private static final int HEIGHT = 600;
	private BufferedImage bufferedImage;
		
	public RocketGarden() {
		bufferedImage = new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
		Graphics g = bufferedImage.getGraphics();
		g.setColor(new Color(200,210,240));
		g.fillRect(0, 0, WIDTH, HEIGHT);
		
		
		Falcon9 myrocket = new Falcon9(400,250,200,20);
		
		myrocket.sOne.par = true;
		myrocket.sTwo.setX(500);
		myrocket.draw(g);
		
		
		myrocket.calculateDrag();
		
			
			
	}
	public void paintComponent(Graphics g) {
		g.drawImage(bufferedImage, 0, 0, getWidth(), getHeight(), null);
	}
	
	public static void main(String[] args) {
		JFrame frame = new JFrame("Rockets");
		frame.setSize(WIDTH, HEIGHT);
		frame.setLocation(300, 100);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setContentPane(new RocketGarden());
		frame.setVisible(true);
	}

}