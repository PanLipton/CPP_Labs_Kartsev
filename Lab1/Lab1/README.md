# Лабораторна робота №1

**Виконав**: студент групи ІПЗ-33-9 **Карцев Ілля**

**Варіант 26**

Василь Афанасьєв як курсова робота отримав завдання - побудувати комп'ютер, який би працював не з числами, а з рядками. Вася спершу фіксував деякий алфавіт. Позначимо за K кількість букв у цьому алфавіті. Далі, Вася фіксував деякий набір різних рядків, довжини трохи більше N кожна, що він назвав базовим. Комп'ютер вміє працювати тільки з рядками, які виходять конкатенацією (тобто приписуванням) деяких рядків з цього набору один до одного (одну і ту ж рядок при приписуванні можна використовувати кілька разів). Проте виявилося, що базовий набір виявився надмірним! Це означає, що в ньому був рядок, при видаленні якого з набору не змінюється безліч рядків, з якими вміє працювати комп'ютер.
Васю зацікавило питання – як багато може бути рядків у ненадмірному наборі, і скільки таких максимальних наборів існує.
Так як його комп'ютер ще не готовий, він попросив Вас порахувати це число.
Вхідні дані
У вхідному файлі INPUT.TXT міститься два цілих числа 1 ≤ N ≤ 1 000 та 1 ≤ K ≤ 100 – відповідно максимальна довжина рядка та кількість символів в алфавіті.
Вихідні дані
У першому рядку вихідного файлу OUTPUT.TXT виведіть кількість рядків у максимальному наборі. У другій – кількість таких наборів.


## Usage

Build and run the project:

```
    msbuild MSBuild.proj /t:Lab01
```

Build and run tests for the project:

```
    msbuild MSBuild.proj /t:Lab01T
```
