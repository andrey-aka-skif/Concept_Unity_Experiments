﻿# Синхронизация с главным репозиторием

Последовательность команд для обновления из главного репозитория:
- обновление из главного репозитория (upstream);
- переключение на нужную локальную ветку (вероятно, уже на ней);
- слияние внешней ветки с локальной;
- отправка принятых изменений в личный удаленный репозиторий (origin)

```
$ git fetch upstream
$ git checkout devel
$ git merge upstream/devel
$ git push origin
```

Ссылки:
- [Syncing a fork](https://stackoverflow.com/questions/7244321/how-do-i-update-or-sync-a-forked-repository-on-github/19506355#19506355)

См. также: [[Общие вопросы по Git]]

#GitHub , #git 

