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
            var applicationDirectory = directoryPath.Text;
            var isDirectoryExists = Directory.Exists(applicationDirectory);
            if (!isDirectoryExists)
            {
                Directory.CreateDirectory(applicationDirectory);
            }

            var msBuildCommand =
                $"msbuild {applicationDirectory} \"/p:Platform=AnyCPU;Configuration=Release;PublishDestination=E:\\batches\\Apps\\WebApp\" /t:PublishToFileSystem";

            var msBuildPathVariable = Environment.GetEnvironmentVariable("msBuildPath");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(msBuildPathVariable)
                {
                    Arguments = msBuildCommand
                }
            };

            process.Start();


        }
    }
}