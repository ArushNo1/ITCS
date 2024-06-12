
//Arush Bodla Block five
//Collaborated with Arnav Gupta 
import java.awt.*;

public class FalconHeavy extends Falcon9 {
	public double groundHeight;
	private static final double G = 6.67 * Math.pow(10, -11);
	public static double Me = 5.98 * Math.pow(10, 24);
	private static final double Re = 6.38 * Math.pow(10, 6);




	public FalconHeavy(double x, double y, int height, int width) {
		super(x, y, height, width);
		burnTime = 187;
		fuelConsump = 950000;
		thrust = 20520000;
		altitude = 0;
		deltaTime = 0.1;
		mass = 1420788;
	}

	public void move(int edge, double time) {


			deltaMass = fuelConsump * (deltaTime / burnTime);
			mass -= deltaMass;
			gravForce = (Me * mass * G) / ((Re + altitude) * (Re + altitude));
			netForce = thrust - gravForce;
			accel = netForce / mass;
			velocity += accel * deltaTime;
			altitude += velocity * deltaTime;

			
			setY(edge * (1 - altitude / 220000) - getHeight()/2 - groundHeight);
		
	
	}

	public void draw(Graphics g) {
		super.draw2(g);

	}


}