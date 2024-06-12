import java.awt.*;
import java.util.Random;

public class SnowBoulder {
	int x;
	int y;
	int size;
	Random rand = new Random();
	
	public SnowBoulder(int ax, int ay, int asize) {
		x = ax;
		y = ay;
		size = asize;
	}
	
	public void draw(Graphics g) {
		//195,166,224
		//78,86,177
		double num = Math.abs((y-400)/200.0);
		double movement = size/5.0;
		double factor = size/10;
		for(int i = y; i < size+y; i++) {
			int r = (int)(215-107*num), G = (int)(186-70*num), b = (int)(234-37*num);
			double num1 = rand.nextDouble(.88,.92);
			r*=num1;
			G*=num1;
			b*=num1;
			double colfac = 1;
			for(int k = (int)(x-movement); k < (int)(x+movement); k++) {
				r *= colfac;
				G *= colfac;
				b *= colfac;
				if(r > 255 || G > 255 || b > 255) {r = rand.nextInt(240,256); G = rand.nextInt(240,256); b = rand.nextInt(240,256);}
				else if(r < 0 || G < 0 || b < 0) {r = 0; G = 0; b = 0;}
				
				g.setColor(new Color(r,G,b));
				g.fillRect(k, i, 1, 1);
				double num2 = rand.nextDouble(-0.002,.005);
				if(k < x-movement/6) {
					colfac += num2;
				}else {
					colfac -= num2;
				}
			}
			double temp = rand.nextDouble(0.8*factor,1.2*factor);
			movement += temp;
			factor *= 0.8;
			
		}
		 
		 
	}
}
