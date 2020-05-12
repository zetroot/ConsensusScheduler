![master build](https://github.com/zetroot/ConsensusScheduler/workflows/master%20build/badge.svg)
[![Coverage Status](https://coveralls.io/repos/github/zetroot/ConsensusScheduler/badge.svg)](https://coveralls.io/github/zetroot/ConsensusScheduler)

# ConsensusScheduler
Пет проект сервиса позволяющего спланировать проведение мероприятия в наиболее подходящую для всех дату.
Функции сервиса:
 - создание опросов
 - фиксация ответов на опрос
 - выбор варианта с наибольшим количеством голосов

Архитеркура сервиса:
 - сервер-ядро, инкапсулирующий в себе бизнеслогику. взаимодействие с БД и прочее.
 - десктоп приложение на Avalonia и .NET Core для Windows и Linux
 - мобильное приложение для Android на Xamarin
 - веб-приложение на Blazor
 - Получить покрытие модульными тестами не менее 90%
