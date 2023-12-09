[⟵ ЭВМ и периферийные устройства]({{ site.baseurl }}/computers-and-peripherals/index.html)

# **ПРАКТИКА №4**

### **Наличие репозитория на Github обязательно**

### **Сроки выполнения практического задания: 13.11.23 - 10.12.23**

### **ЗАДАНИЕ**

Разработать программы на языке программирования С# для микрокомпьютера Raspberry Pi, которые реализуют следующие функции:
1.  Используя библиотеку [Raven.Iot.Device.Bindings]({{ site.repository-files-baseurl }}/interfaces-of-information-systems/Raven.Iot.Device.Bindings.1.0.0.nupkg), расширитель портов Troyka HAT и энкодер, реализовать управление сервоприводом.
2.  Используя библиотеку [Raven.Iot.Device.Bindings]({{ site.repository-files-baseurl }}/interfaces-of-information-systems/Raven.Iot.Device.Bindings.1.0.0.nupkg), расширитель портов Troyka HAT и энкодер, реализовать управление силовым ключом и вентилятором (4-pin) через ШИМ работающий на частоте 25КГц.
3.  Используя библиотеку [Raven.Iot.Device.Bindings]({{ site.repository-files-baseurl }}/interfaces-of-information-systems/Raven.Iot.Device.Bindings.1.0.0.nupkg), модуль с подтягивающим резистором и датчики температуры DS18B20, реализовать вывод показаний. Шина OneWire.
4.  Используя библиотеку [Raven.Iot.Device.Bindings]({{ site.repository-files-baseurl }}/interfaces-of-information-systems/Raven.Iot.Device.Bindings.1.0.0.nupkg), токоизмерительный датчик INA219 и светодиоды реализовать сбор **V**, **I** и **P** для каждого светодиода. Сбор показаний должен проходить каждые 10 секунд и показания должны сохраняться в файл формата [CSV](https://joshclose.github.io/CsvHelper). Общая продолжительность сбора показаний должна быть равна 1 минуте. По данным из файла требуется построить графики для **V**, **I** и **P** в Excel. Сбор показаний требуется провести для красного, желтого, зеленого и синего светодиодов по отдельности. Шина I2C.
5.  Используя библиотеку [Raven.Iot.Device.Bindings]({{ site.repository-files-baseurl }}/interfaces-of-information-systems/Raven.Iot.Device.Bindings.1.0.0.nupkg), Raspberry Pi Pico, энкодер и вентилятор (4-pin) реализовать взаимодействие Raspberry Pi с Raspberry Pi Pico по шине I2C. Raspberry Pi Pico должна управлять вентилятором (4-pin) через ШИМ работающий на частоте 25КГц, а Raspberry Pi считывать сигналы с энкодера для задания скважности ШИМ.

### **Процесс работы с локальным источником пакетов**

Команда для добавления локального источников пакетов:

```console
dotnet nuget add source "The full path to the folder with local packages" -n "Local Nuget"
```

Команда для удаления локального источников пакетов:

```console
dotnet nuget remove source "Local Nuget"
```

### **Схемы распиновки для Raspberry Pi и Troyka HAT**

---

![rpi-pico]({{ site.repository-images-baseurl }}/rpi-pinouts/rpi.png)

---

![rpi-pico]({{ site.repository-images-baseurl }}/rpi-pinouts/rpi-troyka-hat.png)

---

**По вопросам работы с библиотекой Raven.Iot.Device.Bindings и распиновке устройств обращаться к преподавателю.**
