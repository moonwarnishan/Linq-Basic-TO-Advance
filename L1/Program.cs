using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;

var filecontent =await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<CarData[]>(filecontent);


//car atleast 4 doors
// var CarAtLeastfourDoor = cars.Where(n => n.NumOfDoor > 3);
//
// foreach (var c4d in CarAtLeastfourDoor)
// {
//     Console.WriteLine($"{c4d.Make} has {c4d.NumOfDoor} doors");
// }


//car mazda and atleast 4 doors
// var mazfour = cars.Where(n => n.Make =="Mazda"&& n.NumOfDoor>=4);
// //mazfour = cars.Where(car => car.Make == "Mazda").Where(car => car.NumOfDoor >= 4);
// foreach (var c in mazfour)
// {
//     Console.WriteLine($"{c.Make} has {c.NumOfDoor} doors and year is {c.Year}");
// }


//make and model starts with M
// cars.Where(car => car.Make.StartsWith('M')).Where(car=>car.Model.StartsWith('M'))
//     .Select(car=>$"{car.Make} {car.Model}")
//     .ToList().ForEach(car=>Console.WriteLine(car));
//


//display a list of ten most powerful cars interms of horsepower
// cars.OrderByDescending(n=>n.HP)
//     .Take(10)
//     .Select(car=>$"{car.Make} and hp is {car.HP}")
//     .ToList()
//     .ForEach(car=>Console.WriteLine(car));


//display number of models per make that appeared after 1995

// cars.GroupBy(car=>car.Make)
//     .Select(c=>new{c.Key,NumofCount=c.Where(c=>c.Year>=2008).Count()})
//     .ToList()
//     .ForEach(c=>Console.WriteLine($"{c.Key}:{c.NumofCount}"));


//display list of makes that have atleast 2 models whith >=400 hp
//
// cars.Where(car=>car.HP>=400)
//     .GroupBy(car=>car.Make)
//     .Select(car=>new {make=car.Key,numofpowerfulcar=car.Count()})
//     .Where(make=>make.numofpowerfulcar>=2)
//     .ToList()
//     .ForEach(Console.WriteLine);

 
//display the average horsepower per make
// cars.GroupBy(car => car.Make)
//     .Select(car => new {make = car.Key, avghp = car.Average(c => c.HP)})
//     .ToList()
//     .ForEach(Console.WriteLine);


//How many makes build cars with hp between 0-100,101-200,201-300,301-400

cars.GroupBy(car=>car.HP switch
{
    <=100=>"0..100",
    <= 200 => "101..200",
    <= 300 => "201..300",
    <= 400 => "301..400",
    _=>  "401..500"

})
    .Select(car=>new{HPcategory=car.Key,Numberofmake=car.Select(c=>c.Make).Distinct().Count()})
    .ToList()
    .ForEach(n=>Console.WriteLine($"{n.HPcategory}: {n.Numberofmake}"));

class CarData
{
    [JsonPropertyName("id")]
    public int  Id { get; set; }

    [JsonPropertyName("car_make")]
    public string Make { get; set; } 
     
    [JsonPropertyName("car_model")]
    public string Model { get; set; } 

    [JsonPropertyName("car_year")]
    public int Year { get; set; }
    [JsonPropertyName("num_of_door")]
    public int NumOfDoor { get; set; }
    [JsonPropertyName("hp")]
    public int HP { get; set; }
}









/* var result = GenerateNumbers(10).Where(n => n % 2 == 0).Select(n => n * 3);
foreach (var r in result)
{
    Console.WriteLine(r);
}

Console.WriteLine(result.Count());
result = result.OrderByDescending(n => n);
foreach (var r in result)
{
    Console.WriteLine(r);
}



IEnumerable<int> GenerateNumbers(int MaxNum)
{
    
    for (var i = 0; i <= MaxNum; i++)
    {
        yield return i;
    }

}*/