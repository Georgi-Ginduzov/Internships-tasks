
//				The code written in is c++

#include <iostream>

	using std::cout;
	using std::cin;
	using std::endl;

        int main()
        {
            int rows;

            cout << "Enter the rows of the triangle: ";
			cin >> rows;

			int spaceCounter = rows + 2;

			for (int k = 0; k < rows; k++)
			{
				for (int t = 1; t < spaceCounter; t++)
				{
					cout << " ";
				}
				spaceCounter -= 1;
				cout << "@";
				for (int i = 0; i < k; i++)
				{
					cout << '@' << '@';
				}
				cout << endl;
			}

            return 0;
        }
