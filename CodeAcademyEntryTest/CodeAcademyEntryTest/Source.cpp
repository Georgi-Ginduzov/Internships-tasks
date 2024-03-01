#include <iostream>

	using std::cout;
	using std::cin;
	using std::endl;

		int main() 
		{
			
			/*int totalAmount;

			cout << "Enter amount (in levs): ";
			cin >> totalAmount;

			int totalAmountCopy = totalAmount, banknoteOfTwenty = 0, banknoteOfTen = 0, banknoteOfFive = 0, banknoteOfOne = 0;

			while (totalAmountCopy > 0)
			{
				if (totalAmountCopy / 20 )
				{

				}
			}*/

			int amount, twenties, tens, fives, ones;

			cout << "Enter the amount of money: ";
			cin >> amount;

			twenties = amount / 20;
			amount %= 20;

			tens = amount / 10;
			amount %= 10;

			fives = amount / 5;
			amount %= 5;

			ones = amount;

			cout << "Number of twenties: " << twenties << endl;
			cout << "Number of tens: " << tens << endl;
			cout << "Number of fives: " << fives << endl;
			cout << "Number of ones: " << ones << endl;

			return 0;
		}