using System;
using System.Collections;

namespace Game_of_Life
{
    class Program
    {
		
		static void Main(string[] args)
        {
			
			var point00 = new Life.PointWithState(0, 0, 1);
			var point01 = new Life.PointWithState(1, 0, 1);
			var point02 = new Life.PointWithState(2, 0, 0);
			var point03 = new Life.PointWithState(3, 0, 1);
			var point04 = new Life.PointWithState(4, 0, 0);

			var point10 = new Life.PointWithState(0, 1, 0);
			var point11 = new Life.PointWithState(1, 1, 0);
			var point12 = new Life.PointWithState(2, 1, 0);
			var point13 = new Life.PointWithState(3, 1, 0);
			var point14 = new Life.PointWithState(4, 1, 0);

			var point20 = new Life.PointWithState(0, 2, 1);
			var point21 = new Life.PointWithState(1, 2, 1);
			var point22 = new Life.PointWithState(2, 2, 1);
			var point23 = new Life.PointWithState(3, 2, 1);
			var point24 = new Life.PointWithState(4, 2, 1);

			var point30 = new Life.PointWithState(0, 3, 0);
			var point31 = new Life.PointWithState(1, 3, 0);
			var point32 = new Life.PointWithState(2, 3, 0);
			var point33 = new Life.PointWithState(3, 3, 0);
			var point34 = new Life.PointWithState(4, 3, 0);

			var point40 = new Life.PointWithState(0, 4, 0);
			var point41 = new Life.PointWithState(1, 4, 0);
			var point42 = new Life.PointWithState(2, 4, 0);
			var point43 = new Life.PointWithState(3, 4, 0);
			var point44 = new Life.PointWithState(4, 4, 0);

			var point50 = new Life.PointWithState(0, 5, 0);
			var point51 = new Life.PointWithState(1, 5, 1);
			var point52 = new Life.PointWithState(2, 5, 0);
			var point53 = new Life.PointWithState(3, 5, 1);
			var point54 = new Life.PointWithState(4, 5, 1);

			var point60 = new Life.PointWithState(0, 6, 0);
			var point61 = new Life.PointWithState(1, 6, 0);
			var point62 = new Life.PointWithState(2, 6, 0);
			var point63 = new Life.PointWithState(3, 6, 0);
			var point64 = new Life.PointWithState(4, 6, 0);

			var point70 = new Life.PointWithState(0, 7, 0);
			var point71 = new Life.PointWithState(1, 7, 0);
			var point72 = new Life.PointWithState(2, 7, 0);
			var point73 = new Life.PointWithState(3, 7, 0);
			var point74 = new Life.PointWithState(4, 7, 0);

			var point80 = new Life.PointWithState(0, 8, 1);
			var point81 = new Life.PointWithState(1, 8, 1);
			var point82 = new Life.PointWithState(2, 8, 1);
			var point83 = new Life.PointWithState(3, 8, 1);
			var point84 = new Life.PointWithState(4, 8, 1);

			Life.PointWithState[,] arr = new Life.PointWithState[5, 9]
			{
				{point00, point10, point20, point30, point40, point50, point60, point70, point80},
				{point01, point11, point21, point31, point41, point51, point61, point71, point81},
				{point02, point12, point22, point32, point42, point52, point62, point72, point82},
				{point03, point13, point23, point33, point43, point53, point63, point73, point83},
				{point04, point14, point24, point34, point44, point54, point64, point74, point84}
			};
			
			var anotherProcess = new Life.GameProcessor(5, 9, arr);
			
			int[,] oldArr = new int[5, 9] ;
			int[,] newArr = new int[5, 9];

			bool k = true;
			do
			{
				var tempArr = anotherProcess.GetArr();
				for (int i = 0; i < arr.GetLength(0); i++)
				{
					for (int j = 0; j < arr.GetLength(1); j++)
					{
						oldArr[i, j] = tempArr[i, j].GetState();
					}
				}

				anotherProcess.Process();
				anotherProcess.Print();
				tempArr = anotherProcess.GetArr();
				char ch = Console.ReadKey().KeyChar;
				Console.WriteLine(" ");
				Console.WriteLine("-------------------");

				for (int i = 0; i < arr.GetLength(0); i++)
				{
					for (int j = 0; j < arr.GetLength(1); j++)
					{
						newArr[i, j] = tempArr[i, j].GetState();
					}
				}

				k = false;
				for (int i = 0; i < arr.GetLength(0); i++)
				{
					for (int j = 0; j < arr.GetLength(1); j++)
					{
						if (oldArr[i, j] != newArr[i, j]) k = true;
					}
				}

			} while (k);

		}
    }
}
