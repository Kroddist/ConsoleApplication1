#include <iostream>
#include <cmath>
#include <iomanip>
#include <vector>
#include <algorithm>
#include <limits>
#include <random>

using namespace std;

void task1() {
    cout << "Таблица квадратов:\n";
    cout << "Число\tКвадрат\n";
    for (int i = 1; i <= 5; ++i) {
        cout << i << "\t" << i * i << "\n";
    }
}

void task2() {
    int n;
    cout << "Введите n: ";
    cin >> n;

    double total = 0.0;
    double sum_sin = 0.0;

    for (int k = 1; k <= n; ++k) {
        sum_sin += sin(k); 
        if (sum_sin == 0) {
            cout << "Ошибка: деление на ноль!\n";
            return;
        }
        total += 1.0 / sum_sin;
    }

    cout << fixed << setprecision(5);
    cout << "Результат: " << total << "\n";
}

void task3() {
    double a, b, h;
    cout << "Введите a, b, h: ";
    cin >> a >> b >> h;

    cout << "\n  x\t  f(x)\n";
    cout << "----------------\n";

    for (double x = a; x <= b + 1e-9; x += h) {
        if (x <= 0) {
            cout << x << "\tне определён\n";
            continue;
        }

        double ln_x = log(x);
        if (sin(ln_x) == 0) {
            cout << x << "\tбесконечность\n";
            continue;
        }

        double cot = cos(ln_x) / sin(ln_x);
        cout << fixed << setprecision(3);
        cout << x << "\t" << cot * cot << "\n";
    }
}

void task4() {
    int height, width;
    char symbol;

    cout << "Выберите символ (1-* 2-+ 3-#): ";
    int choice;
    cin >> choice;

    switch (choice) {
    case 1: symbol = '*'; break;
    case 2: symbol = '+'; break;
    case 3: symbol = '#'; break;
    default:
        cout << "Ошибка выбора!\n";
        return;
    }

    cout << "Введите высоту и ширину: ";
    cin >> height >> width;

    if (height % 2 == 0 || width % 2 == 0 ||
        height <= 0 || width <= 0 || height != width) {
        cout << "Некорректные размеры!\n";
        return;
    }

    int center = height / 2;
    for (int y = 0; y < height; ++y) {
        int dy = abs(y - center);
        int symbols = width - 2 * dy;
        int spaces = (width - symbols) / 2;

        cout << string(spaces, ' ')
            << string(symbols, symbol)
            << "\n";
    }
}

void task5() {
    int n;
    cout << "Введите размер массива: ";
    cin >> n;

    if (n <= 0) {
        cout << "Некорректный размер!\n";
        return;
    }

    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dist(-10000, 10000);

    vector<int> arr(n);
    generate(arr.begin(), arr.end(), [&]() { return dist(gen); });

    cout << "Нечётные числа:\n";
    bool found = false;
    for (int num : arr) {
        if (abs(num) % 2 == 1) {
            cout << num << " ";
            found = true;
        }
    }
    cout << (found ? "\n" : "Не найдено\n");
}

int main() {
    setlocale(LC_ALL, "Russian");

    while (true) {
        cout << "\nВыберите задачу (1-5, 0-выход): ";
        int choice;
        cin >> choice;

        if (choice == 0) break;

        switch (choice) {
        case 1: task1(); break;
        case 2: task2(); break;
        case 3: task3(); break;
        case 4: task4(); break;
        case 5: task5(); break;
        default:
            cout << "Некорректный ввод!\n";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
    }

    return 0;
}