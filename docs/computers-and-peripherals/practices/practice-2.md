[⟵ ЭВМ и периферийные устройства]({{ site.baseurl }}/computers-and-peripherals/index.html)

# **ПРАКТИКА №2**

### **Наличие репозитория на Github обязательно**

### **Сроки выполнения практического задания: 01.10.23 - 15.10.23**

### **ЗАДАНИЕ**

Разработать микропрограммы для микроконтроллера Raspberry Pi Pico, которые реализуют следующие функции:
1. Силовой ключ и вентилятор (4-pin) подключены к пинам D0 и D1 управляются ШИМ на частоте 25КГц. Скважность ШИМ регулируется поворотом потенциометра подключенного к пину A0.
2. Используя библиотеку [AmperkaFET](https://github.com/amperka/AmperkaFet) и последовательный порт (Serial) реализовать управление набором силовых ключей (P-FET и N-FET).
3. Используя библиотеки [TroykaMeteoSensor](https://github.com/amperka/TroykaMeteoSensor) и [Troyka-IMU](https://github.com/amperka/Troyka-IMU), а также последовательны порт (Serial) реализовать вывод показаний с климатических датчиков SHT31 и LPS25HB.

### **Схемы распиновки для Raspberry Pi Pico**

---

![rpi-pico]({{ site.repository-images-baseurl }}/rpi-pico-pinouts/rpi-pico.png)

---

![rpi-pico-w]({{ site.repository-images-baseurl }}/rpi-pico-pinouts/rpi-pico-w.png)

---

**Установленное в Arduino IDE для выполнения лабораторной работы стороннее ядро «Arduino Pico Core» содержит константы с номерами пинов, поэтому строго запрещается использовать для нумерации пинов свои константы или числа. Например, константа D0 обозначает пин GP0, а константа A0 обозначает пин ADC0 или GP25.**
