import java.awt.*;
import java.util.Random;


import javax.swing.JFrame;
import javax.swing.JPanel;


public class WinterScene extends JPanel{
	public static int width = 800;
	public static int height = 600;
	public static Random rand = new Random();
	
	public void paintComponent (Graphics g)	{
		
		gradientBackground(g);
		drawMountains(g);
		g.setColor(new Color(209,171,220));
		g.fillRect(0, 395, 800, 400);
		drawForest(g);
		drawSnow(g);
		drawHouse(g);
		drawBoulders(g);
		g.drawLine(1,1,10,10);
		g.setColor(Color.black);
		g.setFont(new Font("Kartika", Font.BOLD, 5));
		g.drawString("This ruins the picture", 0, 390);
		
		
	}
	public static void gradientBackground(Graphics g) {
		// convert g into a graphics2d object
		Graphics2D g2D = (Graphics2D) g;
		GradientPaint blueToOrange = new GradientPaint(0, 0, new Color(80, 104, 220), 100, 500, new Color(251, 181, 102));
		g2D.setPaint(blueToOrange);
		g2D.fillRect(0, 0, width, height);
	}
	public static void drawForest(Graphics g) {
		for(int i = 400; i < 500; i += rand.nextInt(5,50)) {
			int y = rand.nextInt(250,350);
			Tree cooltree = new Tree(i, y, rand.nextInt(15,30), Math.abs(y-400), new Color(25,40,24), new Color(49,24,26),false);
			cooltree.draw(g);
		}
		for(int j = 500; j < 800; j += rand.nextInt(15,50)) {
			int y = rand.nextInt(100,250);
			Tree cooltree = new Tree(j, y, rand.nextInt(30,50), (int)(Math.abs(y-400)*rand.nextDouble(0.9,1.1)), new Color(15,30,14), new Color(39,14,16),false);
			cooltree.draw(g);
		}
		for(int j = 500; j < 800; j += rand.nextInt(20,60)) {
			int y = rand.nextInt(125,250);
			Tree cooltree = new Tree(j, y, rand.nextInt(30,50), (int)(Math.abs(y-400)*rand.nextDouble(0.9,1.1)), new Color(25,40,24), new Color(49,24,26),false);
			cooltree.draw(g);
		}
		
		for(int j = 500; j < 800; j += rand.nextInt(25,70)) {
			int y = rand.nextInt(150,250);
			Tree cooltree = new Tree(j, y, rand.nextInt(50,60), (int)(Math.abs(y-450)*rand.nextDouble(0.9,1.1)), new Color(35,50,34), new Color(59,34,36),false);
			cooltree.draw(g);
		}
		
		
	}
	public static void drawHouse(Graphics g) {

		g.setColor(new Color(216,42,20));
		int[] xs = {400, 440, 500, 500, 490, 467, 450, 445, 422, 395, 400};
		int[] ys = {400, 408, 395, 375, 349, 350, 370, 370, 340, 375, 375};
		g.fillPolygon(xs,ys,xs.length);
		
		g.setColor(new Color(69,13,0));
		Triangle(g,422,345,416,353,429,355);
		Triangle(g,415,355,404,368,415,369);
		Triangle(g,430,356,431,371,441,372);
		Diamond(g, 415, 363, 422, 370, 430, 363, 422, 356);
		Diamond(g, 404, 370, 404, 397, 410, 398, 410, 371);
		Diamond(g, 434, 374, 434, 404, 440, 405, 440, 375);
		Triangle(g,467,357,452,376,466,373);
		Triangle(g,487,353,486,372,495,370);
		Diamond(g, 470, 356, 470, 399, 484, 396, 484, 354);
		Diamond(g, 452, 379, 452, 403, 466, 400, 466, 376);
		Diamond(g, 487, 374, 487, 395, 496, 393, 496, 372);
		
		g.setColor(Color.black);
		Diamond(g, 414, 380, 414, 400, 430, 403, 430, 383);
		g.fillOval(413, 373, 16, 20);
		
		g.setColor(new Color(217,181,228));
		Septagon(g,385,410,390,400,440,404,510,390,515,400,530,410,440,425);
		Hexagon(g,395,373,422,339,445,370,445,365,422,334,395,368);
		
		g.setColor(new Color(193,158,210));
		Diamond(g,422,334,445,345,450,365,445,365);
		
		g.setColor(new Color(159,129,174));
		Diamond(g,445,365,450,365,450,370,445,370);
		
		g.setColor(new Color(192,157,203));
		Hexagon(g, 450, 370, 467, 350, 490, 349, 492, 345, 467, 345, 450, 365);
		
		g.setColor(new Color(217,179,228));
		Hexagon(g, 450, 365, 450, 365, 467, 345 , 492, 345 , 471, 337 ,445,345);
		
		
		
	}
	public static void drawMountains(Graphics g) {
		Mountain m1 = new Mountain(300,300,200,500,1.0074);
		m1.draw(g);
		Mountain m2 = new Mountain(100,100,100,450,1.015);
		m2.draw(g);
		
		
	}
	public static void drawSnow(Graphics g) {
		for(int i = 395; i < 600; i++) {
			double num = Math.abs((i-400)/200.0);
			for(int k = 0; k < 800; k++) {
				int r = (int)(195-107*num), G = (int)(166-70*num), b = (int)(224-37*num);
				double num1 = rand.nextDouble(.95,1.05);
				r*=num1;
				G*=num1;
				b*=num1;
				if(r > 255 || G > 255 || b > 255 || r < 0 || G < 0 || b < 0) {r = (int)(195-107*num); G = (int)(166-70*num); b = (int)(224-37*num);}
				g.setColor(new Color(r,G,b));
				g.fillOval(k,i,10,10);
			}
		}
		
		
		
	}
	
	public static void drawBoulders(Graphics g) {
		g.setColor(new Color(38,30,31));
		for(int i = 0; i < 20; i ++) {
			int x = rand.nextInt(800);
			int y = rand.nextInt(400,600);
			int s = rand.nextInt(10,23);
			int r = 0;
			if(x < 400 || x > 500 || y > 420) {
				SnowBoulder one = new SnowBoulder(x,y,s);
				one.draw(g);
			}
			if(s > 20) {
				r = rand.nextInt(3);
			}
			else if(s > 15) {
				r = rand.nextInt(2);
			}
			for(int i1 = 0; i1 < r; i1++) {
				int x2 = x + rand.nextInt(-1*s, s);
				if(x2 < 400 || x2 > 500 || y > 420) {
					SnowBoulder two = new SnowBoulder(x2,y+s,s);
					two.draw(g);
				}
			}
		}
	}
	
	public static void Triangle(Graphics g, int a, int b, int c, int d, int e, int f) {
		int[] xs1 = {a,c,e};
		int[] ys1 = {b,d,f};
		g.fillPolygon(xs1, ys1, xs1.length);
	}
	public static void Diamond(Graphics g, int a, int b, int c, int d, int e, int f, int G, int h) {
		int[] xs1 = {a,c,e,G};
		int[] ys1 = {b,d,f,h};
		g.fillPolygon(xs1, ys1, xs1.length);
	}
	public static void Hexagon(Graphics g, int a, int b, int c, int d, int e, int f, int G, int h, int i, int j, int k, int l) {
		int[] xs1 = {a,c,e,G,i,k};
		int[] ys1 = {b,d,f,h,j,l};
		g.fillPolygon(xs1,ys1,xs1.length);
	}
	public static void Septagon(Graphics g, int a, int b, int c, int d, int e, int f, int G, int h, int i, int j, int k , int l, int m, int n) {
		int[] xs1 = {a,c,e,G,i,k,m};
		int[] ys1 = {b,d,f,h,j,l,n};
		g.fillPolygon(xs1, ys1, xs1.length);
	}
	
	

	public static void main(String[] args) {
		//creates a frame and sets it's properties
		JFrame frame = new JFrame("Cabin");
		frame.setSize(width, height);
		frame.setLocation(0, 0);
		
		//tells the java program to exit when the graphics window is closed
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		//put the panel on the frame and make it visible 
		frame.setContentPane(new WinterScene());
		frame.setVisible(true);

	}

}
