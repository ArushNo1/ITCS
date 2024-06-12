import java.awt.Color;
import java.awt.Graphics;

public class Stage2{

	private double x;
	private double y;
	private int width;
	private int height;
	private double speed;
	private boolean flame;
	private double altitude;
	
	public double getX() {
		return x;
	}

	public void setX(double x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	public void setY(double y) {
		this.y = y;
	}

	public double getSpeed() {
		return speed;
	}

	public void setSpeed(double speed) {
		this.speed = speed;
	}
	public void setAltitude(double altitude) {
		this.altitude = altitude;
	}
	public double getAltitude() {
		return altitude;
	}

	public Stage2(double ax, double ay, int aheight, int awidth) {
		x = ax;
		y = ay;
		height = aheight;
		width = awidth;
		flame = true;
	}
	
	public void draw(Graphics g) {
		int x = (int)this.x;
		int y = (int)this.y;
		int w = (int)this.width;
		int h = (int)this.height;
		g.setColor(new Color(235,235,235));
		g.fillRect(x-w*5/16, y-h*5/16, w*11/16, h*6/32);
		g.setColor(new Color(150,150,150));
		g.drawLine(x-w*5/16, y-h/4, x+w*5/16, y-h/4);
		int[] xs = {x-w*5/16,x-w/2, x+w/2, x+w*5/16};
		int[] ys = {y-h*5/16,y-h*21/64, y-h*21/64, y-h*5/16};
		g.fillPolygon(xs,ys,xs.length);
		g.setColor(new Color(235,235,235));
		g.fillRect(x-w/2, y-h*29/64, w, h*1/8);
		g.fillArc(x-w/2, y-h*35/64, w, h*3/16, 0, 180);
		
		g.setColor(new Color(70,70,70));
		int[] xs3 = {x-w*1/8,x+w*1/8,x+w*3/16,x-w*3/16};
		int[] ys3 = {y-h/8,y-h/8,y-h*7/64,y-h*7/64};
		g.fillPolygon(xs3,ys3,xs3.length);
		
		if(flame) {
			drawFire(g);
		}
	}
	
	public void drawFire(Graphics g) {
		int x = (int)this.x;
		int y = (int)this.y;
		int h = this.height;
		int w = width;
		double rand = 0;
		for(int i = 0; i < 10; i ++) {
		rand = Math.random()*100-50;
			rand += speed;
			rand /= 7050;
		}
		g.setColor(new Color(230, 72, 48));
		int[] x1 = {x-w/4+w/16, x+w/4-w/16, x};
		int[] y1 = {y-(h*7/64), y-(h*7/64), (int) (y+(h*-7/64 + h*2/6*rand))};
		g.fillPolygon(x1,y1,x1.length);
		g.setColor(new Color(250, 159, 40));
		int[] x2 = {x-w/6+w/16, x+w/6-w/16, x};
		int[] y2 = {y-(h*7/64), y-(h*7/64), (int) (y+(h*-7/64 + h*1/4*rand))};
		g.fillPolygon(x2,y2,x2.length);
	} 
	
	public void move() {
		altitude += speed;
	}

}