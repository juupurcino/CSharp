using System;

namespace DataBase.Exceptions;

public class ConvertObjectException : Exception
{
    public override string Message => "algum elemento do banco está mal formatado e não pode ser convertido";
}
