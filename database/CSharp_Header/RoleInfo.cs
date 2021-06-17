//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From E:\Framework\SFWork\database\excel_database\RoleInfo.xlsx.xlsx

public class Main
{
	public string ID; // 编号
	public string DefaultName; // 默认名称
	public PlayerSide PlayerSide; // 角色阵营
	public string BaseHP; // 基础血量(Max|成长比率[mul,const])
	public string BaseActionPower; // 基础行动力(Max|成长比率)
	public string BaseMP; // 基础蓝量(Max|成长比率)
	public string BaseAttack; // 基础攻击(Max|成长比率)
	public string Description; // 介绍
	public string ModelId; // 对应的模型Id
}


// End of Auto Generated Code
