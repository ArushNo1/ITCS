

import java.awt.*;

public class Falcon9 extends Rocket {
	protected double deltaMass;
	protected double mass;
	protected double gravForce;
	protected double thrust;
	protected double deltaTime;
	protected double netForce;
	protected double altitude;
	protected double burnTime;
	protected double fuelConsump;
	protected double velocity = 0;
	protected double accel;
	public Stage1 sOne;
	public Stage2 sTwo;
	protected double stage = 1;
	public double groundHeight;
	protected int scale = 22500000;
	protected static final double G = 6.67 * Math.pow(10, -11);
	public static double Me = 5.98 * Math.pow(10, 24);
	protected static final double Re = 6.38 * Math.pow(10, 6);


	public double getStage() {
		return stage;
	}

	public void setStage(double stage) {
		this.stage = stage;
	}

	public double getDeltaMass() {
		return deltaMass;
	}

	public void setDeltaMass(double deltaMass) {
		this.deltaMass = deltaMass;
	}

	public double getMass() {
		return mass;
	}

	public void setMass(double mass) {
		this.mass = mass;
	}

	public double getGravForce() {
		return gravForce;
	}

	public void setGravForce(double gravForce) {
		this.gravForce = gravForce;
	}

	public double getThrust() {
		return thrust;
	}

	public void setThrust(double thrust) {
		this.thrust = thrust;
	}

	public double getDeltaTime() {
		return deltaTime;
	}

	public void setDeltaTime(double deltaTime) {
		this.deltaTime = deltaTime;
	}

	public double getNetForce() {
		return netForce;
	}

	public void setNetForce(double netForce) {
		this.netForce = netForce;
	}

	public double getAltitude() {
		return altitude;
	}

	public void setAltitude(double altitude) {
		this.altitude = altitude;
	}

	public double getBurnTime() {
		return burnTime;
	}

	public void setBurnTime(double burnTime) {
		this.burnTime = burnTime;
	}

	public double getFuelConsump() {
		return fuelConsump;
	}

	public void setFuelConsump(double fuelConsump) {
		this.fuelConsump = fuelConsump;
	}

	public double getVelocity() {
		return velocity;
	}

	public void setVelocity(double velocity) {
		this.velocity = velocity;
	}

	public double getAccel() {
		return accel;
	}

	public void setAccel(double accel) {
		this.accel = accel;
	}
	public void setScale(int scale) {
		this.scale = scale;
	}

	public Falcon9(double x, double y, int height, int width) {
		super(x, y, height, width, new Color(128, 128, 128), 2, "");
		burnTime = 162;
		fuelConsump = 398900;
		thrust = 6806000;
		altitude = 0;
		deltaTime = 0.1;
		mass = 541300;
		sOne = new Stage1(x, y, height, width);
		sTwo = new Stage2(x, y, height, width);

	}

	public void move(int edge, double time) {

		double s1y = sOne.getAltitude();
		double s1mass = 25600;
		
		if (getStage() < 3) {
			deltaMass = fuelConsump * (deltaTime / burnTime);
			mass -= deltaMass;
			gravForce = (Me * mass * G) / ((Re + altitude) * (Re + altitude));
			netForce = thrust - gravForce - calculateDrag();
			accel = netForce / mass;
			velocity += accel * deltaTime;
			altitude += velocity * deltaTime;

			if (getStage() == 1) {
				if (time <= 162) {
					sOne.setVelocity(velocity);
					sTwo.setSpeed(velocity);
				} else if (Math.floor(time) == 162) {
					s1y = altitude;
					changeStage(time);
				}
			} else if (getStage() == 2) {
				if (time < 559) {
					// sOne.setVelocity(-10);
					sTwo.setSpeed(velocity);
					
					double s1gravForce = (Me * s1mass * G) / ((Re + s1y) * (Re + s1y));
					double s1accel = 0-s1gravForce / mass;
					sOne.setVelocity(sOne.getVelocity() + s1accel * deltaTime);
					if(sOne.getAltitude() <= -25000) {
						sOne.setAltitude(-24990);
						sOne.setVelocity(0);
						sOne.par = false;
					}
					sOne.setAltitude(sOne.getAltitude() + sOne.getVelocity() * deltaTime);
					if(sOne.getVelocity() <= -705) {
						sOne.par = true;
					}
					
				} else if (Math.floor(time) >= 559) {
					changeStage(time);
				}
			}

			sOne.move();
			sTwo.move();

			setY(edge * (1 - altitude / scale) - getHeight()/2 - groundHeight);
			sOne.setY(edge * (1 - sOne.getAltitude() / scale) - getHeight()/2 - groundHeight);
			sTwo.setY(edge * (1 - sTwo.getAltitude() / scale) - getHeight()/2 - groundHeight);
		}
	
	}

	public void draw(Graphics g) {
		sTwo.draw(g);
		sOne.draw(g);

	}
	public void draw2(Graphics g) {
		super.draw(g);
	}

	public void changeStage(double time) {
		if (getStage() == 1) {

			setStage(2);
			burnTime = 397;
			mass = 96750;
			fuelConsump = 92670;
			thrust = 934000;
			

			
			sOne.flame = false;
			sOne.up = false;
			sOne.setVelocity(100);
		}else if (getStage() == 2 && time > 172) {
			setStage(3);
			
			deltaTime = 0;
			deltaMass = 0;
			Me = 0;
			thrust = 0;
			mass = 3900;
		}
	}

	public double calculateDrag() {
		double temperature = 288.706 + altitude * 9.8 / 1000;
		if(temperature < 0) temperature = 0;
		double gasConstant = 8.31446261815324;
		double airPressure = 101325 * Math.pow((1- 2.25577e-5 * altitude),5.25588);
		if(airPressure < 1) airPressure = 1;
		double molarMass_air = 0.0289652;
		Double airDensity = (airPressure * molarMass_air)/(gasConstant * temperature);
		if(airDensity.isNaN()) airDensity = 1.2066645023946743E-5;
		double dragCoef = 0.342;
		double area = 10.752100856911069;
		double dragForce = airDensity * dragCoef * area * 1/2 * velocity * velocity;
		return dragForce;
	}
}
