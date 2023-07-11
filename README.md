## Описание
В сцене находнятся игрок и несколько врагов. Игроку небходимо дойти из точки А в точку В и обнаружить всех врагов.
В тоже время враги, в случайный момент, могут решить напасть на игрока (подойти).
Если враг подойдёт к игроку, то игрок проиграл.
Если игрок дошёл до точки В, не обнаружив всех врагов, он так же проигрывает.
По завершению игры, появляется окно с информацией о прохождении.

### Механика обнаружения
Из центра камеры игрока выпускается луч, при столкновении с врагом заполняет шкалу обнаружения на нём.
Для полного обнаружения на врага необходимо смотреть 3 секунды.
Когда врага обнаружили, он разворачивается и обижено уходит.

### Информационное окно с результатами
* Победа / Поражение
* Список врагов и статус обнаружен / не обнаружен

### Версия Unity
Убедитесь, что версия Unity, которую вы используете, соответствует версии проекта.
Это можно проверить в Unity Hub или посмотреть в файле ProjectSettings/ProjectVersion.txt.

## Критерии оценки:
* Архитектура: разделение данных и логики, использование патернов, DI;
* Структура проекта: организация сцен, папок, UI, префабов и т.д
* Работа с git
