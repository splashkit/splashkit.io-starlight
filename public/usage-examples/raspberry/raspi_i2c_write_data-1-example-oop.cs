using SplashKitSDK;

namespace RaspiI2cWriteDataExample
{
    public static class Program
    {
        public static void Main()
        {

            SplashKit.WriteLine("Testing Quad 14-segment alphanumeric display with HT16K33 I2C driver...");

            SplashKit.RaspiInit();

            int i2c_device = SplashKit.RaspiI2cOpen(1, 0x70);

            SplashKit.RaspiI2cWrite(i2c_device, 0b00100001); // Turn on system oscillator
            SplashKit.RaspiI2cWrite(i2c_device, 0b10000001); // no blink, display on
            SplashKit.RaspiI2cWrite(i2c_device, 0b11100011); // lower brightness

            // clear display
            for (int i = 0; i < 16; i++)
            {
                SplashKit.RaspiI2cWrite(i2c_device, i, 0, 2);
            }

            string message = "HELLO WORLD FROM SPLASHKIT";
            string text = "    " + message + "    ";

            for (int i = 0; i < text.Length - 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    SplashKit.RaspiI2cWrite(i2c_device, j * 2, SplashKit.GetAlphaFont14Seg(text[i + j]), 2);
                }
                SplashKit.Delay(200);
            }

            // Turn off LED device
            SplashKit.RaspiI2cWrite(i2c_device, 0b00100000); // Turn off system oscillator

            // Clean up the GPIO
            SplashKit.RaspiCleanup();

        }
    }
}