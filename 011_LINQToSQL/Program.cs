using _011_LINQToSQL;
using Microsoft.EntityFrameworkCore;

using (ApplicationDbContext db = new ApplicationDbContext())
{
    var groups = from u in db.Users
                group u by u.Company.Name;

    foreach (var group in groups)
    {
        Console.WriteLine(group.Key);
        foreach (var user in group)
        {
            Console.WriteLine($"\t{user.Name}");
        }
    }
}
