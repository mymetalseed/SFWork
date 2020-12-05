# SFWork

整理一套Unity常见的基础框架与系统  

业务逻辑入口 - GameEntry

- singletonManager  **完成**
	- Singleton继承自ImonoBehaviour(尝试全局单Update)
- MessageDispacher  **完成**
	- 消息分发模块
- TimerManger  **完成**
	- 用于计时事件(如冷却时间,对话倒计时)
- Tools  **叠加中**
	- GameObjectTools
	- PathTools
	- PlayerPrefsTools(类Session)
	- ...
- Debuger  **完成**
	- 用于全局管理Debug的开关(禁止非Editor面板下显示日志信息)
- ObjectPoolManger  
	- 对象缓冲池
- ResourcesManager
	- 资源管理
- FSMManager
	- 用于编写角色动画等状态转换系统
- SoundManager
	- 用于控制声音
- DataManager  
	- 数据管理需要考虑,因为打算使用更清晰的SqlLite,如果需要改成Json的话可能需要编写一个接口去控制 数据-实体 间的转换
- SceneManager
	- 场景转换控制
- CameraManager
	- 摄像机控制器,以及摄像机的特效
- SqlLiteManager
	- 考虑是否需要将其并入DataManager,因为可能需要Json
- UIManager
	- 尝试不预设一个MainUI,因为VR场景下的每个UI组都可能是MainUI  
	- 设计一下
- HttpManager


系统部分规划

- 待补充(基础模块编写完后再写)