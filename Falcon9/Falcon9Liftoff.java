
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.Timer;

@SuppressWarnings("serial")
public class Falcon9Liftoff extends JPanel {

	private static final int PANEL_WIDTH = 1200;
	private static final int PANEL_HEIGHT = 600;

	// required global variables
	private BufferedImage image;
	private Graphics g;
	private Timer timer;
	private Falcon9 rocket; 
	double time = -50;
	private Graphics2D g2D;
	GradientPaint skyGradient = new GradientPaint(0, WIDTH, new Color(40, 192, 252), 0, 150, new Color(0,0,40));

	public Falcon9Liftoff() {
		// set up Buffered Image and Graphics objects
		image = new BufferedImage(PANEL_WIDTH, PANEL_HEIGHT, BufferedImage.TYPE_INT_RGB);
		g = image.getGraphics();
		g2D = (Graphics2D) g;

		rocket = new Falcon9(PANEL_WIDTH / 2, (PANEL_HEIGHT)*29/32-25, 50, 10);
		rocket.setDeltaTime(.1);
		rocket.groundHeight = PANEL_HEIGHT*3/32;

		// set up and start the Timer
		timer = new Timer(10, new TimerListener());
		timer.start();

	}

	// TimerListener class that is called repeatedly by the timer
	private class TimerListener implements ActionListener {
		boolean end = false;

		public void actionPerformed(ActionEvent e) {
			
			Color textColor = Color.white;
			String textContent = "Hello";
			g2D.setPaint(skyGradient);
			g2D.fillRect(0, 0, PANEL_WIDTH, PANEL_HEIGHT);
			g.setColor(new Color(35,105,39).brighter());
			g.fillOval(PANEL_WIDTH*-1/6, PANEL_HEIGHT*29/32, PANEL_WIDTH*4/3, PANEL_HEIGHT*2/8);
			g.setColor(new Color(50,50,50));

			if (time >= 0 && time <= 559) rocket.move(HEIGHT, time);
			if (time > 559.5) end = true;
			
			if(time < 0) {
				textColor = new Color(143, 50, 184);
				textContent = "Launching in " + ((int)((time * -1)/10)+1) + "...";
			}else if(time < 20) {
				textColor = new Color(202, 209, 61);
				textContent = "Stage 1 Started";
			}else if(time < 152) {
				textColor = new Color(202,209,61);
				textContent = "Stage 1";
			}else if(time < 172) {
				textColor = new Color(199, 54, 192);
				textContent = "Stage 1 released";
			}else if(time < 192) {
				textColor = new Color(199, 54, 59);
				textContent = "Stage 2 started";
			}else if(time < 400) {
				textColor = new Color(199, 54, 59);
				textContent = "Stage 2";
			}else if(time < 460) {
				textColor = new Color(199, 54, 192);
				textContent = "Stage 1 landing...";
			}else if(time < 480) {
				textColor = new Color(54, 199, 112);
				textContent = "Stage 1 landed";
			}else if(time < 550) {
				textColor = new Color(199, 54, 59);
				textContent = "Stage 2";
			}else {
				textColor = new Color(54, 199, 112);
				textContent = "Payload Delivered";
			}
			
			if (end) {
				time = 559;
				rocket.setMass(3900);
				
			}
			rocket.draw(g);
			//TODO: work on adding dials to show values
			g.setColor(textColor);
			g.setFont(new Font("Bank gothic light bt", Font.PLAIN, 40));
			g.drawString(textContent, 48, 45);
			g.setFont(new Font("Bank gothic light bt", Font.PLAIN, 20));
			g.setColor(Color.white);
			g.drawString("Altitude: " + Math.floor(rocket.getAltitude() * 100) / 100 + " m", 50, 70);
			g.drawString("Mass: " + Math.floor(rocket.getMass() * 100) / 100 + " kg", 50, 90);
			g.drawString("Velocity: " + Math.floor(rocket.getVelocity() * 100) / 100 + " m/s", 50, 110);
			g.drawString("Acceleration: " + Math.floor(rocket.getAccel() * 100) / 100 + " m/s/s", 50, 130);
			String ch = (time > 0) ? "+" : "";
			g.drawString("Time: T" + ch + Math.floor(time * 100) / 100 + " s", 50, 150);
			Dial veldial = new Dial(730, 525 , 60, 0, 12000, true );
			veldial.draw(g, rocket.getVelocity(), new Color(150,150,150));
			Dial acceldial = new Dial(600, 600, 70, 0, 150, false);
			acceldial.draw(g, rocket.getAccel(), textColor);
			Dial massDial = new Dial(200,600,70, 3000, 600000, false);
			massDial.draw(g, rocket.getMass(), textColor);
			Dial altdial = new Dial(70, 525 , 60, 0, 1200000, true);
			altdial.draw(g, rocket.getAltitude(), new Color(150,150,150));
			g.setFont(new Font("Bank gothic light bt", Font.PLAIN, 11));
			
			g.setColor(new Color(230,230,230));
			g.drawString("Acceleration" , 560 , 575 );
			g.drawString("Velocity", 705, 545);
			g.drawString("Mass" , 185 , 575 );
			g.drawString("Position", 45, 545);
			
			

			time += .1;

			repaint();
		}

	}

	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, getWidth(), getHeight(), null);
	}

	
	public static void main(String[] args) {
		JFrame frame = new JFrame("Animation Shell");
		frame.setSize(PANEL_WIDTH, PANEL_HEIGHT);
		frame.setLocation(0, 100);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setContentPane(new Falcon9Liftoff()); 
		frame.setVisible(true);
	}

}