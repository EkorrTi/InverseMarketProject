using InverseMarketProject.entity;
using InverseMarketProject;


Database db = new();

Console.WriteLine(db.GetCustomers());
Console.WriteLine(db.GetVendors());
Console.WriteLine(db.GetRequests());
Console.WriteLine(db.GetResponses());