namespace MyMonkeyApp.Services;

using MyMonkeyApp.Models;

/// <summary>
/// Helper service for managing monkey species data and operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> monkeys = [];
    private static readonly Dictionary<string, int> accessCounts = [];
    private static readonly Random random = new();

    /// <summary>
    /// Initializes the monkey data collection.
    /// </summary>
    public static void InitializeMonkeys(IEnumerable<Monkey> monkeyCollection)
    {
        monkeys.Clear();
        monkeys.AddRange(monkeyCollection);
        accessCounts.Clear();
    }

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A list of all monkey species.</returns>
    public static List<Monkey> GetAllMonkeys() => new(monkeys);

    /// <summary>
    /// Gets a random monkey from the collection.
    /// </summary>
    /// <returns>A random monkey species, or null if no monkeys are available.</returns>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0)
        {
            return null;
        }

        var randomMonkey = monkeys[random.Next(monkeys.Count)];
        TrackAccess(randomMonkey.Id);
        return randomMonkey;
    }

    /// <summary>
    /// Finds a monkey by its name.
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey species matching the name, or null if not found.</returns>
    public static Monkey? FindByName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        var monkey = monkeys.FirstOrDefault(m => 
            m.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) ?? false);
        
        if (monkey is not null)
        {
            TrackAccess(monkey.Id);
        }

        return monkey;
    }

    /// <summary>
    /// Finds a monkey by its ID.
    /// </summary>
    /// <param name="id">The ID of the monkey to find.</param>
    /// <returns>The monkey species matching the ID, or null if not found.</returns>
    public static Monkey? FindById(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return null;
        }

        var monkey = monkeys.FirstOrDefault(m => 
            m.Id?.Equals(id, StringComparison.OrdinalIgnoreCase) ?? false);
        
        if (monkey is not null)
        {
            TrackAccess(id);
        }

        return monkey;
    }

    /// <summary>
    /// Gets the access count for a specific monkey.
    /// </summary>
    /// <param name="monkeyId">The ID of the monkey.</param>
    /// <returns>The number of times the monkey has been accessed.</returns>
    public static int GetAccessCount(string? monkeyId)
    {
        if (string.IsNullOrWhiteSpace(monkeyId))
        {
            return 0;
        }

        return accessCounts.TryGetValue(monkeyId, out var count) ? count : 0;
    }

    /// <summary>
    /// Gets all access count statistics.
    /// </summary>
    /// <returns>A dictionary of monkey IDs and their access counts.</returns>
    public static Dictionary<string, int> GetAllAccessCounts() => new(accessCounts);

    /// <summary>
    /// Gets the monkey with the highest access count.
    /// </summary>
    /// <returns>The monkey most frequently accessed, or null if no monkeys are available.</returns>
    public static Monkey? GetMostAccessedMonkey()
    {
        if (accessCounts.Count == 0)
        {
            return null;
        }

        var mostAccessedId = accessCounts.MaxBy(kvp => kvp.Value).Key;
        return FindById(mostAccessedId);
    }

    /// <summary>
    /// Resets the access count for a specific monkey.
    /// </summary>
    /// <param name="monkeyId">The ID of the monkey.</param>
    public static void ResetAccessCount(string? monkeyId)
    {
        if (string.IsNullOrWhiteSpace(monkeyId))
        {
            return;
        }

        accessCounts.Remove(monkeyId);
    }

    /// <summary>
    /// Resets all access counts.
    /// </summary>
    public static void ResetAllAccessCounts()
    {
        accessCounts.Clear();
    }

    /// <summary>
    /// Gets the total number of monkeys in the collection.
    /// </summary>
    /// <returns>The count of monkey species.</returns>
    public static int GetMonkeyCount() => monkeys.Count;

    /// <summary>
    /// Tracks access to a specific monkey.
    /// </summary>
    /// <param name="monkeyId">The ID of the monkey being accessed.</param>
    private static void TrackAccess(string? monkeyId)
    {
        if (string.IsNullOrWhiteSpace(monkeyId))
        {
            return;
        }

        if (accessCounts.ContainsKey(monkeyId))
        {
            accessCounts[monkeyId]++;
        }
        else
        {
            accessCounts[monkeyId] = 1;
        }
    }
}
