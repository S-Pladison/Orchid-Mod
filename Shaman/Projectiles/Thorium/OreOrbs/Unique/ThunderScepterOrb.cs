using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using OrchidMod;

namespace OrchidMod.Shaman.Projectiles.Thorium.OreOrbs.Unique
{

	public class ThunderScepterOrb : OrchidModShamanProjectile
	{
		private float startX = 0;
		private float startY = 0;
		private int orbsNumber = 0;
		private bool reverseAnim;
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunder Scepter Orb");
        } 
		public override void SafeSetDefaults()
		{
			projectile.width = 16;
			projectile.height = 34;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.timeLeft = 12960000;
			projectile.scale = 1f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 12;
		}
		
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		
		public override bool? CanCutTiles() {
			return false;
		}
		
        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			
			if (player != Main.player[Main.myPlayer]) {
				projectile.active = false;
			}
			
			if (player.GetModPlayer<OrchidModPlayer>().timer120 % 10 == 0) 
			{
				bool done = false;
				
				if (player.GetModPlayer<OrchidModPlayer>().orbCountUnique < 10) {
					if (!done && projectile.frame == 0) {
						projectile.frame = 1;
						reverseAnim = false;
						done = true;
					}
					
					if (!done && projectile.frame == 3) {
						projectile.frame = 2;
						reverseAnim = true;
						done = true;
					}
					
					if (!done && projectile.frame == 1) {
						if (reverseAnim) {
							projectile.frame = 0;
							done = true;
						}
						else {
							projectile.frame = 2;
							done = true;
						}
					}
					
					if (!done && projectile.frame == 2) {
						if (reverseAnim) {
							projectile.frame = 1;
							done = true;
						}
						else {
							projectile.frame = 3;
							done = true;
						}
					}
				}
				
				if (player.GetModPlayer<OrchidModPlayer>().orbCountUnique >= 10 && player.GetModPlayer<OrchidModPlayer>().orbCountUnique < 15){
					if (!done && projectile.frame == 4  || projectile.frame < 4) {
						projectile.frame = 5;
						reverseAnim = false;
						done = true;
					}
					
					if (!done && projectile.frame == 7) {
						projectile.frame = 6;
						reverseAnim = true;
						done = true;
					}
					
					if (!done && projectile.frame == 5) {
						if (reverseAnim) {
							projectile.frame = 4;
							done = true;
						}
						else {
							projectile.frame = 6;
							done = true;
						}
					}
					
					if (!done && projectile.frame == 6) {
						if (reverseAnim) {
							projectile.frame = 5;
							done = true;
						}
						else {
							projectile.frame = 7;
							done = true;
						}
					}
				}
				
				if (player.GetModPlayer<OrchidModPlayer>().orbCountUnique >= 15){
					if (!done && projectile.frame == 8  || projectile.frame < 8) {
						projectile.frame = 9;
						reverseAnim = false;
						done = true;
					}
					
					if (!done && projectile.frame == 11) {
						projectile.frame = 10;
						reverseAnim = true;
						done = true;
					}
					
					if (!done && projectile.frame == 9) {
						if (reverseAnim) {
							projectile.frame = 8;
							done = true;
						}
						else {
							projectile.frame = 10;
							done = true;
						}
					}
					
					if (!done && projectile.frame == 10) {
						if (reverseAnim) {
							projectile.frame = 9;
							done = true;
						}
						else {
							projectile.frame = 11;
							done = true;
						}
					}
				}
			}
			
			if (player.GetModPlayer<OrchidModPlayer>().orbCountUnique < 5 
			|| player.GetModPlayer<OrchidModPlayer>().orbCountUnique > 20 
			|| player.GetModPlayer<OrchidModPlayer>().shamanOrbUnique != ShamanOrbUnique.GRANDTHUNDERBIRD)
			{
				projectile.Kill();
			}
			
			else orbsNumber = player.GetModPlayer<OrchidModPlayer>().orbCountUnique;

			if (projectile.timeLeft == 12960000) {
				startX = projectile.position.X - player.position.X;
				startY = projectile.position.Y - player.position.Y;
			}
			
			projectile.velocity.X = player.velocity.X;
			projectile.position.X = player.position.X + startX;
			projectile.position.Y = player.position.Y + startY;
			
			if (Main.rand.Next(20) == 0) {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity /= 2f;
			}
		}
	
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 2f)
			{
				vector *= 2f / magnitude;
			}
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			
			for(int i=0; i<10; i++)
            {
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229);
				Main.dust[dust].velocity *= 2f;
				Main.dust[dust].scale = 1.75f;
				Main.dust[dust].noGravity = true;
            }
        }
    }
}
 