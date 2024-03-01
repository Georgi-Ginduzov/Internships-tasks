
//              The language written in is c++

#include <iostream>

	using std::cout;
	using std::cin;
	using std::endl;
	using std::string;

		int main() {
			string number;

			cout << "Enter a number: ";
			cin >> number;

			int sum = 0;

			for (size_t i = 0; i < number.size(); i++)
			{
				sum += (int)number[i] - 48;

			}
			
			cout << "The sum of each digit of this number is: " << sum;

			return 0;
		}
		