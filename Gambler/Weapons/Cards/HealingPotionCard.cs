using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace OrchidMod.Gambler.Weapons.Cards
{
	public class HealingPotionCard : OrchidModGamblerItem
	{
		public override void SafeSetDefaults()
		{
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = 1;
			item.damage = 0;
			item.crit = 0;
			item.knockBack = 0f;
			item.useAnimation = 15;
			item.useTime = 15;
			item.shootSpeed = 1f;
			this.cardRequirement = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Playing Card : Lesser Healing");
		    Tooltip.SetDefault("Rapidly heals when used");
		}
	}
}
