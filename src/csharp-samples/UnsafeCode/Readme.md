# **Неуправляемый или небезопасный код в C#**
Справочник содержит подсказки по работе с неуправляемым или небезопасным кодом в C#.

Подробную информацию стоит искать в [документации](https://docs.microsoft.com/ru-ru/dotnet/standard/native-interop/).

Справочник по [WinAPI функциям](https://www.pinvoke.net/) в C#.
#

# **Классы**
1. Marshal;
2. MemoryMarshal;
3. NativeLibrary;
4. AssemblyLoadContext;
5. Unsafe и др.

# **Ключевые слова**
1. stackalloc;
2. unsafe;
3. fixed и др.

# **Атрибуты**
1. DllImport;
2. StructLayout;
3. FieldOffset;
4. MarshalAs и др.

# **Обычные типы**
| C или C++ | C# |
| --- | --- |
| bool | bool |
| char | char |
| char | sbyte |
| unsigned char | byte |
| wchar_t | char |
| short | short |
| unsigned short | ushort |
| int | int |
| long | int |
| unsigned int | uint |
| unsigned long | uint |
| long long | long |
| unsigned long long | ulong |
| float | float |
| float | double |
| double | double |

# **Указатель на переменную**
| C или C++ | C# |
| --- | --- |
| bool* | ref/out bool |
| char* | ref/out char |
| char* | ref/out sbyte |
| unsigned char* | ref/out byte |
| wchar_t* | ref/out char |
| short* | ref/out short |
| unsigned short* | ref/out ushort |
| int* | ref/out int |
| long* | ref/out int |
| unsigned int* | ref/out uint |
| unsigned long* | ref/out uint |
| long long* | ref/out long |
| unsigned long long* | ref/out ulong |
| float* | ref/out float |
| float* | ref/out double |
| double* | ref/out double |

# **Указатель на массив**
| C или C++ | C# |
| --- | --- |
| bool* | bool[] |
| char* | char[] |
| char* | sbyte[] |
| unsigned char* | byte[] |
| wchar_t* | char[] |
| short* | short[] |
| unsigned short* | ushort[] |
| int* | int[] |
| long* | int[] |
| unsigned int* | uint[] |
| unsigned long* | uint[] |
| long long* | long[] |
| unsigned long long* | ulong[] |
| float* | float[] |
| float* | double[] |

# **Строки**
| C или C++ | C# |
| --- | --- |
| char* |	[MarshalAs(UnmanagedType.LPStr)] string |
| wchar_t* |	[MarshalAs(UnmanagedType.LPWStr)] string |
| char* |	[MarshalAs(UnmanagedType.LPStr)] StringBuilder |
| wchar_t* |	[MarshalAs(UnmanagedType.LPWStr)] StringBuilder |

# **Структуры и объединения**
| C или C++ | C# |
| --- | --- |
| other struct |	other struct |
| other struct* |	ref/out other struct |
| other struct* |	other struct[] |
| other struct[] |	other struct[] |
| other union |	other struct |
| other union* |	ref/out other struct |
| other union* |	other struct[] |
| other union[] |	other struct[] |

# **Указатель на функцию**
| C или C++ | C# |
| --- | --- |
| function pointer |	nint |
| function pointer |	delegate |

# **Тип void и указатель класс С++**
| C или C++ | C# |
| --- | --- |
| void |	void |
| void* |	nint |
| void** |	nint |
| other class type* |	nint |
| other class type** |	nint |
