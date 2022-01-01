using System;
using System.DirectoryServices;

namespace LocalAdminSharp
{
    class Program
    {
        static void Main()
        {
            try
            {
                String domain = "DOM.LOCAL";
                String user = "jon";
                String adminGroup = "Administrators";

                string groupPath = string.Format("WinNT://{0}/{1},group", Environment.MachineName, adminGroup);
                using (DirectoryEntry group = new DirectoryEntry(groupPath))
                {
                    string userPath = string.Format("WinNT://{0}/{1},user", domain, user);
                    group.Invoke("Add", userPath);
                    group.CommitChanges();
                }
                Console.WriteLine(string.Format("{0} is now a local admin", user));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
