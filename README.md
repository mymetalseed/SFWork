# SFWork

冬狼的游戏堆栈库

这个库是会一直更新到游戏Demo出来(完整的代码),这个公开库内的资源都将会是免费和开源的以及部分自己做的.(真正的效果Demo会用自己买的资源)

设计图在这 - 

[http://146.56.209.11:90/%e6%b8%b8%e8%ae%be-solvarg/](http://146.56.209.11:90/%e6%b8%b8%e8%ae%be-solvarg/)

![](MenuDemo.jpg)

## 目前包含的功能

计划将大部分的Unity的Update放在一个Update下调用

单例(继承IMonobehaviour) -> 单例管理器

然后尽量使用当前较新的技术

目前功能模块见下

- Singleton -> SingletonManager(管理Singleton的Unity生命周期)
- Procedure(控制整个游戏的流程-基于有限状态机)
- UI(管理UI - 基于有限状态机和Asset管理模块)
- Asset(基于Addressable 管理资源的AB与加载)
- MessageDispatcher(消息分发,用MessageRouter进行接口调用的查找)
- Fsm(有限状态机)
- Timer(延时执行时的模块,通常用于冷却之类的)
- excel与Json的转换 - 基于此延伸出的配置数据库方案
- Dialog(运行时全局提示)
- Google Poly Shader 特效集
- Image Effect 与仿PR转场特效集
- Setting (游戏配置)
- Scene(场景加载与离开管理)
- RoleManager(角色管理系统)
- PlayerCenter(玩家中心)
- 成长系统
- UI画布上的粒子系统(UIParticleSystem)
- 玩法流程(基于Procedure和场景管理系统,实现多种玩法可以在一个项目下)

demo入口: Scenes/Loading 这个场景下!


## 暂时计划添加功能

- 移植技能系统到这里(基于动画状态机)  
- 背包系统
- 对话系统
- 任务系统
- 战斗系统(仿命运之轮(一个古早手机游戏))
- 存档系统
- 本地化
- 动画系统
- 武器系统

# Solvarg...
![](ProgressDemo.jpg)