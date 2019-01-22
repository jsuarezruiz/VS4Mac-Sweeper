using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using VS4Mac.Sweeper.Extensions;
using VS4Mac.Sweeper.Helpers;

namespace VS4Mac.Sweeper.Commands
{
    public class ZipSolutionCommand: CommandHandler
    {
        protected override void Run()
        {
            var solution = ProjectHelper.GetCurrentSolution();
            var solutionFullPath = solution.BaseDirectory.FullPath;
            var progressMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor("Archiving {solutionFullPath}", Stock.StatusSolutionOperation, false, true, false);

            try
            {
                progressMonitor.Log.WriteLine($"Archiving {solutionFullPath}");

                var zipFileName = $"{solution.Name.AppendTimeStamp()}.zip";
                    
                var output = ZipHelper.CreateFromDirectory(solutionFullPath, zipFileName);

                progressMonitor.Log.WriteLine(output);

                progressMonitor.ReportSuccess($"Zip file created: {zipFileName}");
            }
            catch (Exception ex)
            {
                progressMonitor.ReportError($"Archiving failed.", ex);
            }
            finally
            {
                progressMonitor.EndTask();
                progressMonitor.Dispose();
            }
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = IdeApp.Workspace.IsOpen;
        }
    }
}