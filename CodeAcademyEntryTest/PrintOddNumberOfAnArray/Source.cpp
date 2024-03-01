
//              The language written in is c++

#include <iostream>
#include <stdlib.h> // To use srand or rand
#include <time.h> // To use time
 
    using std::cout;
    using std::cin;
    using std::endl;

    int main()
    {
        char typeOfArray;
        cout << "Choose between automaticaly filled array(Type - 'a') or manually(Type 'm'): ";
        cin >> typeOfArray;

        int oddNumberCounter = 0;

        if (typeOfArray == 'a')
        {
            srand(time(NULL)); //initialize random seed
            int randomNumArray[20];

            for (size_t i = 0; i < 20; i++)
            {
                randomNumArray[i] = rand() % 100; // generate number 0 - 99
                cout << randomNumArray[i] << ", ";
            }

            for (size_t i = 0; i < 20; i++)
            {
                if (randomNumArray[i] % 2 == 1)
                {
                    oddNumberCounter++;
                }
            }
        }
        else
        {
            int numArray[20];

            cout << "Enter the array's elements: " << endl;

            for (size_t i = 0; i < 20; i++)
            {
                cin >> numArray[i];
            }

            for (size_t i = 0; i < 20; i++)
            {
                if (numArray[i] % 2 == 1)
                {
                    oddNumberCounter++;
                }
            }
        }

        cout << "There are " << oddNumberCounter << " odd elements in the given array" << endl;


        return 0;
    }
