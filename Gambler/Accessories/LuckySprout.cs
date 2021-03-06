using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OrchidMod.Gambler.Accessories
{
    public class LuckySprout : OrchidModGamblerEquipable
    {
        public override void SafeSetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = 1;
            item.accessory = true;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lucky Sprout");
			Tooltip.SetDefault("Increases the chance for gambler 'biome' cards to spawn seeds");
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			modPlayer.gamblerLuckySprout = true;
        }
    }
}