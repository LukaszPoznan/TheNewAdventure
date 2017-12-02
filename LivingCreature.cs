using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature
    {
        public int CurrentHealth { get; set; }
        public int HealthCap { get; set; }

        public LivingCreature(int currentHealth, int healthCap)
        {
            CurrentHealth = currentHealth;
            HealthCap = healthCap;
        }
    }
}
