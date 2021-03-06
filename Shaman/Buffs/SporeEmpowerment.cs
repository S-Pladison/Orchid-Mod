using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrchidMod.Shaman.Buffs
{
    public class SporeEmpowerment : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
			DisplayName.SetDefault("Spore Empowerment");
			Description.SetDefault("Empowers the spore caller next use");
			Main.buffNoSave[Type] = true;	
        }
    }
}