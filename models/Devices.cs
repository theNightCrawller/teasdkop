namespace app
{
    public class Device(string deviceName)
    {
        public string DeviceName = deviceName;
        public bool IsOn = true;
        public virtual void TurnOn()
        {
            if (PowerGridControlDevice.IsGridOn)
            {
                Console.WriteLine($"{DeviceName} is turned on.");
                IsOn = true;
            }
            else
            {
                Console.WriteLine($"Power grid is off. Cannot turn on {DeviceName}.");
            }
        }

        public virtual void TurnOff()
        {
            Console.WriteLine($"{DeviceName} is turned off.");
            IsOn = false;
        }
    }

    public class TemperatureControlDevice(string deviceName) : Device(deviceName)
    {
        public int Temperature = 25;

        public void AdjustTemperature(int desiredTemperature)
        {
            if (IsOn)
            {

                Temperature = desiredTemperature;
                Console.WriteLine($"{DeviceName} is adjusting temperature to {desiredTemperature} degrees.");
            }
            else
            {
                Console.WriteLine($"{DeviceName} is off.");
            }
        }
        public void CurrentTemeparture()
        {
            if (IsOn)
            {
                Console.WriteLine($"temp is {Temperature}C");
            }
            else
            {
                Console.WriteLine($"{DeviceName} is off.");
            }
        }
    }

    public class LightingControlDevice(string deviceName) : Device(deviceName)
    {

    }

    public  class  PowerGridControlDevice(string deviceName) : Device(deviceName)
    {
        public static bool IsGridOn = true;
        public override void TurnOn()
        {
            Console.WriteLine($"{DeviceName} is turning on the power grid.");
            IsGridOn = true;
            base.TurnOn();
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{DeviceName} is turning off the power grid.");
            IsGridOn = false;
            base.TurnOff();
        }
    }


}