// Reference: UnityEngine.UI
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Stacksize", "Noviets", "1.2.2")]
    [Description("Stacksize")]

    class Stacksize : HurtworldPlugin
    {



        void OnServerInitialized() => ConfigStacks();

        void ConfigStacks()
        {

            GlobalItemManager GIM = GlobalItemManager.Instance;
            Dictionary<int, ItemGeneratorAsset> generators = GIM.GetGenerators();
            generators[170].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
            generators[144].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
            generators[279].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
            generators[338].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
            generators[322].GetDataProvider().MaxStackSize = (ushort)(int)Config["Steak"];
            generators[76].GetDataProvider().MaxStackSize = (ushort)(int)Config["FreshOwrong"];
            generators[166].GetDataProvider().MaxStackSize = (ushort)(int)Config["Arrows"];
            generators[36].GetDataProvider().MaxStackSize = (ushort)(int)Config["OwnershipStake"];
            generators[10].GetDataProvider().MaxStackSize = (ushort)(int)Config["Spears"];
            generators[325].GetDataProvider().MaxStackSize = (ushort)(int)Config["Spears"];
            generators[331].GetDataProvider().MaxStackSize = (ushort)(int)Config["C4"];
            generators[274].GetDataProvider().MaxStackSize = (ushort)(int)Config["Dynamite"];

        }

        void Loaded()
        {
            LoadDefaultConfig();

        }

        protected override void LoadDefaultConfig()
        {
            if (Config["Steak"] == null)
            {
                Config.Set("Steak", 1);
            }

            if (Config["Ruby"] == null)
            {
                Config.Set("Ruby", 1);
            }

            if (Config["Arrows"] == null)
            {
                Config.Set("Arrows", 50);
            }

            if (Config["FreshOwrong"] == null)
            {
                Config.Set("FreshOwrong", 1);
            }

            if (Config["Dynamite"] == null)
            {
                Config.Set("Dynamite", 5);
            }

            if (Config["C4"] == null)
            {
                Config.Set("C4", 1);
            }

            if (Config["Paints"] == null)
            {
                Config.Set("Paints", 1);
            }

            if (Config["PoisonTrap"] == null)
            {
                Config.Set("PoisonTrap", 1);
            }

            if (Config["CarParts"] == null)
            {
                Config.Set("CarParts", 1);
            }

            if (Config["CarPanels"] == null)
            {
                Config.Set("CarPanels", 1);
            }

            if (Config["GoatPanels"] == null)
            {
                Config.Set("GoatPanels", 1);
            }

            if (Config["Wheels"] == null)
            {
                Config.Set("Wheels", 1);
            }

            if (Config["Designs"] == null)
            {
                Config.Set("Designs", 1);
            }

            if (Config["Drills"] == null)
            {
                Config.Set("Drills", 1);
            }

            if (Config["Wrench"] == null)
            {
                Config.Set("Wrench", 1);
            }

            if (Config["OwnershipStake"] == null)
            {
                Config.Set("OwnershipStake", 1);
            }

            if (Config["ConstructionHammer"] == null)
            {
                Config.Set("ConstructionHammer", 1);
            }

            if (Config["BlastFurnace"] == null)
            {
                Config.Set("BlastFurnace", 1);
            }

            if (Config["Backpacks"] == null)
            {
                Config.Set("Backpacks", 1);
            }

            if (Config["LandcrabMine"] == null)
            {
                Config.Set("LandcrabMine", 1);
            }

            if (Config["Sign"] == null)
            {
                Config.Set("Sign", 1);
            }

            if (Config["Spears"] == null)
            {
                Config.Set("Spears", 1);
            }

            if (Config["Diamonds"] == null)
            {
                Config.Set("Diamonds", 1);
            }

            if (Config["KangaParts"] == null)
            {
                Config.Set("KangaParts", 1);
            }

            if (Config["KangaPanels"] == null)
            {
                Config.Set("KangaPanels", 1);
            }

            SaveConfig();
        }

        [ChatCommand("stackitems")]
        void stackCommand(PlayerSession session)
        {
            Dictionary<int, int> items = new Dictionary<int, int>();
            Dictionary<int, ItemGeneratorAsset> generators = new Dictionary<int, ItemGeneratorAsset>();
            Inventory inv = session.WorldPlayerEntity.Storage;
            GlobalItemManager GIM = GlobalItemManager.Instance;
            if (!inv.IsEmpty())
            {
                for (int i = 0; i < inv.Capacity; i++)
                {
                    if (i < 8 || i > 15)
                    {
                        ItemObject item = inv.GetSlot(i);

                        if (item != null)
                        {
                            if (items.ContainsKey(item.ItemId))
                            {
                                items[item.ItemId] += item.StackSize;
                            }
                            else
                            {
                                items.Add(item.ItemId, item.StackSize);
                                generators.Add(item.ItemId, item.Generator);
                            }
                            item.StackSize = 0;
                            inv.Invalidate();
                        }
                    }
                }
                foreach (var item in items)
                {
                    GIM.GiveItem(session.Player, generators[item.Key], item.Value);
                    inv.Invalidate();

                }
            }
        }

    }
}