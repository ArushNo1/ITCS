import java.awt.Color;
import java.awt.Graphics;
import java.math.BigInteger;
import java.util.Arrays;

public class ConwayMap {
	private long[] rows;
	private int size;
	private Color offColor = new Color(102, 102, 102);
	private Color onColor = new Color(7, 225, 102);
	private Color lineColor = new Color(225, 225, 225);
	private int xWidth;
	private int yWidth;
	
	public int getSize() {
		return size;
	}
	
	public void setSize(int s) {
		if(s > rows.length) {
			long[] r2 = Arrays.copyOf(rows, s);
			rows = r2;
		}
		size = s;
	}
	
	public int getXWidth() {
		return xWidth;
	}
	public int getYWidth() {
		return yWidth;
	}
	
	public ConwayMap(int size) {
		rows = new long[size];
		this.size = size;
	}
	public ConwayMap(ConwayMap other) {
		this.size = other.size;
		rows = other.rows.clone();
	}
	public ConwayMap() {
		this(64);
	}
	
	public void set(int r, int c) {
		if(r >= size || r < 0 || c >= size || c < 0) {
			System.out.println("out of bounds buddy :<set");
			return;
		}
		rows[r] |= (1 << c);
	}
	public void unset(int r, int c) {
		if(r >= size || r < 0 || c >= size || c < 0) {
			System.out.println("out of bounds buddy :<unset");
			return;
		}
		rows[r] &= ~(1 << c);
	}
	public void toggle(int r, int c) {
		if(r >= size || r < 0 || c >= size || c < 0) {
			System.out.println("out of bounds buddy :<toggle");
			return;
		}
		rows[r] ^= (1 << c);
	}
	public void write(int r, int c, boolean val) {
		if(val) {
			set(r, c);
		}
		else {
			unset(r, c);
		}
	}
	public boolean isSet(int r, int c) {
		if(r >= size || r < 0 || c >= size || c < 0) {
			System.out.println("out of bounds buddy :<isset");
			return false;
		}
		return ((getRow(r) >> c) & 1) != 0;
	}
	
	
	public long getRow(int r) {
		if(r >= size || r < 0) {
			System.out.println("out of bounds buddy :<");
			return 0;
		}
		return rows[r];
	}
	
	public void printGrid(int size) {
		//System.out.println(Long.toBinaryString(x));
		for(int r = 0; r < size; r++) {
			long row = getRow(r);
			for(int c = 0; c < size; c++) {
				System.out.print(row % 2);
				row /= 2;
			}
			System.out.println();
		}
	}
	public void printGrid() {
		//System.out.println(Long.toBinaryString(x));
		for(int r = 0; r < size; r++) {
			long row = getRow(r);
			for(int c = 0; c < size; c++) {
				System.out.print(row % 2);
				row /= 2;
			}
			System.out.println();
		}
	}
	
	public void draw(Graphics g, int x1, int y1, int x2, int y2) {
		xWidth = (x2 - x1) / size;
		yWidth = (y2 - y1) / size;
		g.setColor(offColor);
		g.fillRect(x1, y1, size * xWidth, size * yWidth);
		
		g.setColor(onColor);
		for(int r = 0; r < size; r++) {
			long curRow = getRow(r);
			for(int c = 0; c < size; c++) {
				if(curRow % 2 != 0) {
					g.fillRect(x1 + xWidth * c, y1 + yWidth * r, xWidth, yWidth);
				}
				curRow /= 2;
			}
		}
		
		g.setColor(lineColor);
		for(int i = 0; i < size + 1; i++) {
			g.drawLine(x1 + xWidth * i, y1, x1 + xWidth * i, y1 + yWidth * size);
			g.drawLine(x1, y1 + yWidth * i, x1 + xWidth * size, y1 + yWidth * i);
		}
	}

	public int getNeighbors(int r, int c) {
		int n = 0;
		if(r > 0) {
			n += isSet(r - 1, c) ? 1 : 0;
			if(c > 0) {
				n += isSet(r - 1, c - 1) ? 1 : 0;
			}
			if(c < size - 1) {
				n += isSet(r - 1, c + 1) ? 1 : 0;
			}
		}
		if(r < size - 1) {
			n += isSet(r + 1, c) ? 1 : 0;
			if(c > 0) {
				n += isSet(r + 1, c - 1) ? 1 : 0;
			}
			if(c < size - 1) {
				n += isSet(r + 1, c + 1) ? 1 : 0;
			}
		}
		if(c > 0) {
			n += isSet(r, c - 1) ? 1 : 0;
		}
		if(c < size - 1) {
			n += isSet(r, c + 1) ? 1 : 0;
		}
		return n;
	}
	
	
	
}
