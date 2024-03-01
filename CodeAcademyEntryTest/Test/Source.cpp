#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    const int SIZE = 5;
    double numbers[SIZE] = { 1.23, 4.5, 6.0, 8.9, 10.0 };

    // Alternatively, you can initialize the array with user input
    /*
    double numbers[SIZE];
    for (int i = 0; i < SIZE; i++) {
        cout << "Enter a real number: ";
        cin >> numbers[i];
    }
    */

    cout << "Integers in the array: ";
    for (int i = 0; i < SIZE; i++) {
        if (floor(numbers[i]) == numbers[i]) {
            cout << numbers[i] << " ";
        }
    }

    cout << endl;

    return 0;
}
