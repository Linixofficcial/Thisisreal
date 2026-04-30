using System;

namespace AircraftCalculations
{
    public class Yak130Aerodynamics
    {
        // Constants for calculations
        private const double AirDensity = 1.225; // kg/m^3 at sea level
        private const double WingArea = 27.0; // m^2, approximate for Yak-130
        private const double LiftCoefficient = 2.5; // assumed at certain angle of attack
        private const double DragCoefficient = 0.03; // assumed

        public (double liftForce, double dragForce, double thrust, double aileronDeflection, double flapDeflection, double rudderYawDeflection, double rudderPitchDeflection) CalculateAircraftCharacteristics(double speed, double altitude, double angle)
        {
            // Calculate air density at altitude (simplified, not using exact altitude equation)
            double densityAtAltitude = AirDensity * Math.Pow(1 - (0.0065 * altitude / 288.15), 4.256);

            // Lift force calculation
            double liftForce = 0.5 * densityAtAltitude * Math.Pow(speed, 2) * WingArea * LiftCoefficient;

            // Drag force calculation
            double dragForce = 0.5 * densityAtAltitude * Math.Pow(speed, 2) * WingArea * DragCoefficient;

            // Thrust calculation (simple assumption)
            double thrust = liftForce * 0.85; // assume thrust to lift ratio

            // Control surface deflections (dummy values for example)
            double aileronDeflection = 5.0; // Degrees
            double flapDeflection = 10.0; // Degrees
            double rudderYawDeflection = 3.0; // Degrees
            double rudderPitchDeflection = 2.0; // Degrees

            return (liftForce, dragForce, thrust, aileronDeflection, flapDeflection, rudderYawDeflection, rudderPitchDeflection);
        }
    }
}