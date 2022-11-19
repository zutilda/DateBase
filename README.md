# DataBase
Проект создан в рамках изучения WPF с подключением к проекту базы данных.
## Начало работы
Для начала работы нужно перейти по ссылке на [проект Git](https://github.com/zutilda/DateBase) и скопировать URL адрес. Затем перейти в программу Visual Studio и клонировать репозиторий.

### Необходимые условия

Для работы с проектом нужно установить Visual Studio версию не раньше 2015 года. Программу можно установить на [сатйе Microsoft](https://visualstudio.microsoft.com/ru/vs/community/).
Перед установкой необходимо проверить системные требования необходимые для установки и сравнить их с характеристиками компьютера.
<br/>
Пример списка требований для установки Visual Studio Community 2022:
+ Операционная система Windows 10 
  +  Разрядность операционной системы х64.
+ 64-разрядный процессор 1,8 ГГц или более мощный. Рекомендуется четырехъядерный или с большим количеством ядер. Процессоры ARM не поддерживаются.
+ Не менее 4 ГБ ОЗУ.
+ Место на диске: от 10 Гб.
+ Видеоадаптер с минимальным разрешением WXGA (1366 на 768 пикселей); для оптимальной работы Visual Studio рекомендуется разрешение 1920 на 1080 пикселей или выше.
  + Минимальное разрешение предполагает масштабирование, параметры DPI и масштабирование текста на уровне 100 %. 
Далее сравним с системными требованиями компьютера. Для этого переходим в Параметры - Система - О программе.

![Params](https://psv4.userapi.com/c236331/u310913061/docs/d5/b785cf23f198/2022-11-18_23-19-21.png?extra=xu_PnvoNldJUUomIk3j76UPU_lb0hUs1vzktJDmoaYyQ0ioNd73wAnxbPmnN2WbYjGDE7QVJ-fgXtMvOMvfltOICfMqPG6sRPOPX_6zWRMJ7yFnTMVsJ7WnhkBHGgN5-tmS8gzYI9cUvLyNlVSQx1w)

### Установка

Для запуска проекта. 
1 шаг. Установить программу по ссылке на [сатйе Microsoft](https://visualstudio.microsoft.com/ru/vs/community/).<br>
2 шаг. Открыть Visual Studio Installer. Перейти во вкладку "Доступно" и выбрать нужную версию программы. В данном случае Community. 
![Installer](https://sun9-east.userapi.com/sun9-29/s/v1/ig2/YJ9oGZrIXvtsoHybB-Nf1V5nWHzEitb_KHoQppYQueAvcuoYIS0CqAL6WkJNUIN5l4rWQa5T2Nb-yeEse-i8dH4n.jpg?size=1280x720&quality=96&type=album, "Установка программы")
3 шаг. Выбираем в появившемся окне нужные компоненты для установки. 
![Installer modul](https://sun9-east.userapi.com/sun9-22/s/v1/ig2/LFHLlximmXXZzPxFW2ct7m_WHc_qmO6WRrKJ2tnRfXMdr1RW8saeMJibpxxETlmve__GSmGNdzpdRWnQ6zYB_nmQ.jpg?size=1232x622&quality=96&type=album, "Выбор компонентов")
Нажимаем на кнопку "Установить" и ждем завершения установки. <br>
По окончанию установки выбираем цвет темы программы и входим в аккаунт Microsoft.<br>
4 шаг. Перейти по [ссылке](https://github.com/zutilda/DateBase) и скопировать URL-адрес. <br>
5 шаг. В главном окне программы Visual Studio нажать на кнопку "клонировтаь репозиторий" и в поле "Расположение репозитория" вставляем скопированный ранее URL из GitHub.
![Clone](https://sun9-west.userapi.com/sun9-54/s/v1/ig2/yGVNTABHZPILDVLN3UdN5f2OTWIYOz-7w6yFPHBfP1T2Tyta6ygMWh3SVRwx-phA0p6h6dLKzqQ5mgNr5B5m5I1f.jpg?size=1013x677&quality=96&type=album, "Клонирование репозитория") 
Для завершения установки нажимаем кнопку "Клонировать".<br>
6 шаг. Нажимаем на кнопку "Пуск".<br>
![Clone](https://sun9-east.userapi.com/sun9-31/s/v1/ig2/bc5BZqbPNbfbxh7BaQ1nIgmTTSfim5V_HW2OjnBi6etqicwHmITLuEv2k1uGoWLHkc02GRylGWVtUTifO2Okc-OJ.jpg?size=400x106&quality=96&type=album, "Запуск проекта") <br>
7 шаг. Программа на данный момент __находится в разработке__. Поэтому чтобы проверить работоспособность программы необходимо зайти под учетной записью администратора в файле *PageLogIn.xaml.cs*, среди кода есть закомментированный участок с логином и паролем, их используем для входа  в систему.
```
// Логин: admin
// Пароль: Admin_12
```
Вводим учетные данные.
![Autor](https://sun1.userapi.com/sun1-90/s/v1/ig2/jNV3W3nq5sqmVSchZ2vRcyjTlErelRF3sXDL-JdKTFpu0AQ-_izmG1YZM0jSHgLT01Qgwpn91SJVT6ikbCmV1Ox-.jpg?size=1008x637&quality=96&type=album)
После чего перейдем на страницу с выбором функционала и там нажимаем на кнопку *"Пользователи"*. После этого осуществляется переход на страницу с таблицей где отображаются все пользователи. Попробуем осуществить поиск по пользователям. В поле имя введем "Екатерина" и в результате будет только 1 запись, так как в базу только один пользователь с таким именем.
![PageUser](https://sun9-east.userapi.com/sun9-23/s/v1/ig2/NND2fVkNTWvW0p-A0N46x6Qbq94y7iNqPMw2cvUZX8cWZbxEytaeALOsSXCzpt7nd5QrDw_Q4j0YixFzDNVfsCm1.jpg?size=1007x602&quality=96&type=album)
## Авторы

* **Жулина Анастасия** - *Initial work* - [zutilda](https://github.com/zutilda)
