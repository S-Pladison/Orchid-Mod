using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OrchidMod.Shaman.Buffs.Debuffs
{
    public class WindStun : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Wind Stun");
			Description.SetDefault("Greatly reduced movement speed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.velocity *= 0.05f;
		}
	}
}
