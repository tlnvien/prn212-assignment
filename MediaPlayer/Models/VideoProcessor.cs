using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MediaPlayer.Models
{
    public class VideoProcessor
    {

        public static void GetRandomFrame(string videoPath, string imagePath)
        {
            Random random = new Random();
            string duration = GetVideoDuration(videoPath);

            int randomTime = random.Next(0, int.Parse(duration));
            
            string ffmpegCommand = $"-i \"{videoPath}\" -ss {randomTime} -vframes 1 \"{imagePath}\"";

            ExecuteFFmpegCommand(ffmpegCommand);
        }

        private static string GetVideoDuration(string videoPath) 
        {
            string ffmpegCommand = $"-i \"{videoPath}\"";
            string output = ExecuteFFmpegCommand(ffmpegCommand);

            var durationIndex = output.IndexOf("Duration: ");
            if (durationIndex > -1)
            {
                string duration = output.Substring(durationIndex + 10, 8);
                return duration.Substring(0, 2);
            }
            return "0";
        }

        private static string ExecuteFFmpegCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = @"D:\ffmpeg-2024-11-11-git-96d45c3b21-essentials_build\bin\ffmpeg.exe";
            psi.Arguments = command;

            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            Process process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}
