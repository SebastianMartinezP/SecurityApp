using Database.Models;
using UserInterface.Business;
ModelContext context = new ModelContext();


#region Testing CRUD usuario

#region Read

//Database.Models.Usuario? usuarioRead =
//    UserInterface.Business.Usuario.GetUsuario("sebas.martinezp@duocuc.cl", "hashed123");

//if (usuarioRead != null)
//{
//    Console.WriteLine("OK");
//    Console.WriteLine(usuarioRead.Idusuario);
//    Console.WriteLine(usuarioRead.Idperfil);
//    Console.WriteLine(usuarioRead.Correo);
//    Console.WriteLine(usuarioRead.Contrasenahashed);
//    Console.WriteLine(usuarioRead.Ishabilitado);
//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region ReadAll

//List<Database.Models.Usuario> usuariosRead =
//    UserInterface.Business.Usuario.GetAllUsuario();

//if (usuariosRead.Any())
//{
//    Console.WriteLine("OK");
//    foreach (var user in usuariosRead)
//    {
//        Console.WriteLine(user.Idusuario);
//        Console.WriteLine(user.Idperfil);
//        Console.WriteLine(user.Correo);
//        Console.WriteLine(user.Contrasenahashed);
//        Console.WriteLine(user.Ishabilitado);
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region Create

//Database.Models.Usuario? usuarioCreate = new Database.Models.Usuario()
//{
//    Correo = "prueba1234@correo.cl",
//    Contrasenahashed = "prueba1234",
//    Ishabilitado = "2",
//    Rutprofesional = "20.244.632-9",
//    Idperfil = 1

//};
//var result = UserInterface.Business.Usuario.Create(usuarioCreate);

//if (result != null)
//{
//    if (result == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(usuarioCreate.Idusuario);
//        Console.WriteLine(usuarioCreate.Idperfil);
//        Console.WriteLine(usuarioCreate.Correo);
//        Console.WriteLine(usuarioCreate.Contrasenahashed);
//        Console.WriteLine(usuarioCreate.Ishabilitado);
//    }
//    else
//    {
//        Console.WriteLine("NO GUARDO");
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region Update

//Database.Models.Usuario? usuarioUpdate = new Database.Models.Usuario()
//{
//    Correo = "prueba1234@correo.cl",
//    Contrasenahashed = "prueba1234",
//    Ishabilitado = "1",
//    Rutprofesional = "20.244.632-9",
//    Idperfil = 1

//};
//var resultUpdate = UserInterface.Business.Usuario.Update(usuarioUpdate);

//if (resultUpdate != null)
//{
//    if (resultUpdate == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(usuarioUpdate.Idusuario);
//        Console.WriteLine(usuarioUpdate.Idperfil);
//        Console.WriteLine(usuarioUpdate.Correo);
//        Console.WriteLine(usuarioUpdate.Contrasenahashed);
//        Console.WriteLine(usuarioUpdate.Ishabilitado);
//    }
//    else
//    {
//        Console.WriteLine("NO Actualizo");
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region Disable

//Database.Models.Usuario? usuarioDisable = new Database.Models.Usuario()
//{
//    Correo = "prueba1234@correo.cl",
//    Contrasenahashed = "prueba1234",
//    Ishabilitado = "1",
//    Rutprofesional = "20.244.632-9",
//    Idperfil = 1

//};
//var resultDisable = UserInterface.Business.Usuario.Disable(usuarioDisable);

//if (resultDisable != null)
//{
//    if (resultDisable == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(usuarioDisable.Idusuario);
//        Console.WriteLine(usuarioDisable.Idperfil);
//        Console.WriteLine(usuarioDisable.Correo);
//        Console.WriteLine(usuarioDisable.Contrasenahashed);
//        Console.WriteLine(usuarioDisable.Ishabilitado);
//    }
//    else
//    {
//        Console.WriteLine("NO Actualizo");
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#endregion


#region Testing CRUD PerfilUsuario

#region Create

//Database.Models.PerfilUsuario perfilUsuarioCreate = new Database.Models.PerfilUsuario()
//{
//    Descripcion = "Testing123"
//};

//var result = UserInterface.Business.PerfilUsuario.Create(perfilUsuarioCreate);

//if (result != null)
//{
//    if (result == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(perfilUsuarioCreate.Idperfil);
//        Console.WriteLine(perfilUsuarioCreate.Descripcion);
//    }
//    else
//    {
//        Console.WriteLine("NO GUARDO");
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region Read

//Database.Models.PerfilUsuario? perfilUsuarioRead = UserInterface.Business.PerfilUsuario.GetPerfilUsuario("Admin");
//if (perfilUsuarioRead != null)
//{
//    Console.WriteLine("OK");
//    Console.WriteLine(perfilUsuarioRead.Idperfil);
//    Console.WriteLine(perfilUsuarioRead.Descripcion);
//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#region ReadAll

//List<Database.Models.PerfilUsuario> perfilUsuarioReadAll = 
//    UserInterface.Business.PerfilUsuario.GetAllPerfilUsuario();

//if (perfilUsuarioReadAll.Any())
//{
//    Console.WriteLine("OK");
//    foreach (var p in perfilUsuarioReadAll)
//    {
//        Console.WriteLine(p.Idperfil);
//        Console.WriteLine(p.Descripcion);
//    }

//}
//else
//{
//    Console.WriteLine("ERROR");
//}

#endregion

#endregion

