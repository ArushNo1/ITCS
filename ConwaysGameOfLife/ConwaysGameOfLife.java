

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.*;
import javax.swing.Timer;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import java.util.*;

@SuppressWarnings("serial")

public class ConwaysGameOfLife extends JPanel {
	@SuppressWarnings("unused")

	private Random rand = new Random();
	private static final int WIDTH = 600;
	private static final int HEIGHT = 700;
	static Color bg = new Color(50, 50, 50);


	private BufferedImage image;
	@SuppressWarnings("unused")

	private Graphics g;
	private Timer timer;
	private JSlider delaySlider;
	private Dial delayDial;
	private JButton start;
	private JSlider sizeSlider;

	private ConwayMap grid;
	private ArrayList<Integer> born;
	private ArrayList<Integer> survive;

	public ConwaysGameOfLife() {
		image =  new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
		g = image.getGraphics();
		
		g.setColor(bg);
		g.fillRect(0, 0, WIDTH, HEIGHT);
		grid = new ConwayMap(16);
		grid.draw(g, 0, 0, WIDTH, 600);
		
		setLayout(null);
		delaySlider = new JSlider(0, 500, 250);
		delaySlider.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				timer.setDelay(delaySlider.getMaximum() - delaySlider.getValue() + 50);
				delayDial.setValue(delaySlider.getValue());
				delayDial.draw(g, bg);
				repaint();
			}
		});		
		delaySlider.setBounds(25, 625, 100, 25);
		add(delaySlider);
		delayDial = new Dial(75, 658, 50, 0, 500, false);
				
		sizeSlider = new JSlider(4, 64, 16);
		sizeSlider.addChangeListener(new ChangeListener() {
			@Override
			public void stateChanged(ChangeEvent e) {
				int value = sizeSlider.getValue();
				grid.setSize(value);
				g.setColor(bg);
				g.fillRect(0, 0, WIDTH, HEIGHT);
				delayDial.draw(g, bg);
				grid.draw(g, 0, 0, WIDTH, 600);
				repaint();
			}
		});
		sizeSlider.setBounds(425, 625, 100, 25);
		add(delaySlider);
		
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
		delaySlider.getChangeListeners()[0].stateChanged(null);
		this.addMouseListener(new MouseListener() {
			@Override
			public void mouseClicked(MouseEvent e) {
				System.out.println(e.getX() + ", " + e.getY());
				if(!timer.isRunning() && e.getY() <= 580) {
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
				
			}
			public void mouseReleased(MouseEvent e) {
				
			}
			public void mouseEntered(MouseEvent e) {
				
			}
			@Override
			public void mouseExited(MouseEvent e) {
				
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
			g.setColor(bg);
			g.fillRect(0, 0, WIDTH, HEIGHT);
			delayDial.draw(g, bg);
			
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

}
