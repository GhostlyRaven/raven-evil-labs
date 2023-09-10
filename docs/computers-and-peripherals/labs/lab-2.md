[⟵ ЭВМ и периферийные устройства]({{ site.baseurl }}/computers-and-peripherals/index.html)

# **ЛАБОРАТОРНАЯ РАБОТА №2**

### **Наличие репозитория на Github обязательно**

### **Сроки выполнения лабораторной работы: 25.09.23 - 15.10.23**

### **ЗАДАНИЕ**

Дополнить первое консольное приложение (сервер) разрабатываемое в лабораторной работе №1 очередью с данными на отправку. Добавление данных для отправки в очередь должно происходить до тех пор, пока не будет нажата комбинация клавиш Ctrl+C. Также при добавлении данных в очередь должен учитываться приоритет отправляемых данных. Полученные обратно от второго консольного приложения (клиент) данные должны сохраняться в буфер, который будет записываться в файл или выводиться на экран после нажатия комбинации клавиш Ctrl+C. В процессе разработки приложений потребуется воспользоваться некоторыми из следующих классов:
* [Task](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.tasks.task?view=net-7.0);
* [Thread](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.thread?view=net-7.0);
* [ThreadPool](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.threadpool?view=net-7.0);
* [Асинхронное программирование на основе Task](https://learn.microsoft.com/ru-ru/dotnet/standard/parallel-programming/task-based-asynchronous-programming);
* [CancellationToken](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.cancellationtoken?view=net-7.0);
* [CancellationTokenSource](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.cancellationtokensource?view=net-7.0);
* [Queue](https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.queue-1?view=net-7.0);
* [PriorityQueue](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2?view=net-7.0).
