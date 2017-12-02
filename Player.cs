using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Xp { get; set; }
        public int Lvl { get; set; }
        public int Gold { get; set; }
        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }

        public Player(int xp, int lvl, int gold, int currentHealth, int healthCap) : base(currentHealth, healthCap)
        {
            Xp = xp;
            Lvl = lvl;
            Gold = gold;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                return true;
            }
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.Id == location.ItemRequiredToEnter.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.Id == quest.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.Id == quest.Id)
                {
                    return playerQuest.IsCompleted;
                }
            }
            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.Id == qci.Details.Id)
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity)
                        {
                            return false;
                        }
                    }
                }

                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.Id == qci.Details.Id)
                    {
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.Id == itemToAdd.Id)
                {
                    ii.Quantity++;
                    return; //getting out of the function
                }
            }

            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.Id == quest.Id)
                {
                    pq.IsCompleted = true;
                    return;
                }
            }
        }
    }
}
