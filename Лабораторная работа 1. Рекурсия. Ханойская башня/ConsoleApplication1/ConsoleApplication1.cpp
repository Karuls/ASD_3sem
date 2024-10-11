#include <iostream>
using namespace std;

void hanoi_towers(int n, int i, int k) {
    if (n == 1) {
        cout << "Диск " << n << " c " << i << "-ого на " << k << endl;
    }
    else {
        int tmp = 6 - i - k;
        hanoi_towers(n - 1, i, tmp);
        cout << "Диск " << n << " c " << i << "-ого на " << k << endl;
        hanoi_towers(n - 1, tmp, k);
    }
}
   /* void matr(int n) {
        if (n == 1) {
            cout << "Последняя матрешка 1!!!" << endl;
        }
        else{
        cout << "Вершина матрешки: "<< n << endl;
        matr(n - 1);
        cout << "Низ матрешки: " << n << endl;
        }
    }*/

int main()
{
    int towers = 0;
    setlocale(0, "");
    do {
        cout << "Ввелите колличество стержней :" << endl;
        cin >> towers;

    } 
    while (towers != 3); cout << "Верное решение" << endl;
    cout << "На какой? " << endl;
    int k = 0; cin >> k;
    cout << "Диски: " << endl;
    int n = 0; cin >> n;
    hanoi_towers(n, 1, k);
    //matr(7);
   


}

