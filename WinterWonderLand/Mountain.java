import java.util.Random;
import java.awt.*;

public class Mountain {
	double colFactor;
	int x;
	int y;
	int leftBound;
	int rightBound;
	int upperBound;
	int lowerBound;
	double fac;
	Random rand = new Random();
	
	public Mountain(int lb, int rb, int ub, int db, double afc) {
		leftBound = lb;
		rightBound = rb;
		upperBound = ub;
		lowerBound = db;
		fac = afc;
		
		
		
	}
	
	public void draw(Graphics g) {
		int c = 0;
		for(int i = upperBound; i < lowerBound; i++) {
			double whiteness = Math.abs(lowerBound-i);
			whiteness /= 100;
			whiteness = Math.pow(whiteness, 5);
			for(int k = leftBound; k <= rightBound; k+=2) {
				colFactor = Math.pow(.995, c);
				double tempfactor = rand.nextDouble(0.8,1.1);
				colFactor *= tempfactor;
				int r =  (int)(200*colFactor-20+whiteness) ,G = (int)(200*colFactor-20+whiteness) ,b= (int)(200*colFactor+whiteness);
				if (r > 255 || G > 255 || b > 255) {
					r = 255;
					G = 255;
					b = 255;
				} else if(b < 0) {
					r = 0;
					G = 0;
					b = 0;
				}
				g.setColor(new Color(r,G,b));
				g.fillRect(k, i, 5, 5);
				//x+=50;
			}
			double tempfactor = rand.nextDouble(.9998,fac);
			rightBound *= tempfactor;
			tempfactor = rand.nextDouble(.996,1.002);
			leftBound *= tempfactor;
			c++;
			
		}
	}
}
