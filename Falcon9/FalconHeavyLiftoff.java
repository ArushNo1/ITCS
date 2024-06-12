

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.Timer;

@SuppressWarnings("serial")
public class FalconHeavyLiftoff extends JPanel {

	private static final int WIDTH = 800;
	private static final int HEIGHT = 600;

	private BufferedImage image;
	private Graphics g;
	private Timer timer;
	private FalconHeavy rocket; 
	double time = -20;
	private Graphics2D g2D;
	GradientPaint skyGradient = new GradientPaint(0, WIDTH, new Color(40, 192, 252), 0, 150, new Color(0,0,40));
	

	public FalconHeavyLiftoff() {
		image = new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
		g = image.getGraphics();
		g2D = (Graphics2D) g;

		rocket = new FalconHeavy(WIDTH / 2, (HEIGHT)*29/32-25, 50, 10);
		rocket.setDeltaTime(.2);
		rocket.groundHeight = HEIGHT*3/32;

		

		// set up and start the Timer
		timer = new Timer(10, new TimerListener());
		timer.start();

	}

	// TimerListener class that is called repeatedly by the timer
	private class TimerListener implements ActionListener {
		boolean end = false;

		public void actionPerformed(ActionEvent e) {
			
			g2D.setPaint(skyGradient);
			g2D.fillRect(0, 0, WIDTH, HEIGHT);
			g.setColor(new Color(35,105,39).brighter());
			g.fillOval(WIDTH*-1/6, HEIGHT*29/32, WIDTH*4/3, HEIGHT*2/8);
			g.setColor(new Color(50,50,50));
			
			if (time >= 0 && time <= 187) rocket.move(HEIGHT, time);
			if (time > 187.5) end = true;
			
			
			if (end) {
				time = 187;
			}
			//TODO: Add dials to show P, V, A, mass
			rocket.draw(g);
			g.setFont(new Font("Bank gothic light bt", Font.PLAIN, 20));
			g.setColor(Color.white);
			g.drawString("Altitude: " + Math.floor(rocket.getAltitude() * 100) / 100 + " m", 50, 70);
			g.drawString("Mass: " + Math.floor(rocket.getMass() * 100) / 100 + " kg", 50, 90);
			g.drawString("Velocity: " + Math.floor(rocket.getVelocity() * 100) / 100 + " m/s", 50, 110);
			g.drawString("Acceleration: " + Math.floor(rocket.getAccel() * 100) / 100 + " m/s/s", 50, 130);
			String ch = (time > 0) ? "+" : "";
			g.drawString("Time: T" + ch + Math.floor(time * 100) / 100 + " s", 50, 150);
			
			

			time += .2;

			repaint(); 
		}

	}

	
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, getWidth(), getHeight(), null);
	}

	public static void main(String[] args) {
		JFrame frame = new JFrame("Animation Shell");
		frame.setSize(WIDTH, HEIGHT);
		frame.setLocation(0, 0);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setContentPane(new FalconHeavyLiftoff()); 
		frame.setVisible(true);
	}

}