using Database.Models;
using Business;
ModelContext context = new ModelContext();


#region Testing CRUD usuario

#region Read

//Business.DTO.Usuario? usuarioRead =
//    Business.DTO.Usuario.GetUsuario("sebas.martinezp@duocuc.cl", "hashed123");

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

List<Business.DTO.Usuario> usuariosRead =
    Business.DTO.Usuario.GetAllUsuario();

if (usuariosRead.Any())
{
    Console.WriteLine("OK");
    foreach (var user in usuariosRead)
    {
        Console.WriteLine(user.Idusuario);
        Console.WriteLine(user.Idperfil);
        Console.WriteLine(user.Correo);
        Console.WriteLine(user.Contrasenahashed);
        Console.WriteLine(user.Ishabilitado);
    }

}
else
{
    Console.WriteLine("ERROR");
}

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
//var result = UserInterface.DTO.Usuario.Create(usuarioCreate);

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
//var resultUpdate = UserInterface.DTO.Usuario.Update(usuarioUpdate);

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
//var resultDisable = UserInterface.DTO.Usuario.Disable(usuarioDisable);

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

//var result = UserInterface.DTO.PerfilUsuario.Create(perfilUsuarioCreate);

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

//Database.Models.PerfilUsuario? perfilUsuarioRead = UserInterface.DTO.PerfilUsuario.GetPerfilUsuario("Admin");
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
//    UserInterface.DTO.PerfilUsuario.GetAllPerfilUsuario();

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



#region Testing CRUD CheckList

#region CREATE

//Database.Models.CheckList cl = new Database.Models.CheckList()
//{
//    Iselementoseguridad = "1",
//    Isluminaria = "1",
//    Ismaterial = "1",
//    Isredagua = "1",
//    Isseguro = "1",
//    Isseniales = "1",
//    Istrabajoseguro = "1",
//    Descripcion = "Descripcion generica del registro de prueba 1",
//    Fecharegistro = DateTime.Now,
//};

//var result = UserInterface.DTO.CheckList.Create(cl);

//if (result != null)
//{
//    if (result == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(cl.Idcheck);
//        Console.WriteLine(cl.Iselementoseguridad);
//        Console.WriteLine(cl.Isluminaria);
//        Console.WriteLine(cl.Ismaterial);
//        Console.WriteLine(cl.Isredagua);
//        Console.WriteLine(cl.Isseguro);
//        Console.WriteLine(cl.Isseniales);
//        Console.WriteLine(cl.Istrabajoseguro);
//        Console.WriteLine(cl.Descripcion);
//        Console.WriteLine(cl.Fecharegistro);
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

#region UPDATE

//Database.Models.CheckList cl = new Database.Models.CheckList()
//{
//    Iselementoseguridad = "1",
//    Isluminaria = "1",
//    Ismaterial = "0",
//    Isredagua = "0",
//    Isseguro = "1",
//    Isseniales = "0",
//    Istrabajoseguro = "0",
//    Descripcion = "Descripcion generica del registro de prueba 3",
//    Fecharegistro = DateTime.Now,
//};

//var result = UserInterface.DTO.CheckList.Update(cl, 22);

//if (result != null)
//{
//    if (result == true)
//    {
//        Console.WriteLine("OK");
//        Console.WriteLine(cl.Idcheck);
//        Console.WriteLine(cl.Iselementoseguridad);
//        Console.WriteLine(cl.Isluminaria);
//        Console.WriteLine(cl.Ismaterial);
//        Console.WriteLine(cl.Isredagua);
//        Console.WriteLine(cl.Isseguro);
//        Console.WriteLine(cl.Isseniales);
//        Console.WriteLine(cl.Istrabajoseguro);
//        Console.WriteLine(cl.Descripcion);
//        Console.WriteLine(cl.Fecharegistro);
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


//Database.Models.CheckList cl2 = new Database.Models.CheckList()
//{
//    Descripcion = "Descripcion generica del registro de prueba 3"
//};

//var result2 = UserInterface.DTO.CheckList.RegisterUpgrade(cl2, 22);

//if (result2 != null)
//{
//    if (result2 == true)
//    {
//        Console.WriteLine(cl2.Descripcion);
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

#endregion

