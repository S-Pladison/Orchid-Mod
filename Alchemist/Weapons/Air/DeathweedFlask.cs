using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Alchemist.Weapons.Air
{
	public class DeathweedFlask : OrchidModAlchemistItem
	{
		public override void SafeSetDefaults()
		{
			item.damage = 18;
			item.width = 30;
			item.height = 30;
			item.rare = 2;
			item.value = Item.sellPrice(0, 0, 10, 0);
			this.potencyCost = 2;
			this.element = AlchemistElement.AIR;
			this.rightClickDust = 27;
			this.colorR = 165;
			this.colorG = 0;
			this.colorB = 236;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deathweed Extract");
		    Tooltip.SetDefault("Deals double damage if another element is used in the reaction"
							+  "\nHitting a target coated in alchemical air deals bonus damage"
							+  "\nReleases lingering air spores"
							+  "\nOnly one set of spores can exist at once"
							+  "\n20% increased damage in evil biomes");
		}
		
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat) {
			mult *= player.GetModPlayer<OrchidModPlayer>().alchemistDamage;
			if (player.ZoneCrimson || player.ZoneCorrupt) mult *= 1.2f;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);		
			recipe.AddIngredient(null, "EmptyFlask", 1);
			recipe.AddIngredient(ItemID.Deathweed, 3);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
		    recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);		
			recipe.AddIngredient(null, "EmptyFlask", 1);
			recipe.AddIngredient(ItemID.Deathweed, 3);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
