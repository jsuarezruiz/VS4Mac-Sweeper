using System.Diagnostics;

namespace VS4Mac.Sweeper.Helpers
{
    public static class ZipHelper
    {
        public static string CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {
            var process = new Process
            {
                // Sample: zip -r archive_name.zip folder_to_compress
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + $"cd {sourceDirectoryName}; zip -r \\\"{destinationArchiveFileName}\\\" . -x packages/\\\\* */bin/\\\\* */obj/\\\\*\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };

            process.Start();
            process.WaitForExit();

            return process.StandardOutput.ReadToEnd();
        }
    }
}