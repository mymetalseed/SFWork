//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From E:\Framework\SFWork\database\excel_database\QuestInfo.xlsx.xlsx

public class Main
{
	public string ID; // 编号
	public string QuestTitle; // 任务标题
	public string PreID; // 前置任务ID
	public string QuestDescription; // 任务描述
	public bool Abandonable; // 是否可以放弃
	public string QuestType; // 保留字段(任务类型,说明,按Sheet来划分任务类型)
	public string PreConditionType; // 先验条件类型
	public string PreConditionParam; // 先验条件参数
	public string ProcConditionType; // 进行中验条件类型
	public string ProcConditionParam; // 进行中验条件参数
	public string QuestReward; // 任务奖励(格式由迭代后确定,goods传递的是id)
}


// End of Auto Generated Code
