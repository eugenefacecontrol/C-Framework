using System.Collections.Generic;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace MyFramework.Utils
{
    public static class TfsExtensions
    {
        public static Query GetBugs(this WorkItemStore workItemStore)
        {
            return workItemStore.GetByType("Bug");
        }

        public static Query GetTasks(this WorkItemStore workItemStore)
        {
            return workItemStore.GetByType("Task");
        }

        private static Query GetByType(this WorkItemStore workItemStore, string type)
        {
            return new Query(
                workItemStore,
                "select * from issue where System.TeamProject = @project and System.WorkItemType = @type",
                new Dictionary<string, string> { { "project", "LeapTest" }, { "type", type } }
            );
        }
    }
}
