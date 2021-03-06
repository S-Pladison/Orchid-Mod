using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Gambler.Weapons.Cards
{
	public class EyeCard : OrchidModGamblerItem
	{
		public override void SafeSetDefaults()
		{
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = 1;
			item.damage = 52;
			item.crit = 4;
			item.knockBack = 3f;
			item.useAnimation = 30;
			item.useTime = 30;
			this.cardRequirement = 6;
			this.gamblerCardSets.Add("Boss");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Playing Card : Guardian of the Night");
		    Tooltip.SetDefault("Summons a servant of cthulhu, dashing at your cursor"
							+  "\nThe servant will only attack if your cursor is far enough from its location");
		}
	}
}
