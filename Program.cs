﻿using System.Collections.Immutable;
using System.Numerics;
using NinetiesTV;

List<Show> shows = DataLoader.GetShows();

ResultPrinter.Print("All Shows", AllShows(shows));
// ResultPrinter.Print("All Names", Names(shows));
// ResultPrinter.Print("Alphabetical Names", NamesAlphabetically(shows));
// ResultPrinter.Print("Ordered by Popularity", ShowsByPopularity(shows));
// ResultPrinter.Print("Shows with an '&'", ShowsWithAmpersand(shows));
// ResultPrinter.Print("Latest year a show aired", MostRecentYear(shows));
// ResultPrinter.Print("Average Rating", AverageRating(shows));
// ResultPrinter.Print("Shows only aired in the 90s", OnlyInNineties(shows));
// ResultPrinter.Print("Top Three Shows", TopThreeByRating(shows));
// ResultPrinter.Print("Shows starting with 'The'", TheShows(shows));
// ResultPrinter.Print("All But the Worst", AllButWorst(shows));
// ResultPrinter.Print("Shows with Few Episodes", FewEpisodes(shows));
// ResultPrinter.Print("Shows Sorted By Duration", ShowsByDuration(shows));
// ResultPrinter.Print("Comedies Sorted By Rating", ComediesByRating(shows));
// ResultPrinter.Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
// ResultPrinter.Print("Most Episodes", MostEpisodes(shows));
// ResultPrinter.Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
// ResultPrinter.Print("Best Drama", BestDrama(shows));
// ResultPrinter.Print("All But Best Drama", AllButBestDrama(shows));
// ResultPrinter.Print("Good Crime Shows", GoodCrimeShows(shows));
// ResultPrinter.Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
// ResultPrinter.Print("Most Words in Title", WordieastName(shows));
// ResultPrinter.Print("All Names", AllNamesWithCommas(shows));
// ResultPrinter.Print("All Names with And", AllNamesWithCommasPlsAnd(shows));

/**************************************************************************************************
    The Exercises

    Above each method listed below, you'll find a comment that describes what the method should do.
    Your task is to write the appropriate LINQ code to make each method return the correct result.

**************************************************************************************************/
static List<Show> AllShows(List<Show> shows)
{
    return shows.ToList();
}


//cc 1. Return a list of each of show names.
static List<string> Names(List<Show> shows)
{
    return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
}

//cc 2. Return a list of show names ordered alphabetically.
static List<string> NamesAlphabetically(List<Show> shows)
{
    return shows
            .OrderBy(s => s.Name)
            .Select(s => s.Name)
            .ToList();
}

//cc 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
static List<Show> ShowsByPopularity(List<Show> shows)
{
    return shows
            .OrderBy(s => s.ImdbRating)
            .ToList();
}

//cc 4. Return a list of shows whose title contains an & character.
static List<Show> ShowsWithAmpersand(List<Show> shows)
{
    return shows
            .Where(s => s.Name.Contains("&"))
            .ToList();
}

//cc 5. Return the most recent year that any of the shows aired.
static int MostRecentYear(List<Show> shows)
{
    return shows
            .Max(s => s.EndYear);
}

//cc 6. Return the average IMDB rating for all the shows.
static double AverageRating(List<Show> shows)
{
    return shows
            .Average(s => s.ImdbRating);
}

//cc 7. Return the shows that started and ended in the 90s.
static List<Show> OnlyInNineties(List<Show> shows)
{
    return shows
            .Where(s => s.StartYear >= 1990
                            && s.StartYear <= 1999
                            && s.EndYear >= 1990
                            && s.EndYear <= 1999)
            .ToList();
}

//cc 8. Return the top three highest rated shows.
static List<Show> TopThreeByRating(List<Show> shows)
{
    return shows
            .OrderByDescending(s => s.ImdbRating)
            .Take(3)
            .ToList();
}

//cc 9. Return the shows whose name starts with the word "The".
static List<Show> TheShows(List<Show> shows)
{
    return shows
            .Where(s => s.Name.StartsWith("The"))
            .ToList();
}

//cc 10. Return all shows except for the lowest rated show.
static List<Show> AllButWorst(List<Show> shows)
{
    return shows
            .OrderBy(s => s.ImdbRating)
            .Skip(1)
            .ToList();
}

//cc 11. Return the names of the shows that had fewer than 100 episodes.
static List<string> FewEpisodes(List<Show> shows)
{
    return shows
            .Where(s => s.EpisodeCount < 100)
            .Select(s => s.Name)
            .ToList();
}

//cc 12. Return all shows ordered by the number of years on air.
//cc Assume the number of years between the start and end years is the number of years the show was on.
static List<Show> ShowsByDuration(List<Show> shows)
{
    return shows
            .OrderByDescending(s => s.EndYear - s.StartYear)
            .ToList();
}

//cc 13. Return the names of the comedy shows sorted by IMDB rating.
static List<string> ComediesByRating(List<Show> shows)
{
    return shows
            .Where(s => s.Genres.Contains("Comedy"))
            .OrderByDescending(s => s.ImdbRating)
            .Select(s => s.Name)
            .ToList();
}

//cc 14. Return the shows with more than one genre ordered by their starting year.
static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
{
    return shows
            .Where(s => s.Genres.Count > 1)
            .OrderBy(s => s.StartYear)
            .ToList();
}

//cc 15. Return the show with the most episodes.
static Show MostEpisodes(List<Show> shows)
{
    return shows
            .OrderByDescending(s => s.EpisodeCount)
            .FirstOrDefault();
}

//cc 16. Order the shows by their ending year then return the first 
//cc     show that ended on or after the year 2000.
static Show EndedFirstAfterTheMillennium(List<Show> shows)
{
    return shows
            .OrderBy(s => s.EndYear)
            .FirstOrDefault(s => s.EndYear >= 2000);
}

//cc 17. Order the shows by rating (highest first) 
//cc     and return the first show with genre of drama.
static Show BestDrama(List<Show> shows)
{
    return shows
            .OrderByDescending(s => s.ImdbRating)
            .FirstOrDefault(s => s.Genres.Contains("Drama"));
}

//cc 18. Return all dramas except for the highest rated.
static List<Show> AllButBestDrama(List<Show> shows)
{
    return shows
            .Where(s => s.Genres.Contains("Drama"))
            .OrderByDescending(s => s.ImdbRating)
            .Skip(1)
            .ToList();
}

//cc 19. Return the number of crime shows with an IMDB rating greater than 7.0.
static int GoodCrimeShows(List<Show> shows)
{
    return shows
            .Where(s => s.Genres.Contains("Crime") && s.ImdbRating > 7)
            .Count();
}

//cc 20. Return the first show that ran for more than 10 years 
//cc     with an IMDB rating of less than 8.0 ordered alphabetically.
static Show FirstLongRunningTopRated(List<Show> shows)
{
    return shows
            .Where(s => s.EndYear - s.StartYear > 10 && s.ImdbRating < 8)
            .OrderBy(s => s.Name)
            .FirstOrDefault();
}

//cc 21. Return the show with the most words in the name.
static Show WordieastName(List<Show> shows)
{
    return shows
            .OrderByDescending(s => s.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length)
            .FirstOrDefault();
}

//cc 22. Return the names of all shows as a single string separated by a comma and a space.
static string AllNamesWithCommas(List<Show> shows)
{
    List<string> showNames = shows
                                .OrderBy(s => s.Name)
                                .Select(s => s.Name)
                                .ToList();

    return string.Join(", ", showNames);
}

//cc 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
static string AllNamesWithCommasPlsAnd(List<Show> shows)
{
    List<string> showNames = shows
                                .OrderBy(s => s.Name)
                                .Select(s => s.Name)
                                .ToList();

    string lastShowName = showNames.Last();
    string secondToLastShowName = showNames[showNames.Count - 2];
    string otherShowNames = string.Join(", ", showNames.Take(showNames.Count - 2));

    return $"{otherShowNames}, {secondToLastShowName} and {lastShowName}";
}


/**************************************************************************************************
    CHALLENGES

    These challenges are very difficult and may require you to research LINQ methods that we haven't
    talked about. Such as:

    GroupBy()
    SelectMany()
    Count()

**************************************************************************************************/

// 1. Return the genres of the shows that started in the 80s.
// ResultPrinter.Print("Genres of Shows from the 80s", GenresFromThe80s(shows));

static List<string> GenresFromThe80s(List<Show> shows)
{
    var showsInThe80s = shows.Where(s => s.StartYear >= 1980 && s.StartYear <= 1989).ToList();

    return showsInThe80s.SelectMany(s => s.Genres).Distinct().ToList();
}

// 2. Print a unique list of genres.
ResultPrinter.Print("List of Genres", ListOfGenres(shows));

static List<string> ListOfGenres(List<Show> shows)
{
    return shows
            .SelectMany(s => s.Genres)
            .Distinct()
            .ToList();
}

// 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
// ResultPrinter.Print("List of Genres", YearsAndShows(shows));

static List<string> YearsAndShows(List<Show> shows)
{
    // filter shows and turn them into a dictionary
    var showsStartedEachYear = shows
                                // conditional for years 1987 --> 2018
                                .Where(s => s.StartYear >= 1987 && s.StartYear <= 2018)
                                // condense to years (no repeats)
                                .GroupBy(s => s.StartYear)
                                // create a dictionary
                                .ToDictionary(g => g.Key, g => g.Count());

    //declare a new list to add dictionary values to
    List<string> results = new List<string>();

    // for each year in range
    for (int year = 1987; year <= 2018; year++)
    {
        // we have the year already so if the entry has a value, then count equals the value, if not, it defaults to 0
        int count = showsStartedEachYear.ContainsKey(year) ? showsStartedEachYear[year] : 0;

        // these are interpolated into string format and returned
        results.Add($"Year: {year}, Number of Shows: {count}");
    }

    return results;
}

// 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
// ResultPrinter.Print("List of Genres", HowLong(shows));

static string HowLong(List<Show> shows)
{
    // where show is a comedy,Sum the episode count and multiply by 22
    var comedyTime = shows
                        .Where(s => s.Genres.Contains("Comedy"))
                        .Sum(s => s.EpisodeCount * 22);

    // where show is not a comedy, sum the episode count and multiple by 42
    var nonComedyTime = shows
                            .Where(s => !s.Genres.Contains("Comedy)"))
                            .Sum(s => s.EpisodeCount * 42);

    // divide total minutes by the amount of minutes in 24 hours (1 day)
    int days = (comedyTime + nonComedyTime) / 1440;

    // return the number of days
    return $"{days} Days";
}
// 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.
ResultPrinter.Print("Year with the highest average IMDB rating", YearWithHighestRating(shows));

static int YearWithHighestRating(List<Show> shows)
{
    //make dictionary holding an integer and a tuple (of cumulative totalRating and showCount)
    Dictionary<int, (double totalRating, int showCount)>
        ratingsByYear = new
            Dictionary<int, (double totalRating, int showCount)>();

    foreach (var show in shows)
    {
        // iterate years in range for show
        for (int year = show.StartYear; year <= show.EndYear; year++)
        {
            // if year doesn't have tuple entry, initialize 0 for both
            if (!ratingsByYear.ContainsKey(year))
            {
                ratingsByYear[year] = (0, 0);
            }

            //ratings for that year and increased showCount by 1
            ratingsByYear[year] =
                (ratingsByYear[year].totalRating + show.ImdbRating, ratingsByYear[year].showCount + 1);
        }
    }

    //Select dictionary into new with new properties from key and the tuple
    return ratingsByYear.Select(rby => new { Year = rby.Key, AverageRating = rby.Value.totalRating / rby.Value.showCount })
                .OrderByDescending(x => x.AverageRating)
                //select just the year
                .Select(x => x.Year)
                .FirstOrDefault();
}



/**************************************************************************************************
 There is no code to write or change below this line, but you might want to read it.
**************************************************************************************************/
class ResultPrinter
{
    public static void Print(string title, List<Show> shows)
    {
        PrintHeaderText(title);
        foreach (Show show in shows)
        {
            Console.WriteLine(show);
        }

        Console.WriteLine();
    }

    public static void Print(string title, List<string> strings)
    {
        PrintHeaderText(title);
        foreach (string str in strings)
        {
            Console.WriteLine(str);
        }

        Console.WriteLine();
    }

    public static void Print(string title, Show show)
    {
        PrintHeaderText(title);
        Console.WriteLine(show);
        Console.WriteLine();
    }

    public static void Print(string title, string str)
    {
        PrintHeaderText(title);
        Console.WriteLine(str);
        Console.WriteLine();
    }

    public static void Print(string title, int number)
    {
        PrintHeaderText(title);
        Console.WriteLine(number);
        Console.WriteLine();
    }

    public static void Print(string title, double number)
    {
        PrintHeaderText(title);
        Console.WriteLine(number);
        Console.WriteLine();
    }

    public static void PrintHeaderText(string title)
    {
        Console.WriteLine("=============================================");
        Console.WriteLine(title);
        Console.WriteLine("---------------------------------------------");
    }
}