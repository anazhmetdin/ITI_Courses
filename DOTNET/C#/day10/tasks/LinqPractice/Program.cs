using Microsoft.VisualBasic;

namespace LinqPractice
{
    internal class Program
    {
        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var unit in sequence)
            {
                Console.WriteLine(unit);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("########################Restriction Operators########################");

            Console.WriteLine("\n------------1. out of stock------------");
            var outofstock = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);
            PrintSequence(outofstock);


            Console.WriteLine("\n------------2. in stock & more than 3.00------------");
            var instockgt300 = ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            PrintSequence(instockgt300);


            Console.WriteLine("\n------------3. string shorter than value------------");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            PrintSequence(Arr.Where((n, i) => n.Length < i));

            Console.WriteLine("\n\n########################Element Operators########################");

            Console.WriteLine("\n------------1. first out of stock------------");
            Console.WriteLine(outofstock.First());

            Console.WriteLine("\n------------2. first price > 1000------------");
            Console.WriteLine(ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000));

            Console.WriteLine("\n------------3. second gt 5------------");
            int[] Arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine(Arr1.Where(n => n > 5).ElementAt(1));


            Console.WriteLine("\n\n########################Set Operators########################");

            Console.WriteLine("\n------------1. unique categories------------");
            PrintSequence(ListGenerators.ProductList.Select(p => p.Category).Distinct());

            Console.WriteLine("\n------------2. unique first letter product customer------------");
            var uniqueletters = ListGenerators.ProductList.Select(p => p.ProductName.ElementAtOrDefault(0));
            uniqueletters = uniqueletters.Union(ListGenerators.CustomerList.Select(c => c.CompanyName.ElementAtOrDefault(0)));
            PrintSequence(uniqueletters);

            Console.WriteLine("\n------------3. common first letter product customer------------");
            var commonletters = ListGenerators.ProductList.Select(p => p.ProductName.ElementAtOrDefault(0));
            commonletters = commonletters.Intersect(ListGenerators.CustomerList.Select(c => c.CompanyName.ElementAtOrDefault(0)));
            PrintSequence(commonletters);

            Console.WriteLine("\n------------4. except first letter product customer------------");
            var exceptletters = ListGenerators.ProductList.Select(p => p.ProductName.ElementAtOrDefault(0));
            exceptletters = exceptletters.Except(ListGenerators.CustomerList.Select(c => c.CompanyName.ElementAtOrDefault(0)));
            PrintSequence(exceptletters);

            Console.WriteLine("\n------------5. last three letter product customer------------");
            var last3letters = ListGenerators.ProductList.Select(p => p.ProductName.TakeLast(3));
            last3letters = last3letters.Concat(ListGenerators.CustomerList.Select(c => c.CompanyName.TakeLast(3)));

            foreach (var unit in last3letters)
            {
                foreach (char ch in unit)
                    Console.Write(ch);

                Console.WriteLine();
            }


            Console.WriteLine("\n\n########################Aggregate Operators########################");

            Console.WriteLine("\n------------1. count odd------------");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddCount = Arr2.Count(n => n % 2 == 1);
            Console.WriteLine(oddCount);

            Console.WriteLine("\n------------2. customers orders count------------");
            var customersOrdersCount = ListGenerators.CustomerList.Select(c => new { customer = c, ordersCount = c.Orders.Count() });
            PrintSequence(customersOrdersCount);

            Console.WriteLine("\n------------3. categories products count------------");
            var categoriesProductCount = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => new {
                    Categorie = group.Key,
                    ProductsCount = group.Count()
                }
            );
            PrintSequence(categoriesProductCount);

            Console.WriteLine("\n------------4. total of numbers------------");
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine(Arr3.Sum());

            Console.WriteLine("\n------------5. charactes count inside dictionary------------");
            var lines = File.ReadAllLines("dictionary_english.txt");
            Console.WriteLine(lines.Sum(l => l.Length));

            Console.WriteLine("\n------------6. categories products in stock count------------");
            var categoriesProductInstockCount = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => new {
                    Categorie = group.Key,
                    InStockCount = group.Sum(p => p.UnitsInStock)
                }
            );
            PrintSequence(categoriesProductInstockCount);

            Console.WriteLine("\n------------7. shortest length inside dictionary------------");
            Console.WriteLine(lines.Min(l => l.Length));

            Console.WriteLine("\n------------8. cheapest price in each category------------");
            var cheapestPriceCategorty = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => new {
                    Categorie = group.Key,
                    CheapestPrice = group.Min(p => p.UnitPrice)
                }
            );
            PrintSequence(cheapestPriceCategorty);

            Console.WriteLine("\n------------9. cheapest price in each category (let)------------");
            var cheapestPriceCategortyLet = from p in ListGenerators.ProductList
                                            group p by p.Category into g
                                            let price = g.Min(p => p.UnitPrice)
                                            select new
                                            {
                                                Categorie = g.Key,
                                                CheapestPrice = price
                                            };
            PrintSequence(cheapestPriceCategortyLet);

            Console.WriteLine("\n------------10. longest length inside dictionary------------");
            Console.WriteLine(lines.Max(l => l.Length));

            Console.WriteLine("\n------------11. most expensive price in each category------------");
            var expensivePriceCategorty = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => new {
                    Categorie = group.Key,
                    CheapestPrice = group.Max(p => p.UnitPrice)
                }
            );
            PrintSequence(expensivePriceCategorty);

            Console.WriteLine("\n------------12. most expensive product in each category------------");
            var expensiveProductCategorty = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => group.OrderByDescending(p => p.UnitPrice).First()
            );
            PrintSequence(expensiveProductCategorty);

            Console.WriteLine("\n------------13. average length inside dictionary------------");
            Console.WriteLine(lines.Average(l => l.Length));

            Console.WriteLine("\n------------14.average price in each category------------");
            var averagePriceCategorty = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Select(group => new {
                    Categorie = group.Key,
                    CheapestPrice = group.Average(p => p.UnitPrice)
                }
            );
            PrintSequence(averagePriceCategorty);


            Console.WriteLine("\n\n########################Ordering Operators########################");

            Console.WriteLine("\n------------1. sort list by product name------------");
            PrintSequence(ListGenerators.ProductList.OrderBy(p=>p.ProductName));

            Console.WriteLine("\n------------2. custom comparer------------");
            string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            PrintSequence(Arr4.OrderBy(s => s, new CaseInsensitiveComparer()));

            Console.WriteLine("\n------------3. sort list by product price desc------------");
            PrintSequence(ListGenerators.ProductList.OrderByDescending(p => p.UnitPrice));

            Console.WriteLine("\n------------4. order by length then alphabetically------------");
            string[] Arr5 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            PrintSequence(Arr5.OrderBy(s => s.Length).ThenBy(s => s));

            Console.WriteLine("\n------------5. sort by word length then case insensitive------------");
            PrintSequence(Arr4.OrderBy(s => s.Length).ThenBy(s => s, new CaseInsensitiveComparer()));

            Console.WriteLine("\n------------6. sort products by categroy then price desc------------");
            PrintSequence(ListGenerators.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice));

            Console.WriteLine("\n------------7. sort by word length then case insensitive desc------------");
            PrintSequence(Arr4.OrderBy(s => s.Length).ThenByDescending(s => s, new CaseInsensitiveComparer()));

            Console.WriteLine("\n------------8. reversed list of digits where second letter is i------------");
            PrintSequence(Arr.Select((n, i) => new { s=n, d=i })
                .Where(o => o.s.ElementAtOrDefault(1) =='i').Select(o => o.d).Reverse());


            Console.WriteLine("\n\n########################Partitioning Operators########################");

            Console.WriteLine("\n------------1. first 3 orders from customers in Washington------------");
            PrintSequence(ListGenerators.CustomerList.Where(c => c.City == "Washington")
                .Select(c => c.Orders.OrderBy(o => o.OrderDate).Take(3)));

            Console.WriteLine("\n------------2. all but first 2 orders from customers in Washington------------");
            PrintSequence(ListGenerators.CustomerList.Where(c => c.City == "Washington")
                .Select(c => c.Orders.OrderBy(o => o.OrderDate).Skip(2)));

            Console.WriteLine("\n------------3. untill number is less than index------------");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            PrintSequence(numbers.TakeWhile((n, i) => n < i));

            Console.WriteLine("\n------------4. skip to first divisble by 3------------");
            PrintSequence(numbers.SkipWhile(n => n % 3 != 0));

            Console.WriteLine("\n------------5. from first number is less than index------------");
            PrintSequence(numbers.SkipWhile((n, i) => n > i));


            Console.WriteLine("\n\n########################Projection Operators########################");

            Console.WriteLine("\n------------1. list of products names------------");
            PrintSequence(ListGenerators.ProductList.Select(p => p.ProductName));

            Console.WriteLine("\n------------2. lower and uppercase versions------------");
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            PrintSequence(words.Select(w => new { lowerCase = w.ToLower(), upperCase = w.ToUpper()}));

            Console.WriteLine("\n------------3. properties of products including price------------");
            PrintSequence(ListGenerators.ProductList.Select(p => new {Price = p.UnitPrice, Name = p.ProductName}));

            Console.WriteLine("\n------------4. number match position------------");
            PrintSequence(numbers.Select((n, i) => new {n, match = n==i}));

            Console.WriteLine("\n------------5. all number pairs where A is less than B------------");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var crossJoin = from a in numbersA
                            from b in numbersB
                            where a < b
                            select new {a, b};
            PrintSequence(crossJoin);

            Console.WriteLine("\n------------6. orders less than 500------------");
            PrintSequence(ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500));
            
            Console.WriteLine("\n------------6. orders made in 1998 or later------------");
            PrintSequence(ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998));

            
            Console.WriteLine("\n\n########################Quantifiers########################");

            Console.WriteLine("\n------------1. any word contains ei in dictionary------------");
            Console.WriteLine(lines.Any(w => w.ToLower().Contains("ei")));

            Console.WriteLine("\n------------2. at least one product out of stock------------");
            var ProcutsCategoryOneOutStock = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(group => new {
                    Categorie = group.Key,
                    Products = group.ToList()
                }
            );
            foreach (var unit in ProcutsCategoryOneOutStock)
            {
                Console.WriteLine(unit.Categorie);
                PrintSequence(unit.Products);
                Console.WriteLine("....");
            }

            Console.WriteLine("\n------------3. all products in stock------------");
            var ProcutsCategoryAllStock = ListGenerators.ProductList.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(group => new {
                    Categorie = group.Key,
                    Products = group.ToList()
                }
            );
            foreach (var unit in ProcutsCategoryAllStock)
            {
                Console.WriteLine(unit.Categorie);
                PrintSequence(unit.Products);
                Console.WriteLine("....");
            }
        }
    }

    class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return x.ToLower().CompareTo(y.ToLower());
        }
    }
}