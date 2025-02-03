using System;
using System.IO.Ports;
using System.Net.Http;
using System.Threading.Tasks;

partial class Program
{
    static async Task Main(string[] args)
    {
        string portName = "COM3"; // Change this to your serial port name
        int baudRate = 9600;

        using (SerialPort serialPort = new SerialPort(portName, baudRate))
        {
            serialPort.Open();
            Console.WriteLine("Reading data from serial port...");

            string data = serialPort.ReadLine();
            Console.WriteLine($"Data received: {data}");

            string url = $"https://api.example.com/users/{data}"; // Change this to your API endpoint

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseBody}");
            }
        }
    }
}