using System;
using System.Collections.Generic;

namespace cSharpPractice {

    public class Vegetable
    {
        public Vegetable(string name) => Name = name;
        public string Name { get; }

        public override string ToString() => Name;

    }

    public enum Unit {
        item,
        kilogram,
        gram,
        dozen
    };


    class Program {

        static void Main(string[] args){

            if (args.Length == 0) {
                Console.WriteLine("You should specify arguments with -- \"arguments\"");
                Console.WriteLine("Program exits.");
                System.Environment.Exit(1);
            }

            string command = args[0];

            switch (command)
            {
                case "circle":
                    circleArea();
                    break;
                case "cond":
                    threeDivisible();
                    break;
                case "str":
                    workingWithString();
                    break;
                case "list":
                    workingWithList();
                    break;
                case "fibonacci":
                    fibonacci();
                    break;
                default:
                    throw new Exception("this never happens");
            }
        }

        static void workingWithString(){
            var veg = new Vegetable("eggPlant");
            var date = DateTime.Now;
            var price = 1.99m;
            var unit = Unit.item;
            Console.WriteLine($"On {date:d}, the price of {veg} was {price:C2} per {unit}.");
        }

        static void threeDivisible(){
            for(int i = 1; i < 21; i++){
                if(i % 3 == 0){
                    Console.WriteLine(i);
                }
            }
        }

        static void circleArea(){
            double radius = 2.50;
            double area = radius * radius * Math.PI;
            Console.WriteLine(area);
        }

        static void workingWithList() {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }

        static void fibonacci(){
            var ans = new List<int> {1,1};

            while(ans.Count < 20 ){
                ans.Add(ans[ans.Count - 1] + ans[ans.Count -2]);
            }
            foreach (var a in ans)
            {
                Console.WriteLine(a);
            }
        }
    }
}
