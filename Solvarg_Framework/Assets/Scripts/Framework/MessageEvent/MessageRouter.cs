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
/// 需求: 一个string作为router,这个router的格式是 ROUTE.ACTION
/// 然后这个router内部有很多Params
/// 约定 2021/6/4
/// Params自己订,但是为了找到Router的引用,需要在这里写Handler
/// </summary>
public static class MessageRouter
{
    #region 配置Handler
    public static string LoadApplicationConfigSuccess = "config.loadApplicationConfigSuccess";
    public static string LoadApplicationConfigFailure = "config.loadApplicationConfigFailure";

    public static string LoadUIConfigSuccess = "config.loadUIConfigSuccess";
    public static string LoadUIConfigFailure = "config.loadUIConfigFailure";

    public static string LoadSceneConfigSuccess = "config.loadSceneConfigSuccess";
    public static string LoadSceneConfigFailure = "config.loadSceneConfigFailure";

    public static string LoadModelConfigSuccess = "config.loadModelConfigSuccess";
    public static string LoadModelConfigFailure = "config.loadModelConfigFailure";
    #endregion

    #region 测试
    public static string TestHandler = "test.test1";
    #endregion


}
