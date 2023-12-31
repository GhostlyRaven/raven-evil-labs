[⟵ Объектно-ориентированное программирование]({{ site.baseurl }}/object-oriented-programming/index.html)

# **ЛАБОРАТОРНАЯ РАБОТА №2**

### **Наличие репозитория на Github обязательно**

### **Сроки выполнения лабораторной работы: 18.09.23 - 15.10.23**

### **ЗАДАНИЕ**

Разработать консольное приложение согласно варианту при помощи схемы приложения, а также следующих принципов и понятий ООП:
*	Класс, объект и экземпляр;
*	Поле, метод, поле только для чтения и константа;
*	Статический метод и класс;
*	Конструктор, деконструктор, деструктор (финализатор), IDisposable и IAsyncDisposable;
*	Свойство;
*	Абстракция;
*	Инкапсуляция и модификаторы доступа;
*	Наследование. Одиночное и множественное. Абстрактный класс и интерфейс;
*	Полиморфизм. Виртуальные функции и перегрузка операторов;
*	Исключительные ситуации и их обработка. Пользовательские исключения;
*	Делегаты, лямбда функции и события;
*	Обобщенные типы, их ограничения и индексаторы.
*   Абстрактная математика;
*	Задачи и асинхронное программирование;
*   Основные классы стандартной библиотеки.

**На схеме приложения в UML-нотации отражены не все типы, понятия и т.д., которые требуется реализовать в лабораторной работе. Смотрите список выше.**

### **Схема приложения в UML-нотации**

![Схема приложения в UML-нотации]({{ site.repository-files-baseurl }}/object-oriented-programming/oop-lab-2.png)

### **ВАРИАНТЫ**

| № | RU | ENG |
|:-:|:-:|:-:|
| **1** | **Треугольник и конус** | **Triangle and cone** |
| **2** | **Квадрат и цилиндр** | **Square  and cylinder** |
| **3** | **Прямоугольник и шар** | **Rectangle and ball** |
| **4** | **Круг и пирамида** | **Circle and pyramid** |
| **5** | **Ромб и куб** | **Rhomb and cube** |
| **6** | **Эллипс и эллипсоид** | **Ellipse and ellipsoid** |
| **7** | **Трапеция и призма** | **Trapezoid and prism** |
| **8** | **Параллелограмм и параллелепипед** | **Parallelogram and parallelepiped** |

**При реализации методов вычисляющих периметр, площадь и объем обязательно использовать формулы из таблиц представленных ниже.**

### **Формулы применяемые для расчётов в 2D фигурах**

| **Фигура** | **P** | **S** | **V** |
|:-:|:-:|:-:|:-:|
| **Треугольник** | $a + b + c$ | $\sqrt{p * (p-a) * (p-b) * (p-c)}$ | $-$ |
| **Квадрат** | $4 * a$ | $a^2$ | $-$ |
| **Прямоугольник** | $2 * (a + b)$ | $a * b$ | $-$ |
| **Круг** | $2 * \pi * r$ | $\pi * r^2$ | $-$ |
| **Ромб** | $4 * a$ | $\frac{1}{2} * d_1 * d_2$ | $-$ |
| **Эллипс** | $4 * \frac{\pi * a * b + (a - b)}{a + b}$ | $\pi * a * b$ | $-$ |
| **Трапеция** | $a + b + c + d$ | $\frac{1}{2} * (a + b) * h$ | $-$ |
| **Параллелограмм** | $2 * (a + b)$ | $a * h$ | $-$ |

### **Формулы применяемые для расчётов в 3D фигурах**

| **Фигура** | **P** | **S** | **V** |
|:-:|:-:|:-:|:-:|
| **Конус** | $2 * \pi * r$ | $\pi * r * l + \pi * r^2$ | $\frac{1}{3} * \pi * r^2 * h$ |
| **Цилиндр** | $2 * \pi * r$  | $2 * \pi * r * h + 2 * \pi * r^2$ | $\pi * r^2 * h$ |
| **Шар** | $2 * \pi * r$ | $4 * \pi * r^2$ | $\frac{4}{3} * \pi * r^3$ |
| **Пирамида** | $4 * a$ | $\frac{1}{2} * P * l + a^2$ | $\frac{1}{3} * a^2 * h$ |
| **Куб** | $12 * a$ | $6 * a^2$ | $a^3$ |
| **Эллипсоид** | $4 * \frac{\pi * a * b + (a - b)}{a + b}$ | $\pi * a * b$ | $\frac{4}{3} * \pi * a * b * c$ |
| **Призма** | $6 * a + 3 * h$ | $3 * a * h + \frac{\sqrt{3} * a^2}{2}$ | $\frac{\sqrt{3} * a^2}{4} * h$ |
| **Параллелепипед** | $4 * (a + b + h)$ | $2 * (a * b + a * h + b * h)$ | $a * b * h$ |

### **Теория по математике. Поможет при работе с формулами для расчётов 😊🎓**
* [Источник #1](https://ru.onlinemschool.com/math/assistance/)
* [Источник #2](https://www.webmath.ru/poleznoe/formules_15_12.php)
* [Источник #3](https://geleot.ru/education/math/geometry/volume/ellipsoid)
* [Источник #4](https://mnogogranniki.ru/pravilnaya-treugolnaya-prizma.html)
* [Источник #5](https://matematikalegko.ru/piramidi/pravilnye-piramidy-ploshhad-poverxnosti.html)
