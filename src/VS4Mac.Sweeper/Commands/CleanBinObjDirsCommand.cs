using System.Linq;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using VS4Mac.Sweeper.Helpers;

namespace VS4Mac.Sweeper.Commands
{
    public class CleanBinObjDirsCommand : CommandHandler
    {
        protected override void Run()
        {
            if (!ProjectHelper.IsProjectReady())
                return;

            bool success = false;

            var progressMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor("Cleaning /bin & /obj directories...", Stock.StatusSolutionOperation, false, true, false);

            var binFullPaths = ProjectHelper.GetProjectFoldersFullPath("bin");

            progressMonitor.Log.WriteLine(GettextCatalog.GetString("/bin paths" + ": " + binFullPaths.Count));

            if (binFullPaths.Any())
            {
                foreach (var binFullPath in binFullPaths)
                {
                    FileService.DeleteDirectory(binFullPath);
                    progressMonitor.Log.WriteLine(GettextCatalog.GetString("Cleaned" + ": " + binFullPath));
                }

                success = true;
            }

            var objFullPaths = ProjectHelper.GetProjectFoldersFullPath("obj");

            progressMonitor.Log.WriteLine(GettextCatalog.GetString("/obj paths" + ": " + binFullPaths.Count));

            if (objFullPaths.Any())
            {
                foreach (var objFullPath in objFullPaths)
                {
                    FileService.DeleteDirectory(objFullPath);
                    progressMonitor.Log.WriteLine(GettextCatalog.GetString("Cleaned" + ": " + objFullPath));
                }
                success = true;
            }

            progressMonitor.EndTask();

            if (success)
            {
                progressMonitor.ReportSuccess("Cleaned /bin & /obj directories successfully.");
            }
            else
            {
                progressMonitor.ReportWarning("The /bin & /obj directories could not be cleaned.");
            }

            progressMonitor.Dispose();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = IdeApp.Workspace.IsOpen;
        }
    }
}