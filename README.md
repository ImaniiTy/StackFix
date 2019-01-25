# StackFix
Just a Temporary fix to the plugin StackSize

Items list:
https://steamcommunity.com/sharedfiles/filedetails/?id=1108537579

Changes:

  -Old: 
  GIM.GetItem(OldId).GetType().BaseType.GetProperty("MaxStackSize").SetValue(GIM.GetItem(OldId) as IItem, (int)Config["Steak"], null);
  
  -New: 
  generators[NewId].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
