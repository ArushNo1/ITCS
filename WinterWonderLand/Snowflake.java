import java.awt.*;
public class Snowflake {
	int x;
	int y;
	int size;
	Color col;
	public Snowflake(int ax, int ay, int asize, Color acolor) {
		x = ax;
		y = ay;
		size = asize;
		col = acolor;
	}
	
	public void draw(Graphics g) {
		g.setColor(col);
		g.fillOval(x, y, size, size);
		g.drawLine(x, y, x+size, y+size);
		g.drawLine(x+size, y, x, y+size);
	}
}
