using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxDmg { get; set; }
        public int RewardXp { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Monster(int id, string name, int maxDmg, int rewardXp, int rewardGold, int currentHealth, int healthCap) : base(currentHealth, healthCap)
        {
            Id = id;
            Name = name;
            MaxDmg = maxDmg;
            RewardXp = rewardXp;
            RewardGold = rewardXp;
            LootTable = new List<LootItem>();
        }
    }
}
