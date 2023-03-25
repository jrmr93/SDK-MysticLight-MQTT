using System;

namespace MysticLightController
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LightController controller = new LightController("2");
            Console.WriteLine("Se encontraron " + controller.Devices.Length + " dispositivos");
            int i = 0;
            foreach (string dev in controller.Devices)
            {

                Console.WriteLine("-Dispositivo: " + dev + " :" + i);

                foreach (LED l in controller.GetAllLEDs())
                {
                    Console.WriteLine("     -" + l.Device + "LED: " + l.Identifier);
                }
                i++;
            }

            while (true)
            {
                Console.WriteLine("Ingrese el numero de dispositivo:");
                int dis = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de led:");
                uint ld = uint.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el valor ROJO:");
                uint eR = uint.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el valor VERDE:");
                uint eG = uint.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el valor AZUL:");
                uint eB = uint.Parse(Console.ReadLine());
                string device = controller.Devices[dis];
                Color color = new Color(eR, eG, eB);
                controller.SetLedStyle(device, ld, "Steady");
                controller.SetLedColor(device, ld, color);
                LED led = controller.GetDeviceLED(device, ld);
                Console.WriteLine(led.ToString());
            }

        }
    }
}
