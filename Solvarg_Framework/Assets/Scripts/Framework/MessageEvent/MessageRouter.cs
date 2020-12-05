using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 首先，结构中保留的仅仅是exception的引用，只占4个字节，
/// 而真正分配内存是在堆上。所以你不用担心内存回收的问题。
/// 再者，是不是应该用class?
/// 如果你使用struct, 那么你要知道，因为其是值类型，struct类型的变量作参数时，
/// 传递的是拷贝。而如果使用class，则传递的仅仅是一个地址，4字节。
/// 所以，如果你的struct比较庞大，而且会经常用作参数，那你就要考虑使用
/// class而不是struct了。
/// 
/// 约定: 
/// 以类名为Router名+Action
/// 以类名中的Router为Action名,且不能一样
/// </summary>
public static class MessageRouter
{
    public static class TestAction
    {
        public static string ROUTE = "TEST";
        public static class Params
        {
            public static string TEST1 = "TEST1";
        }
    }
}
