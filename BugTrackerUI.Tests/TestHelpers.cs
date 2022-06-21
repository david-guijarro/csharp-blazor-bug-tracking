using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Microsoft.AspNetCore.Components;

namespace BugTrackerUI.Tests
{
    public static class TestHelpers
    {
        private static readonly string _projectName = "BugTrackerUI";

        public static Type GetClassType(string fullName)
        {
            Type parentType = typeof(ComponentBase);
            Assembly assembly = Assembly.Load("BugTrackerUI");
            Type[] types = assembly.GetTypes();

            IEnumerable<Type> subclasses = types.Where(t => t.IsSubclassOf(parentType));

            var found = subclasses.FirstOrDefault(x => x.FullName == fullName);

            if(found == null)
            {
                found = assembly.GetTypes().FirstOrDefault(x => x.FullName == fullName);
            }

            return found;
        }

        public static string GetRootString()
        {
            var rootPath = System.IO.Directory.GetCurrentDirectory();
            return rootPath.Substring(0, rootPath.IndexOf("BugTrackerUI.Tests"));
        }
    }
}
