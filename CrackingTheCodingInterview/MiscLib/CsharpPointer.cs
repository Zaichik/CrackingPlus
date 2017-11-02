using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscLib
{
    class CsharpPointer
    {
        public CsharpPointer()
        {
            unsafe
            {
                byte[] source = new byte[10];
                // fix the pointer as immovable, so GC doesn't move it during compaction of free space.
                // sideaffect: GC is less affective in reducing fragmentation.
                // during an exception inside {} the array is unpinned automatically, so no need for exceptino handling
                fixed (byte* p = source) // equivalent to p = &arr[0]
                {
                    *p = (byte) 12;
                    int x = *(int*) p;
                }
            }
        }

        public unsafe void Copy(byte[] src, byte[] dst)
        {
                fixed (byte* p = &src[0])
                {
                    fixed (byte* q = &dst[0])
                    {
                        long* pSrc = (long*)p;
                        long* pDst = (long*)q;
                        for (int i = 0; i < dst.Length / 8; i++)
                        {
                            *pDst = *pSrc;
                            pDst++;
                            pSrc++;
                        }
                    }
                }
        }
    }
}
