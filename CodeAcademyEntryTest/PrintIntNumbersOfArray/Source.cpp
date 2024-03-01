
//				The language used is c++

#include <iostream>
#include <stdlib.h> // To use srand or rand
#include <time.h> // To use time
#include <math.h> // To use floor function

	using std::cout;
	using std::cin;
	using std::endl;

		int main() {

			/*int numberOfArrayElements;

			cout << "Enter the number of elements of the array: ";
			cin >> numberOfArrayElements;

			int* arrayOfNumbers = new int(numberOfArrayElements);*/

            char typeOfArray;
            cout << "Choose between automaticaly filled array(Type - 'a') or manually(Type 'm'): ";
            cin >> typeOfArray;

            int oddNumberCounter = 0;

            if (typeOfArray == 'a')
            {
                srand(time(NULL)); //initialize random seed
                double randomNumArray[20];

                for (size_t i = 0; i < 20; i++)
                {
                    randomNumArray[i] = rand() / (RAND_MAX + 1.0) * 100.0;
                    cout << randomNumArray[i] << ", ";
                }

                for (size_t i = 0; i < 20; i++)
                {
                    if (floor(randomNumArray[i]) == randomNumArray[1]) {
                        cout << "The random integers are: " << randomNumArray[i];
                    }
                }                
            }
            else
            {
                float numArray[20];

                cout << "Enter the array's elements: " << endl;

                for (size_t i = 0; i < 20; i++)
                {
                    cin >> numArray[i];
                }

                for (size_t i = 0; i < 20; i++)
                {
                    if (floor(numArray[i]) == numArray[1]) {
                        cout << numArray[i];
                    }
                }
                
            }



			return 0;
		}

        //Write a program which makes an array initialised in the program or by the user which defines wich numbers are integer and prints them