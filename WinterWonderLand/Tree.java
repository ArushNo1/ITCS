import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Tree {
	int x;
	int y;
	Color lcolor;
	Color tcolor;
	int W;
	int H;
	boolean up = true;
	public Tree(int ax, int ay, int aW, int aH, Color acol, Color bcol, boolean aup) {
		x = ax;
		y = ay;
		W = aW;
		H = aH;
		lcolor = acol;
		tcolor = bcol;
		up = aup;
	}
	public void draw(Graphics g) {
		Random rand = new Random();
		
		g.setColor(tcolor);
		for(int i = 0; i < 20; i++) {
			g.fillRect(x+i, y, (int) (W*.2)-i*2, H);
			if(i%2 == 0) {
				tcolor = tcolor.brighter();
			}else {
				tcolor = tcolor.darker();
			}
			g.setColor(tcolor);
		}
		g.setColor(lcolor);
		
		
		int inc = (H/20);
		int twid = (int)(W/5.0);
		
		float factor;
		
		for(int k = 0; k < 10; k++) {
			factor = (float) (1.2f * Math.pow((.8),k));
			for(int i = y; i < H*0.9 + y; i += inc) {
				float f1 = rand.nextFloat(0.1f,0.3f);
				int[] xs = {x + (int)(W*f1*factor) + twid, x+twid, x+(int)(twid*0.1)};
				int[] ys = {i, i- 20, i - 15};
				g.fillPolygon(xs,ys,xs.length);
				factor *= 1.08f;
			}
			
			if(k % 2 == 0) {
				lcolor =lcolor.brighter();
			}else {
				lcolor = lcolor.darker();
			}
			g.setColor(lcolor);
			factor *= .8f;
		}
		for(int k = 0; k < 10; k++) {
			factor = (float) (1.2f * Math.pow((.8),k));
			for(int i = y; i < H*0.9 + y; i += inc) {
				float f1 = rand.nextFloat(0.1f,0.3f);
				int[] xs = {x - (int)(W*f1*factor) + twid, x, x+(int)(twid*0.9)};
				int[] ys = {i, i- 20, i - 15};
				g.fillPolygon(xs,ys,xs.length);
				factor *= 1.08f;
			}
			
			if(k % 2 == 0) {
				lcolor =lcolor.brighter();
			}else {
				lcolor = lcolor.darker();
			}
			g.setColor(lcolor);
			factor *= .8f;
		}
		
		
	}
}
