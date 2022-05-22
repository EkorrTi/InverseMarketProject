using InverseMarketProject.entity;
using InverseMarketProject;

Database database = new();

//database.InsertUser( new User(
//        1, "email@hentai.com", "password", "87773334422", "firstname", "lastname", "userguy"
//    ));

Console.WriteLine( database.GetUsers() );
Console.WriteLine( database.GetUserByUsername("userguy") );