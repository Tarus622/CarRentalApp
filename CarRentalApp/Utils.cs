using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public static class Utils
    {
        public static bool FormIsOpen(string name)
        {
            // Check if window is already open
            var openForms = Application.OpenForms.Cast<Form>();
            var isOpen = openForms.Any(q => q.Name == name);
            return isOpen;
        }

        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new StringBuilder to collect the bytes and create a string.
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static string DefaultHashedPassword()
        {
            SHA256 sha = SHA256.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("password123"));

            // Create a new StringBuilder to collect the bytes and create a string.
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
