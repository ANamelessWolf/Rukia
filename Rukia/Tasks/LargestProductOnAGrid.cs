﻿using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// In the 20×20 grid below, four numbers along a diagonal.
    /// The product of these numbers is 26(8,7) × 63(9,8) × 78(10,9) × 14(11,10) = 1788696.
    /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
    /// </summary>
    public class LargestProductOnAGrid : ISolution
    {
        string[,] GRID = {
        //            0     1      2     3     4     5     6     7     8     9    10    11    12    13    14    15    16    17    18    19 
                    {"08", "02", "22", "97", "38", "15", "00", "40", "00", "75", "04", "05", "07", "78", "52", "12", "50", "77", "91", "08"}, //  0
                    {"49", "49", "99", "40", "17", "81", "18", "57", "60", "87", "17", "40", "98", "43", "69", "48", "04", "56", "62", "00"}, //  1
                    {"81", "49", "31", "73", "55", "79", "14", "29", "93", "71", "40", "67", "53", "88", "30", "03", "49", "13", "36", "65"}, //  2
                    {"52", "70", "95", "23", "04", "60", "11", "42", "69", "24", "68", "56", "01", "32", "56", "71", "37", "02", "36", "91"}, //  3
                    {"22", "31", "16", "71", "51", "67", "63", "89", "41", "92", "36", "54", "22", "40", "40", "28", "66", "33", "13", "80"}, //  4
                    {"24", "47", "32", "60", "99", "03", "45", "02", "44", "75", "33", "53", "78", "36", "84", "20", "35", "17", "12", "50"}, //  5
                    {"32", "98", "81", "28", "64", "23", "67", "10", "26", "38", "40", "67", "59", "54", "70", "66", "18", "38", "64", "70"}, //  6
                    {"67", "26", "20", "68", "02", "62", "12", "20", "95", "63", "94", "39", "63", "08", "40", "91", "66", "49", "94", "21"}, //  7
                    {"24", "55", "58", "05", "66", "73", "99", "26", "97", "17", "78", "78", "96", "83", "14", "88", "34", "89", "63", "72"}, //  8
                    {"21", "36", "23", "09", "75", "00", "76", "44", "20", "45", "35", "14", "00", "61", "33", "97", "34", "31", "33", "95"}, //  9
                    {"78", "17", "53", "28", "22", "75", "31", "67", "15", "94", "03", "80", "04", "62", "16", "14", "09", "53", "56", "92"}, // 10
                    {"16", "39", "05", "42", "96", "35", "31", "47", "55", "58", "88", "24", "00", "17", "54", "24", "36", "29", "85", "57"}, // 11
                    {"86", "56", "00", "48", "35", "71", "89", "07", "05", "44", "44", "37", "44", "60", "21", "58", "51", "54", "17", "58"}, // 12
                    {"19", "80", "81", "68", "05", "94", "47", "69", "28", "73", "92", "13", "86", "52", "17", "77", "04", "89", "55", "40"}, // 13
                    {"04", "52", "08", "83", "97", "35", "99", "16", "07", "97", "57", "32", "16", "26", "26", "79", "33", "27", "98", "66"}, // 14
                    {"88", "36", "68", "87", "57", "62", "20", "72", "03", "46", "33", "67", "46", "55", "12", "32", "63", "93", "53", "69"}, // 15
                    {"04", "42", "16", "73", "38", "25", "39", "11", "24", "94", "72", "18", "08", "46", "29", "32", "40", "62", "76", "36"}, // 16
                    {"20", "69", "36", "41", "72", "30", "23", "88", "34", "62", "99", "69", "82", "67", "59", "85", "74", "04", "36", "16"}, // 17
                    {"20", "73", "35", "29", "78", "31", "90", "01", "74", "31", "49", "71", "48", "86", "81", "16", "23", "57", "05", "54"}, // 18
                    {"01", "70", "54", "71", "83", "51", "54", "69", "16", "92", "33", "48", "61", "43", "52", "01", "89", "19", "67", "48"}  // 19
            };

        public int Size { get; }
        public int Product { get; }

        public LargestProductOnAGrid(int size)
        {
            this.Size = size;
            this.Product = this.Solve();
        }

        public string PrintResult()
        {
            return String.Format("The greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid is {0}", this.Product);
        }

        public int Solve()
        {
            int largestProduct = 0, product;
            StringMatrixNavigator nav = new StringMatrixNavigator(GRID);
            //No es necesario probar todas las direcciones si vamos de arriba abajo, es suficiente probar hacia abajo
            Direction[] directions = { Direction.down, Direction.left, Direction.right, Direction.diagonal_down_left, Direction.diagonal_down_right };
            for (int y = 0; y < GRID.GetLength(0); y++)
            {
                for (int x = 0; x < GRID.GetLength(1); x++)
                {
                    foreach (Direction direction in directions)
                    {
                        product = nav.GetAdjacentProduct(new Position() { X = x, Y = y }, direction, this.Size);
                        if (largestProduct < product)
                            largestProduct = product;
                    }
                }
            }
            return largestProduct;
        }

    }


}
