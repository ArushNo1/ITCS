import java.awt.*;

public class Stage1{

	private double x;
	private double y;
	private int width;
	private int height;
	public boolean up;
	public boolean flame;
	public boolean par;
	private double velocity = 0;
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

	public double getVelocity() {
		return velocity;
	}

	public void setVelocity(double velocity) {
		this.velocity = velocity;
	}
	public void setAltitude(double altitude) {
		this.altitude = altitude;
	}
	public double getAltitude() {
		return altitude;
	}

	public Stage1(double ax, double ay, int aheight, int awidth) {
		x = ax;
		y = ay;
		height = aheight;
		width = awidth;
		up = true;
		flame = true;
		par = false;
		altitude = 0;
	}
	
	public void draw(Graphics g) {
		
		int x = (int)this.x;
		int y = (int)this.y;
		int w = (int)this.width;
		int h = (int)this.height;
		g.setColor(new Color(235,235,235));
		g.fillRect(x-5*w/16, y-h/8, w*11/16, h*5/8);
		g.setColor(new Color(150,150,150));
		g.drawLine(x-w*5/16, y, x+w*5/16, y);
		g.fillRect(x-w*5/16, y-h/8, w*11/16, h*1/32);
		g.setColor(new Color(235,235,235));
		//g.fillRect(x-w*7/32, y-h*127/1024, w*16/32, h*1/16);
		
		int[] xs = {x-w*7/32    , x+w*9/32   ,x+w*4/32, x-w*4/32};
		int[] ys = {y-h*127/1024,y-h*127/1024,y-h*1/16, y-h*1/16};
		g.fillPolygon(xs, ys, xs.length);
		g.setColor(new Color(120,120,120));
		int[] xs1 = {x-w*5/16,x, x-w*5/16};
		int[] ys1 = {y+h*3/8, y+h/2, y+h/2};
		g.fillPolygon(xs1,ys1,xs1.length);
		int[] xs2 = {x+w*5/16,x, x+w*5/16};
		int[] ys2 = {y+h*3/8,  y+h/2, y+h/2};
		g.fillPolygon(xs2,ys2,xs2.length);
		g.setColor(new Color(70,70,70));
		int[] xs3 = {x-w*1/8,x+w*1/8,x+w*3/16,x-w*3/16};
		int[] ys3 = {y+h/2,y+h/2,y+h*33/64,y+h*33/64};
		g.fillPolygon(xs3,ys3,xs3.length);
		if(flame) {
			drawFire(g);
		}
		if(par) {
			drawParachute(g);
		}
	}
	public void drawParachute(Graphics g) {
		int x = (int)this.x;
		int y = (int)this.y;
		g.setColor(Color.black);
		g.drawLine(x, y-height/8, x-width, y-height*3/8);
		g.drawLine(x, y-height/8, x+width, y-height*3/8);
		g.setColor(new Color(227, 252, 255));
		g.fillArc(x-width, y-height*4/8, width*2, height/4, 0, 180);
	}
	public void drawFire(Graphics g) {
		int x = (int)this.x;
		int y = (int)this.y;
		int h = this.height;
		int w = width;
		double rand = Math.random()*200-100;
		if(up) {
			rand += velocity;
			rand /= 1050;
		}else {
			rand -= velocity;
			rand /= 310;
		}
		g.setColor(new Color(230, 72, 48));
		int[] x1 = {x-w/4+w/16, x+w/4-w/16, x};
		int[] y1 = {y+(h*33/64), y+(h*33/64), (int) (y+(h*33/64 + h*2/6*rand))};
		g.fillPolygon(x1,y1,x1.length);
		g.setColor(new Color(250, 159, 40));
		int[] x2 = {x-w/6+w/16, x+w/6-w/16, x};
		int[] y2 = {y+(h*33/64), y+(h*33/64), (int) (y+(h*33/64 + h*1/4*rand))};
		g.fillPolygon(x2,y2,x2.length);
	} 
	
	public void move() {
		altitude += velocity;
	}

}
