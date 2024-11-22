# Показати інформацію про версію
ikartsev version

# Запустити певну лабораторну роботу з корня CPP LABS
ikartsev run lab1 -i "Lab3/Lab3/files/INPUT.txt" -o "Lab1/Lab1/files/OUTPUT.txt"
ikartsev run lab2 -i "Lab3/Lab3/files/INPUT.txt" -o "Lab2/Lab2/files/OUTPUT.txt"
ikartsev run lab3 -i "Lab3/Lab3/files/INPUT.txt" -o "Lab3/Lab3/files/OUTPUT.txt"

# Встановити шлях за замовчуванням для вхідних/вихідних файлів
ikartsev set-path -p "шлях/до/папки/з/файлами"

Я не зрозумів сенс шляху за замовчуванням в нашому кейсі, бо нам все одно потрібно 3 різних інпута і отпута, і відповідно ну ми можемо створити 1 папку куди закинути 3 ткст файла з інпутами, але так чи інакше все одно руцями придеться переписувати який файл запускати як інпут так і аутпут.