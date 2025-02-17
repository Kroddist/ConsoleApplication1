#include <iostream>
#include <cmath>   
#include <algorithm> 

using namespace std;

int main() {
 
    int x1, y1, x2, y2;
    cin >> x1 >> y1 >> x2 >> y2; 
    int x3, y3, x4, y4;
    cin >> x3 >> y3 >> x4 >> y4;  

    int x_min = min(x1, x3);
    int y_min = min(y1, y3);
    int x_max = max(x2, x4);
    int y_max = max(y2, y4);

    cout << "Задание 1: Минимальный прямоугольник:" << endl;
    cout << "Левый нижний угол: (" << x_min << ", " << y_min << ")" << endl;
    cout << "Правый верхний угол: (" << x_max << ", " << y_max << ")" << endl;
    
    double area_circle, area_square;
    cin >> area_circle >> area_square; 

    double radius = sqrt(area_circle / M_PI);
    double side_square = sqrt(area_square);

    bool circle_in_square = 2 * radius <= side_square;
    bool square_in_circle = sqrt(2) * side_square <= 2 * radius;

    cout << "Задание 2: Уместность круга и квадрата:" << endl;
    cout << "Круг уместится в квадрате: " << (circle_in_square ? "Да" : "Нет") << endl;
    cout << "Квадрат уместится в круге: " << (square_in_circle ? "Да" : "Нет") << endl;

  
    double number;
    cin >> number;

    cout << "Задание 3: Проверка числа на принадлежность интервалу (-5, 3):" << endl;
    if (number > -5 && number < 3) {
        cout << "Число принадлежит интервалу (-5, 3)" << endl;
    } else {
        cout << "Число не принадлежит интервалу (-5, 3)" << endl;
    }

 
    int num;
    cin >> num;

    int first = num / 100;
    int second = (num / 10) % 10;
    int third = num % 10;

    cout << "Задание 4: Сравнение цифр трехзначного числа:" << endl;
    cout << "Первая или последняя: " << (first > third ? "Первая больше" : "Последняя больше") << endl;
    cout << "Первая или вторая: " << (first > second ? "Первая больше" : "Вторая больше") << endl;
    cout << "Вторая или последняя: " << (second > third ? "Вторая больше" : "Последняя больше") << endl;

    double a, b, c, x, y;
    cin >> a >> b >> c >> x >> y;

    double brick[3] = {a, b, c};
    double hole[2] = {x, y};

    sort(brick, brick + 3);
    sort(hole, hole + 2);

    cout << "Задание 5: Проверка, пройдет ли кирпич через отверстие:" << endl;
    if (brick[0] <= hole[0] && brick[1] <= hole[1]) {
        cout << "Кирпич пройдет через отверстие." << endl;
    } else {
        cout << "Кирпич не пройдет через отверстие." << endl;
    }

    return 0;
}
