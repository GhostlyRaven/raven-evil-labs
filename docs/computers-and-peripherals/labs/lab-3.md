[⟵ ЭВМ и периферийные устройства]({{ site.baseurl }}/computers-and-peripherals/index.html)

# **ЛАБОРАТОРНАЯ РАБОТА №3**

### **Наличие репозитория на Github обязательно**

### **Сроки выполнения лабораторной работы: 16.10.23 - 29.10.23**

### **ЗАДАНИЕ**

Дополнить первое консольное приложение (сервер) разрабатываемое в лабораторной работе №2 механизмом автоматического запуска второго консольного приложения (клиент). Запуск второго консольного приложения должен осуществляться для всех данных находящихся в очереди. Также второе консольное приложение должно выполнять приближённый расчёт значения интеграла методом трапеций. Подынтегральная функция выбирается согласно варианту. В процессе разработки приложений потребуется воспользоваться некоторыми из следующих классов:
*   [Process](https://learn.microsoft.com/ru-ru/dotnet/api/system.diagnostics.process?view=net-7.0);
*   [Функция Main](https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/program-structure/main-command-line)
*   [ProcessStartInfo](https://learn.microsoft.com/ru-ru/dotnet/api/system.diagnostics.processstartinfo?view=net-7.0).

### **ВАРИАНТЫ**

| № | Функция | a | b | Контрольный результат |
|:-:|:-:|:-:|:-:|:-:|
| **1** | $2*\sin(x)$ | $0$ | $\pi$ | $4$ |
| **2** | $-2*\sin(x)$ | $0$ | $\pi$ | $-4$ |
| **3** | $2*\cos(x)$ | $-\frac{\pi}{2}$ | $\frac{\pi}{2}$ | $4$ |
| **4** | $-2*\cos(x)$ | $-\frac{\pi}{2}$ | $\frac{\pi}{2}$ | $-4$ |
| **5** | $2*x^2$ | $-3 $ | $3$ | $36$ |
| **6** | $-2*x^2$ | $-3 $ | $3$ | $-36$ |
| **7** | $3*x^3$ | $0$ | $2$ | $12$ |
| **8** | $-3*x^3$ | $0$ | $2$ | $-12$ |
| **9** | $2*x+2$ | $0$ | $2$ | $8$ |
| **10** | $-2*x+2$ | $0$ | $2$ | $-8$ |
| **11** | $2*\ln(x)$ | $1$ | $5$ | $8.0944$ |
| **12** | $-2*\ln(x)$ | $1$ | $5$ | $-8.0944$ |