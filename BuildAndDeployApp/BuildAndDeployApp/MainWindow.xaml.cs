using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace BuildAndDeployApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var msBuildPath = "";
                if (!string.IsNullOrEmpty(msBuildInput.Text))
                {
                    msBuildPath = Environment.GetEnvironmentVariable(msBuildInput.Text);
                    if (string.IsNullOrEmpty(msBuildPath))
                        msBuildPath = msBuildInput.Text;
                }
                else
                {
                    MessageBox.Show("Kindly Set MSBuild Path or Envirement Variable with Direction Path");
                    return;
                }

                var applicationDirectory = directoryPath.Text;
                var isDirectoryExists = Directory.Exists(applicationDirectory);
                if (!isDirectoryExists)
                    Directory.CreateDirectory(applicationDirectory);
                var msBuildCommand =
                    $"msbuild {applicationPath.Text} /p:Platform=AnyCPU;Configuration=Release;PublishDestination={applicationDirectory} /t:PublishToFileSystem";


                var pStartInfo =
                    new ProcessStartInfo("cmd.exe",
                        @"/k ""cd /d " + msBuildPath + @"""")
                    {
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };

                var process = Process.Start(pStartInfo);
                if (process != null)
                {
                    process.StandardInput.WriteLine(msBuildCommand);
                    process.StandardInput.Close();
                    var outputString = process.StandardOutput.ReadToEnd();
                    MessageBox.Show(outputString);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}