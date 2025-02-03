#include <cmath>
#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>
#include <stdexcept>

using namespace std;

const double PI = 3.14159265358979323846;
const double G = 9.81;

double task1(double x_deg, double y_deg) {
    double x = x_deg * PI / 180.0;
    double y = y_deg * PI / 180.0;

    double tan_x = tan(x);
    if (1 - tan_x <= 0) {
        throw invalid_argument("Base (1 - tan(x)) must be positive");
    }
    return pow(1 - tan_x, 1.0 / tan_x) + cos(x - y);
}

double task2(double v, double t) {
    double argument = G * t / (2 * v);
    if (argument < -1 || argument > 1) {
        throw domain_error("Argument for arcsin is out of [-1, 1] range");
    }
    return asin(argument) * 180.0 / PI;
}

int task3(int number) {
    if (number < 100 || number > 999) {
        throw invalid_argument("Number must be 3-digit");
    }

    int d1 = number / 100;
    int d2 = (number / 10) % 10;
    int d3 = number % 10;


    if (d1 >= d2 && d1 >= d3) return d1;
    else if (d2 >= d3) return d2;
    else return d3;
}

double task4(const vector<float>& arr) {
    if (arr.empty()) {
        throw invalid_argument("Array cannot be empty");
    }
    return accumulate(arr.begin(), arr.end(), 0.0) / arr.size();
}

int task5(int limit) {
    int sum = 0;
    int current = 0;
    while (current <= limit) {
        if (current % 5 == 0) {
            sum += current;
        }
        current++;
    }
    return sum;
}

int main() {

    try {

        cout << "Task 1: " << task1(30, 45) << endl;

        cout << "Task 2: " << task2(20, 2.5) << endl;

        cout << "Task 3: " << task3(372) << endl;

        vector<float> arr = { 1.5, 2.5, 3.5, 4.5 };
        cout << "Task 4: " << task4(arr) << endl;

        cout << "Task 5: " << task5(20) << endl;

    }
    catch (const exception& e) {
        cerr << "Error: " << e.what() << endl;
    }
    return 0;
}