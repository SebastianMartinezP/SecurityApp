using Database.Models;

ModelContext context = new ModelContext();


Usuario? u = context.Usuario.FirstOrDefault(u => u.Contrasenahashed.Equals("hashed123"));
Console.WriteLine(u.Rutprofesional);


