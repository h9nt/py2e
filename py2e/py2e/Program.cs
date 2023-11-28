using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

class Vardxg {
    static void Main() {
        try {
            Console.Write("Enter PATH to The .py File >>> ");
            string pypath = Console.ReadLine();
            if (string.IsNullOrEmpty(pypath) || !pypath.EndsWith(".py")) {
                Console.WriteLine("Enter a valid PATH!");
                return;
            }

            string py2exe = $"pyinstaller --noconfirm --onefile --console {pypath}";
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe") {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process {StartInfo = psi};
            process.Start();
            process.StandardInput.WriteLine(py2exe);
            process.StandardInput.WriteLine("exit");

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();
            Console.WriteLine("Finished!");
            Console.WriteLine($"Output: {output}");
            Console.WriteLine($"Error: {error}");
        } catch (Exception ex) {
            Console.WriteLine($"Some error happen lol: {ex.Message}");
        }
    }
}