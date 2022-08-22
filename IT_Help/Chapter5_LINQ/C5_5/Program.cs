
using C5_5;

var orderby = "Age";
var Users = new List<User>
    {
    new User { Name = "QWE",Age=30,BloodType="O",RegisterTime = new DateTime(2021,05,1) },
    new User { Name = "ASD",Age=35,BloodType="A" ,RegisterTime = new DateTime(2021,6,2) },
    new User { Name = "ZXC",Age=20,BloodType="AB" ,RegisterTime = new DateTime(2021,7,3) },
    new User { Name = "RTY",Age=25,BloodType="A" ,RegisterTime = new DateTime(2021,8,6) },
    new User { Name = "FGH",Age=31,BloodType="O" ,RegisterTime = new DateTime(2021,10,1) },
    new User { Name = "VBN",Age=27,BloodType="AB", RegisterTime = new DateTime(2021, 4, 1)},
    new User { Name = "UIO",Age=30,BloodType="B", RegisterTime = new DateTime(2021, 5, 20)}
    };

var result = Users.OrderBy(orderby + "descending");