// ControlSurfaceManager.cs

using System;

public class ControlSurfaceManager
{
    // Properties to hold deflection angles
    public float AileronDeflection { get; private set; }
    public float FlapDeflection { get; private set; }
    public float RudderYawDeflection { get; private set; }
    public float RudderPitchDeflection { get; private set; }

    // Constructor
    public ControlSurfaceManager() {
        AileronDeflection = 0f;
        FlapDeflection = 0f;
        RudderYawDeflection = 0f;
        RudderPitchDeflection = 0f;
    }

    // Method to set aileron deflection
    public void SetAileronDeflection(float angle) {
        AileronDeflection = angle;
        Console.WriteLine($"Aileron deflected to {AileronDeflection} degrees.");
    }

    // Method to set flap deflection
    public void SetFlapDeflection(float angle) {
        FlapDeflection = angle;
        Console.WriteLine($"Flaps deflected to {FlapDeflection} degrees.");
    }

    // Method to set rudder yaw deflection
    public void SetRudderYawDeflection(float angle) {
        RudderYawDeflection = angle;
        Console.WriteLine($"Rudder yaw deflected to {RudderYawDeflection} degrees.");
    }

    // Method to set rudder pitch deflection
    public void SetRudderPitchDeflection(float angle) {
        RudderPitchDeflection = angle;
        Console.WriteLine($"Rudder pitch deflected to {RudderPitchDeflection} degrees.");
    }
}