

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.*;
import javax.swing.Timer;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import java.util.*;

@SuppressWarnings("serial")

public class ConwaysGameOfLife extends JPanel implements ChangeListener {
	@SuppressWarnings("unused")

	private Random rand = new Random();
	private static final int WIDTH = 600;
	private static final int HEIGHT = 800;

	private BufferedImage image;
	@SuppressWarnings("unused")

	private Graphics g;
	private Timer timer;
	private JSlider delaySlider;
	private Dial delayDial;
	private JButton start;

	private ConwayMap grid;
	private ArrayList<Integer> born;
	private ArrayList<Integer> survive;

	public ConwaysGameOfLife() {
		image =  new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
		g = image.getGraphics();
		
		grid = new ConwayMap(16);
		grid.draw(g, 0, 0, WIDTH, 600);
		
		delaySlider = new JSlider(0, 500, 0/*250*/);
		delaySlider.addChangeListener(this);		
		setLayout(null);
		delaySlider.setBounds(25, 625, 100, 25);
		add(delaySlider);
		delayDial = new Dial(75, 658, 50, 0, 500, false);
		
		
		start = new JButton("Start");
		start.setBounds(225,575,125,25);
		start.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(timer.isRunning()) {
					timer.stop();
					start.setText("Start");
				}
				else {
					timer.start();
					start.setText("Stop");
				}
			}
		});
		add(start);
		
		updateGameRules("B3S23");
		//System.out.print(born);
		//System.out.println(survive);
		
		
		timer = new Timer(100, new TimerListener());
		stateChanged(null);
		addMouseListener(new MouseListener() {
			@Override
			public void mouseClicked(MouseEvent e) {
				//System.out.println(e.getX() + ", " + e.getY());
				if(!timer.isRunning()) {
					//int x = (int) Math.round((double) e.getX() / grid.getXWidth());
					int x = e.getX() / grid.getXWidth();
					//int y = (int) Math.round((double) e.getY() / grid.getYWidth());
					int y = e.getY() / grid.getYWidth();
					grid.toggle(y, x);
					grid.draw(g, 0, 0, WIDTH, 600);
					repaint();
				}
			}
			@Override
			public void mousePressed(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
			public void mouseReleased(MouseEvent e) {
				// TODO Auto-generated method stub	
			}
			public void mouseEntered(MouseEvent e) {
				// TODO Auto-generated method stub
			}
			@Override
			public void mouseExited(MouseEvent e) {
				// TODO Auto-generated method stub
			}
		});
		

	}

	public void updateGameRules(String rules) {
		born = new ArrayList<Integer>();
		survive = new ArrayList<Integer>();
		int state = 0;
		for (int i = 0; i < rules.length(); i++) {
			char c = rules.charAt(i);
			if (state == 1 && (c < '0' || c > '9')) {
				state = 2;
			} else {
				if(state == 0) {
					state = 1;
				} else if (state == 2) {
					survive.add(c - '0');
				} else if(state == 1) {
					born.add(c - '0');
				}
			}
		}
	}

	private class TimerListener implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			ConwayMap nextIter = new ConwayMap(grid.getSize());
			for (int r = 0; r < grid.getSize(); r++) {
				for (int c = 0; c < grid.getSize(); c++) {
					int n = grid.getNeighbors(r, c);
					//System.out.print(n);
					if (grid.isSet(r, c)) {
						//System.out.print("s");
						//boolean x = survive.contains(n);
						//System.out.print(x? "v " : "x ");
						nextIter.write(r, c, survive.contains(n));
					} else {
						//System.out.print(".");
						//boolean x = born.contains(n);
						//System.out.print(x? "v " : "x ");
						nextIter.write(r, c, born.contains(n));
						
					}
				}
				//System.out.println();
			}
			grid = nextIter;

			grid.draw(g, 0, 0, WIDTH, 600);
			
			repaint();
		}

	}

	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, getWidth(), getHeight(), null);
	}

	public static void main(String[] args) {
		JFrame frame = new JFrame("Conways Game of Life");
		frame.setSize(WIDTH, HEIGHT);
		frame.setLocation(0, 0);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setContentPane(new ConwaysGameOfLife());
		frame.setVisible(true);
	}

	@Override
	public void stateChanged(ChangeEvent e) {
		timer.setDelay(delaySlider.getMaximum() - delaySlider.getValue() + 50);
		delayDial.setValue(delaySlider.getValue());
		delayDial.draw(g, Color.white);
		repaint();
	}

}
