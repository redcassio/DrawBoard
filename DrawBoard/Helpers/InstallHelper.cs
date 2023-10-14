using DrawBoard.Extensions;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace DrawBoard.Helpers
{
    public class InstallHelper
    {
        public bool IsInstallNET6() => File.Exists(@"C:\Program Files\dotnet\dotnet.exe");
        public async Task InstallNET6Async()
        {
            string net6x64InstallLink = "https://download.visualstudio.microsoft.com/download/pr/66a7c4c6-8401-4799-864f-9afddf5a7733/4052f458f0266e25ab1b9c7959ca245f/windowsdesktop-runtime-6.0.22-win-x64.exe\r\n";
            string net6x64InstallFilename = System.IO.Path.Combine(Application.StartupPath, "windowsdesktop-runtime-6.0.22-win-x64.exe");

            string net6x86InstallLink = "https://download.visualstudio.microsoft.com/download/pr/4842d8ed-dae1-462b-a1c6-f08fcf568aa1/2a4ede4188528a10d003ee797a211568/windowsdesktop-runtime-6.0.22-win-x86.exe\r\n";
            string net6x86InstallFilename = System.IO.Path.Combine(Application.StartupPath, "windowsdesktop-runtime-6.0.22-win-x86.exe");
            var downloadWindow = new DownloadWindow();

            if (!IsInstallNET6())
            {
                using (var httpClient = new HttpClient())
                {
                    bool isDownload = false;
                    try
                    {
                        downloadWindow.Show();
                        Progress<double> progress = new();

                        await Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                        {
                            progress = new Progress<double>(value =>
                            {
                                downloadWindow.ProgressValue = (value * 100);
                                downloadWindow.ProgressValueString = $"{(value * 100).ToString("0")}%";
                            });
                        });

                        if (Environment.Is64BitOperatingSystem)
                        {
                            //isDownload = true;
                            using (var file = new FileStream(net6x64InstallFilename, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await httpClient.DownloadAsync(net6x64InstallLink, file, progress);
                                isDownload = true;
                            }
                        }
                        else
                        {
                            using (var file = new FileStream(net6x86InstallFilename, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await httpClient.DownloadAsync(net6x86InstallLink, file, progress);
                                isDownload = true;
                            }
                        }

                        if (isDownload && (File.Exists(net6x64InstallFilename) || File.Exists(net6x86InstallFilename)))
                        {
                            using (var process = new System.Diagnostics.Process())
                            {
                                process.StartInfo.FileName = Environment.Is64BitOperatingSystem ? net6x64InstallFilename : net6x86InstallFilename;
                                process.StartInfo.Arguments = "/install /quiet /norestart";

                                process.Start();
                                process.WaitForExit();
                                process.Close();
                            }

                            if (IsInstallNET6())
                            {
                                if (Environment.Is64BitOperatingSystem)
                                {
                                    File.Delete(net6x64InstallFilename);
                                }
                                else
                                {
                                    File.Delete(net6x86InstallFilename);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            downloadWindow.Dispatcher.Invoke(DispatcherPriority.Normal, () =>
            {
                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Show();
            });
            downloadWindow.Dispatcher.Invoke(() => { downloadWindow.Close(); });
        }
    }
}
