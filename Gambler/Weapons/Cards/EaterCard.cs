using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Gambler.Weapons.Cards
{
	public class EaterCard : OrchidModGamblerItem
	{
		public override void SafeSetDefaults()
		{
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = 1;
			item.damage = 8;
			item.crit = 4;
			item.knockBack = 1f;
			item.useAnimation = 30;
			item.useTime = 30;
			this.cardRequirement = 4;
			this.gamblerCardSets.Add("Boss");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Playing Card : Corrupted Nightmare");
		    Tooltip.SetDefault("Summon a corrupted eye, following your cursor"
							+  "\nRandomly releases rotten meat chunks"
							+  "\nCollecting them increases the eye damage and size");
		}
	}
}
