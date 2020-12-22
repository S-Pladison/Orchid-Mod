using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Alchemist.Weapons.Air
{
	public class ShiverthornFlask : OrchidModAlchemistItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 14;
			item.width = 30;
			item.height = 30;
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 10, 0);
			this.potencyCost = 2;
			this.element = AlchemistElement.AIR;
			this.rightClickDust = 92;
			this.colorR = 25;
			this.colorG = 33;
			this.colorB = 191;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiverthorn Extract");
		    Tooltip.SetDefault("Deals double damage if another element is used in the reaction"
							+  "\nHitting a target coated in alchemic air deals bonus damage"
							+  "\nReleases lingering water spores"
							+  "\nOnly one set of spores can exist at once"
							+  "\n20% increased damage in the snow biome");
		}
		
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			mult *= player.GetModPlayer<OrchidModPlayer>().alchemistDamage;
			if (player.ZoneSnow) mult *= 1.2f;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);		
			recipe.AddIngredient(null, "EmptyFlask", 1);
			recipe.AddIngredient(ItemID.Shiverthorn, 3);
			recipe.AddIngredient(664, 10); // Ice block
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
