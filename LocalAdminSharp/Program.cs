using System;
using System.DirectoryServices;

namespace LocalAdminSharp
{
    class Program
    {
        static void Main()
        {
            String domain = Environment.MachineName;
            String user = "jon";
            object[] password = new object[] { "localadmin123!" };
            String adminGroup = "Administrators";

            // Create the user
            try
            {
                string computerPath = string.Format("WinNT://{0},computer", Environment.MachineName);
                using (DirectoryEntry machine = new DirectoryEntry(computerPath))
                {
                    DirectoryEntry newUser = machine.Children.Add(user, "user");
                    newUser.Invoke("SetPassword", password);
                    newUser.CommitChanges();
                }
                Console.WriteLine("Account Created Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
            }

            // Add the user to local administrator
            try
            {
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
                Console.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
