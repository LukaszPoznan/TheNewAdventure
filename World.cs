using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int SCISSORS = 1;
        public const int SMALL_KNIFE = 2;
        public const int KNIFE = 3;
        public const int DRILLER = 4;
        public const int GUN = 5;
        public const int BADGE = 6;
        public const int KEY = 7;
        public const int CUP_OF_COFFEE = 8;
        public const int CHANGE = 9;
        public const int TICKET = 10;
        public const int AEROPRESS = 11;
        public const int CZAPKA = 12;

        public const int DRUNK_BUM = 1;
        public const int WILDA_THUG = 2;
        public const int JEZYCE_THUG = 3;
        public const int RUTKOWSKI = 4;
        public const int KLOPOTOWSKA = 5;

        public const int CLEAR_WILDA = 1;
        public const int CLEAR_SZAMA = 2;
        public const int FIND_BADGE = 3;

        public const int HOME = 1;
        public const int WILDA = 2;
        public const int CENTRUM = 3;
        public const int JEZYCE = 4;
        public const int U_BOCKA = 5;
        public const int SZAMA = 6;
        public const int KAJKAS = 7;
        public const int WARTA = 8;
        public const int MALTA = 9;
        public const int MALTA_OFFICE_PARK = 10;
        public const int PRACKA = 11;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(SCISSORS, "Scissors", "Scissors", 1, 3));
            Items.Add(new Weapon(SMALL_KNIFE, "Small knife", "Small knifes", 3, 5));
            Items.Add(new Weapon(KNIFE, "Knife", "Knifes", 4, 6));
            Items.Add(new Weapon(DRILLER, "Driller", "Drillers", 7, 10));
            Items.Add(new Weapon(GUN, "Gun", "Guns", 12, 18));
            Items.Add(new Item(BADGE, "Badge", "Badges"));
            Items.Add(new Item(KEY, "Key", "Keys"));
            Items.Add(new HealingPotion(CUP_OF_COFFEE, "Cup of coffee", "Cups of coffee", 10));
            Items.Add(new Item(CHANGE, "Change", "Change"));
            Items.Add(new Item(TICKET, "ticket", "tickets"));
            Items.Add(new HealingPotion(AEROPRESS, "aeropress", "cups of aeropress", 20));
            Items.Add(new Item(CZAPKA, "czapka wpierdolka", "czapki wpierdolki"));
        }

        private static void PopulateMonsters()
        {
            Monster drunkBum = new Monster(DRUNK_BUM, "Drunk bum", 3, 10, 5, 15, 15);
            drunkBum.LootTable.Add(new LootItem(ItemById(SMALL_KNIFE), 33, false, 0));

            Monster wildaThug = new Monster(WILDA_THUG, "Wilda thug", 5, 15, 8, 10, 10);
            wildaThug.LootTable.Add(new LootItem(ItemById(TICKET), 50, false, 0));
            wildaThug.LootTable.Add(new LootItem(ItemById(CUP_OF_COFFEE), 100, false, 0));

            Monster jezyceThug = new Monster(JEZYCE_THUG, "Jeżyce thug", 10, 25, 22, 27, 27);
            jezyceThug.LootTable.Add(new LootItem(ItemById(GUN), 10, false, 0));
            jezyceThug.LootTable.Add(new LootItem(ItemById(CZAPKA), 20, false, 0));

            Monster rutkowski = new Monster(RUTKOWSKI, "Detektyw Rutkowski", 13, 35, 50, 35, 35);

            Monster klopotowska = new Monster(KLOPOTOWSKA, "Karolina Kłopotowska", 20, 50, 60, 10, 40);
            klopotowska.LootTable.Add(new LootItem(ItemById(BADGE), 25, true, 0));

            Monsters.Add(drunkBum);
            Monsters.Add(wildaThug);
            Monsters.Add(jezyceThug);
            Monsters.Add(rutkowski);
            Monsters.Add(klopotowska);
        }

        private static void PopulateQuests()
        {
            Quest clearWilda = new Quest(CLEAR_WILDA, /*ColoringQuestName(*/"clear Wilda", "Kill those Wilda thugs until you get three tram tickets. You will receive a cup of coffee as a reward.", 20, 10);
            clearWilda.QuestCompletionItems.Add(new QuestCompletionItem((ItemById(TICKET)), 3));
            clearWilda.RewardItem = ItemById(CUP_OF_COFFEE);

            Quest clearSzama = new Quest(CLEAR_SZAMA, "clear Szama", "Get rid of the local thugs so that it's a pleasure to take a walk again. You need to get 3 czapki wpierdolki from them and you'll receive a cup of aeropress as a reward. It's twice as strong as normal coffee.", 40, 30);
            clearSzama.QuestCompletionItems.Add(new QuestCompletionItem((ItemById(CZAPKA)), 3));
            clearSzama.RewardItem = ItemById(AEROPRESS);

            Quest findBadge = new Quest(FIND_BADGE, "find a badge", "You've lost your badge and you won't be able to go to Pracka if you don't get another one! You gotta find Kłopotowska and fight her for it!", 60, 50);
            findBadge.QuestCompletionItems.Add(new QuestCompletionItem((ItemById(BADGE)), 1));
            findBadge.RewardItem = ItemById(CUP_OF_COFFEE);

            Quests.Add(clearWilda);
            Quests.Add(clearSzama);
            Quests.Add(findBadge);
        }

        private static void PopulateLocations()
        {
            Location home = new Location(HOME, "Domek.", "It's your home. A beautifully decorated flat. Only if they stopped flooding you...");
            home.QuestAvailableHere = QuestById(CLEAR_WILDA);

            Location wilda = new Location(WILDA, "Wilda.", "You're entering Wilda. According to a popular song, it's where the devil lives, but you haven't seen one... yet.");
            wilda.MonsterLivingHere = MonsterById(WILDA_THUG);

            Location centrum = new Location(CENTRUM, "Downtown.", "It's the city downtown.");

            Location jezyce = new Location(JEZYCE, "Jeżyce.", "You're entering Jeżyce, a historical district of Poznań. Lots of oldschool shops are located here. There is an old marketplace in the center of it.");
            jezyce.QuestAvailableHere = QuestById(CLEAR_SZAMA);

            Location uBocka = new Location(U_BOCKA, "Pub \"U Boćka\".", "A local sports bar with great Czech beer.");

            Location szama = new Location(SZAMA, "Szamarzewskiego street.", "A street where you can really feel the atmosphere of Jeżyce. Unfortunately, there are many local thugs walking around and discouraging people.");
            szama.MonsterLivingHere = MonsterById(JEZYCE_THUG);

            Location kajkas = new Location(KAJKAS, "Kajka\'s.", "Kajka\'s place. A family of hobbits and two cats are living here.");

            Location warta = new Location(WARTA, "Warta\'s river bank.", "It's the place where Ewa Tylman died. Rutkowski is still here and you gotta fight him.");
            warta.MonsterLivingHere = MonsterById(RUTKOWSKI);

            Location malta = new Location(MALTA, "Malta.", "You're entering the area of the Malta lake. Lots of traffic and many runners here.");

            Location maltaOfficePark = new Location(MALTA_OFFICE_PARK, "Malta Office Park", "Pracka is in building F. You have to find a new badge to get there");
            maltaOfficePark.MonsterLivingHere = MonsterById(KLOPOTOWSKA);
            maltaOfficePark.QuestAvailableHere = QuestById(FIND_BADGE);

            Location pracka = new Location(PRACKA, "Pracka.", "You came to the office at the last minute. Just gotta grab a cup of coffee and you can go and do some interviews. The firm desperately needs more staff!");
            pracka.ItemRequiredToEnter = ItemById(BADGE);

            home.LocationNorth = wilda;

            wilda.LocationNorth = centrum;
            wilda.LocationSouth = home;

            centrum.LocationWest = jezyce;
            centrum.LocationEast = warta;
            centrum.LocationSouth = wilda;

            jezyce.LocationEast = centrum;
            jezyce.LocationNorth = uBocka;
            jezyce.LocationWest = szama;

            uBocka.LocationSouth = jezyce;

            szama.LocationEast = jezyce;
            szama.LocationWest = kajkas;

            kajkas.LocationEast = szama;

            warta.LocationWest = centrum;
            warta.LocationEast = malta;

            malta.LocationWest = warta;
            malta.LocationEast = maltaOfficePark;

            maltaOfficePark.LocationWest = malta;
            maltaOfficePark.LocationEast = pracka;

            pracka.LocationWest = maltaOfficePark;

            Locations.Add(home);
            Locations.Add(wilda);
            Locations.Add(centrum);
            Locations.Add(jezyce);
            Locations.Add(uBocka);
            Locations.Add(szama);
            Locations.Add(kajkas);
            Locations.Add(warta);
            Locations.Add(malta);
            Locations.Add(maltaOfficePark);
            Locations.Add(pracka);

        }

        public static Quest QuestById(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.Id == id)
                {
                    return quest;
                }
            }
            return null;
        }

        /*public static string ColoringQuestName(string questName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return questName.;
    }*/

        public static Item ItemById(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monster MonsterById(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.Id == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Location LocationById(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.Id == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
