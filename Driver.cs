namespace QueryBuilder2
{
    public class Driver
    {
        public static void Main()
        {
            QueryBuilder builder = new("data.db");

            var pokeList = builder.ReadAll<Pokemon>();
            var bannedList = builder.ReadAll<BannedGame>();

            Console.WriteLine($"Current Pokemon records: {builder.ReadAll<Pokemon>().Count}");
            Console.WriteLine($"Current Banned Games records: {builder.ReadAll<BannedGame>().Count}");

            Console.WriteLine("Deleting all records in Pokemon and Banned Games");
            builder.DeleteAll<Pokemon>();
            builder.DeleteAll<BannedGame>();

            Console.WriteLine($"Current Pokemon records: {builder.ReadAll<Pokemon>().Count}");
            Console.WriteLine($"Current Banned Games records: {builder.ReadAll<BannedGame>().Count}");

            Console.WriteLine("Inserting records on Pokemon");
            pokeList.ForEach(builder.Create);
            Console.WriteLine($"Current Pokemon records: {builder.ReadAll<Pokemon>().Count}");

            Console.WriteLine("Inserting records on Banned Games");
            bannedList.ForEach(builder.Create);
            Console.WriteLine($"Current Banned Games records: {builder.ReadAll<BannedGame>().Count}");


            Console.WriteLine($"Inserting {pokeList.First().Name} to database");
            builder.Create(pokeList.First());
            Console.WriteLine($"Current Pokemon records: {builder.ReadAll<Pokemon>().Count}");


            Console.WriteLine($"Inserting {bannedList.First().Title} to database");
            builder.Create(bannedList.First());
            Console.WriteLine($"Current Pokemon records: {builder.ReadAll<BannedGame>().Count}");

        }
    }
}