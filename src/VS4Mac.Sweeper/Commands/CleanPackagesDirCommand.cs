using System.Linq;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using VS4Mac.Sweeper.Helpers;

namespace VS4Mac.Sweeper.Commands
{
    public class CleanPackagesDirCommand : CommandHandler
    {
        protected override void Run()
        {
            if (!ProjectHelper.IsProjectReady())
                return;

            bool success = false;

            var progressMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor("Cleaning /packages directory...", Stock.StatusSolutionOperation, false, true, false);

            var packagesPaths = ProjectHelper.GetProjectFoldersFullPath("packages");

            if (packagesPaths.Any())
            {
                foreach (var packagesPath in packagesPaths)
                {
                    FileService.DeleteDirectory(packagesPath);
                    progressMonitor.Log.WriteLine(GettextCatalog.GetString("Cleaned" + ": " + packagesPath));
                }

                success = true;
            }

            progressMonitor.EndTask();

            if (success)
            {
                progressMonitor.ReportSuccess("Cleaned /packages directory successfully.");
            }
            else
            {
                progressMonitor.ReportWarning("The /packages directory could not be cleaned.");
            }

            progressMonitor.Dispose();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = IdeApp.Workspace.IsOpen;
        }
    }
}