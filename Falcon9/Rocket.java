import java.awt.*;

public class Rocket {
	private double x;
	private double y;
	private int height;
	private int width;
	private Color color1;
	private double ySpeed;
	private boolean up = true;
	private String text;
	public Rocket(double ax, double ay, int aheight, int awidth, Color ac1, double spd, String atext) {
		setX(ax);
		setY(ay);
		setHeight(aheight);
		setWidth(awidth);
		color1 = ac1;
		ySpeed = spd;
		text = atext;
	}
	
	public void draw(Graphics g) {
		int x = (int)this.getX();
		int y = (int)this.getY();
		
		if(up) {
			drawFire(g);
		}else {
			drawParachute(g);
		}
		g.setColor(color1);
		g.fillRect(x-getWidth()/2, y-getHeight()/2, getWidth(), getHeight());
		g.setColor(Color.white);
		int[] xs = {x-getWidth()/2,x,x+getWidth()/2};
		int[] ys = {y-getHeight()/2,(int) (y-getHeight()*0.75),y-getHeight()/2};
		g.fillPolygon(xs,ys,xs.length);
		g.setColor(Color.white);
		int[] x1 = {x+getWidth()/2,x+getWidth()/2,x+(getWidth()*5)/6};
		int[] y1 = {y-getHeight()/6,y+getHeight()/2,y+getHeight()/2};
		g.fillPolygon(x1,y1,x1.length);
		int[] x2 = {x-getWidth()/2,x-getWidth()/2,x-(getWidth()*5)/6};
		int[] y2 = {y-getHeight()/6,y+getHeight()/2,y+getHeight()/2};
		g.fillPolygon(x2,y2,x2.length);
		g.setColor(new Color(56, 54, 52));
		int[] x3 = {x-getWidth()/6, x+getWidth()/6, x+getWidth()/4, x-getWidth()/4};
		int[] y3 = {y+getHeight()/2, y+getHeight()/2, y+(getHeight()*2)/3, y+(getHeight() *2)/3};
		g.fillPolygon(x3,y3,x3.length);
		int len = (text.length() > 0)? text.length() : 1;
		g.setFont(new Font("sans",Font.PLAIN,getWidth()*2/len));
		g.drawString(text, x-getWidth()/2, y);		
		
	}
	public void drawParachute(Graphics g) {
		int x = (int)this.getX();
		int y = (int)this.getY();
		g.setColor(Color.black);
		g.drawLine(x, y-getHeight()/2-getHeight()/8, x-getWidth(), y-getHeight());
		g.drawLine(x, y-getHeight()/2-getHeight()/8, x+getWidth(), y-getHeight());
		g.setColor(new Color(227, 252, 255));
		g.fillArc(x-getWidth(), y-getHeight()-getHeight()/8, getWidth()*2, getHeight()/4, 0, 180);
	}
	public void drawFire(Graphics g) {
		int x = (int)this.getX();
		int y = (int)this.getY();
		g.setColor(new Color(230, 72, 48));
		int[] x1 = {x-getWidth()/4+getWidth()/16, x+getWidth()/4-getWidth()/16, x};
		int[] y1 = {y+(2*getHeight()/3), y+(2*getHeight()/3), y+(getHeight()*5/6)};
		g.fillPolygon(x1,y1,x1.length);
		g.setColor(new Color(250, 159, 40));
		int[] x2 = {x-getWidth()/6+getWidth()/16, x+getWidth()/6-getWidth()/16, x};
		int[] y2 = {y+(2*getHeight()/3), y+(2*getHeight()/3), y+(3*getHeight()/4)};
		g.fillPolygon(x2,y2,x2.length);
	}
	public void move(int edge) {
		if(up) {
		  setY(getY() - ySpeed);
		}else {
			setY(getY() + ySpeed/2);
		}
		if(up && getY()-getHeight()/4 < -15) {
			up = false;
		}else if(!up && getY()+getHeight()/2 > edge + 15) {
			up = true;
		}
	}
	public void setSpeed(int val) {
		ySpeed = val;
	}

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

	public int getWidth() {
		return width;
	}

	public void setWidth(int width) {
		this.width = width;
	}

	public int getHeight() {
		return height;
	}

	public void setHeight(int height) {
		this.height = height;
	}
	
}
