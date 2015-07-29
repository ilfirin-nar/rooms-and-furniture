# RoomsAndFurniture
В процессе работы над заданием использовались следующие пакеты:
* [LightInject](http://www.lightinject.net/)
* [Dapper](https://github.com/StackExchange/dapper-dot-net)
* [NUnit](http://www.nunit.org/)
* [Value Injecter](https://valueinjecter.codeplex.com/)
* [SQLite](https://system.data.sqlite.org/)

## О реализации
Был выбран обыкновенный "слоистый" подход к организации логики: слой контроллеров → слой веб-хэндлеров → бизнес-логика → доступ к данным.
<br/>
В качестве базы данных использовался SQLite для простоты. При первом запуске база создаётся скриптом, накатываются некоторые данные. В тестах (написано только некоторое количество интеграционных, на основые случаи) на каждую сессию создаётся новая база (старая удаляется).
<br/>
ORM минимальная, исключительно для мэппинга. SQL-запросы лежат отдельными скриптами и подключаются через ресурсные файлы.
<br/>
Выбор DI-контейнера обусловлен его высокой производительностью и достаточной функциональностью.
<br/>
### Работа над ошибками
Поздно понял, что была выбрана не лучша схема хранения данных, когда мебель хранится не поэкземплярно, а сгруппирована по типам и с полем, хранящим количество. Изначально руководствовался такими соображениями, что это поможет сэкономить на вычислениях по базе. Однако это поле проблематично обновлять и это усложнило логику. Проще было бы вычислять что нужно "на лету" или при старте приложения, затем кэшировать.
