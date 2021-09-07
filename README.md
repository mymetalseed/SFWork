项目文档详见:   [Solvarg](Doc/README.md)  

## 分支介绍

这个项目的技能系统有两种实现方式,一种是完全基于XNode行为编辑器(即XNode既负责运行时,也负责数据层)  
第二种方式是XNode行为编辑器只负责数据层,抽象出一层C#运行时管理器,这种模式性能会好一些,但是需要编写更多的脚本(可能代码行数差不多,但是创建的文件数量多一些)

完全基于XNode编辑器的分支:  Everything_In_XNode  
第二种方式还在重构中,已完成60%...

## 截图
> 基于Action系统的连击(包括技能连击)和技能系统基石搭建完毕

![](Doc/Capture/Combo.jpg)  

> 一个基本的移动和攻击示例

![](Doc/Capture/Normal.jpg)

![](Doc/Capture/SkillEditor_XNode_Demo2.jpg)

![](Doc/Capture/ProgressDemo.jpg)

![](Doc/Capture/InkDemo.png)

![](Doc/Capture/Dialogue.png)

![](Doc/Capture/WeaponSystem.jpg)

![](Doc/Capture/Attack.jpg)

![](Doc/Capture/SkillEffect.jpg)

![](Doc/Capture/WeaponRelease.jpg)



## 设计图

> Action系统设计图
![](Doc/Capture/Action_Design.jpg)

其余系统级简单设计(很久没更新了)
[http://146.56.209.11:90/%e6%b8%b8%e8%ae%be-solvarg/](http://146.56.209.11:90/%e6%b8%b8%e8%ae%be-solvarg/)