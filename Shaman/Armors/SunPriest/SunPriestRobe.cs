using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrchidMod.Shaman.Armors.SunPriest
{
	[AutoloadEquip(EquipType.Body)]
    public class SunPriestRobe : OrchidModShamanEquipable
    {
        public override void SafeSetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 8;
            item.defense = 18;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Sun Priest Tunic");
		  Tooltip.SetDefault("8% increased shamanic damage"
						   + "\n4% increased shamanic critical stike chance");
		}

        public override void UpdateEquip(Player player)
        {
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			modPlayer.shamanCrit += 4;
			modPlayer.shamanDamage += 0.08f;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LihzahrdSilk", 5);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
