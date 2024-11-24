# Лабораторна робота №5

## Розгортання на Ubuntu/Debian

### 1. Встановлення залежностей

```bash
# Оновлення пакетів
sudo apt-get update
sudo apt-get upgrade

# Встановлення .NET SDK
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get install -y dotnet-sdk-8.0

# Перевірка встановлення
dotnet --version
```

### 2. Налаштування проекту

```bash
# Клонування репозиторію
git clone <your-repository-url>
cd CPP_Labs_Kartsev/Lab5

# Відновлення залежностей та збірка проекту
dotnet restore
dotnet build
```

### 3. Налаштування HTTPS

```bash
# Створення сертифікату для розробки
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

### 4. Публікація проекту

```bash
# Публікація проекту
dotnet publish -c Release

# Перехід до папки з опублікованим проектом
cd Lab5.Web/bin/Release/net8.0/publish
```

### 5. Запуск застосунку

```bash
# Запуск веб-застосунку
dotnet Lab5.Web.dll
```

Застосунок буде доступний за адресою: https://localhost:5001

### 6. Налаштування як системного сервісу (опціонально)

Створіть файл сервісу:
```bash
sudo nano /etc/systemd/system/lab5web.service
```

Додайте наступний вміст:
```ini
[Unit]
Description=Lab5 Web Application

[Service]
WorkingDirectory=/var/www/lab5
ExecStart=/usr/bin/dotnet /var/www/lab5/Lab5.Web.dll
Restart=always
RestartSec=10
SyslogIdentifier=lab5web
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target
```

Активація сервісу:
```bash
sudo systemctl enable lab5web
sudo systemctl start lab5web
```

### 7. Налаштування Nginx (опціонально)

```bash
# Встановлення Nginx
sudo apt-get install nginx

# Налаштування конфігурації
sudo nano /etc/nginx/sites-available/lab5web
```

Додайте конфігурацію:
```nginx
server {
    listen        80;
    server_name   example.com;
    location / {
        proxy_pass         http://localhost:5001;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
```

```bash
# Створення симлінку
sudo ln -s /etc/nginx/sites-available/lab5web /etc/nginx/sites-enabled/lab5web

# Перевірка конфігурації
sudo nginx -t

# Перезапуск Nginx
sudo systemctl restart nginx
```

## Використання

1. Відкрийте браузер та перейдіть за адресою https://localhost:5001
2. Зареєструйте новий обліковий запис
3. Увійдіть в систему
4. Отримайте доступ до лабораторних робіт