using MyMonkeyApp.Models;
using MyMonkeyApp.Services;

var monkeyData = InitializeSampleData();
MonkeyHelper.InitializeMonkeys(monkeyData);

RunMainMenu();

void RunMainMenu()
{
    bool running = true;

    while (running)
    {
        Console.Clear();
        DisplayMainMenu();

        string? choice = Console.ReadLine();

        switch (choice?.ToLower())
        {
            case "1":
                ShowRandomMonkey();
                break;
            case "2":
                ListAllMonkeys();
                break;
            case "3":
                SearchMonkeyByName();
                break;
            case "4":
                ViewAccessCounts();
                break;
            case "5":
                running = false;
                Console.WriteLine("\nGoodbye!");
                break;
            default:
                Console.WriteLine("\nInvalid choice. Please try again.");
                PauseExecution();
                break;
        }
    }
}

void DisplayMainMenu()
{
    DisplayMonkeyArt();
    Console.WriteLine("\n╔════════════════════════════════════════╗");
    Console.WriteLine("║     🐵 MONKEY SPECIES EXPLORER 🐵     ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");
    Console.WriteLine("Choose an option:\n");
    Console.WriteLine("  1. 🎲 Get Random Monkey");
    Console.WriteLine("  2. 📋 List All Monkeys");
    Console.WriteLine("  3. 🔍 Search by Name");
    Console.WriteLine("  4. 📊 View Access Counts");
    Console.WriteLine("  5. 🚪 Exit\n");
    Console.Write("Enter your choice (1-5): ");
}

void ShowRandomMonkey()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║        🎲 RANDOM MONKEY PICKER 🎲       ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    var monkey = MonkeyHelper.GetRandomMonkey();

    if (monkey is null)
    {
        Console.WriteLine("No monkeys available!");
        PauseExecution();
        return;
    }

    DisplayMonkeyDetails(monkey);
    PauseExecution();
}

void ListAllMonkeys()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║         📋 ALL MONKEY SPECIES 📋        ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    var monkeys = MonkeyHelper.GetAllMonkeys();

    if (monkeys.Count == 0)
    {
        Console.WriteLine("No monkeys in the database.");
        PauseExecution();
        return;
    }

    for (int i = 0; i < monkeys.Count; i++)
    {
        var monkey = monkeys[i];
        Console.WriteLine($"{i + 1}. {monkey.Name} ({monkey.ScientificName})");
        Console.WriteLine($"   Region: {monkey.Region} | Habitat: {monkey.Habitat}");
        Console.WriteLine();
    }

    Console.Write("Enter monkey number to view details (or press Enter to go back): ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int index) && index > 0 && index <= monkeys.Count)
    {
        Console.Clear();
        DisplayMonkeyDetails(monkeys[index - 1]);
        PauseExecution();
    }
}

void SearchMonkeyByName()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║        🔍 SEARCH MONKEY BY NAME 🔍      ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    Console.Write("Enter monkey name: ");
    string? name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Invalid input. Please try again.");
        PauseExecution();
        return;
    }

    var monkey = MonkeyHelper.FindByName(name);

    if (monkey is null)
    {
        Console.WriteLine($"\n❌ No monkey found with name '{name}'");
        PauseExecution();
        return;
    }

    Console.Clear();
    DisplayMonkeyDetails(monkey);
    PauseExecution();
}

void ViewAccessCounts()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║       📊 MONKEY ACCESS STATISTICS 📊    ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    var accessCounts = MonkeyHelper.GetAllAccessCounts();

    if (accessCounts.Count == 0)
    {
        Console.WriteLine("No access data available yet. View some monkeys first!");
        PauseExecution();
        return;
    }

    Console.WriteLine($"{"Monkey Name",-30} {"Access Count",10}\n");
    Console.WriteLine(new string('─', 42));

    foreach (var (monkeyId, count) in accessCounts.OrderByDescending(x => x.Value))
    {
        var monkey = MonkeyHelper.FindById(monkeyId);
        if (monkey is not null)
        {
            Console.WriteLine($"{monkey.Name,-30} {count,10}");
        }
    }

    var mostAccessed = MonkeyHelper.GetMostAccessedMonkey();
    if (mostAccessed is not null)
    {
        Console.WriteLine($"\n🏆 Most Accessed: {mostAccessed.Name}");
    }

    PauseExecution();
}

void DisplayMonkeyDetails(Monkey monkey)
{
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine($"║  {monkey.Name,-37} ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    DisplayMonkeySpeciesArt(monkey.Name ?? "Unknown");

    Console.WriteLine($"\n📝 Details:");
    Console.WriteLine($"  • Scientific Name: {monkey.ScientificName}");
    Console.WriteLine($"  • Region: {monkey.Region}");
    Console.WriteLine($"  • Habitat: {monkey.Habitat}");
    Console.WriteLine($"  • Lifespan: {monkey.Lifespan} years");
    Console.WriteLine($"  • Weight: {monkey.Weight} kg");
    Console.WriteLine($"  • Height: {monkey.Height} cm");
    Console.WriteLine($"  • Diet: {monkey.Diet}");
    Console.WriteLine($"  • Social Structure: {monkey.SocialStructure}");
    Console.WriteLine($"  • Intelligence Level: {monkey.IntelligenceLevel}");
    Console.WriteLine($"  • Conservation Status: {monkey.ConservationStatus}");
    Console.WriteLine($"  • Population Trend: {monkey.PopulationTrend}");
    Console.WriteLine($"\n📄 Description:");
    Console.WriteLine($"  {monkey.Description}");

    var accessCount = MonkeyHelper.GetAccessCount(monkey.Id);
    Console.WriteLine($"\n📊 This monkey has been accessed {accessCount} time(s).");
}

void DisplayMonkeyArt()
{
    Console.WriteLine("     🐵");
    Console.WriteLine("    (o_o)");
    Console.WriteLine("     |_|");
    Console.WriteLine("    /| |\\ ");
    Console.WriteLine("   / | | \\");
}

void DisplayMonkeySpeciesArt(string species)
{
    switch (species.ToLower())
    {
        case "capuchin":
            Console.WriteLine("    (o)___(o)");
            Console.WriteLine("    (  O  )");
            Console.WriteLine("     \\___/");
            break;
        case "baboon":
            Console.WriteLine("     (o_o)");
            Console.WriteLine("     |___|");
            Console.WriteLine("    /| | |\\");
            break;
        case "lemur":
            Console.WriteLine("      / \\");
            Console.WriteLine("     / o \\ ");
            Console.WriteLine("    |  _  |");
            Console.WriteLine("     \\\\-//");
            break;
        case "macaque":
            Console.WriteLine("     (^_^)" );
            Console.WriteLine("      (_)" );
            Console.WriteLine("     /| |\\" );
            break;
        default:
            Console.WriteLine("     🐵");
            Console.WriteLine("    (o_o)");
            Console.WriteLine("     |_|");
            break;
    }
}

void PauseExecution()
{
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}

static List<Monkey> InitializeSampleData()
{
    return new List<Monkey>
    {
        new Monkey
        {
            Id = "capuchin-01",
            Name = "Capuchin",
            ScientificName = "Cebus imitator",
            Region = "Central and South America",
            Habitat = "Tropical rainforest",
            Lifespan = 45,
            Weight = 3.6,
            Height = 40,
            Diet = "Omnivorous - fruits, insects, small vertebrates",
            Description = "Capuchins are highly intelligent and social monkeys known for their problem-solving abilities and tool use. They have distinctive curved tails and white facial markings.",
            ConservationStatus = "Least Concern",
            PopulationTrend = "Stable",
            SocialStructure = "Troops of 6-20 individuals",
            IntelligenceLevel = "Very High"
        },
        new Monkey
        {
            Id = "baboon-01",
            Name = "Baboon",
            ScientificName = "Papio anubis",
            Region = "Africa",
            Habitat = "Savanna and grasslands",
            Lifespan = 30,
            Weight = 25,
            Height = 65,
            Diet = "Omnivorous - grasses, roots, insects, small mammals",
            Description = "Baboons are large, powerful primates living in cohesive groups with complex social hierarchies. They are highly adaptable and found across various African landscapes.",
            ConservationStatus = "Least Concern",
            PopulationTrend = "Increasing",
            SocialStructure = "Troops of 50+ individuals",
            IntelligenceLevel = "High"
        },
        new Monkey
        {
            Id = "lemur-01",
            Name = "Lemur",
            ScientificName = "Lemur catta",
            Region = "Madagascar",
            Habitat = "Deciduous forest",
            Lifespan = 27,
            Weight = 2.6,
            Height = 42,
            Diet = "Herbivorous - fruits, leaves, bark",
            Description = "Ring-tailed lemurs are iconic Malagasy primates known for their distinctive black and white banded tails. They are highly social and spend much time on the ground.",
            ConservationStatus = "Endangered",
            PopulationTrend = "Declining",
            SocialStructure = "Female-led groups of 6-30 individuals",
            IntelligenceLevel = "High"
        },
        new Monkey
        {
            Id = "macaque-01",
            Name = "Macaque",
            ScientificName = "Macaca mulatta",
            Region = "Asia",
            Habitat = "Temperate and tropical forests",
            Lifespan = 35,
            Weight = 8,
            Height = 47,
            Diet = "Omnivorous - fruits, seeds, leaves, insects",
            Description = "Rhesus macaques are adaptable primates found across Asia. They are commonly used in medical research and are known for their intelligence and complex social behaviors.",
            ConservationStatus = "Least Concern",
            PopulationTrend = "Stable",
            SocialStructure = "Hierarchical groups of 10-60+ individuals",
            IntelligenceLevel = "High"
        },
        new Monkey
        {
            Id = "gibbon-01",
            Name = "Gibbon",
            ScientificName = "Hylobates lar",
            Region = "Southeast Asia",
            Habitat = "Tropical rainforest canopy",
            Lifespan = 40,
            Weight = 7,
            Height = 45,
            Diet = "Frugivorous - primarily fruits",
            Description = "Gibbons are brachiating apes known for their acrobatic movements through the forest canopy. They form monogamous pairs and are famous for their haunting vocalizations.",
            ConservationStatus = "Endangered",
            PopulationTrend = "Declining",
            SocialStructure = "Monogamous pairs with offspring",
            IntelligenceLevel = "Very High"
        }
    };
}