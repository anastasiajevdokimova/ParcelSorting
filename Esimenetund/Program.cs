using System;
using System.Collections.Generic;

namespace ParcelSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ParcelLine(BoxSize);
        }
        public static bool ParcelLine(List<BoxSize> boxSizes)
        {
            bool parcelFits = false; //по умолчанию bool = true

            foreach (BoxSize box in boxSizes)
            {
                Console.WriteLine("New sorting line starts");

                var boxLengthInHalf = box.Length / 2;  //делим высоту коробки пополам
                var halfBox = (boxLengthInHalf * boxLengthInHalf) + (box.Width * box.Width); //уможаем высоту в квадрате на ширину в квадрате (формула)
                var halfParcelDiagonal = Math.Sqrt(halfBox); //квадратный корень

                var lineWidth = 0;

                foreach (SortingLineParam sortingLine in box.SortingLineParam)
                {
                    var sortingLineNotSquare = (sortingLine.Width * sortingLine.Width) + (lineWidth * lineWidth); //высчитываем диагональ ленты
                    var parcelDiagonal = Math.Sqrt(sortingLineNotSquare);

                    if (sortingLine.Width >= halfParcelDiagonal) //если ширина диагонали ленты больше или равно диагонали коробки
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.Width);
                    }

                    else if (sortingLine.Width <= halfParcelDiagonal && lineWidth >= halfParcelDiagonal) //если ширина диагонали ленты меньше или равно диагонали коробки и ширина ленты больше и рано диагонали коробки
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.Width);
                    }

                    else if (box.Width <= halfParcelDiagonal && lineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.Width);
                    }

                    else if (box.Width >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.Width);
                    }

                    else if (sortingLine.Width <= halfParcelDiagonal && sortingLine.Width >= parcelDiagonal)
                    {
                        parcelFits = sortingLine.Width <= halfParcelDiagonal && sortingLine.Width >= parcelDiagonal;

                        var result = parcelFits ?   //если первое условие не выполняется, выполня
                            "Sorting line width is " + sortingLine.Width + " and it fits " :
                            "It dosent fit to the sorting line and needs to be wider";
                        Console.WriteLine(result);
                    }

                    else
                    {
                        Console.WriteLine("It did not fit to the sortingline and needs to be wider");
                    }
                }

            }

            return parcelFits;

        }

        public static readonly List<BoxSize> BoxSize = new List<BoxSize>
        {
            new BoxSize //a
            {
                Length = 120, //глобальные перемнные с большой буквы и могут использоваться везде
                Width = 60,
                SortingLineParam = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        Width = 100
                    },
                    new SortingLineParam
                    {
                        Width = 75
                    }
                }
            },
            new BoxSize //b
            {
                Length = 35,
                Width = 100,
                SortingLineParam = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        Width = 75
                    },
                    new SortingLineParam
                    {
                        Width = 50
                    },
                    new SortingLineParam
                    {
                        Width = 80
                    },
                    new SortingLineParam
                    {
                        Width = 100
                    },
                    new SortingLineParam
                    {
                        Width = 37
                    },
                }
            },
            new BoxSize //c
            {
                Length = 50,
                Width = 70,
                SortingLineParam = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        Width = 60
                    },
                    new SortingLineParam
                    {
                        Width = 60
                    },
                    new SortingLineParam
                    {
                        Width = 55
                    },
                    new SortingLineParam
                    {
                        Width = 90
                    },
                }
            }
        };
    }

    public class BoxSize
    {
        public int Length { get; set; } //высота коробки

        public int Width { get; set; } //ширина коробки
        public List<SortingLineParam> SortingLineParam { get; set; } = new List<SortingLineParam>(); //список с размерами ширины сортировочной ленты
    }
    public class SortingLineParam
    {
        public int Width { get; set; }  //ширина сортировочной ленты
    }
}