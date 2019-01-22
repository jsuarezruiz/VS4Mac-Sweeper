using System.Collections.Generic;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace VS4Mac.Sweeper.Helpers
{
    public static class ProjectHelper
    {
        public static Solution GetCurrentSolution()
        {
            var solution = IdeApp.ProjectOperations.CurrentSelectedSolution;

            return solution;
        }

        public static bool IsProjectReady()
        {
            var isBuilding = IdeApp.ProjectOperations.IsBuilding(IdeApp.ProjectOperations.CurrentSelectedSolution);
            var isRunning = IdeApp.ProjectOperations.IsRunning(IdeApp.ProjectOperations.CurrentSelectedSolution);

            return !isBuilding && !isRunning;
        }

        public static List<string> GetProjectFoldersFullPath(string folder)
        {
            List<string> projectFoldersFullPath = new List<string>();

            var baseDir = IdeApp.ProjectOperations.CurrentSelectedSolution.RootFolder.BaseDirectory;

            var rootFolderPath = baseDir.FullPath + "/" + folder;

            if (FileService.IsValidPath(rootFolderPath) && FileService.IsDirectory(rootFolderPath))
            {
                projectFoldersFullPath.Add(rootFolderPath);
            }

            var solutionItems = IdeApp.ProjectOperations.CurrentSelectedSolution.Items;

            foreach (var item in solutionItems)
            {
                var folderPath = item.BaseDirectory.FullPath + "/" + folder;

                if (FileService.IsValidPath(folderPath) && FileService.IsDirectory(folderPath))
                {
                    projectFoldersFullPath.Add(folderPath);
                }
            }

            return projectFoldersFullPath;
        }
    }
}