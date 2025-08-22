using System.Security.Cryptography;
Console.ReadLine();
for (int i = 0;i < 32; i++)
{
    Console.WriteLine(1 + RandomNumberGenerator.GetInt32(6));
}
