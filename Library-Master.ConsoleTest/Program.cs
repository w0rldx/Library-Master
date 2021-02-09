using System;
using System.Collections.Generic;
using System.IO;
using Library_Master.Core.Models;
using Library_Master.Core.Services;
using Library_Master.EntityFramework;
using Library_Master.EntityFramework.Services;

namespace Library_Master.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new Library_MasterDbContextFactory());
            userService.Update(1, new User { Klasse = "1/2", IdentId = 1111 });
        }
    }
}