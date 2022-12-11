namespace BinaryOperation
{
    internal class BitMap
    {
        /// <summary>
        /// 总长度
        /// </summary>
        public uint Length { get; private set; }

        /// <summary>
        /// 算出32位中的每位代表的数字,这边的31次方无法用uint表示，所以这边用固定的，不过可以通过16进制表示
        /// </summary>
        public readonly uint[] bitValues = new uint[] {
            1<<0,1<<1,1<<2,1<<3,1<<4,1<<5,1<<6,1<<7,1<<8,1<<9,1<<10,1<<11,1<<12,1<<13,1<<14,1<<15,
            1<<16,1<<17,1<<18,1<<19,1<<20,1<<21,1<<22,1<<23, 1<<24,1<<25,1<<26,1<<27,1<<28,1<<29,1<<30,2147483648
        };

        /// <summary>
        /// 存放数据的容器
        /// </summary>
        uint[] container;

        public BitMap(uint length)
        {
            Length = length;
            //计算需要多少容量的数据来存储数据
            container = new uint[(length / 32) + (length % 32 == 0 ? 0 : 1)];
        }

        public void Add(uint value)
        {
            if (value > Length)
            {
                throw new Exception("out of range");
            }
            //得到该数字在数组中的索引
            uint index = value >> 5;//等价于 value/5
            //得到该数字在指定索引下的位索引
            uint bitIndex = value & 31;//等价于 value%32，因为32是2的N次方 所以可以用按位与来表示
            container[index] = container[index] | bitValues[bitIndex];
        }

        public void Remove(uint value)
        {
            if (value > Length)
            {
                throw new Exception("out of range");
            }
            //得到该数字在数组中的索引
            uint index = value >> 5;//等价于 value/5
            //得到该数字在指定索引下的位索引
            uint bitIndex = value & 31;//等价于 value%32，因为32是2的N次方 所以可以用按位与来表示
            container[index] = container[index] & ~bitValues[bitIndex];//等价于 container[index] = container[index] ^ bitValues[bitIndex];
        }

        public bool IsExists(uint value)
        {
            if (value > Length)
            {
                throw new Exception("out of range");
            }
            //得到该数字在数组中的索引
            uint index = value >> 5;//等价于 length/5
            //得到该数字在指定索引下的位索引
            uint bitIndex = value & 31;//等价于 value%32，因为32是2的N次方 所以可以用按位与来表示
            bool isExists = (container[index] & bitValues[bitIndex]) == bitValues[bitIndex];
            return isExists;
        }
    }
}
