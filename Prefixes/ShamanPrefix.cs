using OrchidMod.Shaman;
using Terraria;
using Terraria.ModLoader;

namespace OrchidMod.Prefixes
{
	public class ShamanPrefix : ModPrefix
	{
		private float pDamage;
		private float pMana;
		private float pUseTime;
		private float pVelocity;
		private float pKnockback;

		public override float RollChance(Item item)
			=> 500f;

		public override bool CanRoll(Item item)
			=> true;

		public override PrefixCategory Category
			=> PrefixCategory.Custom;

		public ShamanPrefix() {
		}
			
		public ShamanPrefix(float pDamage, float pKnockback,float pUseTime, float pMana, float pVelocity) {
			this.pDamage = pDamage;
			this.pKnockback = pKnockback;
			this.pUseTime = pUseTime;
			this.pMana = pMana;
			this.pVelocity = pVelocity;
		}

		public override bool Autoload(ref string name) {
			if (!base.Autoload(ref name)) {
				return false;
			}
			
			mod.AddPrefix("Voodoo", 	new ShamanPrefix( 1.00f, 1.00f, 1.00f, 1.00f, 1.05f));
			mod.AddPrefix("Superior",	new ShamanPrefix( 1.10f, 1.10f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Forceful", 	new ShamanPrefix( 1.00f, 1.15f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Broken", 	new ShamanPrefix( 0.70f, 0.80f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Damaged", 	new ShamanPrefix( 0.85f, 1.00f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Shoddy", 	new ShamanPrefix( 0.90f, 0.85f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Hurtful", 	new ShamanPrefix( 1.10f, 1.00f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Strong", 	new ShamanPrefix( 1.00f, 1.15f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Unpleasant", new ShamanPrefix( 1.05f, 1.15f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Weak", 		new ShamanPrefix( 1.00f, 0.80f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Ruthless", 	new ShamanPrefix( 1.18f, 0.90f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Occult", 	new ShamanPrefix( 1.15f, 1.15f, 1.00f, 1.00f, 1.10f));
			mod.AddPrefix("Diabolic", 	new ShamanPrefix( 1.15f, 1.00f, 1.00f, 1.00f, 1.10f));
			mod.AddPrefix("Spirited", 	new ShamanPrefix( 1.00f, 1.00f, 1.00f, 1.00f, 1.10f));
			
			mod.AddPrefix("Quick", 		new ShamanPrefix( 1.00f, 1.00f, 0.90f, 1.00f, 1.00f));
			mod.AddPrefix("Deadly", 	new ShamanPrefix( 1.10f, 1.00f, 0.90f, 1.00f, 1.00f));
			mod.AddPrefix("Magnetic", 	new ShamanPrefix( 1.00f, 1.00f, 0.90f, 1.00f, 1.05f));
			mod.AddPrefix("Nimble", 	new ShamanPrefix( 1.00f, 1.00f, 0.95f, 1.00f, 1.00f));
			mod.AddPrefix("Runic", 		new ShamanPrefix( 1.07f, 1.00f, 0.94f, 1.00f, 1.05f));
			mod.AddPrefix("Slow", 		new ShamanPrefix( 1.00f, 1.00f, 1.15f, 1.00f, 1.00f));
			mod.AddPrefix("Sluggish",	new ShamanPrefix( 1.00f, 1.00f, 1.20f, 1.00f, 1.00f));
			mod.AddPrefix("Lazy", 		new ShamanPrefix( 1.00f, 1.00f, 1.18f, 1.00f, 1.00f));
			mod.AddPrefix("Annoying", 	new ShamanPrefix( 0.80f, 1.00f, 1.15f, 1.00f, 1.00f));
			mod.AddPrefix("Conjuring", 	new ShamanPrefix( 1.05f, 0.90f, 0.90f, 1.00f, 1.05f));

			mod.AddPrefix("Studious", 	new ShamanPrefix( 1.10f, 1.00f, 1.00f, 1.15f, 1.00f));
			mod.AddPrefix("Unique", 	new ShamanPrefix( 1.15f, 1.05f, 1.00f, 1.20f, 1.00f));
			mod.AddPrefix("Balanced", 	new ShamanPrefix( 1.00f, 1.10f, 0.90f, 1.00f, 1.00f));
			mod.AddPrefix("Hopeful", 	new ShamanPrefix( 1.00f, 1.00f, 1.00f, 1.15f, 1.00f));
			mod.AddPrefix("Enraged", 	new ShamanPrefix( 1.15f, 1.15f, 1.00f, 1.00f, 1.00f));
			mod.AddPrefix("Effervescent", new ShamanPrefix( 1.10f, 1.10f, 1.10f, 1.10f, 1.00f)); // :(
			mod.AddPrefix("Ethereal",	new ShamanPrefix( 1.15f, 1.15f, 0.90f, 1.10f, 1.10f));
			mod.AddPrefix("Focused", 	new ShamanPrefix( 1.10f, 1.00f, 1.00f, 1.15f, 1.00f));
			mod.AddPrefix("Complex", 	new ShamanPrefix( 0.90f, 1.00f, 0.90f, 1.10f, 1.00f));

			return false;
		}

		public override void Apply(Item item) {
			item.GetGlobalItem<InstancedShamanItem>().pDamage = pDamage;
			item.GetGlobalItem<InstancedShamanItem>().pKnockback = pKnockback;
			item.GetGlobalItem<InstancedShamanItem>().pUseTime = pUseTime;
			item.GetGlobalItem<InstancedShamanItem>().pMana = pMana;
			item.GetGlobalItem<InstancedShamanItem>().pVelocity = pVelocity;
		}

		public override void ModifyValue(ref float valueMult) {
            float multiplier = 1f * (pDamage * 0.96f) * (pKnockback * 0.96f) * (pMana * 0.96f) * ((2f - pUseTime) * 0.96f) * (pVelocity * 0.96f);
            valueMult *= multiplier;
		}
		
		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, 
		ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult = this.pDamage;
			knockbackMult = this.pKnockback;
			useTimeMult = this.pUseTime;
			critBonus = (int)(this.pMana * 100 - 100);
			shootSpeedMult = this.pVelocity;
		}
	}
}