using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using OrchidMod;
using static Terraria.ModLoader.ModContent;

namespace OrchidMod.Shaman.Projectiles.Bonds
{
    public class FireBondProj5 : OrchidModShamanProjectile
    {
        public override void SafeSetDefaults()
        {
            projectile.width = 8;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.aiStyle = 1;
			projectile.timeLeft = 90;
			projectile.scale = 1f;
			aiType = ProjectileID.Bullet; 
			projectile.alpha = 128;
        }
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Bond");
        } 
		
        public override void AI()
        {
			projectile.velocity *= 1.01f;
            int index1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0.0f, 0.0f, 0, new Color(), Main.rand.Next(30, 130) * 0.013f);
            Main.dust[index1].velocity *= 0.2f;
			Main.dust[index1].fadeIn = 1f;
			Main.dust[index1].scale = 1.5f;
            Main.dust[index1].noGravity = true;
			
			if (projectile.timeLeft % 3 == 0) {
				spawnDustCircle(6, 13 + Main.rand.Next(11));
			}
		}
		
		public void spawnDustCircle(int dustType, int distToCenter) {
			for (int i = 0 ; i < 20 ; i ++ ) {
				double deg = (i * (36 + 5 - Main.rand.Next(10)));
				double rad = deg * (Math.PI / 180);
					 
				float posX = projectile.Center.X - (int)(Math.Cos(rad) * distToCenter) + projectile.velocity.X - 4;
				float posY = projectile.Center.Y - (int)(Math.Sin(rad) * distToCenter) + projectile.velocity.Y - 4;
					
				Vector2 dustPosition = new Vector2(posX, posY);
					
				int index2 = Dust.NewDust(dustPosition, 1, 1, dustType, 0.0f, 0.0f, 0, new Color(), Main.rand.Next(30, 130) * 0.013f);
					
				Main.dust[index2].velocity = projectile.velocity / 2;
				Main.dust[index2].fadeIn = 1f;
				Main.dust[index2].scale = projectile.velocity.X == 0 ? 1.5f :(float) Main.rand.Next(70, 110) * 0.013f;
				Main.dust[index2].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[projectile.owner];
			OrchidModPlayer modPlayer = player.GetModPlayer<OrchidModPlayer>();
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("FireBondExplosion5"), projectile.damage, 0.0f, projectile.owner, 0.0f, 0.0f);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			
			for (int i = 0 ; i < 10 ; i ++) {
				float posX = projectile.Center.X - 75 + Main.rand.Next(150);
				float posY = projectile.Center.Y - 75 + Main.rand.Next(150);
				Projectile.NewProjectile(posX, posY, 0f, 0f, mod.ProjectileType("FireBondEmber"), projectile.damage, 0.0f, projectile.owner, 0.0f, 0.0f);
			}
			
			float oldVelocityX = 0 + projectile.velocity.X / 2;
			float oldVelocityY = 0 + projectile.velocity.Y / 2;
			projectile.velocity.X *= 0;
			projectile.velocity.Y *= 0;
			
			for (int i = 1 ; i < 3 + 1 ; i ++) {
				spawnDustCircle(6, 15 * i);
			}
			
			projectile.velocity.X = oldVelocityX;
			projectile.velocity.Y = oldVelocityY;
			
			projectile.position.X += projectile.velocity.X;
			projectile.position.Y += projectile.velocity.Y;
			spawnDustCircle(6, 75);
			projectile.position.X += projectile.velocity.X * 3;
			projectile.position.Y += projectile.velocity.Y * 3;
			spawnDustCircle(6, 50);
			projectile.position.X += projectile.velocity.X * 3;
			projectile.position.Y += projectile.velocity.Y * 3;
			spawnDustCircle(6, 25);
			projectile.velocity *= 0;
        }
		
		public override void SafeOnHitNPC(NPC target, int damage, float knockback, bool crit, Player player, OrchidModPlayer modPlayer)
		{
			OrchidModGlobalNPC modTarget = target.GetGlobalNPC<OrchidModGlobalNPC>();
			
			target.AddBuff(BuffID.OnFire, 60 * 5);
			modTarget.shamanBomb = 300;
		}
    }
}