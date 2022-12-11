using BinaryOperation;
using System.Diagnostics;

BitwiseOperation();

PermissionOperation();

BitMapOperation();

//二进制位运算操作
void BitwiseOperation()
{
    int[] power = new int[] { 1, 2, 4, 8, 16, 32, 64 };
    int value = 126;
    /*
     * 1的二进制形式：  00000001
     * 2的二进制形式：  00000010
     * 4的二进制形式：  00000100
     * 8的二进制形式：  00001000
     * 16的二进制形式： 00010000
     * 32的二进制形式： 00100000
     * 64的二进制形式： 01000000
     * 126的二进制形式：01111110
     */
    for (int i = 0; i < power.Length; i++)
    {
        if ((value & power[i]) != 0)
        {
            Console.WriteLine($"value:{value}有power[{i}]={power[i]}所代表的权限");
        }
    }
    Console.WriteLine("按位与：126&4={0}", value & 4);
    Console.WriteLine("按位或：126|4={0}", value | 4);
    Console.WriteLine("左移：126<<4={0}", value << 4);
    Console.WriteLine("右移：126>>4={0}", value >> 4);
    Console.WriteLine("异或：126^4={0}", value ^ 4);
    Console.WriteLine("按位取反：~126={0}", ~value);
}

//位运算操作权限
void PermissionOperation()
{
    //1、给用户创建、读取，修改和删除的权限
    var permission = PermissionEnum.Create | PermissionEnum.Read | PermissionEnum.Update | PermissionEnum.Delete;

    Console.WriteLine($"给用户创建、读取，修改和删除的权限:{permission}");

    //2、去掉用户的修改和删除权限
    permission = permission & ~PermissionEnum.Update;

    Console.WriteLine($"去掉用户的修改权限:{permission}");

    permission = permission & ~PermissionEnum.Delete;
    

    Console.WriteLine($"去掉用户的删除权限:{permission}");

    //3、给用户加上修改的权限
    permission = permission | PermissionEnum.Update;

    Console.WriteLine($"给用户加上修改的权限:{permission}");

    //4、判断用户是否有创建的权限
    var isCreate = (permission & PermissionEnum.Create) != 0;
    //或者
    var isCreate2 = (permission & PermissionEnum.Create) == PermissionEnum.Create;

    Console.WriteLine($"判断用户是否有创建的权限isCreate:{isCreate}");

    Console.WriteLine($"判断用户是否有创建的权限isCreate2:{isCreate2}");
}

//BitMap
void BitMapOperation()
{
    BitMap bitMap = new BitMap(4000000000);
    bitMap.Add(0);
    bitMap.Add(10);
    bitMap.Add(30);
    bitMap.Add(40);
    var isExists = bitMap.IsExists(0);
    Console.WriteLine("0" + isExists);
    isExists = bitMap.IsExists(9);
    Console.WriteLine("9" + isExists);
    isExists = bitMap.IsExists(8);
    Console.WriteLine("8" + isExists);
    isExists = bitMap.IsExists(30);
    Console.WriteLine("30" + isExists);

    bitMap.Remove(20);
    isExists = bitMap.IsExists(20);
    Console.WriteLine("Remove20" + isExists);
    bitMap.Remove(20);

    isExists = bitMap.IsExists(40);
    Console.WriteLine("40" + isExists);

    bitMap.Remove(30);
    isExists = bitMap.IsExists(30);
    Console.WriteLine("Remove30" + isExists);

    long b = GC.GetTotalMemory(true);
    Console.WriteLine($"{bitMap.Length}个数字占用内存大约为:{b}个字节,{b / 1024 / 1024}M");
}