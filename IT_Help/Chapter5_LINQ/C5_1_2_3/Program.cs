// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> numbers1 = new List<int> { 6, 4, 8, 3, 2, 1, 5, 7, 0, 9 };
List<int> numbers2 = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
List<int> numbers = new List<int> { 6, 4, 8, 3, 2, 1, 5, 7, 0, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

var average = numbers1.Average();

var concatenationQuery = numbers1.Concat(numbers2);
var largeNumbersQuery = numbers2.Where(c => c > 15);

int numcount1 =
        (
        from num in numbers
        where num < 3 || num > 7
        select num
        ).Count();
IEnumerable<int> numQuery =
    from num in numbers
    where num < 3 || num > 7
    select num;
int numcount2 = numQuery.Count();
int i = 123;
