namespace BinaryOperation
{
    [Flags]
    internal enum PermissionEnum
    {
        Create = 1<<0,
　　　　　　　　　　　　　　　　　　　　
    　　Read = 1<<1,  

   　　 Update = 1<<2, 

   　　 Delete = 1<<3  
    }
}
