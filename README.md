<br />
<div align="center">
    <img src="media/logo.svg" alt="Logo" width="300" height="80">
  <h2 align="center">MTC.ИГРЫ</h2>
  <h3 align="center">MISIS venum</h3>
</div>

<div align="center">

<img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white">
<img src="https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54">
<img src="https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white">
<img src="https://img.shields.io/badge/FastAPI-005571?style=for-the-badge&logo=fastapi">
<img src="https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white">
<img src="https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white">
<img src="https://img.shields.io/badge/WebGL-990000?logo=webgl&logoColor=white&style=for-the-badge">
<img src="https://img.shields.io/badge/figma-%23F24E1E.svg?style=for-the-badge&logo=figma&logoColor=white">
<img src="https://img.shields.io/badge/nginx-%23009639.svg?style=for-the-badge&logo=nginx&logoColor=white">
<img src="https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white">
<img src="https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white">
<img src="https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white">
<img src="https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black">


</div>

# 🚀  О Проекте
Наш сервис представляет собой конструктор тайм-киллер игр, который будет внедрён в корпоративную систему 
банка для создания игровых механик, направленных на вовлечение пользователей и повышение их лояльности. Этот инструмент позволяет сотрудникам, 
даже не имеющим технической подготовки, быстро и легко разрабатывать игры, 
которые впоследствии будут интегрированы в приложение банка.

## 🖼️ Превью

### Экраны Web приложения
<div style="display: grid; grid-template-columns: repeat(2, auto)">
<img src="media/start1.png">
<img src="media/start.png">
<img src="media/collection.png">
<img src="media/redactor.png">
</div>

| Экраны Web приложения  |  |
| ------------- | ------------- |
| ![](media/start1.png)  | ![](media/start.png)  |
| ![](media/collection.png)  | ![](media/redactor.png)  |

### Экраны игр
<div style="display: grid; grid-template-columns: repeat(5, auto)">
<img src="media/game1_process.png">
<img src="media/game2_process.png">
<img src="media/game_finish.png">
<img src="media/game_shop-1.png">
<img src="media/game_shop.png">
</div>




## 📚 Установка 

### Требования 
На вашей машине должне быть установлен **docker compose**.

### Инструкция по установке и запуску 

Скачайте и перейдите в директорию проекта.
```zsh
git clone git@github.com:Klopi746/MTS_Hack20.git # клонирование репозитория
cd MTS_Hack20 # переход в рабочую директорию

```
Далее нужно создать и заполнить .env по аналогии с .env.example:
```zsh
# General
DOMAIN=<ХОСТ СЕРВИСА>

# Backend Config
BACKEND_APPLICATION=<НАЗВАНИЕ REST ПРИЛОЖЕНИЯ>
BACKEND_MODE=<DEV, PROD>


# Postgres
POSTGRES_USER=<ПОЛЬЗОВАТЕЛЬ БД>
POSTGRES_PASSWORD=<ПАРОЛЬ ОТ БД>
POSTGRES_HOST=<ХОСТ БД>
POSTGRES_DB=<НАЗВАНИЕ БД>
POSTGRES_PORT=<ПОРТ БД>


# Mongo
MONGO_DRIVER=<ДРАЙВЕР МОНГИ>
MONGO_HOST=<ХОСТ МОНГИ>
MONGO_DB_NAME=<НАЗВАНИЕ БАЗЫ ДАННЫХ>
MONGO_PORT=<ПОРТ МОНГИ>
```

После чего можно запустить проект
```zsh
docker compose up --build -d
```

**!Адресс запросов к REST API фиксированный для билда игры. Его нужно менять внутри игры, а затем сделать и загрузить новый билд**

### Настройка CI / CD
Для работы автодеплоя в настройках репозитория на Github нужно настроить следующие параметры:
```shell
HOST=<Адрес сервера, на котором расположен проект>
PROJECT_DIR=<Рабочая директория проекта>
USERNAME=<Пользователь сервера(Linux)>
PASSWORD=<Пароль пользователя>
```

## ⚙️ Архитектруа 
<img src="media/112.png">

## 📋 Основной функционал 
- [x] Web приложение
  - [x] Просмотр готовых конфигураций для игр
  - [x] Установка текущей конфигурации для конкретной игры 
  - [x] Редактор игр
  - [x] Возможность добавлять / удалять / редактировать конфигурации игр
  - [ ] Возможность добавлять новые игры
- [x] Игры 
  - [x] Игры Color Switch
  - [x] Игра Path of Hero
- [ ] Система накопления и траты очков
- [ ] Реферальная система 
- [ ] Внутриигровой / МТС магазин


## 🗨️ Состав команды 
[Крылов Никита](https://github.com/NikitaKrylov) - **Backend / DevOps / Lead**

[Имран Шокуев](https://github.com/imka07) - **Unity Dev**

[Данила Бочаров](https://github.com/Klopi746) - **Unity Dev**

[Тимофей Костров](https://t.me/timkoskos) - **UI / UX / Frontend**

[Андрей Тычинин](https://t.me/timkoskos) - **UI / UX / Frontend**




