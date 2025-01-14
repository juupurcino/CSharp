using System;

namespace DataBase.Exceptions;

public class CustomNotDefinedException : Exception
{
    public override string Message => "algum elemento do banco está mal formatado e não pode ser convertido";
}