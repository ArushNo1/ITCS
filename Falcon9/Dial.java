import java.awt.*;

public class Dial {

	private int x;
	private int y;
	private int r;
	private double min;
	private double max;
	public boolean full;
	private double maxangle;
	private double minangle;

	public Dial(int xPos, int yPos, int radius, double minimum, double maximum, boolean full1) {
		x = xPos;
		y = yPos;
		r = radius;
		min = minimum;
		max = maximum;
		full = full1;
		maxangle = (full) ? 215 : 150;
		minangle = (full) ? -35 : 30;
	}

	public void draw(Graphics g, double val, Color resetColor) {
		g.setFont(new Font("Bank gothic light bt", Font.PLAIN, (int)(r * 15/100)));
		val = (val - min) / (max - min);
		double angle = (full) ? 215 - (val * 250) : 150 - (val * 120);
		g.setColor(new Color(20, 20, 20));
		if (full) {
			g.fillOval(x - r, y - r, 2 * r, 2 * r);
		} else {
			g.fillArc(x - r, y - r, 2 * r, 2 * r, 0, 180);
		}
		g.setColor(new Color(50, 50, 50));
		if (full) {
			g.fillOval(x - r * 7 / 8, y - r * 7 / 8, r * 7 / 4, r * 7 / 4);
		} else {
			g.fillArc(x - r * 7 / 8, y - r * 29 / 32, r * 7 / 4, r * 26 / 16, 0, 180);
		}
		g.setColor(new Color(255, 50, 50));
		int shortr = r / 8;
		int longr = r * 6 / 8;
		double anglePlus = angle + 155;
		double angleMinus = angle - 155;
		int[] xs = { (int) (x + (shortr) * Math.cos(Math.toRadians(anglePlus))),
				(int) (x + (shortr) * Math.cos(Math.toRadians(angleMinus))),
				(int) (x + longr * Math.cos(Math.toRadians(angle))) };
		int[] ys = { (int) (y - (shortr) * Math.sin(Math.toRadians(anglePlus))),
				(int) (y - (shortr) * Math.sin(Math.toRadians(angleMinus))),
				(int) (y - longr * Math.sin(Math.toRadians(angle))) };
		g.fillPolygon(xs, ys, xs.length);

		longr = r * 7 / 8;
		shortr = r * 13 / 16;
		int shorterr = r * 11 / 16;
		int counter = 0;
		g.setColor(new Color(230, 230, 230));
		for (int i = (int) minangle; i <= (int) maxangle; i += 10) {
			int[] xs1 = { (int) (x + (shortr) * Math.cos(Math.toRadians(i + 1))),
					(int) (x + (shortr) * Math.cos(Math.toRadians(i - 1))),
					(int) (x + longr * Math.cos(Math.toRadians(i - 1))),
					(int) (x + longr * Math.cos(Math.toRadians(i + 1))) };
			int[] ys1 = { (int) (y - (shortr) * Math.sin(Math.toRadians(i + 1))),
					(int) (y - (shortr) * Math.sin(Math.toRadians(i - 1))),
					(int) (y - longr * Math.sin(Math.toRadians(i - 1))),
					(int) (y - longr * Math.sin(Math.toRadians(i + 1))) };
			g.fillPolygon(xs1, ys1, xs1.length);
			int num = (full) ? 5 : 4;
			if (counter % num == 0) {
				int[] xs2 = { (int) (x + (shorterr) * Math.cos(Math.toRadians(i + 1))),
						(int) (x + (shorterr) * Math.cos(Math.toRadians(i - 1))),
						(int) (x + longr * Math.cos(Math.toRadians(i - 1))),
						(int) (x + longr * Math.cos(Math.toRadians(i + 1))) };
				int[] ys2 = { (int) (y - (shorterr) * Math.sin(Math.toRadians(i + 1))),
						(int) (y - (shorterr) * Math.sin(Math.toRadians(i - 1))),
						(int) (y - longr * Math.sin(Math.toRadians(i - 1))),
						(int) (y - longr * Math.sin(Math.toRadians(i + 1))) };
				g.fillPolygon(xs2, ys2, xs2.length);
			}
			counter++;
		}
		int yval = (full) ? y + r * 10 / 16 : y - r / 8;
		int rval = (full) ? r * 9 / 16 : r * 13 / 16;
		int mintemp = (int) Math.floor(min) ;
		int maxtemp = (int) Math.ceil(max) ;
		String mins = "";
		String maxs = "";
		String suffixes = "kmbtqQsSon";
		counter = 0;
		while(mintemp > 1000){
			mins = suffixes.charAt(counter) + "";
			counter++;
			mintemp /= 1000;
		}
		counter = 0;
		while(maxtemp > 1000){
			maxs = suffixes.charAt(counter) + "";
			counter++;
			maxtemp /= 1000;
		}
		int num = (counter > 0)? 0 : (int)(r * 15/100);
		g.drawString(mintemp + "" + mins, x - rval, yval);
		g.drawString(maxtemp + "" + maxs, x + ((rval) - ((int) (Math.log10(maxtemp) + 1) * (int)(r * 15/100)) + num), yval);
		if(!full) {
			g.setColor(new Color(20,20,20));
			g.fillRect(x-r* 3/4, y - r * 23/256 , r * 3 / 2, r * 22/256);
			g.setColor(resetColor);
			g.fillRect(x-r* 3/4, y , r * 3 / 2, r * 3/32);
		}
	}
}
