// See https://aka.ms/new-console-template for more information
using C5_4;

var Users = new List<User>
    {
    new User { Name = "QWE",age=30,BloodType="O" },
    new User { Name = "ASD",age=35,BloodType="A" },
    new User { Name = "ZXC",age=20,BloodType="AB" },
    new User { Name = "RTY",age=25,BloodType="A" },
    new User { Name = "FGH",age=31,BloodType="O" },
    new User { Name = "VBN",age=27,BloodType="AB" },
    new User { Name = "UIO",age=30,BloodType="B" }
    };
var result1 = Users.Where(u => u.age > 25);
var result2 = Users.Where(u => u.age > 25 && u.BloodType == "O");
var result3 = Users.FirstOrDefault();
var result4 = Users.FirstOrDefault(u => u.age > 25 && u.BloodType == "AB");
var result5 = Users.OrderBy(U => U.age);
var result6 = Users.OrderByDescending(U => U.age);
var result7 = Users.GroupBy(U => U.BloodType);

int i = 123;
