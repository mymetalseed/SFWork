//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From C:\D\Unity_Project\SFWork\database\excel_database\ItemInfo.xlsx.xlsx

public class ItemInfo
{
	public string ID; // 道具的唯一ID编编号
	public string Name; // 道具的名字
	public string Description; // 道具描述
	public string Icon; // 道具的IconId
	public ItemType Type; // 道具类型(武器,补给品,任务品等等)
	public int Rarity; // 道具稀有度
	public int RequireLevel; // 道具需求等级(-1,无级别)
	public int MaxCount; // 一个人持有上限
	public int BuyPrice; // 购买价格
	public int SellPrice; // 卖出价格
	public bool CanSell; // 是否可出售
	public string ModelId; // 如果需要模型的话,对应的ID
}


// End of Auto Generated Code
