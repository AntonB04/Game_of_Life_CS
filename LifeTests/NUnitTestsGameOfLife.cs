using NUnit.Framework;
using Game_of_Life;


namespace LifeTests
{
    public class NUnitTestsGameOfLife
	{
		[Test]
		//[IgnoreAttribute("Ignore OneOnOneSizeField Test")]
		public void GameProcessor_OneOnOneSizeField_IsDeadCell()
		{
			var onePoint = new Life.PointWithState(0, 0, 1);
			var singleProc = new Life.GameProcessor(1, 1, new Life.PointWithState[1, 1] { { onePoint } });

			var checkPoint = new Life.PointWithState(0, 0, 0);

			singleProc.Process();
			Assert.True(singleProc.GetArr()[0, 0].GetState() == checkPoint.GetState(), "wrong state for a single cell");
		}

		[Test]
		public void GameProcessor_AllCellsAreAlive_OnlyCornersStayingAlive()
		{

			var point00 = new Life.PointWithState(0, 0, 1);
			var point01 = new Life.PointWithState(1, 0, 1);
			var point02 = new Life.PointWithState(2, 0, 1);
			var point03 = new Life.PointWithState(3, 0, 1);
			var point04 = new Life.PointWithState(4, 0, 1);

			var point10 = new Life.PointWithState(0, 1, 1);
			var point11 = new Life.PointWithState(1, 1, 1);
			var point12 = new Life.PointWithState(2, 1, 1);
			var point13 = new Life.PointWithState(3, 1, 1);
			var point14 = new Life.PointWithState(4, 1, 1);

			var point20 = new Life.PointWithState(0, 2, 1);
			var point21 = new Life.PointWithState(1, 2, 1);
			var point22 = new Life.PointWithState(2, 2, 1);
			var point23 = new Life.PointWithState(3, 2, 1);
			var point24 = new Life.PointWithState(4, 2, 1);

			var point30 = new Life.PointWithState(0, 3, 1);
			var point31 = new Life.PointWithState(1, 3, 1);
			var point32 = new Life.PointWithState(2, 3, 1);
			var point33 = new Life.PointWithState(3, 3, 1);
			var point34 = new Life.PointWithState(4, 3, 1);

			var point40 = new Life.PointWithState(0, 4, 1);
			var point41 = new Life.PointWithState(1, 4, 1);
			var point42 = new Life.PointWithState(2, 4, 1);
			var point43 = new Life.PointWithState(3, 4, 1);
			var point44 = new Life.PointWithState(4, 4, 1);

			Life.PointWithState[,] aliveArr = new Life.PointWithState[5, 5]
			{
				{point00, point10, point20, point30, point40},
				{point01, point11, point21, point31, point41},
				{point02, point12, point22, point32, point42},
				{point03, point13, point23, point33, point43},
				{point04, point14, point24, point34, point44}
			};

			var anotherProc = new Life.GameProcessor(5, 5, aliveArr);

			anotherProc.Process();

			int numberAlive = 0;

			/*
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (anotherProc.GetArr()[i, j].GetState() == 1) numberAlive += 1;
				}
			}
			*/
			numberAlive += anotherProc.GetArr()[0, 0].GetState() +
						anotherProc.GetArr()[0, 4].GetState() +
						anotherProc.GetArr()[4, 4].GetState() +
						anotherProc.GetArr()[4, 0].GetState();

			Assert.True(numberAlive == 4, "more or less than 4 cells are alive");

		}

		[Test]
		public void GameProcessor_ChessFieldTest_InnerPartOfFieldAndConersAreDead()
		{
			var point00 = new Life.PointWithState(0, 0, 0);
			var point01 = new Life.PointWithState(1, 0, 1);
			var point02 = new Life.PointWithState(2, 0, 0);
			var point03 = new Life.PointWithState(3, 0, 1);
			var point04 = new Life.PointWithState(4, 0, 0);
			var point05 = new Life.PointWithState(5, 0, 1);
			var point06 = new Life.PointWithState(6, 0, 0);
			var point07 = new Life.PointWithState(7, 0, 1);

			var point10 = new Life.PointWithState(0, 1, 1);
			var point11 = new Life.PointWithState(1, 1, 0);
			var point12 = new Life.PointWithState(2, 1, 1);
			var point13 = new Life.PointWithState(3, 1, 0);
			var point14 = new Life.PointWithState(4, 1, 1);
			var point15 = new Life.PointWithState(1, 1, 0);
			var point16 = new Life.PointWithState(2, 1, 1);
			var point17 = new Life.PointWithState(3, 1, 0);

			var point20 = new Life.PointWithState(0, 2, 0);
			var point21 = new Life.PointWithState(1, 2, 1);
			var point22 = new Life.PointWithState(2, 2, 0);
			var point23 = new Life.PointWithState(3, 2, 1);
			var point24 = new Life.PointWithState(4, 2, 0);
			var point25 = new Life.PointWithState(5, 2, 1);
			var point26 = new Life.PointWithState(6, 2, 0);
			var point27 = new Life.PointWithState(7, 2, 1);

			var point30 = new Life.PointWithState(0, 3, 1);
			var point31 = new Life.PointWithState(1, 3, 0);
			var point32 = new Life.PointWithState(2, 3, 1);
			var point33 = new Life.PointWithState(3, 3, 0);
			var point34 = new Life.PointWithState(4, 3, 1);
			var point35 = new Life.PointWithState(1, 3, 0);
			var point36 = new Life.PointWithState(2, 3, 1);
			var point37 = new Life.PointWithState(3, 3, 0);

			var point40 = new Life.PointWithState(0, 4, 0);
			var point41 = new Life.PointWithState(1, 4, 1);
			var point42 = new Life.PointWithState(2, 4, 0);
			var point43 = new Life.PointWithState(3, 4, 1);
			var point44 = new Life.PointWithState(4, 4, 0);
			var point45 = new Life.PointWithState(5, 4, 1);
			var point46 = new Life.PointWithState(6, 4, 0);
			var point47 = new Life.PointWithState(7, 4, 1);

			var point50 = new Life.PointWithState(0, 5, 1);
			var point51 = new Life.PointWithState(1, 5, 0);
			var point52 = new Life.PointWithState(2, 5, 1);
			var point53 = new Life.PointWithState(3, 5, 0);
			var point54 = new Life.PointWithState(4, 5, 1);
			var point55 = new Life.PointWithState(1, 5, 0);
			var point56 = new Life.PointWithState(2, 5, 1);
			var point57 = new Life.PointWithState(3, 5, 0);

			var point60 = new Life.PointWithState(0, 6, 0);
			var point61 = new Life.PointWithState(1, 6, 1);
			var point62 = new Life.PointWithState(2, 6, 0);
			var point63 = new Life.PointWithState(3, 6, 1);
			var point64 = new Life.PointWithState(4, 6, 0);
			var point65 = new Life.PointWithState(5, 6, 1);
			var point66 = new Life.PointWithState(6, 6, 0);
			var point67 = new Life.PointWithState(7, 6, 1);

			var point70 = new Life.PointWithState(0, 7, 1);
			var point71 = new Life.PointWithState(1, 7, 0);
			var point72 = new Life.PointWithState(2, 7, 1);
			var point73 = new Life.PointWithState(3, 7, 0);
			var point74 = new Life.PointWithState(4, 7, 1);
			var point75 = new Life.PointWithState(1, 7, 0);
			var point76 = new Life.PointWithState(2, 7, 1);
			var point77 = new Life.PointWithState(3, 7, 0);

			Life.PointWithState[,] chessArr = new Life.PointWithState[8, 8]
			{
				{point00, point10, point20, point30, point40, point50, point60, point70},
				{point01, point11, point21, point31, point41, point51, point61, point71},
				{point02, point12, point22, point32, point42, point52, point62, point72},
				{point03, point13, point23, point33, point43, point53, point63, point73},
				{point04, point14, point24, point34, point44, point54, point64, point74},
				{point05, point15, point25, point35, point45, point55, point65, point75},
				{point06, point16, point26, point36, point46, point56, point66, point76},
				{point07, point17, point27, point37, point47, point57, point67, point77}
			};

			var anotherProc = new Life.GameProcessor(8, 8, chessArr);

			anotherProc.Process();

			bool row1 = true;
			bool row8 = true;
			bool col1 = true;
			bool col8 = true;

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (i == 0 && !(j == 0 || j == 8 - 1))
					{
						if (anotherProc.GetArr()[i, j].GetState() != 1) row1 = false;
					}
					else if (i == 8 - 1 && !(j == 0 || j == 8 - 1))
					{
						if (anotherProc.GetArr()[i, j].GetState() != 1) row8 = false;
					}
					else if (j == 0 && !(i == 0 || i == 8 - 1))
					{
						if (anotherProc.GetArr()[i, j].GetState() != 1) col1 = false;
					}
					else if (j == 8 - 1 && !(i == 0 || i == 8 - 1))
					{
						if (anotherProc.GetArr()[i, j].GetState() != 1) col8 = false;
					}
				}
			}

			Assert.True(row1 && row8 && col1 && col8);

		}
	}
}